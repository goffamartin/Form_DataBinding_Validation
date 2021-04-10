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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Formulář_s_validací
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Employee emp;

        public MainWindow()
        {
            InitializeComponent();
            emp = new Employee("John", "Doe", 0, "None", "Unknown", 100000);
            this.DataContext = emp;
            NameAlert.DataContext = this;
            LastNameAlert.DataContext = this;
            YearAlert.DataContext = this;
            EducationAlert.DataContext = this;
            JobAlert.DataContext = this;
            CashAlert.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!NameAlert.IsVisible && !LastNameAlert.IsVisible && !YearAlert.IsVisible && !EducationAlert.IsVisible && !JobAlert.IsVisible && !CashAlert.IsVisible)
            {
                MessageBox.Show($@"Rekapitulace informací:
                   Jméno: {emp.Name}
                Příjmení: {emp.LastName}
            Rok narození: {emp.BirthYear}
                Vzdělání: {emp.Education}
            Prac. pozice: {emp.Job}
              hrubý plat: {emp.Cash} Kč");
                Employee.employeeList.Add(emp);
                emp = new Employee("", "", 2000, "", "", 0);
                this.DataContext = emp;
            }
        }
        #region Name
        private Visibility _NameAlertVisibility;
        public Visibility NameAlertVisibility
        {
            get { return _NameAlertVisibility; }
            set
            {
                _NameAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NameAlertVisibility"));
            }
        }
        private string _NameAlertContent = "Jméno je povinná položka";        
        public string NameAlertContent {get { return _NameAlertContent; }}
        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(emp.Name.Length > 0)
            {
                NameAlertVisibility = Visibility.Hidden;
            }
            else
            {
                NameAlertVisibility = Visibility.Visible;
            }
        }
        #endregion
        #region LastName
        private Visibility _LastNameAlertVisibility;
        public Visibility LastNameAlertVisibility
        {
            get { return _LastNameAlertVisibility; }
            set
            {
                _LastNameAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastNameAlertVisibility"));
            }
        }
        private string _LastNameAlertContent;
        public string LastNameAlertContent 
        { 
            get { return _LastNameAlertContent; }
            set
            {
                if (emp.LastName.Length > 2)
                {
                    _LastNameAlertContent = "";
                }
                if (emp.LastName.Length < 2)
                {
                    _LastNameAlertContent = "Příjmení musí obsahovat více než 2 znaky";
                }
                if (emp.LastName.Length > 20)
                {
                    _LastNameAlertContent = "Příjmení musí obsahovat méně než 20 znaků";
                }
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastNameAlertContent"));
            }
        }
        private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(emp.LastName.Length > 2) 
            {
                LastNameAlertVisibility = Visibility.Hidden;
            }
            if (emp.LastName.Length < 2)
            {
                LastNameAlertVisibility = Visibility.Visible;
            }
            if (emp.LastName.Length > 20)
            {
                LastNameAlertVisibility = Visibility.Visible;
            }
            LastNameAlertContent = "cokoliv";
        }
        #endregion
        #region BirthYear
        private Visibility _BirthYearAlertVisibility;
        public Visibility BirthYearAlertVisibility
        {
            get { return _BirthYearAlertVisibility; }
            set
            {
                _BirthYearAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BirthYearAlertVisibility"));
            }
        }
        private string _BirthYearAlertContent;
        public string BirthYearAlertContent 
        { 
            get { return _BirthYearAlertContent; }
            set
            {
               if (emp.BirthYear > DateTime.Now.Year)
                    _BirthYearAlertContent = "Ještě jsi se nenarodil :)";
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BirthYearAlertContent"));
            }
        }
        private void BirthYearBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(emp.BirthYear);
                BirthYearAlertVisibility = Visibility.Hidden;
            }
            catch
            {
                BirthYearAlertVisibility = Visibility.Visible;
            }
            BirthYearAlertContent = "cokoliv";
        }
        #endregion
        #region Education
        private Visibility _EducationAlertVisibility;
        public Visibility EducationAlertVisibility
        {
            get { return _EducationAlertVisibility; }
            set
            {
                _EducationAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EducationAlertVisibility"));
            }
        }
        private void EducationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EducationBox.SelectedIndex == -1)
                EducationAlertVisibility = Visibility.Visible;
            else
                EducationAlertVisibility = Visibility.Hidden;
        }
        #endregion
        #region Job
        private Visibility _JobAlertVisibility;
        public Visibility JobAlertVisibility
        {
            get { return _JobAlertVisibility; }
            set
            {
                _JobAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("JobAlertVisibility"));
            }
        }
        private void JobBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emp.Job.Length > 0)
            {
                JobAlertVisibility = Visibility.Hidden;
            }
            else
            {
                JobAlertVisibility = Visibility.Visible;
            }
        }
        #endregion
        #region Cash
        private Visibility _CashAlertVisibility;
        public Visibility CashAlertVisibility
        {
            get { return _CashAlertVisibility; }
            set
            {
                _CashAlertVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CashAlertVisibility"));
            }
        }
        private string _CashAlertContent;
        public string CashAlertContent
        {
            get { return _CashAlertContent; }
            set
            {
                if (emp.Cash < 0)
                    _CashAlertContent = "To moc nevyděláváš :)";
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CashAlertContent"));
            }
        }
        private void CashBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emp.Cash >= 0)
            {
                CashAlertVisibility = Visibility.Hidden;
            }
            else
            {
                CashAlertVisibility = Visibility.Visible;
            }
            CashAlertContent = "cokoliv";
        }
        #endregion   
    }
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public Person(string name, string lastname, int birthyear)
        {
            Name = name;
            LastName = lastname;
            BirthYear = birthyear;
        }
    }
    public class Employee : Person
    {
        public static List<Employee> employeeList = new List<Employee>();
        public string Education { get; set; }
        public string Job { get; set; }
        public double Cash { get; set; }
        public Employee(string name, string lastname, int birthyear, string education, string job, double cash) : base(name, lastname, birthyear)
        {
            Education = education;
            Job = job;
            Cash = cash;
        }
    }
}
