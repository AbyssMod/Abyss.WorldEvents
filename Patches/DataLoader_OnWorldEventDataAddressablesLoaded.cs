using System.Collections.Generic;
using Abyss.Api;
using Abyss.Api.WorldEvents;
using HarmonyLib;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Abyss.Patches;

[HarmonyPatch(typeof(DataLoader), nameof(DataLoader.OnWorldEventDataAddressablesLoaded))]
internal static class DataLoader_OnWorldEventDataAddressablesLoaded
{
    [HarmonyPostfix]
    private static void Postfix(AsyncOperationHandle<IList<WorldEventData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded)
        {
            return;
        }
        foreach (var modworldevent in ModContent.GetContent<ModWorldEventData>())
        {
            handle.Result.Add(modworldevent.Item);
        }
    }
}