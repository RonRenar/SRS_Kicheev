using AddToDB.Model;
using HashPasswords;
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


namespace WpfApp1Pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        private void GenerateCapcha()
        {
            txtboxCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;

            Random rnd = new Random();
            Char[] alf = new Char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            txtBlockCaptcha.Text = null;
            for (int i = 0; i < 8; i++)
                txtBlockCaptcha.Text += alf[rnd.Next(0,35)];
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;

           




        }
        private int countUnsuccessful = 0;
        public Auto() 
        {
            InitializeComponent();
            txtboxCaptcha.Visibility = Visibility.Hidden;
            txtBlockCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
           
            string login = txtLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
           

            if(login.Length>0 && password.Length>0 ) 
            {
                if (countUnsuccessful < 1)
                {

                    password = Hash.Hashing(password);


                    Users users = new Users();

                    users = Helper.GetContext().Users.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
                   
                    if(users != null) 
                    { 
                   
                        NavigationService.Navigate(new Admin());
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с таким логином или паролем нет","Ошибка", MessageBoxButton.OK);

                        countUnsuccessful++;
                        GenerateCapcha();


                    }
                
                    
                      
                 }
                else
                {
                    password = Hash.Hashing(password);


                    Users users = new Users();

                    users = Helper.GetContext().Users.Where(p => p.Login == login && p.Password == password).FirstOrDefault();

                    string captcha = txtboxCaptcha.Text.Trim();
                    if(users != null && captcha == txtBlockCaptcha.Text) 
                    
                    { 
                    Admin admin = new Admin();
                        NavigationService.Navigate(new Admin());
                        txtBlockCaptcha.Visibility = Visibility.Hidden;
                        txtboxCaptcha.Visibility = Visibility.Hidden;
                        txtBlockCaptcha.Text = "";
                        txtboxCaptcha.Text = "";
                        countUnsuccessful = 0;
                    
                    
                    
                    
                    
                    }


                }    




            
            }
            else
            {
                MessageBox.Show("Не все обязательные поля заполены! Заполните логин и пароль, и повторите попытку авторизации ", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
