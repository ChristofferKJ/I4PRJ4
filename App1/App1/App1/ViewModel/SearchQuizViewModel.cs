using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;

using Xamarin.Forms;
namespace App1.ViewModel
{
    public class SearchQuizViewModel : BaseViewModel
    {
        private List<string> categories_;

        public List<string> Categories { get => categories_; set => SetProperty(ref categories_, value); }


        SearchQuizViewModel()
        {
            Title = "Vælg Kategori";
            Categories = new List<string>();

        }


         
    }
}
