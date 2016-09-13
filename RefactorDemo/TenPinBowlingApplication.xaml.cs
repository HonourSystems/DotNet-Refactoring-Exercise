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

namespace RefactorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var map = new Dictionary<string, PlayerPanel>();

            Player1Frames.Player = new Player { Name = "Player1" };
            map[Player1Frames.Player.Name] = Player1Frames;

            Player2Frames.Player = new Player { Name = "Player2" };
            map[Player2Frames.Player.Name] = Player2Frames;

            ScoringButtons.pnlScoringDisplays = map;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

        private void ChangePlayer_Click(object sender, RoutedEventArgs e)
        {
            ScoringButtons.togglecurrentplayer();
        }
    }
}
