﻿using System;
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
using TestsSystem.Models;

namespace TestsSystem.Pages
{
    /// <summary>
    /// Interaction logic for adminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void addUserBut_Click(object sender, RoutedEventArgs e)
        {
            // Переходим на окно добавления пользователя
            MainClass.FrameVar.Navigate(new AddUserPanel());
        }

        private void delUserBut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить эту запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                // Проверяем выбран ли какой-либо пользователь из списка
                if ((usersDG.SelectedItem as Users)!=null)
                {
                    MainClass.db.Users.Remove((usersDG.SelectedItem as Users));
                    MainClass.db.SaveChanges();
                    usersDG.ItemsSource = MainClass.db.Users.ToList(); // Обновляем таблицу
                }
            }
        }

        private void saveBut_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем изменения
            MainClass.db.SaveChanges();
            MessageBox.Show("Изменения успешно сохранены","Информация",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            usersDG.ItemsSource = MainClass.db.Users.ToList(); // Загружаем пользователей в таблицу
        }
    }
}
