using OverItProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OverItProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Photo photo)
        {
            InitializeComponent();
            imgTitle.Text = photo.Title;
            img.Source = photo.ImageUrl;
            lblDescription.Text =$"Photo owner:{photo.Owner}";
            
        }
    }
}