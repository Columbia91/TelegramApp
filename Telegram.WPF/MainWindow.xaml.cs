using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Telegram.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();
        
        public MainWindow()
        {
            InitializeComponent();
            
            users.AddRange(new User[]
            {
                new User
                {
                    Name = "Arman",
                    LastName = "Armanov",
                    FavouriteColor = "Aqua"
                },
                new User
                {
                    Name = "Marat",
                    LastName = "Ospanov",
                    FavouriteColor = "Coral"
                },
                new User
                {
                    Name = "Artur",
                    LastName = "Tolepov",
                    FavouriteColor = "Cyan"
                },
                new User
                {
                    Name = "Victor",
                    LastName = "Goncharenko",
                    FavouriteColor = "LightGreen"
                },
                new User
                {
                    Name = "Alan",
                    LastName = "Dzagoev",
                    FavouriteColor = "Orange"
                },
                new User
                {
                    Name = "Ruslan",
                    LastName = "Musin",
                    FavouriteColor = "Violet"
                }
            });

            List<string> styles = new List<string> { "Light", "Dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "Dark";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = users;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
