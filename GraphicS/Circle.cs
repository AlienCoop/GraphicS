using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicS
{
    public class Circle
    {
       
        public static void CreateCircle(int _x, int _y, int _z)
        {

           int x =  _x;
           int y =  _y;
           int r =  _z;
 
            using (var game = new GameWindow())
            {


                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0.0f, 1000, 1000, 0.0f, 0.0f, 1.0f);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex2(x, y);
                    for (int j = 0; j < 360; j++)
                    {
                        GL.Vertex2(x + Math.Cos(j) * r, y + Math.Sin(j) * r);
                    }

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
