using System.Numerics;
using ArabicaCliento.Components;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Map;
using Robust.Shared.Physics.Components;

namespace ArabicaCliento.Systems;


public record struct AimOutput(MapCoordinates Position, Vector2? Velocity);

public class ArabicaAimSystem : EntitySystem
{
    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly TransformSystem _transform = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    
    
    public static Vector2? CalculateInterceptPosition(Vector2 shooterPosition, float bulletSpeed, Vector2 targetPosition, Vector2 targetVelocity)
    {
        // Вектор от стрелка до цели
        var toTarget = targetPosition - shooterPosition;

        // Решение квадратичного уравнения в 2D
        var a = Vector2.Dot(targetVelocity, targetVelocity) - bulletSpeed * bulletSpeed;
        var b = 2 * Vector2.Dot(toTarget, targetVelocity);
        var c = Vector2.Dot(toTarget, toTarget);

        // Решаем уравнение at^2 + bt + c = 0
        var discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            // Нет реального решения, пересечения не будет
            return null; // Возвращаем текущую позицию цели как fallback
        }

        // Ищем два возможных времени пересечения
        var sqrtDiscriminant = (float)Math.Sqrt(discriminant);
        var t1 = (-b - sqrtDiscriminant) / (2 * a);
        var t2 = (-b + sqrtDiscriminant) / (2 * a);

        // Выбираем минимальное положительное время
        var interceptTime = Math.Max(0, Math.Min(t1, t2));

        // Если оба t отрицательны, значит цель ушла или слишком быстрая
        if (interceptTime < 0)
        {
            return null; // Возвращаем текущую позицию цели как fallback
        }

        // Позиция пересечения
        return targetPosition + targetVelocity * interceptTime;
    }

    public AimOutput? GetClosestToEntInRange(
        EntityUid ent,
        float range,
        HashSet<EntityUid>? exclude = null)
    {
        var mapCords = _transform.GetMapCoordinates(Transform(ent));
        var entitiesInRange = _lookup.GetEntitiesInRange(mapCords, range, LookupFlags.Uncontained);
        if (exclude != null)
            entitiesInRange.ExceptWith(exclude);
        return GetClosestTo(mapCords, entitiesInRange);
    }

    public AimOutput? GetClosestInRange(
        ScreenCoordinates screenCoordinates,
        float range,
        HashSet<EntityUid>? exclude = null)
    {
        return GetClosestInRange(_eyeManager.PixelToMap(screenCoordinates), range, exclude);
    }

    public AimOutput? GetClosestInRange(
        MapCoordinates coordinates,
        float range,
        HashSet<EntityUid>? exclude = null)
    {
        var entitiesInRange = _lookup.GetEntitiesInRange(coordinates, range, LookupFlags.Uncontained);

        if (exclude != null)
            entitiesInRange.ExceptWith(exclude);

        return GetClosestTo(coordinates, entitiesInRange);
    }

    private AimOutput? GetClosestTo(MapCoordinates coordinates, HashSet<EntityUid> entities)
    {
        MapCoordinates? closestCoordinates = null;
        EntityUid? closestEntity = null;
        var closestDistance = float.MaxValue;
        foreach (var ent in entities)
        {
            var transform = Transform(ent);
            if (!FilterEntity((ent, transform)))
                continue;
            var entityMapPos = _transform.GetMapCoordinates(transform);
            var vector = coordinates.Position - entityMapPos.Position;
            var distance = vector.Length();
            if (!(distance < closestDistance)) continue;
            closestCoordinates = entityMapPos;
            closestDistance = distance;
            closestEntity = ent;
        }

        Vector2? velocity = null;
        if (TryComp<PhysicsComponent>(closestEntity, out var phys))
            velocity = phys.LinearVelocity;
        if (closestCoordinates is null)
            return null;

        return new AimOutput {Position = closestCoordinates.Value, Velocity = velocity};
    }

    private bool FilterEntity(Entity<TransformComponent> ent)
    {
        if (ent.Comp.MapID != _eyeManager.CurrentMap) return false;
        if (!TryComp(ent, out MobStateComponent? state))
            return false;
        if (state.CurrentState != MobState.Alive) return false;
        if (HasComp<ArabicaFriendComponent>(ent)) return false;
        return true;
    }
}