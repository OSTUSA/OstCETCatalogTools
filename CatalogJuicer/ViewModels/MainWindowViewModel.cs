using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using OstCatalogJuicer.Commands;
using OstCatalogJuicer.Controls;
using OstCatalogJuicer.Models;

namespace OstCatalogJuicer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Current Content View Model
        /// </summary>
        private ViewModelBase _currentContentViewModel;

        private readonly ViewModelBase _homeViewModel = new HomeControlViewModel();

        public ViewModelBase CurrentContentViewModel
        {
            get => _currentContentViewModel;
            set
            {
                _currentContentViewModel = value;
                OnPropertyChanged("CurrentContentViewModel");
            }
        }

        public ContentControl NavBar { get; }

        /// <summary>
        /// Load Option Cleaner command
        /// </summary>
        public ICommand LoadOptionCleanerCommand { get; private set; }

        /// <summary>
        /// Load Home Command.
        /// </summary>
        public ICommand LoadHomeCommand { get; private set; }

        public ICommand LoadCreatorCommand { get; private set; }

        public MainWindowViewModel()
        {
            // Load Initial Content Model
            LoadHome();
            NavBar = new NavBar(this);

            InitializeCommands();
        }

        /// <summary>
        /// Initialize Commands
        /// </summary>
        private void InitializeCommands()
        {
            LoadOptionCleanerCommand = new DelegateCommand(o => LoadOptionCleaner());
            LoadHomeCommand = new DelegateCommand(o => LoadHome());
            LoadCreatorCommand = new DelegateCommand(o => LoadCreator());
        }



        /// <summary>
        /// Load Option Cleaner Control
        /// </summary>
        private void LoadOptionCleaner() => CurrentContentViewModel = new OptionCleanerViewModel(new OptionCleanerModel());

        /// <summary>
        /// Load home Control
        /// </summary>
        private void LoadHome() => CurrentContentViewModel = _homeViewModel;

        /// <summary>
        /// Load Creator Control
        /// </summary>
        private void LoadCreator() => CurrentContentViewModel = new CreatorViewModel();
    }
}
