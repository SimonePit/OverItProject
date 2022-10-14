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
            mainPageViewmodel.SearchPhotos(e.NewTextValue);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
