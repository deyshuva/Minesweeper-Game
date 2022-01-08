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
using MineSweeperFinal.GameLogic;
using MineSweeperFinal.Backend;
using System.IO;

namespace MineSweeperFinal
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : Window
    {
        Middleware controller = new Middleware();
        int[,] grid = new int[3, 3];
        int count, totalMine;
        long currentTime;

        
        public Gameplay()
        {
            InitializeComponent();
            disableAllBoxes();
            
            
        }
        private void disableAllBoxes()
        {
            box_0_0.IsEnabled = false;
            box_0_1.IsEnabled = false;
            box_0_2.IsEnabled = false;
            box_1_0.IsEnabled = false;
            box_1_1.IsEnabled = false;
            box_1_2.IsEnabled = false;
            box_2_0.IsEnabled = false;
            box_2_1.IsEnabled = false;
            box_2_2.IsEnabled = false;
        }
        private void enableAllBoxes()
        {
            box_0_0.IsEnabled = true;
            box_0_1.IsEnabled = true;
            box_0_2.IsEnabled = true;
            box_1_0.IsEnabled = true;
            box_1_1.IsEnabled = true;
            box_1_2.IsEnabled = true;
            box_2_0.IsEnabled = true;
            box_2_1.IsEnabled = true;
            box_2_2.IsEnabled = true;
        }

        private void intial()
        {
            for (int i=0;i<3;i++)
                for(int j=0; j<3; j++)
                {
                    grid[i, j] = 0;
                }
        }

        private void clearBoxes()
        {
            box_0_0.Text = "";
            box_0_1.Text = "";
            box_0_2.Text = "";
            box_1_0.Text = "";
            box_1_1.Text = "";
            box_1_2.Text = "";
            box_2_0.Text = "";
            box_2_1.Text = "";
            box_2_2.Text = "";
        }
   
        private void xml_button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../../Minefield.xml") == false)
            {
                MessageBox.Show("You did not set mines");
                return;
            }
                clearBoxes();
                disableAllBoxes();
                intial();
                List<Tuple<int, int>> values = controller.getMineFieldData();
                foreach (Tuple<int, int> value in values)
                {
                    grid[value.Item1, value.Item2] = -1;
                }

                fillMineInBox();
            
           
            

        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists("../../../Minefield.xml") ==false)
            {
                MessageBox.Show("You did not set mines");
                return;
            }
            clearBoxes();
            enableAllBoxes();
            count = 0;
            intial();
            List<Tuple<int, int>> values = controller.getMineFieldData();
            totalMine = values.Count;
            Logic logic = new Logic();
            logic.calculateNumber(values,grid);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    // grid[i, j] = 0;
                    Console.WriteLine(grid[i, j] + " ");

                }

            currentTime = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            controller.startGame();


        }

        private void fillMineInBox()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] != -1)
                    {
                        continue;
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            box_0_0.Text = "M";
                        }
                        else if (i == 0 && j == 1)
                        {
                            box_0_1.Text = "M";
                        }
                        else if (i == 0 && j == 2)
                        {
                            box_0_2.Text = "M";
                        }
                        else if (i == 1 && j == 0)
                        {
                            box_1_0.Text = "M";
                        }
                        else if (i == 1 && j == 1)
                        {
                            box_1_1.Text = "M";
                        }
                        else if (i == 1 && j == 2)
                        {
                            box_1_2.Text = "M";
                        }
                        else if (i == 2 && j == 0)
                        {
                            box_2_0.Text = "M";
                        }
                        else if (i == 2 && j == 1)
                        {
                            box_2_1.Text = "M";
                        }
                        else if (i == 2 && j == 2)
                        {
                            box_2_2.Text = "M";
                        }


                    }
                }
            }
        }

        private void box_0_0_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 0, 0);
            if (grid[0,0]==-1)
            {
                box_0_0.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();
            }else
            {
                box_0_0.Text = grid[0, 0].ToString();
                box_0_0.IsEnabled = false;
                count++;
                if(count==(9-totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();
                }

            }
        }

        private void box_0_1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 0, 1);
            if (grid[0, 1] == -1)
            {
                box_0_1.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();

            }
            else
            {
                box_0_1.Text = grid[0, 1].ToString();
                box_0_1.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();

                }
            }
        }

        private void box_0_2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 0, 2);
            if (grid[0, 2] == -1)
            {
                box_0_2.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();

            }
            else
            {
                box_0_2.Text = grid[0, 2].ToString();
                box_0_2.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();

                }
            }
        }

        private void box_1_0_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 1, 0);
            if (grid[1, 0] == -1)
            {
                box_1_0.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();
            }
            else
            {
                box_1_0.Text = grid[1, 0].ToString();
                box_1_0.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();

                }
            }
        }

        private void box_1_1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 1, 1);
            if (grid[1, 1] == -1)
            {
                box_1_1.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close(); 

            }
            else
            {
                box_1_1.Text = grid[1, 1].ToString();
                box_1_1.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();
                }
            }
        }

        private void box_1_2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 1, 2);
            if (grid[1, 2] == -1)
            {
                box_1_2.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();

            }
            else
            {
                box_1_2.Text = grid[1, 2].ToString();
                box_1_2.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();
                }
            }
        }

        private void box_2_0_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 2, 0);
            if (grid[2, 0] == -1)
            {
                box_2_0.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();

            }
            else
            {
                box_2_0.Text = grid[2, 0].ToString();
                box_2_0.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();
                }
            }
        }

        private void box_2_1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 2, 1);
            if (grid[2, 1] == -1)
            {
                box_2_1.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();
            }
            else
            {
                box_2_1.Text = grid[2, 1].ToString();
                box_2_1.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();
                }
            }
        }

       
        private void box_2_2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            controller.addStep(currentTime, "user", "X", 2, 2);
            if (grid[2, 2] == -1)
            {
                box_2_2.Text = "M";
                disableAllBoxes();
                MessageBox.Show("You lost the game!!");
                controller.close();
            }
            else
            {
                box_2_2.Text = grid[2, 2].ToString();
                box_2_2.IsEnabled = false;
                count++;
                if (count == (9 - totalMine))
                {
                    MessageBox.Show("Congrats!!You won!!");
                    disableAllBoxes();
                    fillMineInBox();
                    controller.close();

                }
            }
        }     
    }
}
