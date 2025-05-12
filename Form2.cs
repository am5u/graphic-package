using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class Table : Form
    {
        public List<Circletable> Circle { get; set; }
        public List<Bresenhamtable> Bres { get; set; }
        public Table()
        {
            InitializeComponent();
            
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //=============== Load data ===============
        public void Table_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (Myglobals.Shape_mode)
            {
                // circle
                case 'c':         
                    dt.Columns.Add("K",typeof(int));
                    dt.Columns.Add("P",typeof(int));
                    dt.Columns.Add("X",typeof(int));
                    dt.Columns.Add("Y",typeof(int));
                    dt.Columns.Add("X*2",typeof(int));
                    dt.Columns.Add("Y*2",typeof(int));

                    // Rows : k p x y x*2 y*2
                    for(int i = 0;i<Myglobals.Table_x.Count;i++)
                        dt.Rows.Add(i , Myglobals.Table_array_p[i] , Myglobals.Table_x[i], Myglobals.Table_y[i], Myglobals.Table_x[i]*2 , Myglobals.Table_y[i]*2);
                    break;

                // bresenham
                case 'b':
                    dt.Columns.Add("K", typeof(int));
                    dt.Columns.Add("P", typeof(int));
                    dt.Columns.Add("X", typeof(int));
                    dt.Columns.Add("Y", typeof(int));

                    // Rows : k p x y
                    for (int i = 0; i < Myglobals.Table_x.Count; i++)
                        dt.Rows.Add(i+1, Myglobals.Table_array_p[i], Myglobals.Table_x[i], Myglobals.Table_y[i]);
                    break;

                // DDA
                case 'd':
                    dt.Columns.Add("P", typeof(int));
                    dt.Columns.Add("X", typeof(float));
                    dt.Columns.Add("Y", typeof(float));
                    dt.Columns.Add("( x , y )", typeof(string));

                    // Rows: p x y (x,y)
                    for (int i = 0; i < Myglobals.DDA_x.Count; i++)
                        dt.Rows.Add(i+1, Myglobals.DDA_x[i], Myglobals.DDA_y[i],"( " + Myglobals.Table_x[i].ToString() + " , " + Myglobals.Table_y[i].ToString() + " )");
                    break;

                // ellipse
                case 'e':
                    dt.Columns.Add("K", typeof(int));
                    dt.Columns.Add("P", typeof(int));
                    dt.Columns.Add("( x , y )", typeof(string));
                    dt.Columns.Add("2(Ry * Ry)*X", typeof(int));
                    dt.Columns.Add("2(Rx * Rx)*Y", typeof(int));
                    // Rows: k p (x,y) 2Rx 2Ry
                    for (int i = 0; i < Myglobals.Table_x.Count; i++)
                        dt.Rows.Add(i + 1, Myglobals.Table_array_p[i], "( " + Myglobals.Table_x[i].ToString() + " , " + Myglobals.Table_y[i].ToString() + " )" ,2*(Myglobals.Ry*Myglobals.Ry)* Myglobals.Table_x[i], 2 * (Myglobals.Rx * Myglobals.Rx) * Myglobals.Table_y[i]);

                    break;

                default:
                    dt.Columns.Add("K", typeof(int));
                    dt.Columns.Add("P", typeof(int));
                    break;


            }
            dataGridView1.DataSource = dt;
            

           
            
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
