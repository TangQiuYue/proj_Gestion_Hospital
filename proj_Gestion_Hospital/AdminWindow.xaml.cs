using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Threading;

namespace proj_Gestion_Hospital
{
    /// <summary>
    /// Logique d'interaction pour AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static DBHospital myDataBase;
        public AdminWindow()
        {
            InitializeComponent();
            myDataBase = new DBHospital();
            fillCombo();
        }

        private void deleteDoc_Click(object sender, RoutedEventArgs e)
        {
            consultForm.Visibility = Visibility.Hidden;
            addDocForm.Visibility = Visibility.Hidden;
            modifierBtn.Visibility = Visibility.Hidden;
            fillCombo();

            modifForm.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

        }

        private void doctorList_Click(object sender, RoutedEventArgs e)
        {
            modifierBtn.Visibility = Visibility.Hidden;
            doctorListCmb.Visibility = Visibility.Hidden;

            try
            {
               var query =
               from i in myDataBase.Medecins

               select new { i.ID_medecin, i.nom, i.prenom, i.specialite };

                doctorsdataGrid.ItemsSource = query.ToList();
            } catch(Exception)
            {
                MessageBox.Show("Database could not load");
            }
            consultForm.Visibility = Visibility.Visible;

        }

        private void addDoc_Click(object sender, RoutedEventArgs e)
        {
            consultForm.Visibility = Visibility.Hidden;
            modifForm.Visibility = Visibility.Hidden;
            addDocForm.Visibility = Visibility.Visible;

            nomTxtBox.Text = "";
            prenomTxtBox.Text = "";
            specialiteTxtBox.Text = "";
        }


        private void modifDoc_Click(object sender, RoutedEventArgs e)
        {
            consultForm.Visibility = Visibility.Hidden;
            addDocForm.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
            fillCombo();
                
            modifForm.Visibility = Visibility.Visible;
            modifierBtn.Visibility = Visibility.Visible;

        }

        private void ajouterBtn_Click(object sender, RoutedEventArgs e)
        {
            Medecin meds = new Medecin();
            meds.nom = nomTxtBox.Text;
            meds.prenom = prenomTxtBox.Text;
            meds.specialite = specialiteTxtBox.Text;

            myDataBase.Medecins.Add(meds);

            try
            {
                myDataBase.SaveChanges();
                MessageBox.Show("New doctors added successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Oops! Something went wrong : \n" + ex.Message);
            }
            fillCombo();

        }

        private void modifierBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int docId = int.Parse(doctorListCmb.Text);
 
                MessageBoxResult res = MessageBox.Show("Do you really want to modify doctor " + nomModTxtBox.Text, "ATTENTION!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (res == MessageBoxResult.Yes)
                {
                    var query =
                        from doc in myDataBase.Medecins
                        where doc.ID_medecin == docId
                        select doc;
                   foreach(Medecin doc in query)
                    {
                        doc.nom = nomModTxtBox.Text;
                        doc.prenom = prenommodTxtBox.Text;
                        doc.specialite = specialiteModTxtBox.Text;
                    }
                    myDataBase.SaveChanges();
                    fillCombo();
                    MessageBox.Show("Doctor information succesfully updated");
                     nomModTxtBox.Text = "";
                     prenommodTxtBox.Text = "";
                     specialiteModTxtBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Doctor was not updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops!Something went wrong: \n" + ex.Message);

            }
        }

        private void doctorListCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

      
        private void fillCombo()
        {
            doctorListCmb.DataContext = myDataBase.Medecins.ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int whichDoc = int.Parse(doctorListCmb.Text);

            MessageBoxResult res = MessageBox.Show("Do you really want to delete doctor " + nomModTxtBox.Text, "ATTENTION!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    myDataBase.Medecins.Remove(myDataBase.Medecins.Single(a => a.ID_medecin == whichDoc));

                    myDataBase.SaveChanges();
                    nomModTxtBox.Text = "";
                    prenommodTxtBox.Text = "";
                    specialiteModTxtBox.Text = "";
                    MessageBox.Show("Doctor deleted successfully");
                    fillCombo();
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show("Oops!Something went wrong: \n" + ex.Message);
                }
            }
        }

        private void goBtn_Click(object sender, RoutedEventArgs e)
        {
            int whichDoc = int.Parse(doctorListCmb.Text);

            var query =
             from doc in myDataBase.Medecins
             where doc.ID_medecin == whichDoc
             select doc;
            foreach (Medecin doc in query)
            {
                nomModTxtBox.Text = doc.nom;
                prenommodTxtBox.Text = doc.prenom;
                specialiteModTxtBox.Text = doc.specialite;
            }
     
        }
    }
    }

