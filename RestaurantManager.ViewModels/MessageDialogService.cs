using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class MessageDialogService :IMessageService
    {
        public async void ShowDialog(string msg)
        {
            await new MessageDialog(msg).ShowAsync();
        }
    }
}
