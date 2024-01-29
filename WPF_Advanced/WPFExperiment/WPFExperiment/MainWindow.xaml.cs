using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using WPFExperiment.GLDrawers;

namespace WPFExperiment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGLDrawer drawer;
        public MainWindow()
        {
            InitializeComponent();
            drawer = new PyramidSquareTutorial();
        }

        private void openGLControl_OpenGLDraw(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args)
        {
            var drawer = new PyramidSquareTutorial();
            drawer.Draw(sender, args);
        }

        private void openGLControl_OpenGLInitialized(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args)
        {
            drawer.Initialize(sender, args);
        }

        private void openGLControl_Resized(object sender, SharpGL.WPF.OpenGLRoutedEventArgs args)
        {
            drawer.OnWindowResized(sender, args);
        }
    }
}
