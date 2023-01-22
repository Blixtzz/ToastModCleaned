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

namespace ToastModCleaned.QOL
{
    public class AssetBundlePatch
    { //taken from bundle bouncer, idk how they manage this shit lol
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate IntPtr AttemptAvatarDownloadDelegate(IntPtr hiddenValueTypeReturn, IntPtr thisPtr, IntPtr apiAvatarPtr, IntPtr multicastDelegatePtr, bool idfk, IntPtr nativeMethodInfo);
        private static AttemptAvatarDownloadDelegate dgAttemptAvatarDownload;
        public static void assetBundlePatch(Harmony.HarmonyInstance harmony)
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
                    MelonLogger.Msg($"Hooked AssetBundleDownloadManager.");
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
                if (File.ReadAllText(@"ToastClient\avtr_blacklist.txt").Contains(av.id))
                {
                    av.assetUrl = null;
                    MelonLogger.Msg(ConsoleColor.Red, "BAATL PtrReF -> " + av.id);
                }
                if (!File.ReadAllText(@"ToastClient\log\AvLog.txt").Contains(av.id))
                {
                    string[] lines = { "-============================================================-\nAvatar Download Started\n-============================================================-", "avatar name: " + av.name, "download: " + av.assetUrl, "id: " + av.id, "image: " + av.thumbnailImageUrl, "author: " + av.authorName, "release: " + av.releaseStatus, "\n\n" };
                    File.AppendAllLines(@"ToastClient\log\AvLog.txt", lines);
                }
            }
            return dgAttemptAvatarDownload(hiddenStructReturn, thisPtr, pApiAvatar, pMulticastDelegate, param_3, nativeMethodInfo);
        }
    }
}