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

namespace proj_Gestion_Hospital
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = loginBox.Text;

            switch (username)
            {
                case "admin":
                    if (passwordBox.Password.ToString() == "admin")
                    {
                        AdminWindow adminWin = new AdminWindow();
                        adminWin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("I'm sorry, I don't recognise this password.");
                    } 
                    break;
                case "orderly":
                    if (passwordBox.Password.ToString() == "orderly")
                    {
                        OrderlyWindow orderlyWin = new OrderlyWindow();
                        orderlyWin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("I'm sorry, I don't recognise this password.");
                    }
                    break;
                case "doctor":
                    if (passwordBox.Password.ToString() == "doctor")
                    {
                        DoctorWindow docWin = new DoctorWindow();
                        docWin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("I'm sorry, I don't recognise this password.");
                    }
                    break;
                default: MessageBox.Show("I'm sorry, I don't recognise this username.");
                    break;

            }
        }


    }
}
