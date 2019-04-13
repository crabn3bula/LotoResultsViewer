using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using LotoResultsViewer.Models.Data;
using LotoResultsViewer.Models.Entities;
using LotoResultsViewer.Models.Interfaces;
using Newtonsoft.Json;

namespace LotoResultsViewer.Services
{
    public class ApiProviderService
    {
        public ObservableCollection<GameType> GetGameTypes(IApiProvider apiProvider)
        {
            using (var w = new WebClient())
            {
                var jsonData = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    jsonData = w.DownloadString(apiProvider.GetGameTypes());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var message = JsonConvert.DeserializeObject<ResponseMessage>(jsonData);
                    if (message.Status == HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<GameType>>(message.Result.ToString());
                    }
                }
                return null;
            }
        }

        public ObservableCollection<GameResultArchive> GetResultArchive(IApiProvider apiProvider, GameType gameType)
        {
            using (var w = new WebClient())
            {
                var jsonData = string.Empty;
                try
                {
                    jsonData = w.DownloadString(apiProvider.GetGameArchives(gameType));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var message = JsonConvert.DeserializeObject<ResponseMessage>(jsonData);
                    if (message.Status == HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<GameResultArchive>>(message.Result.ToString());
                    }
                }
                return null;
            }
        }
    }
}