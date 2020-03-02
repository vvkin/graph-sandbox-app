﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph_sandbox
{
    public partial class Form1 : Form
    {
        int MaxWidth = 200;
        bool Hided = true;

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.addVertex, "Add vertex");
            toolTip2.SetToolTip(this.addEdge, "Add edge");
            toolTip3.SetToolTip(this.remove, "Remove");
            toolTip4.SetToolTip(this.download, "Download graph");
            toolTip5.SetToolTip(this.functions, "Functions");
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void hideForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                while(buttonsPanel.Width < MaxWidth)
                {
                    buttonsPanel.Width += 30;
                }
                functionsPanel.Visible = true;
                Hided = false;
            }
            else
            {
                functions.Visible = false;
                while (buttonsPanel.Width > 60)
                {
                    buttonsPanel.Width -= 30;
                }
                Hided = true;
            }
            timer1.Stop();
            this.Refresh();
            functions.Visible = true;
        }
    }
}
