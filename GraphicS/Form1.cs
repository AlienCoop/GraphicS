using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

namespace GraphicS
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        { 
        }
        public void BresenhamLine(float x, float y, float x2, float y2, float color)
        {
            float w = x2 - x;
            float h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(Convert.ToInt32(w));
            int shortest = Math.Abs(Convert.ToInt32(h));
            if (!(longest > shortest))
            {
                longest = Math.Abs(Convert.ToInt32(h));
                shortest = Math.Abs(Convert.ToInt32(w));
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                points(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
        public void points(float x, float y, float color)
        {
            OpenGL gl = this.openGLControl1.OpenGL;

             gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

           // gl.LoadIdentity();

            gl.Translate(0.0f, 0.0f, -5.0f);
            
            
            gl.Begin(OpenGL.GL_POINTS);
            gl.Color(color, color, color);
            gl.Vertex(x, y);
            gl.End();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;

            BresenhamLine(1f,1f,1.2f,1.2f,1f);

        }
    }
}
