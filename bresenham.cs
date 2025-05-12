using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Graphic
{
    public partial class Bresenham : Form
    {
        //public static int x0 = 493;
        //public static int y0 = 286;
        

        public Bresenham()
        {
            InitializeComponent();
        }

        // Back button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            Myglobals.No_indexes.Clear();
            Myglobals.Table_x.Clear();
            Myglobals.Table_y.Clear();
            Myglobals.Table_array_p.Clear();
            Myglobals.DDA_x.Clear();
            Myglobals.DDA_y.Clear();

        }

        private void Bresenham_Load(object sender, EventArgs e)
        {
            

        }

        // Drawing
        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            var aBruch = Brushes.Black;
            var bBruch = Brushes.Green;
            var g = panel1.CreateGraphics();
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;
            
            for (int i = 0; i <= panelHeight; i++) {
                g.FillRectangle(aBruch, (panelWidth/2) , i , 1, 1);
            }
            for (int i = 0; i <= panelWidth; i++)
            {
                g.FillRectangle(aBruch, i, (panelHeight/2), 1, 1 );

                
            }
            
            
            for (int i = 0 ; i < Myglobals.Draw_array_x.Count ; i++  )
            {
                g.FillRectangle(bBruch, Myglobals.Draw_array_x[i]+(panelWidth/2), (panelHeight/2)- Myglobals.Draw_array_y[i],2,2);
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Table button
        private void button2_Click(object sender, EventArgs e)
        {

            Table t1 = new Table();
            t1.Show();

        }
    }
}
