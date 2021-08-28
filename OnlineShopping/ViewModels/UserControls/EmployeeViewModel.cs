using OnlineShopping.Commands.Employees;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.ViewModels.UserControls
{
    public class EmployeeViewModel : BaseControlViewModel
    {
        public override string Header => "Employees";
        private EmployeeModel currentEmployee = new EmployeeModel();
        public EmployeeModel CurrentEmployee
        {
            get => currentEmployee;
            set
            {
                currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
        }
        private EmployeeModel selectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));

                CurrentEmployee = SelectedEmployee?.Clone();

                if (SelectedEmployee != null)
                {
                    DeleteVisibility = Visibility.Visible;
                    SaveVisibility = Visibility.Hidden;
                }
            }
        }
        private ObservableCollection<EmployeeModel> employees;
        public ObservableCollection<EmployeeModel> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private List<EmployeeModel> allEmployees;
        public List<EmployeeModel> AllEmployees
        {
            get => allEmployees;
            set
            {
                allEmployees = value;
                OnPropertyChanged(nameof(AllEmployees));
            }
        }
        private Visibility saveVisibility = Visibility.Visible;
        public Visibility SaveVisibility
        {
            get => saveVisibility;
            set
            {
                saveVisibility = value;
                OnPropertyChanged(nameof(SaveVisibility));
            }
        }
        private Visibility deleteVisibility = Visibility.Collapsed;
        public Visibility DeleteVisibility
        {
            get => deleteVisibility;
            set
            {
                deleteVisibility = value;
                OnPropertyChanged(nameof(DeleteVisibility));
            }
        }
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateDataFiltered();
            }
        }
        public void UpdateDataFiltered()
        {
            IEnumerable<EmployeeModel> filteredEmployees = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredEmployees = AllEmployees;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredEmployees = AllEmployees.Where(x =>
                        x.Name.ToLower().Contains(lowerSearchText) ||
                        x.Surname.Contains(lowerSearchText) ||
                        x.Salary.ToString().Contains(lowerSearchText) ||
                        x.Pin.Contains(lowerSearchText)||
                        x.PhoneNumber.Contains(lowerSearchText));
            }

            Employees.Clear();

            foreach (var item in filteredEmployees)
            {
                Employees.Add(item);
            }
            CurrentEmployee = new EmployeeModel();
            SaveVisibility = Visibility.Visible;
            DeleteVisibility = Visibility.Collapsed;
        }

        public OpenEmployeeAddWindowCommand Save => new OpenEmployeeAddWindowCommand(this);
        public DeleteEmployeeCommand Delete => new DeleteEmployeeCommand(this);
        public ExportToExcelEmployeesCommand ExportToExcel => new ExportToExcelEmployeesCommand(this);
    }

}
