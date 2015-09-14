﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace com.tk.dam.Views
{
    public partial class Sp : XtraUserControlBase
    {
        public Sp()
        {
            InitializeComponent();
        }

        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.Cursor = Cursors.Hand;
            panel.BackColor = Color.FromArgb(227, 166, 41);
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.BackColor = Color.FromArgb(0, 89, 145);
        }

        private void panelViedo_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.Cursor = Cursors.Hand;
            panel.BorderStyle = BorderStyle.Fixed3D;
            //panel.
        }

        private void panelVideo_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.BorderStyle = BorderStyle.None;
            //panel.BackColor = Color.FromArgb(0, 89, 145);
        }

        private void panel8_DoubleClick(object sender, EventArgs e)
        {
            videoCtrl(pboxVideo1, lblVideo1);
        }

        private void panel10_DoubleClick(object sender, EventArgs e)
        {
            videoCtrl(pboxVideo2, lblVideo2);
        }

        private void panel12_DoubleClick(object sender, EventArgs e)
        {
            videoCtrl(pboxVideo3, lblVideo3);
        }

        private void panel14_DoubleClick(object sender, EventArgs e)
        {
            videoCtrl(pboxVideo4, lblVideo4);
        }

        private void videoCtrl(PictureBox PlayScreen, Label lblVideo)
        {
            string mciCommand;
            string alias = "MyAVI" + PlayScreen.Name;
            if (lblVideo.Tag == null || lblVideo.Tag.ToString() != "正在播放")
            {
                lblVideo.Hide();

                mciCommand = string.Format("open {0}\\video\\Bear.wmv alias {1} ", Environment.CurrentDirectory, alias);
                mciCommand = mciCommand + " parent " + PlayScreen.Handle.ToInt32() + " style child ";
                LibWrap.mciSendString(mciCommand, null, 0, 0);
                Rectangle r = PlayScreen.ClientRectangle;
                mciCommand = string.Format(" put {0} window at 0 0 {1} {2}", alias, r.Width, r.Height);
                LibWrap.mciSendString(mciCommand, null, 0, 0);
                LibWrap.mciSendString(string.Format(" play {0} repeat", alias), null, 0, 0);

                lblVideo.Tag = "正在播放";
            }
            else
            {
                LibWrap.mciSendString(string.Format("close {0}", alias), null, 0, 0);
                lblVideo.Show();
                lblVideo.Tag = "停止播放";
            }
        }
    }
    public class LibWrap
    {
        [DllImport(("winmm.dll "), EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string lpszCommand, string lpszReturnString,
                    uint cchReturn, int hwndCallback);
    }
}
