using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicS
{
    public class DDA
    {
        static int y1, y2;
        static int x1, x2;
        public static void dda(int _x1, int _y1, int _x2, int _y2)
        {
            y1 = _y1;
            x1 = _x1;
            y2 = _y2;
            x2 = _x2;
            

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

                    float y = y1;
                    float m = (y2 - y1) / (x2 - x1);
                    GL.Begin(PrimitiveType.Points);
                    for (int x = x1; x <= x2; x++, y += m)
                    {
                        m = (y2 - y1) / (x2 - x1);
                        GL.Color3(Color.White);
                        GL.Vertex2(x, Math.Round(y));
                    }

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
