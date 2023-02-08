using ExitGames.Client.Photon;
using Harmony;
using MelonLoader;
using Photon.Realtime;
using System;
using System.Threading;
using System.Timers;
using ToastModCleaned.Controls;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;

namespace ToastModCleaned.QOL
{
    internal class AntiEvents : BaseModule
    {
        private static System.Timers.Timer aTimer;
        public static bool EventAntis = true;
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
            UdonPatch.udonRateLimit = 0;
            e6 = 0;
            e9 = 0;
        }
        public override void Init()
        {
            new Thread(() => { AntiEvents.HarmonyInit(new Harmony.HarmonyInstance("AntiEvents")); }).Start();
            SetTimer();
        }
        private static void HarmonyInit(HarmonyInstance harmony)
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
        private static bool OnEvent(ref EventData __0)
        {
            if (EventAntis)
            {
                switch (__0.Code)
                {
                    case 1:
                        //casting bytes the way I was throws errors and breaks everything now. I'll work on a different e1 anti ig
                        break;
                    case 6:
                        if (Panic || e6 <= 50)
                        {
                            return true;
                        }
                        if (EventAntis)
                            e6++;
                        break;
                    case 9:
                        if (Panic || e9 <= 50)
                        {
                            return true;
                        }
                        if (EventAntis)
                            e9++;
                        break;
                }
            }
            return true;
        }
    }
}
