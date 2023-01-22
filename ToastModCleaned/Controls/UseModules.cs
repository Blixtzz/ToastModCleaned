using Il2CppSystem.Net;
using RenderHeads.Media.AVProVideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastModCleaned.Controls
{
    public class UseModules
    {
        private static List<ToastClientCleaned.Controls.BaseModule> modules = new List<ToastClientCleaned.Controls.BaseModule>();
        public static void OnUpdate()
        {
            foreach (var module in modules)
            {
                module.OnUpdate();
            }
        }
    }
}
