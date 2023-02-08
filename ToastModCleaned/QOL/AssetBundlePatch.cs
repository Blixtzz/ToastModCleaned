using MelonLoader;
using System;
using UnityEngine;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;
using VRC.Core;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using ToastModCleaned.Controls;

namespace ToastModCleaned.QOL
{
    public class AssetBundlePatch : BaseModule
    { //taken from bundle bouncer, idk how they manage this shit lol
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate IntPtr AttemptAvatarDownloadDelegate(IntPtr hiddenValueTypeReturn, IntPtr thisPtr, IntPtr apiAvatarPtr, IntPtr multicastDelegatePtr, bool idfk, IntPtr nativeMethodInfo);
        private static AttemptAvatarDownloadDelegate dgAttemptAvatarDownload;
        public override void Init()
        {
            new Thread(() => { QOL.AssetBundlePatch.HarmonyPatch(new Harmony.HarmonyInstance("AssetBundlePatch")); }).Start();
        }
        private static void HarmonyPatch(Harmony.HarmonyInstance harmony)
        {
            try
            {
                unsafe
                {
                    // God I hate pointers.
                    var originalMethodPointer = *(IntPtr*)(IntPtr)UnhollowerUtils
                        .GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(AssetBundleDownloadManager).GetMethod(
                            nameof(AssetBundleDownloadManager.Method_Internal_UniTask_1_InterfacePublicAbstractIDisposableGaObGaUnique_ApiAvatar_MulticastDelegateNInternalSealedVoUnUnique_Boolean_0)))
                        .GetValue(null);

                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPointer), typeof(AssetBundlePatch).GetMethod(nameof(AssetBundlePatch.OnAssetBundleLoaded), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());

                    dgAttemptAvatarDownload = Marshal.GetDelegateForFunctionPointer<AttemptAvatarDownloadDelegate>(originalMethodPointer);
                    MelonLogger.Msg(ConsoleColor.Cyan, $"[Patch] On AssetBundleDownloadManager Success");
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ex);
            }
        }
        private struct AttemptAvatarDownloadContext : IDisposable
        {
            internal static ApiAvatar apiAvatar;

            public AttemptAvatarDownloadContext(ApiAvatar iApiAvatar)
            {
                apiAvatar = iApiAvatar;
            }

            public void Dispose()
            {
                apiAvatar = null;
            }
        }
        static unsafe IntPtr OnAssetBundleLoaded(IntPtr hiddenStructReturn, IntPtr thisPtr, IntPtr pApiAvatar, IntPtr pMulticastDelegate, bool param_3, IntPtr nativeMethodInfo)
        {
            using (var ctx = new AttemptAvatarDownloadContext(pApiAvatar == IntPtr.Zero ? null : new ApiAvatar(pApiAvatar)))
            {
                var av = AttemptAvatarDownloadContext.apiAvatar;
                if (File.ReadAllText(@"Mods\meow\avtr_blacklist.txt").Contains(av.id))
                {
                    av.assetUrl = null;
                    MelonLogger.Msg(ConsoleColor.Red, "BAATL PtrReF -> " + av.id);
                }
                if (!File.ReadAllText(@"Mods\meow\log\AvLog.txt").Contains(av.id))
                {
                    string[] lines = { "-============================================================-\nAvatar Download Started\n-============================================================-", "avatar name: " + av.name, "download: " + av.assetUrl, "id: " + av.id, "image: " + av.thumbnailImageUrl, "author: " + av.authorName, "release: " + av.releaseStatus, "\n\n" };
                    string line = $"{av.name}\n{av.id}\n{av.releaseStatus}\n{av.imageUrl}";
                    File.AppendAllLines(@"Mods\meow\log\AvLog.txt", lines);
                }
            }
            return dgAttemptAvatarDownload(hiddenStructReturn, thisPtr, pApiAvatar, pMulticastDelegate, param_3, nativeMethodInfo);
        }
    }
}