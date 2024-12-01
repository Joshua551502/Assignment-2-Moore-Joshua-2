using Assignment2_MooreJoshua.Models;
using Assignment2_MooreJoshua.Services;
using Assignment2_MooreJoshua.Models;
using Assignment2_MooreJoshua.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2_MooreJoshua.UserControls
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public partial class WatchGallery : UserControl
    {
        public ObservableCollection<Item> Watches { get; set; }
        private bool _isLoading = false; // Prevent concurrent calls
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public WatchGallery()
        {
            InitializeComponent();

            // Initialize the collection
            Watches = new ObservableCollection<Item>();

            // Fetch data from the database
            LoadData();

            // Bind the data to the DataContext
            DataContext = this;
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        private async void LoadData()
        {
            if (!_isLoading) 
            {
                _isLoading = true;


                Watches.Clear();


                await DataServices.GetItemsAsync(Watches);

                _isLoading = false;
            }
        }

        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="filterType"></param>
        internal async void LoadItemsByType(string filterType)
        {
            if (!_isLoading)
            {
                _isLoading = true;

                await DataServices.GetItemsAsync(Watches, filterType);

                _isLoading = false;
            }
        }
    }

}
