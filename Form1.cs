using Example2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        DrawerState drawer;
      
        public Form1()
        {
            InitializeComponent();
            drawer = new DrawerState(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawer.prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawer.FixPath();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawer.Draw(e.Location);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Line;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Eraser;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Circle;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Rectangle;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawer.Shape = Shape.Pencil;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.pen.Color = colorDialog1.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Png file (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog () == DialogResult.OK)
            {
                drawer.Load(openFileDialog1.FileName);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawer.pen.Width = trackBar1.Value;
        }

        
    }
}
