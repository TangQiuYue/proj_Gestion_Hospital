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
    /// Logique d'interaction pour OrderlyWindow.xaml
    /// </summary>
    public partial class OrderlyWindow : Window
    {
        Provinces provinceList;
        public static DBHospital myDataBase;
        public OrderlyWindow()
        {
            InitializeComponent();
            myDataBase = new DBHospital();
            provinceList = new Provinces();
            fillCombo();
        }

        private void findPatient_Click(object sender, RoutedEventArgs e)
        {
     
            searchForPatientForm.Visibility = Visibility.Visible;
            admitPatientForm.Visibility = Visibility.Hidden;
            addNewPatientForm.Visibility = Visibility.Hidden;
            addParentGrid.Visibility = Visibility.Hidden;
        }

        private void addPatient_Click(object sender, RoutedEventArgs e)
        {
            searchForPatientForm.Visibility = Visibility.Hidden;
            admitPatientForm.Visibility = Visibility.Hidden;
            addNewPatientForm.Visibility = Visibility.Visible;
            addParentGrid.Visibility = Visibility.Hidden;
        }

        private void admitPatient_Click(object sender, RoutedEventArgs e)
        {
            addNewPatientForm.Visibility = Visibility.Hidden;
            admitPatientForm.Visibility = Visibility.Visible;
            addParentGrid.Visibility = Visibility.Hidden;
            searchForPatientForm.Visibility = Visibility.Hidden;
            fillAdmitCombo();
        }
        private void fillCombo()
        {
            provincecomboBox.ItemsSource = provinceList.addProvinces();
            assurancecomboBox.DataContext = myDataBase.Compagnie_Assurance.ToList();
            parentCombo.DataContext = myDataBase.Parents.ToList();
            parentProvincecomboBox.ItemsSource = provinceList.addProvinces();
        }

        private void addNewParent_Click(object sender, RoutedEventArgs e)
        {
            Parent parent = new Parent();

            try
            {
            parent.nom = parentnomTxtBox.Text;
            parent.prenom = parentprenomTxtBox.Text;
            parent.adresse = parentAddressTextBox.Text;
            parent.code_postale = parentcodePostalTxtBox.Text;
            parent.ville = parentvilleTxtBox.Text;
            parent.telephone = parenttelephoneTxtBox.Text;
            parent.province = parentProvincecomboBox.SelectedItem.ToString();
            parent.ref_parent = refParentTextBox.Text;

            myDataBase.Parents.Add(parent);

                myDataBase.SaveChanges();
                MessageBox.Show("New Parent added successfully!");
                parentnomTxtBox.Text = "";
                parentprenomTxtBox.Text = "";
                parentAddressTextBox.Text = "";
                parentcodePostalTxtBox.Text = "";
                parentvilleTxtBox.Text = "";
                parenttelephoneTxtBox.Text = "";
                refParentTextBox.Text = "";
                fillCombo();
                closeParent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! Something went wrong : \n" + ex.Message);
            }
         }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            closeParent();
        }

        private void closeParent()
        {
            parentnomTxtBox.Text = "";
            parentprenomTxtBox.Text = "";
            parentAddressTextBox.Text = "";
            parentcodePostalTxtBox.Text = "";
            parentvilleTxtBox.Text = "";
            parenttelephoneTxtBox.Text = "";
            refParentTextBox.Text = "";
            addParentGrid.Visibility = Visibility.Hidden;
        }

        private void addNewPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            try { 
            patient.nom = nomTxtBox.Text;
            patient.prenom = prenomTxtBox.Text;
            patient.NSS = nssTextBox.Text;
            patient.ville = villeTxtBox.Text;
            patient.province = provincecomboBox.SelectedItem.ToString();
            patient.code_postale = codePostalTxtBox.Text;
            patient.telephone = telephoneTxtBox.Text;
            patient.id_compagnie = assurancecomboBox.SelectedIndex;
            patient.ref_parent = parentCombo.Text;

            myDataBase.Patients.Add(patient);

            myDataBase.SaveChanges();
                fillCombo();
            MessageBox.Show("New Patient added successfully!");
        }
          catch (Exception ex)
           {
               MessageBox.Show("Oops! Something went wrong : \n" + ex.Message);
            }
        }

        private void fillAdmitCombo()
        {
              nssComboBox.DataContext = myDataBase.Patients.ToList();
              docNameCombo.DataContext = myDataBase.Medecins.ToList();

            var query =
            from b in myDataBase.Lits
            where b.occupe == false
            select new { b.Numero_Lit };
            bedNumCombo.DataContext = query.ToList();
            
        }

        private void nssComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void admitBtn_Click(object sender, RoutedEventArgs e)
        {
            Dossier_Admission admit = new Dossier_Admission();

            int bedNumber = int.Parse(bedNumCombo.Text);

            try { 
            admit.nss = nssComboBox.Text;
            admit.Chirurgie_prog = typePfSurgeTxtBx.Text;
            admit.date_admission = admissionDate.DisplayDate;
            admit.date_chirurgie = surgeryDate.DisplayDate;
            admit.numero_lits = bedNumber;
            var query1 =
                from docs in myDataBase.Medecins
                where docs.nom == docNameCombo.Text
                select docs;
            foreach(Medecin docs in query1)
            {
                admit.ID_Medecin = docs.ID_medecin;
            }

            myDataBase.Dossier_Admission.Add(admit);

                var query2 =
                    from beds in myDataBase.Lits
                    where beds.Numero_Lit == bedNumber
                    select beds;
   
                foreach(Lit beds in query2)
                {
                  beds.occupe = true;
                }
                fillCombo();
                fillAdmitCombo();
                myDataBase.SaveChanges();
            MessageBox.Show("New Patient admitted successfully!");
        }
          catch (Exception ex)
          {
              MessageBox.Show("Oops! Something went wrong : \n" + ex.Message);
            }
            
}

        private void lastNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            string findMe;
            findMe = lastNameTxtBox.Text;

            var query =
                     from patients in myDataBase.Patients
                     where patients.nom == findMe
                     select new {patients.NSS, patients.nom, patients.prenom, patients.ref_parent};

            searchDataGrid.ItemsSource = query.ToList();
        }

        private void addParentdd_Click(object sender, RoutedEventArgs e)
        {
            addParentGrid.Visibility = Visibility.Visible;
            admitPatientForm.Visibility = Visibility.Hidden;
            addNewPatientForm.Visibility = Visibility.Hidden;
        }
    }
}
