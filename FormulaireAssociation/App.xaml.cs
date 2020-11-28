using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FormulaireAssociation
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>

    public partial class App : Application
    {
        private SplashScreen splashScreen;

        public App()
        {
            this.MainWindow = new MainWindow();

            this.splashScreen = new SplashScreen();
            this.splashScreen.Show();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Shortest loading
            await this.ShortLoading();

            this.splashScreen.Close();
            this.MainWindow.Show();
            this.splashScreen = null;
        }

        /// Gestion de la progression de la barre de chargement
        private async Task ShortLoading()
        {
            for (int i = 0; i < 100; i++)
            {
                this.splashScreen.SetProgress(i);
                await Task.Delay(10);
            }
            await Task.Delay(2000);
            
        }

    }

}
