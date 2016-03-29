using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;
        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;
        private IMessageService _messageService;

        public ICommand AddToOrderCommand { get; private set; }
        public ICommand SubmitOrderCommand { get; private set; }

        public OrderViewModel(IMessageService message)
        {
            _messageService = message;
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToOrder);
            SubmitOrderCommand = new DelegateCommand<ObservableCollection<MenuItem>>(SubmitOrder);
        }


    
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };

        }

        public string SpecialNotes { get; set; }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    OnPropertyChanged();
                }
                
            } 
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (value != _currentlySelectedMenuItems)
                {
                    _currentlySelectedMenuItems = value;
                    OnPropertyChanged();

                }
            }
        }

        private void AddToOrder(MenuItem parameter)
        {
            CurrentlySelectedMenuItems.Add(parameter);
        }

        private void SubmitOrder(ObservableCollection<MenuItem> parameter)
        {
            var newOrder = new Order
            {
                Items = parameter.ToList(),
                Complete = false,
                Expedite = false,
                Table = Repository.Tables.First(),
                Id = Repository.Orders.Max(o=>o.Id) + 1,
                SpecialRequests = SpecialNotes
            };

            Repository.Orders.Add(newOrder);
            _messageService.ShowDialog("Order successfully added !");
        }
    }
}
