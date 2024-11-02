using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fahrgemeinschaftsplattform.Services
{
    public class RouteService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("GoogleMapsApiKey"); 
        private readonly HttpClient httpClient;

        public RouteService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetRouteAsync(string origin, string destination)
        {
            var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={origin}&destination={destination}&key={apiKey}";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new Exception("Fehler beim Abrufen der Route: " + response.ReasonPhrase);
            }
        }
    }
}
