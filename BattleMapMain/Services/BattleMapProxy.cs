using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;


namespace BattleMapMain.Services
{
    public class BattleMapProxy
    {
        #region without tunnel
        /*
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "localhost";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110/api/" : $"http://{serverIP}:5110/api/";
        private static string ImageBaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110" : $"http://{serverIP}:5110";
        */
        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "nln3m383-5219.uks1.devtunnels.ms";
        private readonly HubConnection hubConnection;
        private string baseUrl;
        public static string BaseAddress = "https://nln3m383-5219.uks1.devtunnels.ms/BattleMapHub/";
        #endregion

        public BattleMapProxy()
        {
            string hubUrl = GetHubUrl();
            hubConnection = new HubConnectionBuilder().WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .WithKeepAliveInterval(TimeSpan.FromSeconds(10))
                .WithServerTimeout(TimeSpan.FromSeconds(120))
                .ConfigureLogging(logging =>
                {
                    // Log to the Console
                    logging.AddDebug();

                    // This will set ALL logging to Debug level
                    logging.SetMinimumLevel(LogLevel.Debug);
                }).Build();

        }

        private string GetHubUrl()
        {
            return BaseAddress;
        }
        //Connect 
        public async Task<string> Connect(string sessionCode, int userId,  bool isCreator)
        {

            try
            {
                await hubConnection.StartAsync();
                string errorMsg = await hubConnection.InvokeAsync<string>("AddToGroup", sessionCode, userId, isCreator);
                if (errorMsg != "")
                {
                    await hubConnection.StopAsync();
                    await Application.Current.MainPage.DisplayAlert("Session", errorMsg, "ok");
                }
                    
                return errorMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Use this method when the chat is finished so the connection will not stay open
        public async Task Disconnect(string sessionCode)
        {
            try
            {
                await hubConnection.InvokeAsync("RemoveFromGroup", sessionCode);
                await hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //This message send a message to the specified userId
        public async Task SendDetails(MapDetails details)
        {
            try
            {                
                await hubConnection.InvokeAsync("UpdateMapDetails", details, "123");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //this method register a method to be called upon receiving a message from other user id
        public async Task RegisterToUpdateDetails(Action<MapDetails> UpdateMapDetails)
        {
            hubConnection.On<MapDetails>("UpdateMap", UpdateMapDetails);
        }
        public async Task RegisterToUpdateUsers(Action<User> UpdateUsers)
        {
            hubConnection.On<User>("UpdateUsers", UpdateUsers);
        }

    }
}
