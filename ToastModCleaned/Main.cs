using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastModCleaned.Controls;

namespace ToastModCleaned
{
    public class ToastMain : MelonLoader.MelonMod
    {
        private void StartProcesses()
        {
            MelonLogger.Msg(ConsoleColor.Cyan, "[\nI plan to make this public \nEveryone loves bruce\nIf your game closes for some reason, read readme\nThis is just the stuff I like, if you want something added, contact me ig\nDiscord -> olive#3042\n]");
        }
        public override void OnApplicationStart()
        {
            StartProcesses();
        }
        public override void OnUpdate()
        {
            UseModules.OnUpdate();
        }
    }
}
