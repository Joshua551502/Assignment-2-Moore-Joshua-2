namespace Assignment2_MooreJoshua.Models
{

    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-11-28
    /// </summary>
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageSource { get; set; }
        public decimal ItemPrice { get; set; }
    }

}