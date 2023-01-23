using Harmony;
using MelonLoader;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;

namespace ToastModCleaned.QOL
{
    internal class AntiEvents
    {
        public static void InitEventPatch(HarmonyInstance harmony)
        {
            try
            {
                harmony.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(AntiEvents), nameof(OnEvent))));
                MelonLogger.Msg(ConsoleColor.Cyan, "[Patch] On Event Success");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ConsoleColor.Red, $"{ex} \n-> [Patch] Analytics Error while Patching Events");
            }
        }
        public static bool OnEvent(ref EventData __0)
        {
            switch(__0.Code)
            {
                case 1:
                    var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                    if (bytes.Length == 71 || bytes.Length == 37 || bytes.Length == 398)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
    }
}
