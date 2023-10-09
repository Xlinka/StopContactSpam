using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;

namespace StopContactSpam
{
    public class StopContactSpamMod : ResoniteMod
    {
        public override string Name => "StopContactSpam";
        public override string Author => "xlinka";
        public override string Version => "1.0.0";

        public override void OnEngineInit()
        {
            var harmony = new Harmony("com.xlinka.StopContactSpam");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(EngineStatusSource), "IsUserPresent", MethodType.Getter)]
        public static class Patch_IsUserPresent
        {
            [HarmonyPostfix]
            public static void Postfix(ref bool __result)
            {
                // Override the result of the IsUserPresent getter to always return true. This is a Temporary Fix
                __result = true;
            }
        }
    }
}
