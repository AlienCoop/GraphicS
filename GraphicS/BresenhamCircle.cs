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
    public class BresCircle
    {
        
        public static void BreshamCircle(int _x, int _y, int _r)
        {

            int x = _x;
            int y = _y;
            int r = _r;

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
                    
                    int yd = r;
                    int xd = 0;
                    int d = 2 - 2 * r;
                    while (xd <= yd)
                    {
                        GL.Color3(Color.Red);
                        GL.Vertex2(x + xd, y + yd);
                        GL.Color3(Color.Blue);
                        GL.Vertex2(x - xd, y + yd); GL.Color3(Color.White);
                        GL.Vertex2(x + xd, y - yd); GL.Color3(Color.Green);
                        GL.Vertex2(x - xd, y - yd); GL.Color3(Color.Gray);
                        GL.Vertex2(x + yd, y + xd); GL.Color3(Color.Aqua);
                        GL.Vertex2(x - yd, y + xd); GL.Color3(Color.DarkOrchid);
                        GL.Vertex2(x + yd, y - xd); GL.Color3(Color.Red);
                        GL.Vertex2(x - yd, y - xd); GL.Color3(Color.Violet);


                        if (d < 0)
                            d += (2 * xd) + 3;
                        else
                        {
                            d += (2 * (xd - yd)) + 5;
                            yd -= 1;
                        }
                        xd++;
                    }

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
