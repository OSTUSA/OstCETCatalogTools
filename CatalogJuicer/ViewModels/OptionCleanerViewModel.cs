using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstCatalogJuicer.Models;

namespace OstCatalogJuicer.ViewModels
{
    public class OptionCleanerViewModel : ViewModelBase
    {
        /// <summary>
        /// Model data
        /// </summary>
        public OptionCleanerModel Model { get; private set; }

        /// <inheritdoc />
        public OptionCleanerViewModel(OptionCleanerModel model)
        {
            Model = model;
        }
    }
}
