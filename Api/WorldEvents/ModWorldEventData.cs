using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.WorldEvents;

/// <summary>
/// The base class for all custom world events
/// </summary>
public abstract class ModWorldEventData : ScriptableObjectModContent<WorldEventData>
{
    /// <summary>
    /// The WorldEventType of this event
    /// </summary>
    public abstract WorldEventType Type { get; }

    /// <summary>
    /// The prefab to spawn for this event, if enabled
    /// </summary>
    public virtual GameObject? Prefab => null;

    /// <summary>
    /// Whether or not this event can be dispelled by banish
    /// </summary>
    public virtual bool DispelByBanish => true;

    /// <summary>
    /// Whether or not this event can be dispelled by foghorn
    /// </summary>
    public virtual bool DispelByFoghorn => false;

    /// <summary>
    /// The time it takes for this event to be dispelled by foghorn
    /// </summary>
    public virtual float FoghornDispelTime => 0;

    /// <summary>
    /// The number of times the foghorn must be used to dispel this event
    /// </summary>
    public virtual float FoghornDispelCount => 3f;

    /// <summary>
    /// The minimum sanity required for this event to spawn, 0-1
    /// </summary>
    public virtual float MinSanity => 0;

    /// <summary>
    /// The maximum sanity required for this event to spawn, 0-1
    /// </summary>
    public virtual float MaxSanity => 1;

    /// <summary>
    /// The delay between repeats of this event, per game mode
    /// </summary>
    public abstract Dictionary<GameMode, float> RepeatDelay { get; }

    /// <summary>
    /// The weight of this event to spawn
    /// </summary>
    public abstract float Weight { get; }

    /// <summary>
    /// The time at which this event can stop spawning, 0-1, where 0 is midnight and 1 is 11:59pm
    /// </summary>
    public virtual float SpawnStartTime => 0;

    /// <summary>
    /// The time at which this event can stop spawning, 0-1, where 0 is midnight and 1 is 11:59pm
    /// </summary>
    public virtual float SpawnEndTime => 1;

    /// <summary>
    /// Whether or not this event has a duration
    /// </summary>
    public virtual bool HasDuration => false;

    /// <summary>
    /// The duration of this event, in seconds, if it has a duration
    /// </summary>
    public virtual float DurationSec => 0;

    /// <summary>
    /// Whether or not this event has a minimum ocean depth it can spawn in
    /// </summary>
    public virtual bool HasMinDepth => false;

    /// <summary>
    /// The minimum water depth this event can spawn in
    /// </summary>
    public static float MinDepth => 0;

    /// <summary>
    /// The path to use for depth testing
    /// </summary>
    public virtual List<Vector3> DepthTestPath => new(){Vector3.zero};

    /// <summary>
    /// Whether or not this event follows a path
    /// </summary>
    public virtual bool IsPath => false;

    /// <summary>
    /// The number of depth checks to perform along the path
    /// </summary>
    public virtual float DepthPathNumChecks => 5f;

    /// <summary>
    /// The offset to use for the player spawn position
    /// </summary>
    public virtual Vector3 PlayerSpawnOffset => Vector3.zero;

    /// <summary>
    /// The offset to use for the zone test for forbidden zones
    /// </summary>
    public virtual Vector3 ZoneTestOffset => Vector3.zero;

    /// <summary>
    /// Whether or not this event should check for safe zones around docks
    /// </summary>
    public virtual bool DoSafeZoneHitCheck => true;

    /// <summary>
    /// The offset to use for the safe zone hit check
    /// </summary>
    public virtual Vector3 SafeZoneHitCheckOffset => Vector3.zero;

    /// <summary>
    /// The zones that this event is forbidden from spawning in
    /// </summary>
    public virtual ZoneEnum ForbiddenZones => ZoneEnum.NONE;

    /// <summary>
    /// The inventory conditions for this event to be able to spawn
    /// </summary>
    public virtual List<InventoryCondition> ItemInventoryConditions => new();

    /// <summary>
    /// Whether or not this event can spawn in passive mode
    /// </summary>
    public virtual bool AllowInPassiveMode => false;

    /// <summary>
    /// The minimum world phase required for this event to spawn
    /// </summary>
    public virtual int MinWorldPhase => 0;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.eventType = Type;
        Item.prefab = Prefab;
        Item.dispelByBanish = DispelByBanish;
        Item.dispelByFoghorn = DispelByFoghorn;
        Item.foghornDispelTime = FoghornDispelTime;
        Item.foghornDispelCount = FoghornDispelCount;
        Item.minWorldPhase = MinWorldPhase;
        Item.minSanity = MinSanity;
        Item.maxSanity = MaxSanity;
        Item.repeatDelay = RepeatDelay;
        Item.weight = Weight;
        Item.spawnStartTime = SpawnStartTime;
        Item.spawnEndTime = SpawnEndTime;
        Item.hasDuration = HasDuration;
        Item.durationSec = DurationSec;
        Item.hasMinDepth = HasMinDepth;
        Item.minDepth = MinDepth;
        Item.depthTestPath = DepthTestPath;
        Item.isPath = IsPath;
        Item.depthPathNumChecks = DepthPathNumChecks;
        Item.playerSpawnOffset = PlayerSpawnOffset;
        Item.zoneTestOffset = ZoneTestOffset;
        Item.doSafeZoneHitCheck = DoSafeZoneHitCheck;
        Item.safeZoneHitCheckOffset = SafeZoneHitCheckOffset;
        Item.forbiddenZones = ForbiddenZones;
        Item.itemInventoryConditions = ItemInventoryConditions;
        Item.allowInPassiveMode = AllowInPassiveMode;
    }
}