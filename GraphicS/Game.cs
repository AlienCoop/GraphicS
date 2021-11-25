using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicS
{
    public class Game
    {
        public GameWindow window;

        public Game(GameWindow windowInput)
        {
            this.window = windowInput;

            window.Load += window_Load;
            window.RenderFrame += Window_RenderFrame;
            window.UpdateFrame += Window_UpdateFrame;
            window.Closing += Window_Closing;
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            //  GL.ClearColor(Color.FromArgb(5, 5, 25));
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Flush();
            window.SwapBuffers();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {

        }

        void window_Load(object sender, EventArgs e)
        {

        }

    }
}
