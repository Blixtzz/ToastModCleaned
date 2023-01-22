using Il2CppSystem.Threading.Tasks;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ToastModCleaned.Controls;
using UnityEngine;
using UnityEngine.UI;
using VRC;


namespace ToastModCleaned.Wrappers 
{
    public class LeaveJoin : BaseModule
    {
        public override void OnPlayerJoin(Player player)
        {
            Exploits.Esp.HighlightPlayer(player, true);
            if (player.prop_APIUser_0.isFriend)
            {
                MelonLogger.Msg(System.ConsoleColor.Magenta, "Friend Joined -> " + player.prop_APIUser_0.displayName);
            }
        }
        public override void OnPlayerLeft(Player player)
        {
            if (player.prop_APIUser_0.isFriend)
            {
                MelonLogger.Msg(System.ConsoleColor.Red, "Friend Left -> " + player.prop_APIUser_0.displayName);
            }
        }

        #region buildPatch
        private static event Action<Player> OnJoin;
        private static event Action<Player> OnLeave;
        public override void Init()
        {
            MelonLoader.MelonCoroutines.Start(InitNetwork());
        }
        private IEnumerator InitNetwork()
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
                yield return null;

            Setup();
        }
        private void Setup()
        {
            var field0 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
            var field1 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_2;

            OnJoin += OnPlayerJoinedEvent;
            field0.field_Private_HashSet_1_UnityAction_1_T_0.Add(OnJoin);
            OnLeave += OnPlayerLeftEvent;
            field1.field_Private_HashSet_1_UnityAction_1_T_0.Add(OnLeave);
        }
        public static void OnPlayerJoinedEvent(Player player)
        {
            foreach (BaseModule snaxModule in UseModules.instance.modules)
                snaxModule.OnPlayerJoin(player);
        }
        public static void OnPlayerLeftEvent(Player player)
        {
            foreach (BaseModule snaxModule in UseModules.instance.modules)
                snaxModule.OnPlayerLeft(player);
        }
        #endregion
    }

}