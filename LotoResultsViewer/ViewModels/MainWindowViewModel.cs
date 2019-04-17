using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using LotoResultsViewer.Models.Data;
using LotoResultsViewer.Models.Entities;
using LotoResultsViewer.Services;
using Newtonsoft.Json;

namespace LotoResultsViewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        [NotNull]
        private readonly ApiProviderService _apiProviderService;

        public MainWindowViewModel()
        {
            _apiProviderService = new ApiProviderService();
        }
    
        //Get api providers from config file
        public ObservableCollection<ApiProvider> ApiProviders
        {
            get { 
                var configFile = "config.json";
                if (!File.Exists(configFile))
                    return new ObservableCollection<ApiProvider>();

                return JsonConvert.DeserializeObject<ObservableCollection<ApiProvider>>(File.ReadAllText(configFile));
            }
        }

        private ApiProvider _selectedProvider;
        public ApiProvider SelectedProvider
        {
            get => _selectedProvider;
            set
            {
                _selectedProvider = value;
                OnPropertyChanged("GameTypes"); 
            }
        }

        //Get game types from api provider
        public ObservableCollection<GameType> GameTypes
        {
            get
            {
                if (SelectedProvider == null)
                    return new ObservableCollection<GameType>();
                return _apiProviderService.GetGameTypes(SelectedProvider);
            }
        }

        private GameType _selectedGameType;
        public GameType SelectedGameType
        {
            get => _selectedGameType;
            set
            {
                _selectedGameType = value;
                //StockOverflow!!! 
                OnPropertyChanged("GameResultTirages");
            }
        }

        public ObservableCollection<GameResultTirage> GameResultTirages
        {
            get
            {
                if (SelectedProvider == null && SelectedGameType == null)
                    return new ObservableCollection<GameResultTirage>();
                return _apiProviderService.GetResultArchive(SelectedProvider, SelectedGameType);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
