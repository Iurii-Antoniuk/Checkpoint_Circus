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
using Nancy;
using Nancy.Hosting.Self;

namespace Checkpoint_WCircus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var host = new NancyHost(new Uri("http://localhost:1234"));
            //host.Start();
            string imageLink = "https://pmcvariety.files.wordpress.com/2015/05/kung-fury-cannes.jpg";
            var imageSource = new Uri(imageLink, UriKind.Absolute);
            titleImage.Source = new BitmapImage(imageSource);
        }

        private void contactButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void animalsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tamersButton_Click(object sender, RoutedEventArgs e)
        {
            var tamersControl = new TamersControl();
            coreGrid.Children.Clear();
            coreGrid.Children.Add(tamersControl);
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            Image homeScreen = (Image)mainWindow.FindName("titleImage");
            coreGrid.Children.Clear();
            coreGrid.Children.Add(homeScreen);
        }
    }
}
