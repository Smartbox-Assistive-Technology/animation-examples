using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
namespace AnimationExamples.Video
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : Page
    {
        public VideoPlayer()
        {
            InitializeComponent();

            player.MediaFailed += Player_MediaFailed;
        }

        private void Player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OnPlay(object sender, RoutedEventArgs e)
        {
            if (player.Source == null)
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Video", "big_buck_bunny.mp4");
                player.Source = new Uri(path, UriKind.Absolute);
            }

            player.Play();
        }

        private void OnStop(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
    }
}
