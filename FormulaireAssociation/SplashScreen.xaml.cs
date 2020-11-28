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
using System.Windows.Shapes;

namespace FormulaireAssociation
{
    /// <summary>
    /// LOGIQUE D'INTERSACTION DE "SplashScreen.xaml " :
    ///
    /// On affiche simplement la fenêtre principale qui
    /// sera placée en arrière-plan par rapport au splashscreen.
    /// Puis on lance un autre chargement de données comme précédemment, 
    /// afin que le splashscreen reste devant l’application un petit moment.
    /// Enfin, on ferme le splashscreen et on le « libère » en réinitialisant la variable qui le référence.
    /// </summary>
    /// <returns></returns>



    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();

            Application.Current.Activated += OnAppActivated;
            Application.Current.Deactivated += OnAppDeactivated;
            Application.Current.MainWindow.Activated += OnMainWindowActivated;
        }

        /// Lorsque l’application sera activée, on placera notre splashscreen au premier plan.
        /// Dans le cas inverse, on la replacera en arrière-plan.
        private void OnAppActivated(object sender, EventArgs e)
        {
            this.Topmost = true;
        }

        private void OnAppDeactivated(object sender, EventArgs e)
        {
            this.Topmost = false;
        }

        ///Lors de l’activation de la fenêtre principale,
        ///il faut que notre splashscreen reste au premier plan
        private void OnMainWindowActivated(object sender, EventArgs e)
        {
            this.Topmost = true;
        }

        /// Maintenant, il faut passer le splashscreen au premier plan s’il est activé
        /// et le repasser en arrière-plan s’il est désactivé.
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.Topmost = true;
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            this.Topmost = false;
        }

        ///Dernière étape, pour éviter les fuites mémoires et permettre au GC
        ///de libérer l’espace utilisé par le splashscreen,
        ///il va falloir le désabonner des 3 évènements auxquels on l’a abonné lors de sa création.
        ///Pour cela, nous allons le faire en surchargeant la méthode OnClosed
        protected override void OnClosed(EventArgs e)
        {
            Application.Current.Activated -= OnAppActivated;
            Application.Current.Deactivated -= OnAppDeactivated;
            Application.Current.MainWindow.Activated -= OnMainWindowActivated;

            base.OnClosed(e);
        }

        ///Une méthode SetProgress qui va modifier la valeur de la barre de
        public void SetProgress(double value)
        {
            this.progress.IsIndeterminate = false;
            this.progress.Value = value;
        }
    }
}
