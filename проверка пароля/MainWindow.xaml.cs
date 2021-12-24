using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace проверка_пароля
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

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //Проверки условий
            bool A, B, C, D;

            if (txtPassword.Text.Length < 6) { MessageBox.Show("Минимум 6 символов"); A = false; }
            else A = true;

            if (Regex.IsMatch(txtPassword.Text, @"[A-Z]") || Regex.IsMatch(txtPassword.Text, @"[А-Я]")) B = true;
            else { MessageBox.Show("Минимум 1 прописная буква"); B = false; }

            if (Regex.IsMatch(txtPassword.Text, @"[0-9]")) C = true;
            else { MessageBox.Show("Минимум 1 цифра"); C = false; }

            if (Regex.IsMatch(txtPassword.Text, @"[!@#$%^]")) D = true;
            else { MessageBox.Show("Минимум 1 один символ из набора:  ! @ # $ % ^"); D = false; }


            //Работа с файлом
            try
            {
                if (A == true && B == true && C == true && D == true)
                {
                    FileStream file = new FileStream("Resource1.txt", FileMode.Open);
                    StreamWriter wr = new StreamWriter(file);
                    wr.Write(txtPassword.Text);
                    wr.Close();
                    MessageBox.Show("Пароль сохранён");
                }
            }
            catch { MessageBox.Show("Файл не найден!"); }
        }
    }
}
