using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p1;
        public MainWindow()
        {
            InitializeComponent();
            p1 = new Person()
            {
                Name = "James Crowning",
                Address = "10 Downing St",
                DOB = new DateTime(2000, 7, 15),
                EMail = "abc@zoo.edu",
                
            };

            
            MyGrid.DataContext = p1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p1.calculateAge();
            ageTxt.Text =  p1.Age.ToString();
            int value = p1.Age;
            if (value >= 18)
            {
                rbCanVote.IsChecked = true;
                rbCannnotVote.IsChecked = false;
            }
            else
            {
                rbCanVote.IsChecked = false;
                rbCannnotVote.IsChecked = true;
            }
            personInfoTxt.Text = p1.ToString();
                
        }

        
    }

    public class Person
    {
        private string name;
        private string address;
        private DateTime dob;
        private string email;
        private int age;
        public Person() { }

        //Accessors
        public string Name {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string Address {
            get { return address; }
            set
            {
                address = value;
            }
        }
        public DateTime DOB {
            get { return dob; }
            set
            {
                dob = value;
            }
        }
        public string EMail {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public int Age
        {
            get
            {
                calculateAge();
                return age;
            }
        }

        public void calculateAge()
        {
            int year = DOB.Year;
            DateTime today = DateTime.Now;
            age = (today.Year - year);
        }

        public override string ToString()
        {
            string str = String.Format( "I am {0} {1} {2} {3}", name, age, email, address);
            return str;


        }
    }
}
