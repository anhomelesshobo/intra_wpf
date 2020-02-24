using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using intra_models;


namespace wpf_intra
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Customer currentcustomer;

        private int currentnblist;

        private int previousindex;

        public ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>();

        public Customer CurrentCustomer
        {
            get => currentcustomer;
            set
            {
                currentcustomer = value;
                OnPropertyChanged();
            }
        }

        public int MaxIndex { get; set; }
        public int SelectedIndex { get; private set; }

        public MainWindow()
        {

            InitializeComponent();
            initValues();
        }

        private void initValues()
        {
            customers.Add(new Customer() { Name = "Ayanna", LastName = "Vargas", Address = "401-3122 Nullam Ave", City = "Pickering", Province = "ON", PostalCode = "N6C 7M5", PicturePath = "image/CLION.png", ContactInfo = "Work : 624-767-4994" });
            customers.Add(new Customer() { Name = "Whitney", LastName = "Parks", Address = "563-3207 Mi Rd.", City = "Greater Sudbury", Province = "ON", PostalCode = "N9G 5V1", PicturePath = "image/VMWARE.png", ContactInfo = "Cell : 175-370-4839" });
            customers.Add(new Customer() { Name = "Louis", LastName = "Watts", Address = "P.O. Box 529, 6291 Aliquam Road", City = "Fredericton", Province = "NB", PostalCode = "E2T 4M4", PicturePath = "image/CLION.png", ContactInfo = "Cell : 734-499-0531" });
            customers.Add(new Customer() { Name = "Pamela", LastName = "Knapp", Address = "2425 Urna Road", City = "Mission", Province = "BC", PostalCode = "V6W 1J0", PicturePath = "image/VMWARE.png", ContactInfo = "Home : 510-433-5623" });
            customers.Add(new Customer() { Name = "Clinton", LastName = "Gallagher", Address = "Ap #150-7450 Sapien Rd.", City = "Scarborough", Province = "ON", PostalCode = "M5V 7N1", PicturePath = "image/VMWARE.png", ContactInfo = "Home : 328-524-0475" });
            customers.Add(new Customer() { Name = "Amal", LastName = "Cross", Address = "P.O. Box 738, 9025 Sed Street", City = "Parkland County", Province = "AB", PostalCode = "T6S 6A4", PicturePath = "image/CLION.png", ContactInfo = "Cell : 250-555-4617" });
            customers.Add(new Customer() { Name = "Vanna", LastName = "Hyde", Address = "5671 Eros Rd.", City = "Daly", Province = "MB", PostalCode = "R0E 5T0", PicturePath = "image/GIT.png", ContactInfo = "Email : Quisque@neque.net" });
            customers.Add(new Customer() { Name = "Madonna", LastName = "Navarro", Address = "P.O. Box 647, 5331 Erat, Rd.", City = "Prince George", Province = "BC", PostalCode = "V6Y 0X2", PicturePath = "image/CLION.png", ContactInfo = "Home : 369-993-0222" });
            customers.Add(new Customer() { Name = "Rina", LastName = "Decker", Address = "138-7714 Orci, St.", City = "Hamilton", Province = "ON", PostalCode = "L7Z 9Z5", PicturePath = "image/GIT.png", ContactInfo = "Work : 140-464-7242" });
            customers.Add(new Customer() { Name = "Dustin", LastName = "Cole", Address = "531-6134 Ut St.", City = "St. Thomas", Province = "ON", PostalCode = "K1C 9L0", PicturePath = "image/GIT.png", ContactInfo = "Email : eget.dictum@Aliquamvulputate.ca" });
            customers.Add(new Customer() { Name = "Kellie", LastName = "Hanson", Address = "6655 Integer Avenue", City = "Windsor", Province = "ON", PostalCode = "P5Y 0S4", PicturePath = "image/FIREFOX.png", ContactInfo = "Work : 175-412-9657" });
            customers.Add(new Customer() { Name = "Cain", LastName = "Booth", Address = "P.O. Box 733, 4514 Id Road", City = "Rimouski", Province = "QC", PostalCode = "J7Y 1R5", PicturePath = "image/VMWARE.png", ContactInfo = "Cell : 668-418-2708" });
            customers.Add(new Customer() { Name = "Todd", LastName = "Christian", Address = "8576 A Av.", City = "Smoky Lake", Province = "AB", PostalCode = "T7W 1W6", PicturePath = "image/VMWARE.png", ContactInfo = "Cell : 401-455-7531" });
            customers.Add(new Customer() { Name = "Hashim", LastName = "Hodge", Address = "800-2799 Phasellus Street", City = "Sunset Point", Province = "AB", PostalCode = "T7K 1L3", PicturePath = "image/VMWARE.png", ContactInfo = "Home : 108-300-4964" });
            customers.Add(new Customer() { Name = "Leah", LastName = "Miller", Address = "P.O. Box 716, 6477 Fringilla Rd.", City = "Shawinigan", Province = "QC", PostalCode = "J8Y 2A2", PicturePath = "image/GIT.png", ContactInfo = "Cell : 408-758-5810" });
            customers.Add(new Customer() { Name = "Kenneth", LastName = "Roberts", Address = "Ap #173-2146 Ac Street", City = "Swan Hills", Province = "AB", PostalCode = "T3X 8M7", PicturePath = "image/CLION.png", ContactInfo = "Home : 122-178-1426" });
            customers.Add(new Customer() { Name = "Carly", LastName = "Christensen", Address = "773-7929 Dapibus Av.", City = "Legal", Province = "AB", PostalCode = "T2C 7N9", PicturePath = "image/FIREFOX.png", ContactInfo = "Home : 386-338-5818" });
            customers.Add(new Customer() { Name = "Malik", LastName = "Compton", Address = "7436 Arcu St.", City = "Cap-Rouge", Province = "QC", PostalCode = "J4V 0H1", PicturePath = "image/GIT.png", ContactInfo = "Cell : 369-993-0222" });
            customers.Add(new Customer() { Name = "Victoria", LastName = "King", Address = "261-9542 Luctus Rd.", City = "Whitchurch-Stouffville", Province = "ON", PostalCode = "K8N 2G7", PicturePath = "image/FIREFOX.png", ContactInfo = "Home : 550-230-2146" });
            customers.Add(new Customer() { Name = "James", LastName = "Simon", Address = "4628 Enim. Av.", City = "Chilliwack", Province = "BC", PostalCode = "V3Z 2J1", PicturePath = "image/CLION.png", ContactInfo = "Cell : 343-151-5411" });
            customers.Add(new Customer() { Name = "Christopher", LastName = "Monroe", Address = "8142 Fusce St.", City = "Baie-Comeau", Province = "QC", PostalCode = "G2B 9R9", PicturePath = "image/FIREFOX.png", ContactInfo = "Work : 827-654-9939" });
            
            currentnblist = Listview.Items.Count;

            CurrentCustomer = customers[0];

            MaxIndex = customers.Count - 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void selected(object sender, SelectionChangedEventArgs e)
        {
            if (currentnblist != Listview.Items.Count)
            {

                CurrentCustomer = customers[previousindex - 1];
                currentnblist--;
            }
            else
            {
                CurrentCustomer = customers[Listview.SelectedIndex];
            }

        }

        private void del_button(object sender, RoutedEventArgs e)
        {
            previousindex = Listview.SelectedIndex;
            customers.Remove((Customer)Listview.SelectedItem);
            
            
        }

        private void Newcustomer(object sender, RoutedEventArgs e)
        {
            var emp = new Customer() { Name = "name", LastName = "new", Address = "", City = "", Province = "", PostalCode = "", PicturePath = "image/Default.png", ContactInfo = "" };
            customers.Add(emp);
            currentnblist++;
        }
    }
}
