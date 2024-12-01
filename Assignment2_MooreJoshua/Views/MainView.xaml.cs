using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment2_MooreJoshua.Views
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public partial class MainView : Window
    {
        #region Constructor
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        #endregion
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucShellMain_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
