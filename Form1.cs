using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Timers.Timer;

namespace Graphic

{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
         

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //bresenham frm2 = new bresenham() { Dock= DockStyle.Fill , TopLevel = false , TopMost=true};
            var aBruch = Brushes.Black;
            var g = panel1.CreateGraphics();

            this.Hide();
            Bresenham f2 = new Bresenham();
            Table t1 = new Table();
            
            f2.Show();
            //t1.Show();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EndPoint_lbl_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = e.Url.ToString() + "Is loading ...";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            label23.Hide();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        //================= Draw Buttons ==================

        //// DDA
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bresenham f2 = new Bresenham();
            f2.Show();

            int x0 = Convert.ToInt32(textBox6.Text),
                y0 = Convert.ToInt32(textBox5.Text),
                xEnd = Convert.ToInt32(textBox9.Text),
                yEnd = Convert.ToInt32(textBox13.Text);
            
            lineDDA(x0,y0,xEnd,yEnd);
            Myglobals.Shape_mode = 'd';
        }

        //// Circle
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bresenham f2 = new Bresenham();
            f2.Show();

            int Wanted_x = Convert.ToInt32(textBox2.Text); 
            int Wanted_y = Convert.ToInt32(textBox1.Text); 
            int Radius = Convert.ToInt32(textBox3.Text);    
            
            int x = 0;
            int y = Radius;
            int p = 1 - Radius;

            int count=0;

            // first point
            Myglobals.Draw_array_x.Add(x);
            Myglobals.Draw_array_y.Add(y);
            Myglobals.Table_array_p.Add(p);
            Myglobals.Table_x.Add(x);
            Myglobals.Table_y.Add(y);
            Myglobals.No_indexes.Add(1);
            // assume : x=10 / y=20 / p=-9
            // The rest points
            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    p = p + 2 * x + 1;
                }
                else
                {
                    y--;
                    p = p + 2*(x-y)+1;
                }
                Wanted_points(Wanted_x, Wanted_y, x, y);
                Myglobals.Table_array_p.Add(p);
                Myglobals.Table_x.Add(x);
                Myglobals.Table_y.Add(y);

                count++;
            }
            Myglobals.No_indexes.Add(count);
            Myglobals.Shape_mode = 'c';

        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //// Bresenham
        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Bresenham f2 = new Bresenham();
            f2.Show();
            

            int xStart= Convert.ToInt32(textBox8.Text), 
                yStart= Convert.ToInt32(textBox7.Text),
                xEnd=Convert.ToInt32(textBox15.Text) , 
                yEnd= Convert.ToInt32(textBox14.Text);

            Myglobals.Draw_array_x.Add(xStart);
            Myglobals.Draw_array_y.Add(yStart);
            Myglobals.Table_x.Add(xStart);
            Myglobals.Table_y.Add(yStart);
            BresenhamLine(xStart, yStart, xEnd, yEnd);
            Myglobals.Shape_mode = 'b';
        }

        //// Ellipse
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bresenham f2 = new Bresenham();
            f2.Show();

            int xCenter = Convert.ToInt32(textBox10.Text),
                yCenter = Convert.ToInt32(textBox4.Text),
                xRadius = Convert.ToInt32(textBox12.Text),
                yRadius = Convert.ToInt32(textBox11.Text);

             EllipseMidPoint(xCenter, yCenter, xRadius,yRadius);

        }

        //// 2D transformation
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            _2dTransformation f3 = new _2dTransformation();
            f3.Show();
        }


        //================= Algorithms function ==================
        static void Bresenham_Sample(int xStart, int yStart, int xEnd, int yEnd)
        {
            int dx = xEnd - xStart, dy = yEnd - yStart;
            int steps, pk = 2 * dy - dx, negative_inc = 2 * dy, positive_inc = 2 * dy - 2 * dx;
            float xIncrement, yIncrement;
            //for(int i = 0; i < steps; i++)

            while (Math.Abs(xStart) <= Math.Abs(xEnd))
            {
                xStart++;
                if (pk >= 0)
                {
                    pk = pk + positive_inc;
                    yStart++;
                }
                else
                {
                    pk = pk + negative_inc;
                }
                Myglobals.Draw_array_x.Add(xStart);
                Myglobals.Draw_array_y.Add(yStart);
            }



        }
        void BresenhamLine2(int x1, int y1, int x2, int y2)
        {
            int dx, dy, Po;
            int k = 0;
            dx = (x2 - x1);
            dy = (y2 - y1);
            if (dy <= dx && dy > 0)
            {
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);
                Po = (2 * dy) - dx;
                Myglobals.Draw_array_x.Add(x1);
                Myglobals.Draw_array_y.Add(y1);
                int xk = x1;
                int yk = y1;
                for (k = x1; k < x2; k++)
                {
                    if (Po < 0)
                    {
                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(yk);
                        Po = Po + (2 * dy);
                    }
                    else
                    {
                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(++yk);
                        Po = Po + (2 * dy) - (2 * dx);
                    }
                }
            }
            else if (dy > dx && dy > 0)
            {
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);
                Po = (2 * dx) - dy;
                Myglobals.Draw_array_x.Add(x1);
                Myglobals.Draw_array_y.Add(y1);
                int xk = x1; int yk = y1;
                for (k = y1; k < y2; k++)
                {
                    if (Po < 0)
                    {

                        Myglobals.Draw_array_x.Add(xk);
                        Myglobals.Draw_array_y.Add(++yk);
                        Po = Po + (2 * dx);
                    }
                    else
                    {

                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(++yk);
                        Po = Po + (2 * dx) - (2 * dy);
                    }
                }
            }
            else if (dy >= -dx)
            {
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);
                Po = (2 * dy) - dx;

                Myglobals.Draw_array_x.Add(x1);
                Myglobals.Draw_array_y.Add(y1);
                int xk = x1;
                int yk = y1;
                for (k = x1; k < x2; k++)
                {
                    if (Po < 0)
                    {
                        
                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(yk);
                        Po = Po + (2 * dy);
                    }
                    else
                    {
               
                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(--yk);
                        Po = Po + (2 * dy) - (2 * dx);
                    }
                }
            }
            else if (dy < -dx)
            {
                dx = Math.Abs(dx);
                dy = Math.Abs(dy);
                Po = (2 * dy) - dx;
                
                Myglobals.Draw_array_x.Add(x1);
                Myglobals.Draw_array_y.Add(y1);
                int xk = x1;
                int yk = y1;
                for (k = y1; k > y2; k--)
                {
                    if (Po < 0)
                    {
                        
                        Myglobals.Draw_array_x.Add(xk);
                        Myglobals.Draw_array_y.Add(--yk);
                        Po = Po + (2 * dx);
                    }
                    else
                    {
                       
                        Myglobals.Draw_array_x.Add(++xk);
                        Myglobals.Draw_array_y.Add(--yk);
                        Po = Po + (2 * dx) - (2 * dy);
                    }
                }
            }
            
        }

        //// Bresenham algo
        static void BresenhamLine(int xStart, int yStart, int xEnd, int yEnd)
        {
            int dx = xEnd - xStart, dy = yEnd - yStart , tmp=0;
            int pk , negative_inc  , positive_inc ;
            double slope = (double)dy / (double)dx;
            double abs = Math.Abs(slope);

            int count = 0;

            // Octant 2 
            if (slope > 1 && yStart < yEnd)
            {
                tmp = xStart;
                xStart = yStart;
                yStart = tmp;

                tmp = xEnd;
                xEnd = yEnd;
                yEnd = tmp;

                dx = xEnd - xStart;
                dy = yEnd - yStart;

                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart <= xEnd)
                {
                    xStart++;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart++;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(yStart);
                    Myglobals.Draw_array_y.Add(xStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            // Octant 1
            else if ((slope >= 0 && slope <= 1) && xStart < xEnd)
            {
                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart <= xEnd)
                {
                    xStart++;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart++;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(xStart);
                    Myglobals.Draw_array_y.Add(yStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }

            }
            // Octant 3
            else if (slope < -1 && yStart < yEnd)
            {
                tmp = xStart;
                xStart = yStart;
                yStart = tmp;
                
                tmp = xEnd;
                xEnd = yEnd;
                yEnd = tmp;
                
                dx = xEnd - xStart;
                dy =Math.Abs( yEnd - yStart );
                
                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart <= xEnd)
                {
                    xStart++;
                    
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart--;
                        
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(-yStart);
                    Myglobals.Draw_array_y.Add(xStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            // Octant 4
            else if ((slope >= -1 && slope <= 0) && xEnd<xStart)
            {
                dx = -dx;
                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart >= xEnd)
                {
                    xStart--;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart++;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(-xStart);
                    Myglobals.Draw_array_y.Add(yStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }

            }
            // Octant 5
            else if ((slope > 0 && slope <= 1) && xEnd < xStart)
            {
                dy = -dy;
                dx = -dx;
                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart >= xEnd)
                {
                    xStart--;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart--;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(-xStart);
                    Myglobals.Draw_array_y.Add(-yStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            // Octant 6
            else if (slope > 1 && yEnd < yStart)
            {
                tmp = xStart;
                xStart = yStart;
                yStart = tmp;

                tmp = xEnd;
                xEnd = yEnd;
                yEnd = tmp;

                dx = xEnd - xStart;
                dy = yEnd - yStart;

                dx = -dx;
                dy = -dy;

                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart >= xEnd)
                {
                    xStart--;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart--;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(-yStart);
                    Myglobals.Draw_array_y.Add(-xStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            // Octant 7
            else if (slope < -1 && yEnd<yStart)
            {
                tmp = xStart;
                xStart = yStart;
                yStart = tmp;

                tmp = xEnd;
                xEnd = yEnd;
                yEnd = tmp;

                dx = xEnd - xStart;
                dy = yEnd - yStart;

                dx= -dx;

                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart >= xEnd)
                {
                    xStart--;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart++;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(yStart);
                    Myglobals.Draw_array_y.Add(-xStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            // Octant 8
            else if ((slope >= -1 && slope < 0) && xStart < xEnd)
            {
                dy = -dy;

                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart <= xEnd)
                {
                    xStart++;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart--;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(xStart);
                    Myglobals.Draw_array_y.Add(-yStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }
            else
            {
                pk = 2 * dy - dx;
                negative_inc = 2 * dy;
                positive_inc = 2 * dy - 2 * dx;
                Myglobals.Table_array_p.Add(pk);

                while (xStart <= xEnd)
                {
                    xStart++;
                    if (pk >= 0)
                    {
                        pk = pk + positive_inc;
                        yStart++;
                    }
                    else
                    {
                        pk = pk + negative_inc;
                    }
                    Myglobals.Draw_array_x.Add(xStart);
                    Myglobals.Draw_array_y.Add(yStart);
                    Myglobals.Table_x.Add(xStart);
                    Myglobals.Table_y.Add(yStart);
                    Myglobals.Table_array_p.Add(pk);
                    count++;
                }
            }

            Myglobals.No_indexes.Add(count);

        }
        //// Circle wanted points
        static void Wanted_points(int wanted_x , int wanted_y , int x , int y)
        {
            Myglobals.Draw_array_x.Add(wanted_x +x); Myglobals.Draw_array_y.Add(wanted_y +y);
            Myglobals.Draw_array_x.Add(wanted_x -x); Myglobals.Draw_array_y.Add(wanted_y +y);
            Myglobals.Draw_array_x.Add(wanted_x +x); Myglobals.Draw_array_y.Add(wanted_y -y);
            Myglobals.Draw_array_x.Add(wanted_x -x); Myglobals.Draw_array_y.Add(wanted_y -y);
            Myglobals.Draw_array_x.Add(wanted_x +y); Myglobals.Draw_array_y.Add(wanted_y +x);
            Myglobals.Draw_array_x.Add(wanted_x -y); Myglobals.Draw_array_y.Add(wanted_y +x);
            Myglobals.Draw_array_x.Add(wanted_x +y); Myglobals.Draw_array_y.Add(wanted_y -x);
            Myglobals.Draw_array_x.Add(wanted_x -y); Myglobals.Draw_array_y.Add(wanted_y -x);
            
        }

        //// DDA algo
        private void ddaPlotPoints(float x, float y)
        {
            
            Myglobals.Draw_array_x.Add((int)Math.Round(x));
            Myglobals.Draw_array_y.Add((int)Math.Round(y));
            Myglobals.Table_x.Add((int)Math.Round(x));
            Myglobals.Table_y.Add((int)Math.Round(y));
            Myglobals.DDA_x.Add(x);
            Myglobals.DDA_y.Add(y);
            
        }

        void lineDDA(int x0, int y0, int xEnd, int yEnd)
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;

                try
                {
                    ddaPlotPoints(x, y);
                }
                catch (InvalidOperationException)

                {
                    return;
                }

            }
        }

        //// Ellipse algo
        private void EllipseMidPoint(int xCenter, int yCenter, int rX, int rY)
        {
            Myglobals.Shape_mode = 'e';
            Myglobals.Rx = rX;
            Myglobals.Ry = rY;
            int dx, dy, p1, p2, x, y;
            x = 0;
            y = rY;
            p1 = (rY * rY) - (rX*rX*rY) + (int)(0.25*rX*rX);
            Myglobals.Table_array_p.Add(p1);


            dx = 2 * rY * rY * x;
            dy = 2 * rX * rX * y;
            EllipsePlotPoints(xCenter, yCenter, x, y);
            

            //region 1
            while (dx < dy)
            {
                x++;
                dx = dx + (2 * rY * rY);
                if (p1 < 0)
                {

                    p1 = p1 + dx + (rY * rY);
                }

                else
                {
                    y--;
                    dy = dy - (2 * rX * rX);
                    p1 = p1 + dx - dy + (rY * rY);
                }
                EllipsePlotPoints(xCenter, yCenter, x, y);
                Myglobals.Table_x.Add(x);
                Myglobals.Table_y.Add(y);
                Myglobals.Table_array_p.Add(p1);
            }
            //region 2
            p2 = Convert.ToInt32((rY * rY) * ((x + 1 / 2) * (x + 1 / 2)))
                + ((rX * rX) * ((y - 1) * (y - 1)))
                - (rX * rX * rY * rY);
            Myglobals.Table_array_p.Add(p2);


            while (y >= 0)
            {
                y--;
                dy = dy - (2 * rX * rX);
                if (p2 > 0)
                {

                    p2 = p2 + (rX * rX) - dy;
                }
                else
                {
                    x++;
                    dx = dx + (2 * rY * rY);
                    p2 = p2 + dx - dy + (rX * rX);
                }
                EllipsePlotPoints(xCenter, yCenter, x, y);
                Myglobals.Table_x.Add(x);
                Myglobals.Table_y.Add(y);
                Myglobals.Table_array_p.Add(p2);
            }

        }

        // Ellipse points
        public void EllipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            //g.FillRectangle(aBrush, 300 + (xCenter + x), 225 - (yCenter + y), 2, 2);
            Myglobals.Draw_array_x.Add(xCenter + x); Myglobals.Draw_array_y.Add(yCenter + y);

            //g.FillRectangle(aBrush, 300 + (xCenter - x), 225 - (yCenter + y), 2, 2);
            Myglobals.Draw_array_x.Add(xCenter - x); Myglobals.Draw_array_y.Add(yCenter + y);

            //g.FillRectangle(aBrush, 300 + (xCenter + x), 225 - (yCenter - y), 2, 2);
            Myglobals.Draw_array_x.Add(xCenter + x); Myglobals.Draw_array_y.Add(yCenter - y);

            //g.FillRectangle(aBrush, 300 + (xCenter - x), 225 - (yCenter - y), 2, 2);
            Myglobals.Draw_array_x.Add(xCenter - x); Myglobals.Draw_array_y.Add(yCenter - y);

        }


        public static void Timer_elapsed (Object sender, ElapsedEventArgs eventArgs)
        {
            
        }
        // // // // /// ////// / / / / // / /// / // / / // / / / / / / / / / / / / / / ///// /// / /

        //// Clear button
        private void button1_Click_1(object sender, EventArgs e)
        {
            Myglobals.Draw_array_x.Clear();
            Myglobals.Draw_array_y.Clear();
            Myglobals.No_indexes.Clear();
   
            label23.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {


        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
 static class Myglobals
{
    public static char Shape_mode = 'a';
    public static List<int> Table_x = new List<int>();
    public static List<int> Draw_array_x = new List<int>();
    public static List<int> Draw_array_y = new List<int>();

    public static List<double> DDA_x = new List<double>();
    public static List<double> DDA_y = new List<double>();

    public static int Rx = 0;
    public static int Ry = 0;

    public static List<int> Table_array_p = new List<int>();
    public static List<int> No_indexes = new List<int>();
    public static List<int> Table_y = new List<int>();
}
