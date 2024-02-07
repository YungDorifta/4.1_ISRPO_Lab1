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
using System.Windows.Shapes;
using System.Timers;

namespace Лаб1_лифт_
{
    /// <summary>
    /// Логика взаимодействия для LiftWindow.xaml
    /// </summary>
    public partial class LiftWindow : Window
    {
        private Lift lift;

        /// <summary>
        /// Конструктор окна панели лифта
        /// </summary>
        /// <param name="i"></param>
        public LiftWindow(int i)
        {
            InitializeComponent();

            //создание лифта
            lift = new Lift(i);

            //создание кнопки
            Button b;

            for (int i1 = 1; i1 <= i; i1++)
            {
                b = new Button()
                {
                    Content = i1.ToString(),
                    Margin = new Thickness(1, 1, 1, 1)
                };
               
                //добавления действия по нажатию на кнопку
                b.Click += ChangeFloor;

                //добавление кнопки в тег WPF (свойсво x:Name тега в примере - Oneggg), который будет ее содержать
                Oneggg.Children.Add(b);
            }
        }

        //public delegate void RoutedEventHandler(object sender, RoutedEventArgs e); -  
        //это делегат. Его нужно использовать для создания функции
        //В примере это функция, которая будет выводить текст на кнопке в отдельное окно при нажатии на кнопку.
        /// <summary>
        /// Кнопка с этажом нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeFloor(object sender, RoutedEventArgs e)
        {
            lift.ChangeFloor(Convert.ToInt32((sender as Button).Content.ToString()));
        }
        
        /// <summary>
        /// Открыть двери
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open(object sender, RoutedEventArgs e)
        {
            lift.OpenDoors();
        }

        /// <summary>
        /// Закрыть двери
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            lift.CloseDoors();
        }

        /// <summary>
        /// Посмотреть статус лифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowStatusClick(object sender, RoutedEventArgs e)
        {
            Status.Content = lift.Status();
        }
    }
}
