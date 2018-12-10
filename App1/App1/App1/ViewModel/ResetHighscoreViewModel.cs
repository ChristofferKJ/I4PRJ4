using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace App1.ViewModel
{
    class ResetHighscoreViewModel
    {
        public ICommand ResertHighscoreCommand
        {
            get
            {
                return new Command(() =>
                {
                    var isConnected = CrossConnectivity.Current.IsConnected;

                    if (!isConnected)
                    {
                        Response = "Kan ikke oprette forbindelse";

                    }

                    
                    var isHighscoresDeleted = _apiServices.DeleteHighscores();
                    
                });
            }
        }

        private readonly ApiServices _apiServices = new ApiServices();
        public string Response { get; set; }
    }
}