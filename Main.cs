using BepInEx;
using JetBrains.Annotations;

namespace Abyss;

[BepInPlugin(Id, Name, Version)]
[UsedImplicitly]
internal class WorldEvents : DredgeMod
{
     private const string Id = "com.grahamkracker.abyss.worldevents";
     private const string Name = "Abyss.WorldEvents";
     private const string Version = "0.0.1";
}
