using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModuleRx.Models_Dto;
using ModuleRx.Models_View;
using ModuleRx.Services;
using ModuleRx.Shared;
using Xamarin.Forms;

namespace ModuleRx.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly InfoStorageService _infoStorage = new();
        //private readonly RxNetHandler _rxNetHandler = new();
        private List<InfoDto> _infos;
        public ObservableCollection<InfoDto> InfosCollection { get; set; }

        private IDisposable _disposed;

        private CopyModel _copyModel;

        public MainPage()
        {
            InitializeComponent();
            InitSub();
            _infos = new List<InfoDto>();
            InfosCollection = new ObservableCollection<InfoDto>();
            _copyModel = new CopyModel();
            Init();
            BindingContext = this;
            
            
            
            //_disposed.Dispose();
        }

        protected override void OnAppearing()
        {


        }

        private void InitSub()
        {
            _disposed = RxNetHandler.InfoSubject.Subscribe(
                infos =>
                {
                    InfosCollection = new ObservableCollection<InfoDto>();
                    _infos = infos;
                    CopyCollection(_infos, InfosCollection);
                    BindingContext = this;
                },
                () =>
                {
                    Console.WriteLine("[ completed ]");
                }
            );
        }

        private void CopyCollection(List<InfoDto> infos, ObservableCollection<InfoDto> collection)
        {
            foreach (var info in infos)
            {
                collection.Add(new InfoDto(){UserId = info.UserId, Id = info.Id, Title = info.Title, Body = info.Body});
            }
        }

        private async void Init()
        {
            await _infoStorage.GetInfosDetails();
            InfoListView.ItemSelected += InfoListOnItemSelected;
        }

        private void InfoListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (InfoListView.SelectedItem == null) return;
            var item = InfoListView.SelectedItem as InfoViewModel;
            DisplayAlert("Info", $"{item.Body}", "OK");
            InfoListView.SelectedItem = null;
        }

        private async void OnAddInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInfoPage(_infos));
        }
    }
}
