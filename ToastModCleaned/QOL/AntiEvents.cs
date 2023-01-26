using ExitGames.Client.Photon;
using Harmony;
using MelonLoader;
using Photon.Realtime;
using System;
using System.Threading;
using System.Timers;
using ToastModCleaned.Controls;
using UnhollowerBaseLib;

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
            switch (__0.Code)
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
                    if (EventAntis)
                        e6++;
                    return true;
                case 9:
                    if (Panic || e9 >= 50)
                    {
                        return false;
                    }
                    if (EventAntis)
                        e9++;
                    return true;
            }
            return true;
        }
    }
}
