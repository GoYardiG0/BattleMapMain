using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BattleMapMain.Classes_and_Objects;
using Microsoft.AspNetCore.SignalR.Client;

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
                .WithServerTimeout(TimeSpan.FromSeconds(120)).Build();

        }

        private string GetHubUrl()
        {
            return BaseAddress;
        }
        //Connect 
        public async Task Connect(string userId)
        {
            try
            {
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("AddToGroup", "123");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Use this method when the chat is finished so the connection will not stay open
        public async Task Disconnect()
        {
            try
            {
                await hubConnection.InvokeAsync("RemoveFromGroup", "123");
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
        public void RegisterToUpdateDetails(Action<MapDetails> UpdateMapDetails)
        {
            hubConnection.On("UpdateMap", UpdateMapDetails);
        }

    }
}
