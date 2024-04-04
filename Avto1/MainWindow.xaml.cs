using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Avto1
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbLogin.Text.Trim(); // Объявляем переменную, в которую будет записываться значения с TextBlock`а логина
            string password = txtPassword.Text.Trim(); // Объявляем переменную, в которую будет записываться значения с TextBlock`а пароля

            Avtorizaciya user = new Avtorizaciya(); // создаем пустой обьект авторизации пользователя

            user = Helper.GetContext().Avtorizaciyas.Where(p => p.Login == login && p.Parol == password).FirstOrDefault(); // Условие на нахождение пользователя с введенными логином и паролем
            int userCount = Helper.GetContext().Avtorizaciyas.Where(p => p.Login == login && p.Parol == password).Count(); // Находим количество пользователей
            
            if (userCount > 0)  // если количество пользователей с введеными данными более 0, 
            {
                
                MessageBox.Show("Вы вошли под: " + user);// Появляется окно информации
                LoadForm(user.IdpolzovateliNavigation.IdroliNavigation.Nazvanieroli.ToString());                           // И передается роль в метод загрузки страниц по ролям
            }
            else
            {
                MessageBox.Show("Вы ввели неверно логин или пароль!");

            }

        }
        private void LoadForm(string _rele)
        {
            switch (_rele)
            {
                case "Администратор":
                    Polzovatel plv = new Polzovatel();
                    plv.Show();  //Если роль пользователя "Администратор", переходим на страницу пользователи
                    break;
                case "Ученик":
                    Raspisanie rsp = new Raspisanie();
                    rsp.Show();  //Если роль пользователя "Ученик", переходим на страницу расписания
                    break;
            }
        }
    }
}
