﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;
using VRC.UI;
using ToastModCleaned.Controls;

namespace ToastModCleaned.QOL
{
    public class ApiControls : BaseModule
    {
        private static bool HideSelf;
        private static int targetFramerate;
        public static void ChangeAvi(string avatarId)
        {
            //taken from remod CE, doesn't care abt credit, but yea
            var apiModelContainer = new ApiModelContainer<ApiAvatar>
            {
                OnSuccess = new Action<ApiContainer>(c =>
                {
                    var pageAvatar = Resources.FindObjectsOfTypeAll<PageAvatar>()[0];
                    var apiAvatar = new ApiAvatar
                    {
                        id = avatarId
                    };
                    pageAvatar.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = apiAvatar;
                    pageAvatar.ChangeToSelectedAvatar();
                })
            };
            API.SendRequest($"avatars/{avatarId}", 0, apiModelContainer, null, true, true, 3600f, 2);
        }
        public static void HideMe()
        {
            //also remod I think but not sure
            HideSelf = !HideSelf;
            var HidePreview = GameObject.FindObjectsOfType<VRCUiManager>().First(x => x.name.StartsWith("UserInterface"));
            if (HideSelf)
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.SetActive(false);
                HidePreview.transform.FindChild("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Panel_SelectedAvatar/Panel_MM_AvatarViewer").gameObject.SetActive(false);
            }
            if (!HideSelf)
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.SetActive(true);
                HidePreview.transform.FindChild("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Panel_SelectedAvatar/Panel_MM_AvatarViewer").gameObject.SetActive(true);
            }
        }
        public static void ClearAssets()
        {
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Cache_0.ClearCache();
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_ObjectPublicInStInCoBoUnInStObBoUnique_0.Clear();
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_ObjectPublicInStInCoBoUnInStObBoUnique_1.Clear();
        }
        public static void PauseAssetBundleManager()
        {
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.enabled = !AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.enabled;
        }
        public override void Init()
        {
            targetFramerate = Application.targetFrameRate;
        }
        public override void OnUpdate()
        {
            if (Application.isFocused)
            {
                Application.targetFrameRate = targetFramerate;
            }
            if (!Application.isFocused)
            {
                Application.targetFrameRate = 25;
            }
        }
    }
}
