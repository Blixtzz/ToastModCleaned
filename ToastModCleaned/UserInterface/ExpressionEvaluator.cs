﻿using Il2CppSystem.Xml.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastModCleaned.Controls;
using ToastModCleaned.QOL;

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
                    QOL.ApiControls.HideSelf = !QOL.ApiControls.HideSelf;
                    break;
                case "PauseAB":
                    QOL.ApiControls.PauseAssetBundleManager();
                    break;
                case "Clear":
                    QOL.ApiControls.ClearAssets();
                    break;
                default: break;
            }
        }
    }
}