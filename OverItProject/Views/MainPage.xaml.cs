using OverItProject.Viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OverItProject
{
    public partial class MainPage : ContentPage
    {
        MainPageViewmodel mainPageViewmodel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainPageViewmodel=new MainPageViewmodel();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length < 2)
            {
                mainPageViewmodel.IsListVisible = false;
                mainPageViewmodel.ListPhotos = null;
            }
        }

    }
}
