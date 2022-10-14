using OverItProject.Helpers;
using OverItProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OverItProject.Services
{
    public class SearchService
    {
        public static async Task<List<Photo>> GetListPhotosFromString(string strToSearch)
        {
            List<Photo> photos = null;
            string url = $"{Constants.BaseUrl}method=flickr.photos.search&api_key={Constants.ApiKeyFlickr}&text={strToSearch}&page=1&format=json&nojsoncallback=1";
            var res = await HttpHelper.HttpGetRequest<SearchResponseModel>(url);
            if (res != null)
            {
                photos = res.Photos.Photo;
            }
            return photos;
        }
    }
}
