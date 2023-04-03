using System;
using System.Drawing;
//using System.Web.Helpers;
//using System.Web.Helpers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _12
{
    public partial class Form1 : Form
    {

        Graphics graphics;
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Purple };
         
            public Form1()
            {
                InitializeComponent();

                graphics = CreateGraphics();




            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

                string input = textBox1.Text;


                string[] values = input.Split(',');


                int[] percentages = new int[values.Length];


                for (int i = 0; i < values.Length; i++)
                {
                    int percent;
                    if (int.TryParse(values[i], out percent))
                    {
                        percentages[i] = percent;
                    }

                }


                DrawPieChart(percentages);
            }

            private void DrawPieChart(int[] percentages)
            {
                try
                {




                    graphics = pictureBox2.CreateGraphics();
                    graphics.Clear(Color.White);


                    int sum = 0;
                    foreach (int percent in percentages)
                    {
                        sum += percent;
                    }


                    List<float> angles = new List<float>();
                    foreach (int percent in percentages)
                    {
                        float angle = percent * 360f / sum;
                        angles.Add(angle);
                    }


                    float startAngle = 0;
                    for (int i = 0; i < percentages.Length; i++)
                    {
                        float sweepAngle = angles[i];
                        Color color = colors[i % colors.Length];
                        Brush brush = new SolidBrush(color);
                        graphics.FillPie(brush, 0, 0, pictureBox2.Width, pictureBox2.Height, startAngle, sweepAngle);
                        startAngle += sweepAngle;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }

            private Color GetRandomColor()
            {
                Random random = new Random();
                return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            }

            

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
    }


