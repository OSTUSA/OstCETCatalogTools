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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CatalogJuicer;
using OstCatalogJuicer.Models;
using OstCatalogJuicer.ViewModels;

namespace OstCatalogJuicer.Controls
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        public readonly MainWindowViewModel MainWindowViewModel;

        public NavBar(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            InitializeComponent();
        }


        private void Nav_items_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            var item = listView?.SelectedItem as ListViewItem;
            // var item 
            switch (item?.Name)
            {
                case "Home":
                {
                    MainWindowViewModel.LoadHomeCommand.Execute(null);
                    return;
                }
                case "Creator":
                {
                    MainWindowViewModel.LoadCreatorCommand.Execute(null);
                    return;
                }
                case "OptionsCleaner":
                {
                    MainWindowViewModel.LoadOptionCleanerCommand.Execute(null);
                    return;
                }
            }
        }
    }
}
