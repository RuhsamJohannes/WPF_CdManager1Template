using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cdmanager.Wpf
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
        public AddCdWindow()
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;
        }

        private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            btnSave.Click += new RoutedEventHandler(btnSave_Click);

            DataContext = new Cd() /*{ AlbumTitle = "<Bitte Titel Eingeben>"}*/;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().AddCd(DataContext as Cd);
            Close();
        }

    }
}
