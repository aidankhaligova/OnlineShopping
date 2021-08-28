using OnlineShopping.Commands.Customers;
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
    public class CustomerViewModel : BaseControlViewModel
    {
        public override string Header => "Customers";
        private CustomerModel currentCustomer = new CustomerModel();
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        private CustomerModel selectedCustomer;
        public CustomerModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));

                CurrentCustomer = SelectedCustomer?.Clone();

                if (SelectedCustomer != null)
                {
                    DeleteVisibility = Visibility.Visible;
                    SaveVisibility = Visibility.Hidden;
                }
            }
        }
        private ObservableCollection<CustomerModel> customers;
        public ObservableCollection<CustomerModel> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        private List<CustomerModel> allCustomers;
        public List<CustomerModel> AllCustomers
        {
            get => allCustomers;
            set
            {
                allCustomers = value;
                OnPropertyChanged(nameof(AllCustomers));
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
        public void UpdateDataFiltered()
        {
            IEnumerable<CustomerModel> filteredCustomers = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredCustomers = AllCustomers;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredCustomers = AllCustomers.Where(x =>
                        x.Name.ToLower().Contains(lowerSearchText) ||
                        x.Surname.ToLower().Contains(lowerSearchText) ||
                        x.Address.ToLower().Contains(lowerSearchText) ||
                        x.Phone.ToLower().Contains(lowerSearchText));
            }

            Customers.Clear();

            foreach (var item in filteredCustomers)
            {
                Customers.Add(item);
            }
            CurrentCustomer = new CustomerModel();
            SaveVisibility = Visibility.Visible;
            DeleteVisibility = Visibility.Collapsed;
        }
        public OpenCustomerAddWindowCommand Save => new OpenCustomerAddWindowCommand(this);
        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);
        public ExportToExcelCustomersCommand ExportToExcel => new ExportToExcelCustomersCommand(this);
    }
}
