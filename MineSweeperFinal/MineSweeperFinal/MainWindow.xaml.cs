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

namespace MineSweeperFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void set_button_Click(object sender, RoutedEventArgs e)
        {
            SetField obj = new SetField();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            Gameplay obj = new Gameplay();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }
    }
}
