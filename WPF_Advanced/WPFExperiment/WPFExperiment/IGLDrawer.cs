using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFExperiment
{
    public interface IGLDrawer
    {
        void Initialize(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args);

        void Draw(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args);
        void OnWindowResized(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args);
    }
}
