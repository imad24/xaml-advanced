using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehaviour :DependencyObject, IBehavior
    {
        public String Message { get; set; }
        public String Title { get; set; }
        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                AssociatedObject = associatedObject;
                (AssociatedObject as Page).RightTapped += OnRightTapped;
            }
      
        }

        private async void OnRightTapped(object sender, RightTappedRoutedEventArgs rightTappedRoutedEventArgs)
        {
            await new MessageDialog(Message,Title).ShowAsync();
        }

        public void Detach()
        {
            var page = AssociatedObject as Page;
            if (page != null) page.RightTapped -= OnRightTapped;
        }

        public DependencyObject AssociatedObject { get; private set; }
    }
}
