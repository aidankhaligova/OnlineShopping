using OnlineShopping.Commands.Orders;
using OnlineShopping.Models;
using OnlineShopping.Views.SmallWindows;
using System.Collections.Generic;
using System.Windows.Controls;

namespace OnlineShopping.ViewModels.SmallWindows
{
    public class OrderAddViewModel : BaseViewModel
    {
        public StackPanel DetailPanel;
        public OrderAddWindow CurrentWindow;

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
        
        private List<CustomerModel> customers;
        public List<CustomerModel> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public AddOrderCommand Add => new AddOrderCommand(this);
    }
}
