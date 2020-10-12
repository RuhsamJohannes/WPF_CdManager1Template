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
        public Cd SelectedCd { get; }
        public AddCdWindow()
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;
        }

        public AddCdWindow(Cd selectedCd)
        {
            InitializeComponent();
            SelectedCd = selectedCd;
            Loaded += EditCdWindow_Loaded;
        }

        private void EditCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            btnSave.Click += new RoutedEventHandler(btnSave_Click);

            lblTitle.Text = "Cd Bearbeiten";
            DataContext = new Cd() { AlbumTitle = SelectedCd.AlbumTitle, Artist = SelectedCd.Artist };
        }

        private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            btnSave.Click += new RoutedEventHandler(btnSave_Click);
            DataContext = new Cd();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCd != null)
            {
                Repository.GetInstance().RemoveCd(SelectedCd);
            }

            Repository.GetInstance().AddCd(DataContext as Cd);
            Close();
        }

    }
}
