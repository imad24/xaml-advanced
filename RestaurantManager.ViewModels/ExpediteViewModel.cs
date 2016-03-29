using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private List<Order> _orderItems;

        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }

        public List<Order> OrderItems
        {
            get
            { 
                return Repository.Orders;
            }
            set
            {
                if (_orderItems != value)
                {
                    _orderItems = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
