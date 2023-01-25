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
using System.Timers;

namespace ToastModCleaned.QOL
{
    internal class AntiEvents
    {
        private static System.Timers.Timer aTimer;
        public static bool Panic = false;
        private static int e6;
        private static int e9;

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            e6 = 0;
            e9 = 0;
        }
        public static void InitEventPatch(HarmonyInstance harmony)
        {
            try
            {
                SetTimer();
                harmony.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(AntiEvents), nameof(OnEvent))));
                MelonLogger.Msg(ConsoleColor.Cyan, "[Patch] On Event Success");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ConsoleColor.Red, $"{ex} \n-> [Patch] Analytics Error while Patching Events");
            }
        }
        private static bool OnEvent(ref EventData __0)
        {
            switch(__0.Code)
            {
                case 1:
                    var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                    if (bytes.Length == 71 || bytes.Length == 37 || bytes.Length == 398)
                    {
                        return false;
                    }
                    return true;
                case 6: 
                    if (Panic || e6 >= 50)
                    {
                        return false;
                    }
                    e6++;
                    return true;
                case 9: 
                    if (Panic || e9 >= 50)
                    {
                        return false;
                    }
                    e9++;
                    return true;
            }
            return true;
        }
    }
}
