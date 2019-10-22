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

namespace proj_Gestion_Hospital
{
    /// <summary>
    /// Logique d'interaction pour DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public static DBHospital myDataBase;
        public DoctorWindow()
        {
            InitializeComponent();
            myDataBase = new DBHospital();
            loadCombo();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string patientRef = nssComboBox.Text;
                int whichBed = 0;
                MessageBoxResult res = MessageBox.Show("Do you really want to discharge " + nssComboBox.Text, "ATTENTION!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (res == MessageBoxResult.Yes)
                {
                    var query =
                        from pat in myDataBase.Dossier_Admission
                        where pat.nss == patientRef
                        select pat;
                    foreach (Dossier_Admission pat in query)
                    {
                        pat.date_conge = DateTime.Today;
                        whichBed = (int)pat.numero_lits;
                    }
                    var query2 =
                    from bed in myDataBase.Lits
                    where bed.Numero_Lit == whichBed
                    select bed;
                    foreach (Lit bed in query2)
                    {
                        bed.occupe = false;
                    }

                    myDataBase.SaveChanges();
                    loadCombo();
                    MessageBox.Show("Patient successfully discharged");
                }
                else
                {
                    MessageBox.Show("Patient was not discharged");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong: \n");
            }

        }
        private void loadCombo()
        {

            var query =
                      from pat in myDataBase.Dossier_Admission
                      where pat.date_conge == null
                      select pat;
            nssComboBox.DataContext = query.ToList();

        }
    }
}
