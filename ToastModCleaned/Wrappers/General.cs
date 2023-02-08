using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace ToastModCleaned.Wrappers
{
    internal class General
    {
        public static VRC.Player TargetPlayer;
        //private static VRC.Player targetPlayer;
        //public static VRC.Player TargetPlayer { get => targetPlayer; set => targetPlayer = value; }
        public static Color GetTrustColor(VRC.Player player)
        { return VRCPlayer.Method_Public_Static_Color_APIUser_0(player.field_Private_APIUser_0); }
        public static Player GetPlayer(string name)
        {
            Il2CppSystem.Collections.Generic.List<Player> players = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].prop_APIUser_0.displayName == name)
                {
                    return players[i];
                }
            }
            return null;
        }

    }
}
