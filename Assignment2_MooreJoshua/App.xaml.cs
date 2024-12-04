using Assignment2_MooreJoshua.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;

namespace Assignment2_MooreJoshua
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Set DataDirectory to the project's root directory
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.FullName;

            AppDomain.CurrentDomain.SetData("DataDirectory", projectRoot);

            try
            {
                RunLogic();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        private void RunLogic()
        {

            using (var context = new HarryRosenWatchesDB())
            {
                context.Database.Initialize(force: true);
                if (!context.Database.Exists())
                {
                    MessageBox.Show("Database does not exist. Creating and seeding database...");
                    context.Database.Create();
                }

                if (!context.Items.Any()) // Only execute inserts if Items table is empty
                {
                    MessageBox.Show("Database is empty. Seeding data...");

                    // Perform all inserts
                    InsertOrUpdateItem(context, 1, "Frederque Constant", "Watch", "Classic Quartz Chronograph Watch", "/Assets/Images/Watches/fred.jpg", 1395.00m);
                    InsertOrUpdateItem(context, 2, "Citizen", "Watch", "TSUYOSA Collection Watch", "/Assets/Images/Watches/citi.jpg", 595.00m);
                    InsertOrUpdateItem(context, 3, "Shinola", "Watch", "Canfield C56 43mm Watch", "/Assets/Images/Watches/shin.jpg", 1385.00m);
                    InsertOrUpdateItem(context, 4, "Shinola", "Watch", "Canfield C56 Watch", "/Assets/Images/Watches/shin2.jpg", 1255.00m);
                    InsertOrUpdateItem(context, 5, "Wolf 1834", "Watch Box", "Axis 8 Piece Watch Box", "/Assets/Images/Watches/box.jpg", 615.00m);
                    InsertOrUpdateItem(context, 6, "Rapport London", "Watch Box", "Heritage Ten Watch Box", "/Assets/Images/Watches/watch_box_2.jpeg", 1095.00m);
                    InsertOrUpdateItem(context, 7, "Rapport London", "Watch Box", "Brompton Five Watch Box", "/Assets/Images/Watches/watch_box_3.jpeg", 925.00m);
                    InsertOrUpdateItem(context, 8, "Wolf 1834", "Watch Box", "Eight-Piece British Racing Watch Box", "/Assets/Images/Watches/watch_box_4.jpeg", 685.00m);
                    InsertOrUpdateItem(context, 9, "Tateossian", "Pocket Watch", "Pocket Watch", "/Assets/Images/Watches/pocket_watch_1.jpeg", 475.00m);
                    InsertOrUpdateItem(context, 10, "Rapport London", "Pocket Watch", "Mechanical Half Hunter Pocket Watch", "/Assets/Images/Watches/pocket_watch_2.jpeg", 390.00m);
                    InsertOrUpdateItem(context, 11, "Rapport London", "Pocket Watch", "Mechanical Full Hunter Pocket Watch", "/Assets/Images/Watches/pocket_watch_3.jpeg", 395.00m);
                    InsertOrUpdateItem(context, 12, "Rapport London", "Pocket Watch", "Mechanical Half Hunter Pocket Watch", "/Assets/Images/Watches/pocket_watch_4.jpeg", 475.00m);

                    MessageBox.Show("Data seeding completed.");
                }
            }
        }

        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="imagesource"></param>
        /// <param name="price"></param>
        private void InsertOrUpdateItem(HarryRosenWatchesDB context, int id, string name, string type, string description, string imagesource, decimal price)
        {
            var existingItem = context.Items.SingleOrDefault(i => i.ItemId == id);

            if (existingItem == null)
            {
                // Item doesn't exist, insert it
                var item = new Item
                {
                    ItemId = id,
                    ItemName = name,
                    ItemType = type,
                    ItemDescription = description,
                    ItemImageSource = imagesource,
                    ItemPrice = price
                };

                context.Items.Add(item);
            }
            else
            {
                // Item already exists, update its details
                existingItem.ItemName = name;
                existingItem.ItemType = type;
                existingItem.ItemDescription = description;
                existingItem.ItemImageSource = imagesource;
                existingItem.ItemPrice = price;
            }

            context.SaveChanges();
        }

    }
}
