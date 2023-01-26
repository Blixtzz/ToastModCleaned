using Il2CppSystem.Xml.Schema;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastModCleaned.Controls;
using ToastModCleaned.QOL;
using VRC.Udon;

namespace ToastModCleaned.UserInterface
{
    public class ExpressionEvaluator
    {
        public static void ReadText(string text)
        {
            switch (text)
            {
                case "bHop":
                    QOL.Movement.Bhop = !QOL.Movement.Bhop;
                    break;
                case "Inf":
                    QOL.Movement.inf = !QOL.Movement.inf;
                    break;
                case "CTP":
                    QOL.Movement.clickTP = !QOL.Movement.clickTP;
                    break;
                case "ESP":
                    Exploits.Esp.ESP = !Exploits.Esp.ESP;
                    break;
                case "Id":
                    string id = System.Windows.Forms.Clipboard.GetText().Trim();
                    QOL.ApiControls.ChangeAvi(id);
                    break;
                case "HideSelf":
                    QOL.ApiControls.HideMe();
                    break;
                case "PauseAB":
                    QOL.ApiControls.PauseAssetBundleManager();
                    break;
                case "Clear":
                    QOL.ApiControls.ClearAssets();
                    break;
                case "Panic":
                    AntiEvents.Panic = !AntiEvents.Panic;
                    break;
                case "ULC":
                    Movement.UseLegacyLocomotion();
                    break;
                case "EventAntis":
                    QOL.AntiEvents.EventAntis = !QOL.AntiEvents.EventAntis;
                    break;
                case "FuckUdon":
                    Exploits.EventExploits.UdonFuck();
                    break;
                case "LogUdon":
                    QOL.UdonPatch.LogUdon = !QOL.UdonPatch.LogUdon;
                    break;
                case "NoUdon":
                    QOL.UdonPatch.NoUdon = !QOL.UdonPatch.NoUdon;
                    break;
                default: break;
            }
        }
    }
}
