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
    /// Interaction logic for FramePanel.xaml
    /// </summary>
    public partial class FramePanel : UserControl
    {
        public FramePanel()
        {
            InitializeComponent();

            First.Content = ".";
            Second.Content = ".";
            Third.Content = ".";
            Total.Content = ".";
        }

        private Frame frame;

        public Frame Frame
        {
            get { return frame; }
            set
            {
                this.frame = value;
                First.Content = value.FirstRound;
                Second.Content = value.SecondRound;
                Third.Content = value.ThirdRound;
                Total.Content = value.Total;
            }
        }
    }
}
