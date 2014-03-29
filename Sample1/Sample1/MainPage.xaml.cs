using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Sample1.Resources;
using Microsoft.WindowsAzure.MobileServices;

namespace Sample1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private MobileServiceUser user;
        private async System.Threading.Tasks.Task Autenticar(MobileServiceAuthenticationProvider provider)
        {
            while (user == null)
            {
                string mensagem = string.Empty;
                try
                {
                    user = await App.MobileService.LoginAsync(provider);
                    mensagem = string.Format("Usuário logado em: {0}", user.UserId);
                }
                catch(InvalidOperationException ex)
                {
                    mensagem = "Usuário não Logado.";
                }
                MessageBox.Show(mensagem);
            }
        }

        

        private async  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Autenticar(MobileServiceAuthenticationProvider.Facebook);            
        }

        private async  void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await Autenticar(MobileServiceAuthenticationProvider.Twitter);
        }

        
        
    }
}