using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.WorldEvents;

public abstract class ModWorldEventData : ScriptableObjectModContent<WorldEventData>
{
    public WorldEventType eventType;

    public GameObject prefab;

    public bool dispelByBanish;

    public bool dispelByFoghorn;

    public float foghornDispelTime;

    public float foghornDispelCount;

    /// <summary>
    /// The minimum sanity required for this event to spawn, 0-1
    /// </summary>
    public virtual float MinSanity => 0;

    /// <summary>
    /// The maximum sanity required for this event to spawn, 0-1
    /// </summary>
    public virtual float MaxSanity => 1;

    public abstract Dictionary<GameMode, float> repeatDelay { get; }

    public abstract float Weight { get; }

    [field: Range(0f, 1f)] public float SpawnStartTime => 0;

    [field: Range(0f, 1f)] public float SpawnEndTime => 1;

    public bool hasDuration;

    public float durationSec;

    public bool hasMinDepth;

    public float minDepth;

    public List<Vector3> depthTestPath;

    public bool isPath;

    public float depthPathNumChecks = 5f;

    public Vector3 playerSpawnOffset;

    public Vector3 zoneTestOffset;

    public bool doSafeZoneHitCheck;

    public Vector3 safeZoneHitCheckOffset;

    public ZoneEnum forbiddenZones;

    public List<InventoryCondition> itemInventoryConditions = new List<InventoryCondition>();

    /// <summary>
    /// Whether or not this event can spawn in passive mode
    /// </summary>
    public bool AllowInPassiveMode => false;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.eventType = eventType;
        Item.prefab = prefab;
        Item.dispelByBanish = dispelByBanish;
        Item.dispelByFoghorn = dispelByFoghorn;
        Item.foghornDispelTime = foghornDispelTime;
        Item.foghornDispelCount = foghornDispelCount;
        Item.minWorldPhase = 0;
        Item.minSanity = MinSanity;
        Item.maxSanity = MaxSanity;
        Item.repeatDelay = repeatDelay;
        Item.weight = Weight;
        Item.spawnStartTime = SpawnStartTime;
        Item.spawnEndTime = SpawnEndTime;
        Item.hasDuration = hasDuration;
        Item.durationSec = durationSec;
        Item.hasMinDepth = hasMinDepth;
        Item.minDepth = minDepth;
        Item.depthTestPath = depthTestPath;
        Item.isPath = isPath;
        Item.depthPathNumChecks = depthPathNumChecks;
        Item.playerSpawnOffset = playerSpawnOffset;
        Item.zoneTestOffset = zoneTestOffset;
        Item.doSafeZoneHitCheck = doSafeZoneHitCheck;
        Item.safeZoneHitCheckOffset = safeZoneHitCheckOffset;
        Item.forbiddenZones = forbiddenZones;
        Item.itemInventoryConditions = itemInventoryConditions;
        Item.allowInPassiveMode = AllowInPassiveMode;
    }
}