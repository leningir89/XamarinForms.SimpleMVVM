﻿using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using SimpleMVVM.Core.Services;
using SimpleMVVM.Core.ViewModels;

namespace SimpleMVVM.Sample.ViewModels
{
    [ImplementPropertyChanged]
    public class DetailViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public override void OnInit(object args)
        {
            MainText = args.ToString();
        }

        public DetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string MainText { get; set; }

        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand
        {
            get
            {
                if (_goBackCommand == null)
                {
                    _goBackCommand = new RelayCommand(async () =>
                    {
                        await _navigationService.GoBack();
                    });
                }

                return _goBackCommand;
            }
        }

    }
}
