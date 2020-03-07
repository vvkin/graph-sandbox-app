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
        int MaxWidth = 230;
        bool Hided = true;
        private bool addVertex_clicked = false;
        private bool removeObject_clicked = false;
        private Color activeButtonColor = Color.FromArgb(100, 100, 100);
        private Color passiveButtonColor = Color.FromArgb(51, 75, 180);
        private bool dragable;
        private Point startPosition;

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
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void hideForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                while(buttonsPanel.Width < MaxWidth)
                {
                    buttonsPanel.Width += 30;
                    functions.Enabled = false;
                }
                functionsPanel.Visible = true;
                functions.Enabled = true;
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
            functions.Visible = true;
        }

        private void addVertex_MouseClick(object sender, MouseEventArgs e)
        {
            addVertex_clicked = !addVertex_clicked;
            removeObject_clicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void DrawCircle(object sender, MouseEventArgs e)
        {
            if (removeObject_clicked)
            {
                drawingSurface1.TryToRemove(e);
            }

            else if (addVertex_clicked)
            {
                Circle currentNew = new Circle();

                currentNew.Center = new Point(e.X, e.Y);

                if (drawingSurface1.isValid(currentNew))
                {
                    drawingSurface1.Add(currentNew);
                    currentNew.Draw(drawingSurface1.CreateGraphics());
                }
                else
                {
                    --Circle.number;
                }
            }
        }

        private void ChangeState(object sender, MouseEventArgs e)
        {
            removeObject_clicked = !removeObject_clicked;
            addVertex_clicked = false;
            ChangeButtonsColor();
            ChangeCanBeMoved();
        }

        private void ChangeCanBeMoved()
        {
            Circle.canBeMoved = !(addVertex_clicked || removeObject_clicked);
        }


        private void ChangeButtonsColor()
        {
            remove.BackColor = (removeObject_clicked) ? activeButtonColor : passiveButtonColor;
            addVertex.BackColor = (addVertex_clicked) ? activeButtonColor : passiveButtonColor;
        }

        // Drag window when drag topPanel

        private void MakeDragable(object sender, MouseEventArgs e)
        {
            dragable = true;
            startPosition = e.Location;
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (dragable)
            {
                Location = new Point(Cursor.Position.X - startPosition.X, Cursor.Position.Y - startPosition.Y);
            }
        }

        private void DisableDrag(object sender, MouseEventArgs e)
        {
            dragable = false;
        }

        // End
    }
}
