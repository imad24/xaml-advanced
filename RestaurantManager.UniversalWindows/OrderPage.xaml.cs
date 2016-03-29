using System.ServiceModel.Channels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RestaurantManager.Models;
using RestaurantManager.ViewModels; 

namespace RestaurantManager.UniversalWindows
{
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
            IMessageService messageService = new MessageDialogService();
            DataContext = new OrderViewModel(messageService);
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
