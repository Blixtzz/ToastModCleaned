using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;

namespace ToastModCleaned.UserInterface
{
    public partial class RecieveInput : Form
    {
        public RecieveInput()
        {
            InitializeComponent();
        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }
        private void Send_Click(object sender, EventArgs e)
        {
            string text = ToastMain.UserInput.UserInput.Text;
            ExpressionEvaluator.ReadText(text);
        }

        private void Players_Click(object sender, EventArgs e)
        {
            Wrappers.General.TargetPlayer = Wrappers.General.GetPlayer(ToastMain.UserInput.Players.SelectedItem.ToString());
        }
        private void Players_DoubleClick(object sender, EventArgs e)
        {
            var target = Wrappers.General.TargetPlayer;
            Clipboard.SetText($"{target.prop_APIUser_0.displayName}\n{target.prop_APIUser_0.id}\n{target.prop_ApiAvatar_0.id}\navatar is {target.prop_ApiAvatar_0.releaseStatus}");
        }
        private void Players_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SitOnHead_Click(object sender, EventArgs e)
        {
            QOL.Movement.SitOnHead = !QOL.Movement.SitOnHead;
        }
    }
}