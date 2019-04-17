using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using JetBrains.Annotations;
using LotoResultsViewer.Models.Data;
using LotoResultsViewer.Models.Entities;
using LotoResultsViewer.Models.Interfaces;
using Newtonsoft.Json;

namespace LotoResultsViewer.Services
{
    public class ApiProviderService
    {
        public ObservableCollection<GameType> GetGameTypes([NotNull] IApiProvider apiProvider)
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
                    var message = JsonConvert.DeserializeObject<ResponseMessage<ObservableCollection<GameType>>>(jsonData);
                    if (message !=null && message.Status == HttpStatusCode.OK)
                    {
                        return message.Result;
                    }
                }
                return null;
            }
        }

        public ObservableCollection<GameResultTirage> GetResultArchive([NotNull] IApiProvider apiProvider, GameType gameType)
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
                    ObservableCollection<GameResultTirage> tiregesList = new ObservableCollection<GameResultTirage>();
                    var message = JsonConvert.DeserializeObject<ResponseMessage<List<Dictionary<string, Dictionary<string, List<GameResultTirage>>>>>>(jsonData);
                    foreach (var mes in message.Result[0].Values)
                    {
                        foreach (var tirages in mes.Values)
                        {
                            foreach (var tirage in tirages)
                            {
                                tiregesList.Add(tirage);
                            }
                        }
                    }

                    if (message != null &&  message.Status == HttpStatusCode.OK)
                    {
                        return tiregesList;
                    }
                }
                return null;
            }
        }
    }
}