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

namespace IlyaFrame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
                        try
            {
                if (!int.TryParse(DistanceBox.Text, out int x) || Convert.ToInt32(DistanceBox.Text) <= 0)
                {
                    MessageBox.Show("Введена некорректное расстояние!", "Ошибка");
                }
                if (!int.TryParse(TimeBox.Text, out int y) || Convert.ToInt32(TimeBox.Text) <= 0)
                {
                    MessageBox.Show("Введена некорректное время!", "Ошибка");
                }

                double selectedsystem = SelectSystem();

                if (selectedsystem == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите систему вычисления.");
                    return;
                }

                double result = Speed(x, y, selectedsystem);
                ResultBox.Text = result.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private double SelectSystem()
        {
            if (Meters.IsChecked == true) return 1;
            if (Kilometers.IsChecked == true) return  3.6;

            return 0;
        }

        private double Speed(int x, int y, double selectedsystem) {
            return (x/y) * selectedsystem;
        }
    }
}
