using Assignment2_MooreJoshua.Models;
using Assignment2_MooreJoshua.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2_MooreJoshua.UserControls
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public partial class PocketWatch : UserControl
    {
        private readonly PocketWatchViewModel ViewModel = new PocketWatchViewModel();

        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public PocketWatch()
        {
            InitializeComponent();
            ViewModel.InitializeUserInput(tbWatchName, tbWatchDescription, tbWatchPrice);
            DataContext = ViewModel;
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddItem_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.AddPocketWatch();
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EditItem_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.EditPocketWatch();
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RefreshView();
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.DeletePocketWatch();
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var selectedItem = (Item)button.DataContext;
            ViewModel.SelectPocketWatch(selectedItem.ItemId);
        }
    }
}
