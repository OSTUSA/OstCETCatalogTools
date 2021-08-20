using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;

using Microsoft.Win32;
using OstCatalogJuicer.Models;

namespace OstCatalogJuicer.ViewModels
{
    public class HomeControlViewModel : ViewModelBase
    {
        public HomeModel Model { get; set; }

        public ICommand OpenFolderExplorerCommand { get; private set; }

        public HomeControlViewModel()
        {
            
        }

        private void OpenFolderExplorer()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

        }
    }
}
