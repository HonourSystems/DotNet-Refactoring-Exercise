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
    /// Interaction logic for PlayerPanel.xaml
    /// </summary>
    public partial class PlayerPanel : UserControl
    {
        private List<FramePanel> framePanels = new List<FramePanel>();

        public PlayerPanel()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                FramePanel panel = new FramePanel();
                framePanels.Add(panel);
                Layout.Children.Add(panel);
            }

        }

        public PlayerPanel(string playerName)
            : this()
        {
            Player = new Player { Name = playerName };
        }

        private Player player;
        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                this.player = value;
                PlayerNameLabel.Content = value.Name;
            }
        }

        public void addFrame(Frame newOrUpdatedFrame)
        {
            if (newOrUpdatedFrame == null)
            {
                return;
            }

            bool found = false;
            foreach (FramePanel panel in framePanels)
            {
                if (panel.Frame != null && panel.Frame.Round == newOrUpdatedFrame.Round)
                {
                    found = true;
                    panel.Frame = newOrUpdatedFrame;
                    break;
                }
            }
            if (!found)
            {
                foreach (FramePanel panel in framePanels)
                {
                    if (panel.Frame == null)
                    {
                        panel.Frame = newOrUpdatedFrame;
                        break;
                    }
                }
            }

        }
    }
}
