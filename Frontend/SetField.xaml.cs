using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MineSweeperFinal.Controller;

namespace MineSweeperFinal
{
    /// <summary>
    /// Interaction logic for SetField.xaml
    /// </summary>
    public partial class SetField : Window
    {
        Middleware controller = new Middleware();
        int count;

        public SetField()
        {
            InitializeComponent();
            count = 0;
        }



        private void xml_button_Click(object sender, RoutedEventArgs e)
        {
            List<Tuple<int, int>> value = new List<Tuple<int, int>>();

            string gridValue = "M";
            if (box_0_0.Text==gridValue)
            {
                var T = Tuple.Create(0, 0);
                value.Add(T);
                count++;
            }
            if (box_0_1.Text == gridValue)
            {
                var T = Tuple.Create(0, 1);
                value.Add(T);
                count++;

            }
            if (box_0_2.Text == gridValue)
            {
                var T = Tuple.Create(0, 2);
                value.Add(T);
                count++;


            }
            if (box_1_0.Text == gridValue)
            {
                var T = Tuple.Create(1, 0);
                value.Add(T);
                count++;

            }
            if (box_1_1.Text == gridValue)
            {
                var T = Tuple.Create(1, 1);
                value.Add(T);
                count++;

            }
            if (box_1_2.Text == gridValue)
            {
                var T = Tuple.Create(1, 2);
                value.Add(T);
                count++;

            }
            if (box_2_0.Text == gridValue)
            {
                var T = Tuple.Create(2, 0);
                value.Add(T);
                count++;

            }
            if (box_2_1.Text == gridValue)
            {
                var T = Tuple.Create(2, 1);
                value.Add(T);
                count++;

            }
            if (box_2_2.Text == gridValue)
            {
                var T = Tuple.Create(2, 2);
                value.Add(T);
                count++;
            }

            if (count<1)
            {
                MessageBox.Show("Please put at least one mine");
                return;
            }
            controller.saveMinefieldData(value);
        }
        

        private void auto_button_Click(object sender, RoutedEventArgs e)
        {
            box_1_0.Text = "M";
            box_1_2.Text = "M";
            box_2_1.Text = "M";
            box_0_0.IsEnabled = false;
            box_0_1.IsEnabled = false;
            box_0_2.IsEnabled = false;
            box_1_0.IsEnabled = false;
            box_1_1.IsEnabled = false;
            box_1_2.IsEnabled = false;
            box_2_0.IsEnabled = false;
            box_2_1.IsEnabled = false;
            box_2_2.IsEnabled = false;

            var T1 = Tuple.Create(1, 0);
            var T2 = Tuple.Create(1, 2);
            var T3 = Tuple.Create(2, 1);
            List<Tuple<int, int>> value = new List<Tuple<int, int>>();
            value.Add(T1);
            value.Add(T2);
            value.Add(T3);
            controller.saveMinefieldData(value);

        }


        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }
    }
}
