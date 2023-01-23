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
        public UseModules()
        {
            this.modules.Add(this.flight = new Exploits.Flight());
            this.modules.Add(this.movement = new Movement());
            this.modules.Add(this.joinLeave = new Wrappers.LeaveJoin());
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
