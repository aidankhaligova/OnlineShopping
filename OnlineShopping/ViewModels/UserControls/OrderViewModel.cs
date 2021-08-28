using OnlineShopping.Commands.Orders;
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
    public class OrderViewModel : BaseControlViewModel
    {
        public override string Header => "Orders";
        private OrderModel currentOrder = new OrderModel();
        public OrderModel CurrentOrder
        {
            get => currentOrder;
            set
            {
                currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }
        private OrderModel selectedOrder;
        public OrderModel SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));

                CurrentOrder = SelectedOrder?.Clone();

                if (SelectedOrder != null)
                {
                    DeleteVisibility = Visibility.Visible;
                    SaveVisibility = Visibility.Hidden;
                }
            }
        }
        private List<OrderDetailModel> orderDetails;
        public List<OrderDetailModel> OrderDetails
        {
            get => orderDetails;
            set 
            {
                orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }
        private ObservableCollection<OrderModel> orders;
        public ObservableCollection<OrderModel> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private List<OrderModel> allOrders;
        public List<OrderModel> AllOrders
        {
            get => allOrders;
            set
            {
                allOrders = value;
                OnPropertyChanged(nameof(AllOrders));
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
            IEnumerable<OrderModel> filteredOrders = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredOrders = AllOrders;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredOrders = AllOrders.Where(x =>
                        x.Customer.Id.ToString().Contains(lowerSearchText) ||
                        x.Address.ToLower().Contains(lowerSearchText) ||
                        x.Note.ToLower().Contains(lowerSearchText));
            }

            Orders.Clear();

            foreach (var item in filteredOrders)
            {
                Orders.Add(item);
            }
            CurrentOrder = new OrderModel();
            SaveVisibility = Visibility.Visible;
            DeleteVisibility = Visibility.Collapsed;
        }
        public OpenOrderDetailsCommand OpenDetails => new OpenOrderDetailsCommand(this);
        public OpenOrderAddWindowCommand Save => new OpenOrderAddWindowCommand(this);
        public DeleteOrderCommand Delete => new DeleteOrderCommand(this);
        public ExportToExcelOrderCommand ExportToExcel => new ExportToExcelOrderCommand(this);
    }
}
