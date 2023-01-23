using Il2CppSystem.Threading.Tasks;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToastModCleaned.Controls;
using ToastModCleaned.QOL;

namespace ToastModCleaned
{
    public class ToastMain : MelonLoader.MelonMod
    {
        private void StartProcesses()
        {
            MelonLogger.Msg(ConsoleColor.Cyan, "\n[\nI plan to make this public \nEveryone loves bruce\nIf your game closes for some reason, read readme\nThis is just the stuff I like, if you want something added, contact me ig\nDiscord -> olive#3042\n]");
            new Thread(() => { AntiEvents.InitEventPatch(new Harmony.HarmonyInstance("AntiEvents")); }).Start();
            new Thread(() => { QOL.AssetBundlePatch.assetBundlePatch(new Harmony.HarmonyInstance("AssetBundlePatch")); }).Start();
            UseModules.instance = new UseModules();
            UseModules.instance.Init();
        }
        public override void OnApplicationStart()
        {
            StartProcesses();
        }
        public override void OnUpdate()
        {
            UseModules.instance.OnUpdate();
        }
    }
}
