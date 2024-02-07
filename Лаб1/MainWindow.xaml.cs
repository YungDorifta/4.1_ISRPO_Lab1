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
using Лаб1_консоль_;

namespace Лаб1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double insertedmoney = 0;
        private string type = "Espresso";
        private Beverage coffee;
        
        /// <summary>
        /// Конструктор главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Переключение типа кофе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (((RadioButton)sender).IsChecked == true) type = ((RadioButton)sender).Name;

            if (type != null)
            {
                
                BitmapImage CI = new BitmapImage();
                CI.BeginInit();
                CI.UriSource = new Uri(@"E:\\College\\4th_course\\images\\" + type + ".jpg");
                CI.EndInit();
                if (CoffeeImage != null) CoffeeImage.Source = CI;
                
            }
        }
        
        /// <summary>
        /// Вывести результаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitCoffee(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case "Espresso":
                    {
                        coffee = new Espresso();
                        break;
                    }
                case "HouseBlend":
                    {
                        coffee = new HouseBlend();
                        break;
                    }
                case "DarkRoast":
                    {
                        coffee = new DarkRoast();
                        break;

                    }
                case "Decaf":
                    {
                        coffee = new Decaf();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
            if (Milk.IsChecked == true)
            {
                coffee = new Milk(coffee);
            }
            if (Whip.IsChecked == true) coffee = new Whip(coffee);
            if (Soy.IsChecked == true) coffee = new Soy(coffee);
            if (Mocha.IsChecked == true) coffee = new Mocha(coffee);

            cost.Content = "Cost: " + coffee.cost();
            if (insertedmoney >= coffee.cost()) re_turn.Content = "Return: " + Math.Round(insertedmoney - coffee.cost(), 2); 
            else re_turn.Content = "Return: not enough money";
        }

        /// <summary>
        /// Проверка ввода в поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text != "" && e.Key == Key.OemComma) return;
            string nums = "0123456789";
            if (nums.Contains(e.Key.ToString()[e.Key.ToString().Length - 1]) || e.Key == Key.Back || e.Key == Key.Right || e.Key == Key.Left) return;
            else
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).Text.Length - 1);
            }
        }

        /// <summary>
        /// Внесение суммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            insertedmoney = Convert.ToDouble(MoneyBox.Text);
            money.Content = "Money: " + Convert.ToString(insertedmoney);
            if (coffee != null)
            {
                if (insertedmoney >= coffee.cost()) re_turn.Content = "Return: " + Math.Round(insertedmoney - coffee.cost(), 2);
                else re_turn.Content = "Return: not enough money";
            }

        }

        /// <summary>
        /// Добавление добавок в окно (картинки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Milk_Checked(object sender, RoutedEventArgs e)
        {
            switch (((CheckBox)sender).Name)
            {
                case "Milk":
                    {
                        if (((CheckBox)sender).IsChecked == true) MilkImage.Visibility = Visibility.Visible;
                        else MilkImage.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Soy":
                    {
                        if (((CheckBox)sender).IsChecked == true) SoyImage.Visibility = Visibility.Visible;
                        else SoyImage.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Mocha":
                    {
                        if (((CheckBox)sender).IsChecked == true) MochaImage.Visibility = Visibility.Visible;
                        else MochaImage.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Whip":
                    {
                        if (((CheckBox)sender).IsChecked == true) WhipImage.Visibility = Visibility.Visible;
                        else WhipImage.Visibility = Visibility.Hidden;
                        break;
                    }
                default:
                    break;
            } 

            
        }
    }
}
