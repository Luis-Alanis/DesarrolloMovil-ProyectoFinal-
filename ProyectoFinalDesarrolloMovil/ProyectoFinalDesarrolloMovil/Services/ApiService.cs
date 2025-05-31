using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Models;
using System.Text.Json;
using ProyectoFinalDesarrolloMovil.Helpers;

namespace ProyectoFinalDesarrolloMovil.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client;

        static ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            client = new HttpClient(handler)
            {
                BaseAddress = new Uri(AppSettings.ApiBaseUrl)
            };
        }

        public static async Task<List<Gasto>> ObtenerGastosAsync()
        {
            var response = await client.GetAsync("gastos");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Gasto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<Gasto> ObtenerGastoPorIdAsync(int id)
        {
            var response = await client.GetAsync($"gastos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Gasto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }


        public static async Task AgregarGastoAsync(Gasto gasto)
        {
            var json = JsonSerializer.Serialize(gasto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("gastos", content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task EditarGastoAsync(Gasto gasto)
        {
            var json = JsonSerializer.Serialize(gasto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"gastos/{gasto.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task EliminarGastoAsync(int id)
        {
            var response = await client.DeleteAsync($"gastos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}