using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphic
{
    public partial class _2dTransformation : Form
    {
        public _2dTransformation()
        {
            InitializeComponent();
        }

        private void _2dTransformation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Myglobals2.draw_default_x.Clear();
            Myglobals2.draw_default_y.Clear();
            Myglobals2.draw_any_x.Clear();
            Myglobals2.draw_any_y.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var aBruch = Brushes.Black;
            var bBruch = Brushes.Green;
            var g = panel1.CreateGraphics();
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            for (int i = 0; i <= panelHeight; i++)
            {
                g.FillRectangle(aBruch, (panelWidth / 2), i, 1, 1);
            }
            for (int i = 0; i <= panelWidth; i++)
            {
                g.FillRectangle(aBruch, i, (panelHeight / 2), 1, 1);


            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        
        
        /// draw the triangle
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            int x1 = Convert.ToInt32(textBox6.Text),
                y1 = Convert.ToInt32(textBox9.Text),
                x2 = Convert.ToInt32(textBox12.Text),
                y2 = Convert.ToInt32(textBox13.Text),
                x3 = Convert.ToInt32(textBox10.Text),
                y3 = Convert.ToInt32(textBox11.Text);

            drawLine(x1,y1,x2,y2,'d');
            drawLine(x2,y2,x3,y3,'d');
            drawLine(x3,y3,x1,y1,'d');

            drawInPanel('d');
            

        }

        private void putInList(double x, double y,char t)
        {
            if (t == 'd')
            {
                Myglobals2.draw_default_x.Add(x);
                Myglobals2.draw_default_y.Add(y);
            }
            else
            {
                Myglobals2.draw_any_x.Add((int)Math.Round(x));
                Myglobals2.draw_any_y.Add((int)Math.Round(y));

            }
        }

        /// global draw
        void drawInPanel(char t)
        {
            var aBruch = Brushes.Black;
            var bBruch = Brushes.Green;
            var g = panel1.CreateGraphics();
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;
            switch (t)
            {
                case 's':
                    for (int i = 0; i < Myglobals2.draw_any_x.Count; i++)
                    {
                        g.FillRectangle(bBruch, (float)(Myglobals2.draw_any_x[i] + (panelWidth / 2)), (panelHeight / 2) - (float)Myglobals2.draw_any_y[i], 2, 2);
                    }
                    break;

                case 't':
                    for (int i = 0; i < Myglobals2.draw_any_x.Count; i++)
                    {
                        g.FillRectangle(bBruch, (float)(Myglobals2.draw_any_x[i] + (panelWidth / 2)), (panelHeight / 2) - (float)Myglobals2.draw_any_y[i], 2, 2);
                    }
                    break;

                case 'r':
                    for (int i = 0; i < Myglobals2.draw_any_x.Count; i++)
                    {
                        g.FillRectangle(bBruch, (float)Myglobals2.draw_any_x[i] + (panelWidth / 2), (panelHeight / 2) - (float)Myglobals2.draw_any_y[i], 2, 2);
                    }
                    break;

                case 'h':
                    for (int i = 0; i < Myglobals2.draw_any_x.Count; i++)
                    {
                        g.FillRectangle(bBruch, (float)Myglobals2.draw_any_x[i] + (panelWidth / 2), (panelHeight / 2) - (float)Myglobals2.draw_any_y[i], 2, 2);
                    }
                    break;

                case 'f':
                    for (int i = 0; i < Myglobals2.draw_any_x.Count; i++)
                    {
                        g.FillRectangle(bBruch, (float)Myglobals2.draw_any_x[i] + (panelWidth / 2), (panelHeight / 2) - (float)Myglobals2.draw_any_y[i], 2, 2);
                    }
                    break;

                case 'd':
                    for (int i = 0; i < Myglobals2.draw_default_x.Count; i++)
                    {
                        g.FillRectangle(aBruch, (float)Myglobals2.draw_default_x[i] + (panelWidth / 2), (panelHeight / 2) - (float)Myglobals2.draw_default_y[i], 2, 2);
                    }
                    break;
            }
            //Myglobals2.draw_any_x.Clear();
            //Myglobals2.draw_any_y.Clear();
            //Myglobals2.draw_default_x.Clear();
            //Myglobals2.draw_default_y.Clear();
            
        }

        /// draw a line
        void drawLine(double x0, double y0, double xEnd, double yEnd , char t)
        {

            double dx = xEnd - x0, dy = yEnd - y0, steps, k;
            double xIncrement, yIncrement, x = x0, y = y0;

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
                    putInList(x ,y ,t);
                }
                catch (InvalidOperationException)

                {
                    return;
                }

            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        /// scale
        private void button4_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox6.Text),
                y1 = Convert.ToDouble(textBox9.Text),
                x2 = Convert.ToDouble(textBox12.Text),
                y2 = Convert.ToDouble(textBox13.Text),
                x3 = Convert.ToDouble(textBox10.Text),
                y3 = Convert.ToDouble(textBox11.Text);

            //Myglobals2.xScale = Convert.ToDouble(textBox8.Text);
            //   Myglobals2.yScale = Convert.ToDouble(textBox7.Text);
            double xScale = Convert.ToDouble(textBox8.Text);
            double yScale = Convert.ToDouble(textBox7.Text);

            x1 = x1 * xScale;
            x2 = x2 * xScale;
            x3 = x3 * xScale;
            y1 = y1 * yScale;
            y2 = y2 * yScale;
            y3 = y3 * yScale;


            drawLine(x1, y1, x2, y2, 's');
            drawLine(x2, y2, x3, y3, 's');
            drawLine(x3, y3, x1, y1, 's');



            drawInPanel('s');


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        /// translate
        private void button5_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox6.Text),
                y1 = Convert.ToInt32(textBox9.Text),
                x2 = Convert.ToInt32(textBox12.Text),
                y2 = Convert.ToInt32(textBox13.Text),
                x3 = Convert.ToInt32(textBox10.Text),
                y3 = Convert.ToInt32(textBox11.Text);

            int xTaranlate = Convert.ToInt32(textBox1.Text),
                yTranslate = Convert.ToInt32(textBox2.Text);

            x1 += xTaranlate;
            x2 += xTaranlate;
            x3 += xTaranlate;
            y1 += yTranslate;
            y2 += yTranslate;
            y3 += yTranslate;

            drawLine(x1, y1, x2, y2, 't');
            drawLine(x2, y2, x3, y3, 't');
            drawLine(x3, y3, x1, y1, 't');

            drawInPanel('t');
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // rotation
        private void button6_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToInt32(textBox6.Text),
                y1 = Convert.ToInt32(textBox9.Text),
                x2 = Convert.ToInt32(textBox12.Text),
                y2 = Convert.ToInt32(textBox13.Text),
                x3 = Convert.ToInt32(textBox10.Text),
                y3 = Convert.ToInt32(textBox11.Text);

            float beta = Convert.ToInt32(textBox5.Text);

            x1 = Convert.ToInt32((-Math.Sin(beta) * y1) + (Math.Cos(beta) * x1));
            y1 = Convert.ToInt32((Math.Sin(beta) * x1) + (Math.Cos(beta) * y1));
            x2 = Convert.ToInt32((-Math.Sin(beta) * y2) + (Math.Cos(beta) * x2));
            y2 = Convert.ToInt32((Math.Sin(beta) * x2) + (Math.Cos(beta) * y2));
            x3 = Convert.ToInt32((-Math.Sin(beta) * y3) + (Math.Cos(beta) * x3));
            y3 = Convert.ToInt32((Math.Sin(beta) * x3) + (Math.Cos(beta) * y3));

            drawLine(x1, y1, x2, y2, 'r');
            drawLine(x2, y2, x3, y3, 'r');
            drawLine(x3, y3, x1, y1, 'r');

            drawInPanel('r');
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //shering

        private void button7_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox6.Text),
                y1 = Convert.ToDouble(textBox9.Text),
                x2 = Convert.ToDouble(textBox12.Text),
                y2 = Convert.ToDouble(textBox13.Text),
                x3 = Convert.ToDouble(textBox10.Text),
                y3 = Convert.ToDouble(textBox11.Text);

            double xSh = Convert.ToDouble(textBox3.Text);
            double ySh = Convert.ToDouble(textBox4.Text);

            x1 += (double)(xSh * y1);
            x2 += (double)(xSh * y2);
            x3 += (double)(xSh * y3);
            y1 += (double)(ySh * x1);
            y2 += (double)(ySh * x2);
            y3 += (double)(ySh * x3);

            drawLine(x1, y1, x2, y2, 'h');
            drawLine(x2, y2, x3, y3, 'h');
            drawLine(x3, y3, x1, y1, 'h');

            drawInPanel('h');
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox6.Text),
                y1 = Convert.ToDouble(textBox9.Text),
                x2 = Convert.ToDouble(textBox12.Text),
                y2 = Convert.ToDouble(textBox13.Text),
                x3 = Convert.ToDouble(textBox10.Text),
                y3 = Convert.ToDouble(textBox11.Text);
            
            y1 *= -1;
            y2 *= -1;
            y3 *= -1;

            drawLine(x1, y1, x2, y2, 'f');
            drawLine(x2, y2, x3, y3, 'f');
            drawLine(x3, y3, x1, y1, 'f');

            drawInPanel('f');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox6.Text),
                y1 = Convert.ToDouble(textBox9.Text),
                x2 = Convert.ToDouble(textBox12.Text),
                y2 = Convert.ToDouble(textBox13.Text),
                x3 = Convert.ToDouble(textBox10.Text),
                y3 = Convert.ToDouble(textBox11.Text);

            x1 *= -1;
            x2 *= -1;
            x3 *= -1;
            

            drawLine(x1, y1, x2, y2, 'f');
            drawLine(x2, y2, x3, y3, 'f');
            drawLine(x3, y3, x1, y1, 'f');


            drawInPanel('f');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox6.Text),
                y1 = Convert.ToDouble(textBox9.Text),
                x2 = Convert.ToDouble(textBox12.Text),
                y2 = Convert.ToDouble(textBox13.Text),
                x3 = Convert.ToDouble(textBox10.Text),
                y3 = Convert.ToDouble(textBox11.Text);

            x1 *= -1;
            x2 *= -1;
            x3 *= -1;
            y1 *= -1;
            y2 *= -1;
            y3 *= -1;


            drawLine(x1, y1, x2, y2, 'f');
            drawLine(x2, y2, x3, y3, 'f');
            drawLine(x3, y3, x1, y1, 'f');


            drawInPanel('f');

        }
    }
}

 static class Myglobals2
{
    public static List<double> draw_default_x = new List<double>();
    public static List<double> draw_default_y = new List<double>();
    public static List<double> draw_any_x = new List<double>();
    public static List<double> draw_any_y = new List<double>();
    public static double xScale = 1;
    public static double yScale = 1;

}
