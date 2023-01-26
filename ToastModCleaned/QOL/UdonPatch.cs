using Harmony;
using MelonLoader;
using System;
using System.Threading;
using ToastModCleaned.Controls;
using VRC.Networking;

namespace ToastModCleaned.QOL
{
    public class UdonPatch : BaseModule
    {
        public static bool LogUdon = false;
        public static bool NoUdon = false;
        public static int udonRateLimit = 0;
        public override void Init()
        {
            new Thread(() => { UdonPatch.HarmonyInit(new Harmony.HarmonyInstance("UdonPatch")); }).Start();
        }
        private static void HarmonyInit(HarmonyInstance harmony)
        {
            try
            {
                harmony.Patch(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), new HarmonyMethod(AccessTools.Method(typeof(UdonPatch), nameof(UdonSyncRunProgramAsRPC))));
                MelonLogger.Msg(ConsoleColor.Cyan, "[Patch] On UdonSyncRunProgramAsRPC Success");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ConsoleColor.Red, $"{ex} \n-> [Patch] Analytics Error while Patching UdonSyncRunProgramAsRPC");
            }
        }
        private static bool UdonSyncRunProgramAsRPC(string __0, VRC.Player __1)
        {
            if (NoUdon || udonRateLimit >= 50)
                return false;
            if (LogUdon)
                MelonLogger.Msg($"{__0} -> sent by: {__1.field_Private_APIUser_0.displayName}");

            return true;
        }
    }
}
