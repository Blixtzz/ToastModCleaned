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
        public static void InitEventPatch(Harmony.HarmonyInstance harmony)
        {
            try
            {
                harmony.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(AntiEvents), nameof(OnEvent))));
            }
            catch
            {
                MelonLogger.Msg(ConsoleColor.Red, "[Patch] Analytics Error while Patching Events");
            }
        }
        public static bool OnEvent(ref EventData data)
        {
            if (data == null) return false;
            switch(data.Code)
            {
                case 1:
                    var bytes = data.CustomData.Cast<Il2CppArrayBase<byte>>();
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
