using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using HarmonyLib;
using ModSmith.Util;

namespace GamblingMod;

[ModInitializer(nameof(Initialize))]
public static class GamblingModMain
{
    public const string ModId = "GamblingMod"; // Must match the id in `GamblingMod.json`

    public static Logger Logger { get; } = new(ModId, LogType.Generic);

    public static ResourcePaths Res { get; } = new(ModId);

    public static void Initialize()
    {
        Logger.Info("Initializing...");
        Harmony harmony = new(ModId);
        harmony.PatchAll();

        // Register your content...
        StarterContent.RegisterStarterContent();
        GamblingContent.RegisterContent();

        Logger.Info("Initialized.");
    }
}
