﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.tk.dam.Entity;

namespace com.tk.dam.Views
{
    public partial class Yhgl : XtraUserControlBase
    {
        IList<Yh> mYhList = new List<Yh>();

        public Yhgl()
        {
            InitializeComponent();
            gridColumn_xh.Caption = "\n序号\n "; //调整ColumnHeader的高度
            BindingGrid();
        }

        /// <summary>
        ///  更新用户
        /// </summary>
        /// <param name="yh">用户对象</param>
        /// <param name="isNew">是否新增</param>
        public void UpdateYHList(Yh yh, bool isNew)
        {
            if (isNew)
            {
                yh.Xh = mYhList.Max(temp => temp.Xh) + 1;
                mYhList.Add(yh);
            }
            else
            {
                mYhList.Remove(mYhList.Single(temp => temp.Xh == yh.Xh));
                mYhList.Add(yh);
            }
            gcMain.RefreshDataSource();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="yh">用户</param>
        public void DeleteYH(Yh yh)
        {
            mYhList.Remove(yh);
            gcMain.RefreshDataSource();
        }

        private void BindingGrid()
        {
            mYhList.Add(new Yh { Xh = 1, Xm = "张三", Dlm = "zhangsan", Xb = "男", Qx = "超级管理员" });
            mYhList.Add(new Yh { Xh = 2, Xm = "李四", Dlm = "lisi", Xb = "男", Qx = "员工" });
            mYhList.Add(new Yh { Xh = 3, Xm = "赵五", Dlm = "zhaowu", Xb = "男", Qx = "员工" });
            gcMain.DataSource = mYhList;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm.ShowYHEditFlyout(null);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainForm.ShowDeleteYHConfirm(mYhList[gridView1.FocusedRowHandle]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainForm.ShowYHEditFlyout(mYhList[gridView1.FocusedRowHandle]);
        }
    }
}
