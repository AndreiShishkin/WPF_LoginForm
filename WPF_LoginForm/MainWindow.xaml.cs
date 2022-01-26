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
using WPF_LoginForm.DataAccess;

namespace WPF_LoginForm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.loginText.GotFocus += LoginText_GotFocus;
            this.loginText.LostFocus += new RoutedEventHandler (LoginText_LostFocus);
            this.pwdText.GotFocus += PwdText_GotFocus;
            this.pwdText.LostFocus += PwdText_LostFocus;
        }

        private void PwdText_LostFocus(object sender, RoutedEventArgs e)
        {
            if(pwdText.Password == "")
            pwdText.Password = "Password";
            this.bottomPwd.Background = Brushes.White;
        }

        private void PwdText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(pwdText.Password == "Password")
            pwdText.Password = "";
            this.pwdText.CaretBrush = Brushes.White;
            this.bottomPwd.Background = Brushes.DeepSkyBlue;
        }

        private void LoginText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (loginText.Text == "")
                loginText.Text = "User name";
            this.bottomLogin.Background = Brushes.White;
        }

        private void LoginText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(loginText.Text == "User name")
                loginText.Text = "";
            this.loginText.CaretBrush = Brushes.White;
            this.bottomLogin.Background = Brushes.DeepSkyBlue;
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void EnterArea(object sender, MouseEventArgs e)
        {
            this.exitBtn.Foreground = Brushes.DeepSkyBlue;
        }

        private void LeaveArea(object sender, MouseEventArgs e)
        {
            this.exitBtn.Foreground = Brushes.White;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            DataService ds = new DataService();
            int count = ds.GetAccount(this.loginText.Text, this.pwdText.Password);
            if (count == 1) 
            {

            }
            else
            {
                this.bottomLogin.Background = Brushes.Red;
                this.bottomPwd.Background = Brushes.Red;
            }
        }
    }
}
