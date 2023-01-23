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
    }
}