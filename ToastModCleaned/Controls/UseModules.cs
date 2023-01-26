using Il2CppSystem.Net;
using RenderHeads.Media.AVProVideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastModCleaned.Exploits;
using ToastModCleaned.QOL;
using VRC.UI;

namespace ToastModCleaned.Controls
{
    public class UseModules : BaseModule
    {
        public static UseModules instance;
        public List<BaseModule> modules = new List<BaseModule>();
        Movement movement;
        Wrappers.LeaveJoin joinLeave;
        Exploits.Flight flight;
        QOL.AntiEvents antiEvent;
        QOL.UdonPatch udonPatch;
        ApiControls api;
        QOL.AssetBundlePatch abPatch;
        public UseModules()
        {
            this.modules.Add(this.flight = new Exploits.Flight());
            this.modules.Add(this.movement = new Movement());
            this.modules.Add(this.joinLeave = new Wrappers.LeaveJoin());
            this.modules.Add(this.api = new ApiControls());
            this.modules.Add(this.antiEvent = new QOL.AntiEvents());
            this.modules.Add(this.udonPatch = new QOL.UdonPatch());
            this.modules.Add(this.abPatch = new QOL.AssetBundlePatch());
        }
        public void Init()
        {
            for (int i = 0; i < this.modules.Count; i++)
            {
                this.modules[i].Init();
            }
        }
        public void OnUpdate()
        {
            for (int i = 0; i < this.modules.Count; i++)
            {
                this.modules[i].OnUpdate();
            }
        }
    }
}
