using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StockItUp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StockItUp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private LoginViewModel _lvm;

        public Login()
        {
            this.InitializeComponent();
            _lvm = new LoginViewModel();
            this.DataContext = _lvm;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (_lvm.LoginMethod()) Frame.Navigate(typeof(Lager));
        }
    }
}
