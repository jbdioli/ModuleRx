using System;
using System.Collections.Generic;
using ModuleRx.Models_Dto;
using ModuleRx.Models_View;
using ModuleRx.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuleRx.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInfoPage : ContentPage
    {
        //private readonly RxNetHandler _rxNetHandler = new();

        private readonly List<InfoDto> _infos;
        private readonly InfoDto _info = new();
        private readonly InfoViewModel _infoView = new();
        private readonly CopyModel _copyModel;


        public AddInfoPage(List<InfoDto> infos)
        {
            InitializeComponent();
            _copyModel = new CopyModel();
            _infos = infos;
            BindingContext = _infoView;
        }

        private void Button_OnSave(object sender, EventArgs e)
        {
            _copyModel.CopyInfoViewModelToDto(_infoView, _info);

            _infos.Add(_info);
            RxNetHandler.InfoSubject.OnNext(_infos);
            Navigation.PopAsync();
        }
    }
}