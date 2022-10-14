using Acr.UserDialogs;
using OverItProject.Helpers;
using OverItProject.Models;
using OverItProject.Services;
using OverItProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace OverItProject.Viewmodels
{
    public class MainPageViewmodel:BaseViewModel
    {
        private ObservableCollection<Photo> listPhotos;
        public ObservableCollection<Photo> ListPhotos
        {
            get { return listPhotos; }
            set
            {
                SetProperty(ref listPhotos, value);
            }
        }
        private bool isListVisible;
        public bool IsListVisible
        {
            get => isListVisible;
            set => SetProperty(ref isListVisible, value);
        }
        public Command ImageTapped { get; }
        public Command SearchCommand { get; }
        public MainPageViewmodel()
        {
            ImageTapped = new Command<Photo>(ImageClicked);
            SearchCommand = new Command<string>(SearchPhotos);
        }

        private void ImageClicked(Photo obj)
        {
            var navPage = new NavigationPage(new DetailPage(obj));
            Application.Current.MainPage.Navigation.PushAsync(navPage);
        }
        internal async void SearchPhotos(string newTextValue)
        {
            try
            {
                if (newTextValue.Length > 2)
                {
                    UserDialogs.Instance.ShowLoading();
                    var res = await SearchService.GetListPhotosFromString(newTextValue);
                    if (res != null)
                    {
                        ListPhotos = new ObservableCollection<Photo>(res);
                        IsListVisible = true;
                    }
                }
                else if(newTextValue.Length == 0)
                {
                    ListPhotos = new ObservableCollection<Photo>();
                    IsListVisible = false;
                }
                Device.StartTimer(new TimeSpan(2000), () =>
                {
                    UserDialogs.Instance.HideLoading();
                    return false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                UserDialogs.Instance.HideLoading();
            }
            
        }
    }
}
