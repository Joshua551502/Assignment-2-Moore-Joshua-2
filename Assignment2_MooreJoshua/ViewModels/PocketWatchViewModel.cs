using Assignment2_MooreJoshua.Models;
using Assignment2_MooreJoshua.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2_MooreJoshua.ViewModels
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public partial class PocketWatchViewModel
    {
        #region Properties
        private TextBox _tbPocketWatchName;
        private TextBox _tbPocketWatchDescription;
        private TextBox _tbPocketWatchPrice;

        public TextBox TbPocketWatchName
        {
            get { return _tbPocketWatchName; }
            set { _tbPocketWatchName = value; }
        }
        public TextBox TbPocketWatchDescription
        {
            get { return _tbPocketWatchDescription; }
            set { _tbPocketWatchDescription = value; }
        }

        public TextBox TbPocketWatchPrice
        {
            get { return _tbPocketWatchPrice; }
            set { _tbPocketWatchPrice = value; }
        }
        public int PocketWatchId { get; set; }

        public ObservableCollection<Item> PocketWatchList { get; set; } = new ObservableCollection<Item>();

        #endregion

        #region Private Members

        private readonly CrudOperationsTypedDataSet _crudService;

        #endregion

        #region Constructor

        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public PocketWatchViewModel()
        {
            _tbPocketWatchName = new TextBox();
            _tbPocketWatchDescription = new TextBox();
            _tbPocketWatchPrice = new TextBox();
            _crudService = new CrudOperationsTypedDataSet();
            LoadItems();
        }

        #endregion

        #region Load Data
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public void LoadItems()
        {
            if (PocketWatchList != null)
            {
                PocketWatchList.Clear();
                _crudService.GetItemsByType(PocketWatchList, "Pocket Watch");
            }
        }

        #endregion

        #region Initialize Input
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="tbPocketWatchName"></param>
        /// <param name="tbPocketWatchDescription"></param>
        /// <param name="tbPocketWatchPrice"></param>
        public void InitializeUserInput(TextBox tbPocketWatchName, TextBox tbPocketWatchDescription, TextBox tbPocketWatchPrice)
        {
            _tbPocketWatchName = tbPocketWatchName;
            _tbPocketWatchDescription = tbPocketWatchDescription;
            _tbPocketWatchPrice = tbPocketWatchPrice;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public void ClearUserInput()
        {
            _tbPocketWatchName.Text = string.Empty;
            _tbPocketWatchDescription.Text = string.Empty;
            _tbPocketWatchPrice.Text = string.Empty;
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public void RefreshView()
        {
            ClearUserInput();
            LoadItems();
            PocketWatchId = -1;
        }
        #endregion

        #region Relay Commands
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="id"></param>
        public void SelectPocketWatch(int id)
        {
            PocketWatchId = id;

            var selectedPocketWatch = PocketWatchList.FirstOrDefault(c => c.ItemId == id);
            if (selectedPocketWatch != null)
            {
                _tbPocketWatchName.Text = selectedPocketWatch.ItemName;
                _tbPocketWatchDescription.Text = selectedPocketWatch.ItemDescription;
                _tbPocketWatchPrice.Text = selectedPocketWatch.ItemPrice.ToString("F2");

            }
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <returns></returns>
        public async Task AddPocketWatch()
        {
            var PocketWatchName = _tbPocketWatchName.Text;
            var PocketWatchDescription = _tbPocketWatchDescription.Text;
            var PocketWatchPrice = _tbPocketWatchPrice.Text;

            if (string.IsNullOrWhiteSpace(PocketWatchName))
            {
                MessageBox.Show("The Watch Name field cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(PocketWatchDescription))
            {
                MessageBox.Show("The Watch Description field cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(PocketWatchPrice))
            {
                MessageBox.Show("The Watch Price field cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(PocketWatchPrice, out decimal price))
            {
                MessageBox.Show("Invalid price. Please enter a valid decimal value.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                const string placeholderImagePath = "/Assets/Images/Watches/placeholder-pocket.png";
                const string defaultType = "Pocket Watch";

                await Task.Run(() => _crudService.InsertItem(PocketWatchName, PocketWatchDescription, price, placeholderImagePath, defaultType));
                RefreshView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <returns></returns>
        public async Task EditPocketWatch()
        {
            if (PocketWatchId <= 0)
            {
                MessageBox.Show("Please select an item to edit before proceeding.");
                return;
            }

            var PocketWatchName = _tbPocketWatchName.Text;
            var PocketWatchDescription = _tbPocketWatchDescription.Text;
            var PocketWatchPrice = _tbPocketWatchPrice.Text;

            if (!string.IsNullOrWhiteSpace(PocketWatchName))
            {
                if (decimal.TryParse(PocketWatchPrice, out decimal price))
                {
                    _crudService.EditItem(PocketWatchId, PocketWatchName, PocketWatchDescription, price);
                    RefreshView();
                }
                else
                {
                    await Task.FromException(new Exception("Invalid price. Please enter a valid decimal value."));
                }
            }
            else
            {
                await Task.FromException(new Exception("PocketWatch name cannot be empty."));
            }
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <returns></returns>
        public async Task DeletePocketWatch()
        {
            if (PocketWatchId > 0)
            {
                try
                {
                    await Task.Run(() => _crudService.DeleteItem(PocketWatchId));
                    RefreshView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the item: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete before proceeding.");
            }
        }


        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPocketWatchNameById()
        {
            if (PocketWatchId > 0)
            {
                return _crudService.GetItemNameById(PocketWatchId);
            }

            await Task.FromException(new Exception("Invalid PocketWatch ID."));
            return string.Empty;
        }

        #endregion
    }
}
