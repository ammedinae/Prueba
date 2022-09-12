using Newtonsoft.Json;
using Prueba.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Prueba.Web.Service
{
    public class UtilApi
    {
        public static string ObtenerToken()
        {
            try
            {
                string tokens = null;
                string Url = ConfigurationManager.AppSettings["Url"];
                HttpClient tokenHttp = new HttpClient();
                tokenHttp.BaseAddress = new Uri(Url);

                var user = "userPrueba";
                var password = "userPrueba";

                var Request = new Dictionary<string, string>
                    {
                        {"UserName", user },
                        {"Password", password }
                    };
                var APIResponse = tokenHttp.PostAsync("api/login/authenticate", new FormUrlEncodedContent(Request)).Result;
                if (APIResponse.IsSuccessStatusCode)
                {
                    var resultString = APIResponse.Content.ReadAsStringAsync().Result;
                    tokens = JsonConvert.DeserializeObject<string>(resultString);
                }

                return tokens;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool CrearSeller(SellerDto sellerDto)
        {
            bool Validar = false;

            string Url = ConfigurationManager.AppSettings["Url"] + "/api/Seller/SellerCrear";
            string Token = ObtenerToken();
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        request.Content = new StringContent(JsonConvert.SerializeObject(sellerDto), Encoding.UTF8, "application/json");
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            Validar = true;
                        }
                    }
                }
            }
            return Validar;
        }

        public static bool EliminarSeller(long id)
        {
            bool Validar = false;

            string Url = ConfigurationManager.AppSettings["Url"] + "/api/Seller/SellerEliminar?id="+id;
            string Token = ObtenerToken();
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            Validar = true;
                        }
                    }
                }
            }
            return Validar;
        }

        public static List<SellerDto> ObtenerSeller()
        {
            List<SellerDto> sellerDtos = new List<SellerDto>();
            string Url = ConfigurationManager.AppSettings["Url"] + "/api/Seller/SellerConsulta";

            string Token = ObtenerToken();

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            string Json = Respuesta.Content.ReadAsStringAsync().Result;
                            sellerDtos = JsonConvert.DeserializeObject<List<SellerDto>>(Json);
                        }
                    }
                }
            }
            return sellerDtos;
        }

        public static SellerDto ObtenerSellerId(long id)
        {
            SellerDto sellerDtoss = new SellerDto();
            string Url = ConfigurationManager.AppSettings["Url"] + "/api/Seller/SellerConsulaId?id=" + id;

            string Token = ObtenerToken();

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            string Json = Respuesta.Content.ReadAsStringAsync().Result;
                            sellerDtoss = JsonConvert.DeserializeObject<SellerDto>(Json);
                        }
                    }
                }
            }
            return sellerDtoss;
        }

        public static List<CityDto> ObtenerCity()
        {
            List<CityDto> cityDtos = new List<CityDto>();
            string Url = ConfigurationManager.AppSettings["Url"] + "/api/City/City";

            string Token = ObtenerToken();

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            string Json = Respuesta.Content.ReadAsStringAsync().Result;
                            cityDtos = JsonConvert.DeserializeObject<List<CityDto>>(Json);
                        }
                    }
                }
            }
            return cityDtos;
        }
    }
}