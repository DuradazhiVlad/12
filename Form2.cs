using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12
{
    public partial class Form2 : Form
    {
        double a, b;

        public Form2()
        {
            InitializeComponent();
            
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b))
            {
                DrawHyperbola();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b))
            {
                DrawHyperbola();
            }
        }

        private void DrawHyperbola()
        {
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);

            Pen pen = new Pen(Color.Black);
            
            if (!double.TryParse(textBox1.Text, out a))
            {
                a = double.Parse(textBox1.Text); 
                

            }

            if (!double.TryParse(textBox2.Text, out b))
            {
                
                b = double.Parse(textBox2.Text); 

            }


            double x0 = pictureBox2.Width / 2; 
            double y0 = pictureBox2.Height / 2;

            for (int x = 0; x < pictureBox2.Width; x++)
            {
                double y = b * Math.Sqrt(1 + (x - x0) * (x - x0) / (a * a)) + y0;
                double y2 = -b * Math.Sqrt(1 + (x - x0) * (x - x0) / (a * a)) + y0;
                g.DrawEllipse(pen, (float)x, (float)y, 1, 1);
                g.DrawEllipse(pen, (float)x, (float)y2, 1, 1);
            }

            pictureBox2.Image = bmp;
        }

    }
}
