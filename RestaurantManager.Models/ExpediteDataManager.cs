using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
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
