using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Path = System.IO.Path;

namespace FormulaireAssociation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Mathieu8v8_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" '' (...) Vous l'avez recu gratuitement, donnez-le gratuitement. '' ", "Matthieu 8v8");
        }

        private void Dossiers_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                //FileContent.Text = File.ReadAllText(openFileDialog.FileName);

            TableController.SelectedIndex = 3;
            
        }

        private void Parametres_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aucun paramètre pour l'instant", "Paramètres");
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            // On change ca pour l'impression
            Effacer.Visibility = Visibility.Collapsed;
            UsagerForm.Visibility = Visibility.Collapsed;
            LesBoutons.Visibility = Visibility.Collapsed;
            MessageAccueil0.Visibility = Visibility.Collapsed;

            MessageAccueil1.Text = "Impression en cours ...";
            MessageAccueil1.Visibility = Visibility.Visible;

            var content = FichierOuvertEntete.Content;
            FichierOuvertEntete.Content = "Impression en cours ... veuillez patienter !";

            // L'impression du document
            PrintDialog Printdlg = new PrintDialog();
            bool result = Printdlg.ShowDialog().Value;
            if (result)
            {
                MessageBox.Show("Impression du fichier en pdf ...", "Impression du fichier", MessageBoxButton.OK, MessageBoxImage.Information);
                FichierOuvertEntete.Content = "Enregistrement du " + DateTime.Now.ToString();

                // Messsages d'attente d'impression
                Printdlg.PrintVisual(Affichage, "Impression");
                FichierOuvertEntete.Content = "Impression en cours ... veuillez patienter !";

                MessageBox.Show("Impression effectuée ", "Impression");

            }

            else
            {
                MessageBox.Show("Impression annulée", "Impression");
            }

            MessageAccueil1.Text = "Cliquez sur 'Ajouter Famille' pour d'autres saisies !";
            Effacer.Visibility = Visibility.Visible;
            FichierOuvertEntete.Content = content;

        }



        private void Envoyer_Click(object sender, RoutedEventArgs e)
        {
            // Vérouillage des champs
            Nom.IsEnabled = false;
            Prenom.IsEnabled = false;
            Telephone.IsEnabled = false;
            nbAdulte.IsEnabled = false;
            nbEnfant.IsEnabled = false;
            Statut.IsEnabled = false;
            Legumes.IsEnabled = false;
            Fruits.IsEnabled = false;
            Viennoiseries.IsEnabled = false;
            QFruits.IsEnabled = false;
            QLegumes.IsEnabled = false;
            QViennoiseries.IsEnabled = false;

            //Transfert des données dans la table d'affichage
            String dateTime = "";

            dateTime = "Date : " + DateTime.Now.ToString();

            String nom = Nom.Text;
            String prenom = Prenom.Text;
            String telephone = Telephone.Text;
            String nbAdultes = nbAdulte.Text;
            String nbEnfants = nbEnfant.Text;
            String legumes = QLegumes.Text + " " + Legumes.Text + "(s)";
            String fruits = QFruits.Text + " " + Fruits.Text + "(s)";
            String viennoiseries = QViennoiseries.Text + " " + Viennoiseries.Text + "(s)";
            String statut = Statut.Text;

            // Remplissage de la famille
            Famille famille = new Famille();

            famille.Nom = Nom.Text;
            famille.Prenom = prenom;
            famille.Telephone = telephone;
            famille.nbAdulte = nbAdultes;
            famille.nbEnfant = nbEnfants;
            famille.Legumes = legumes;
            famille.Fruits = fruits;
            famille.Viennoiseries = viennoiseries;
            famille.Statut = statut;

            DataGrille.Items.Add(famille);

            //DataGrille.ItemsSource = famille.AjouterFamille();

            MessageBoxResult voir = MessageBox.Show("Voulez-vous visualiser le fichier ?", "Voir le Fichier", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Process message box results
            switch (voir)
            {
                case MessageBoxResult.Yes:
                    TableController.SelectedIndex = 3;
                    break;
                case MessageBoxResult.No:
                    break;
            }

            FichierOuvertEntete.Content = "Récapitulatif de la saisie";
            Enregistrer.IsEnabled = true;
            Effacer.Visibility = Visibility.Visible;

        }

        private void Nouveau_Click(object sender, RoutedEventArgs e)
        {
            // Reinitialisation des champs
            Nom.Text = "";
            Prenom.Text = "";
            Telephone.Text = "";
            nbAdulte.Text = "0";
            nbEnfant.Text = "0";
            Legumes.Text = "Légumes";
            Fruits.Text = "Fruits";
            Viennoiseries.Text = "Viennoiseries" +
                "";
            QFruits.Text = "0";
            QLegumes.Text = "0";
            QViennoiseries.Text = "0";

            // Dévérouillage des champs
            Nom.IsEnabled = true;
            Prenom.IsEnabled = true;
            Telephone.IsEnabled = true;
            nbAdulte.IsEnabled = true;
            nbEnfant.IsEnabled = true;
            Statut.IsEnabled = true;
            Legumes.IsEnabled = true;
            Fruits.IsEnabled = true;
            Viennoiseries.IsEnabled = true;
            QFruits.IsEnabled = true;
            QLegumes.IsEnabled = true;
            QViennoiseries.IsEnabled = true;
        }

        private void Effacer_Click(object sender, RoutedEventArgs e)
        {
            DataGrille.Items.Clear();
            Enregistrer.IsEnabled = false;
            Effacer.Visibility = Visibility.Collapsed;
        }

        private void Famille_Click(object sender, RoutedEventArgs e)
        {
            // Apparition des du formulaire d'ajout de familles
            UsagerForm.Visibility = Visibility.Visible;
            LesBoutons.Visibility = Visibility.Visible;
            MessageAccueil0.Visibility = Visibility.Visible;
            MessageAccueil1.Visibility = Visibility.Collapsed;

            // Switch vers la table 'Usagers'
            TableController.SelectedIndex = 0;

        }

    }

}
