using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ToastModCleaned.Wrappers
{
    internal class General
    {
        public static Color GetTrustColor(VRC.Player player)
        { return VRCPlayer.Method_Public_Static_Color_APIUser_0(player.field_Private_APIUser_0); }
    }
}
