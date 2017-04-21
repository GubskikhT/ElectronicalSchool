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

namespace ElectronicSchool
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private readonly AccountManager accountManager;

        public TeacherPage(AccountManager accountManager)
        {
            this.accountManager = accountManager;
            InitializeComponent();
        }

        private void LogutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage(accountManager));
        }
    }
}
