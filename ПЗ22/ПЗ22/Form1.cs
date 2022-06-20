using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПЗ22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Rectangle Rectangle = new Rectangle(70, 90, 200, 100);
        Rectangle Circle = new Rectangle(330, 90, 150, 150);
        Rectangle Square = new Rectangle(540, 90, 150, 150);

        bool r = false, c = false, s = false;

        int rx = 0, ry = 0, cx = 0, cy = 0, sx = 0, sy = 0;

        int x, y, dx, dy;
        int lastClicked = 1;


        

       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X < Rectangle.X + Rectangle.Width) && (e.X > Rectangle.X))
            {
                if ((e.Y < Rectangle.Y + Rectangle.Height) && (e.Y > Rectangle.Y))
                {
                    r = true;
                    rx = e.X - Rectangle.X;
                    ry = e.Y - Rectangle.Y;
                }
            }
            if ((e.X < Circle.X + Circle.Width) && (e.X > Circle.X))
            {
                if ((e.Y < Circle.Y + Circle.Height) && (e.Y > Circle.Y))
                {
                    c = true;
                    cx = e.X - Circle.X;
                    cy = e.Y - Circle.Y;
                }
            }
            if ((e.X < Square.X + Square.Width) && (e.X > Square.X))
            {
                if ((e.Y < Square.Y + Square.Height) && (e.Y > Square.Y))
                {
                    s = true;
                    sx = e.X - Square.X;
                    sy = e.Y - Square.Y;
                }
            }

            if (r == true)
            {
                lastClicked = 1;
            }
            if (c == true)
            {
                lastClicked = 2;
            }
            if (s == true)
            {
                lastClicked = 3;
            }
        }

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, Circle);
            e.Graphics.FillRectangle(Brushes.Blue, Square);
            e.Graphics.FillRectangle(Brushes.Yellow, Rectangle);

            if (lastClicked == 1)
            {
                e.Graphics.FillEllipse(Brushes.Red, Circle);
                e.Graphics.FillRectangle(Brushes.Blue, Square);
                e.Graphics.FillRectangle(Brushes.Yellow, Rectangle);
            }
            if (lastClicked == 2)
            {
                e.Graphics.FillRectangle(Brushes.Blue, Square);
                e.Graphics.FillRectangle(Brushes.Yellow, Rectangle);
                e.Graphics.FillEllipse(Brushes.Red, Circle);
            }
            if (lastClicked == 3)
            {
                e.Graphics.FillRectangle(Brushes.Yellow, Rectangle);
                e.Graphics.FillEllipse(Brushes.Red, Circle);
                e.Graphics.FillRectangle(Brushes.Blue, Square);
            }


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (r == true)
            {
                Rectangle.X = e.X - rx;
                Rectangle.Y = e.Y - ry;
            }
            if ((label1.Location.X < Rectangle.X + Rectangle.Width) && (label1.Location.X > Rectangle.X))
            {
                if ((label1.Location.Y < Rectangle.Y + Rectangle.Height) && (label1.Location.Y > Rectangle.Y))
                {
                    label3.Text = "Жёлтый прямоугольник";
                }
            }
            if (c == true)
            {
                Circle.X = e.X - cx;
                Circle.Y = e.Y - cy;
            }
            if ((label1.Location.X < Circle.X + Circle.Width) && (label1.Location.X > Circle.X))
            {
                if ((label1.Location.Y < Circle.Y + Circle.Height) && (label1.Location.Y > Circle.Y))
                {
                    label3.Text = "Красный круг";
                }
            }
            if (s == true)
            {
                Square.X = e.X - sx;
                Square.Y = e.Y - sy;
            }
            if ((label1.Location.X < Square.X + Square.Width) && (label1.Location.X > Square.X))
            {
                if ((label1.Location.Y < Square.Y + Square.Height) && (label1.Location.Y > Square.Y))
                {
                    label3.Text = "Синий квадрат";
                }
            }
            pictureBox1.Invalidate();
        }

        

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (lastClicked == 1)
            {
                Recatangle_replace();
            }
            if (lastClicked == 2)
            {
                Circle_replace();
            }
            if (lastClicked == 3)
            {
                Square_replace();
            }

            r = false;
            c = false;
            s = false;
        }

        public void Recatangle_replace()
        {
            if ((label2.Location.X < Rectangle.X + Rectangle.Width) && (label2.Location.X > Rectangle.X))
            {
                if ((label2.Location.Y < Rectangle.Y + Rectangle.Height) && (label2.Location.Y > Rectangle.Y))
                {
                    x = Rectangle.X;
                    y = Rectangle.Y;
                    dx = rx;
                    dy = ry;
                    Rectangle.X = Circle.X;
                    Rectangle.Y = Circle.Y;
                    rx = cx;
                    ry = cy;

                    Circle.X = x;
                    Circle.Y = y;
                    cx = dx;
                    cy = dy;
                }
            }
        }

        public void Circle_replace()
        {
            if ((label2.Location.X < Circle.X + Circle.Width) && (label2.Location.X > Circle.X))
            {
                if ((label2.Location.Y < Circle.Y + Circle.Height) && (label2.Location.Y > Circle.Y))
                {
                    x = Circle.X;
                    y = Circle.Y;
                    dx = cx;
                    dy = cy;
                    Circle.X = Square.X;
                    Circle.Y = Square.Y;
                    cx = sx;
                    cy = sy;

                    Square.X = x;
                    Square.Y = y;
                    sx = dx;
                    sy = dy;
                }
            }
        }

        public void Square_replace()
        {
            if ((label2.Location.X < Square.X + Square.Width) && (label2.Location.X > Square.X))
            {
                if ((label2.Location.Y < Square.Y + Square.Height) && (label2.Location.Y > Square.Y))
                {
                    x = Square.X;
                    y = Square.Y;
                    dx = sx;
                    dy = sy;
                    Square.X = Rectangle.X;
                    Square.Y = Rectangle.Y;
                    sx = rx;
                    sy = ry;

                    Rectangle.X = x;
                    Rectangle.Y = y;
                    rx = dx;
                    ry = dy;
                }
            }
        }
    }
}
