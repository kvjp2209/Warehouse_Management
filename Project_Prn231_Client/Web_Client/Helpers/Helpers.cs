using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Web_Client.Helpers
{
    public class Helpers
    {
        public static async Task<TResponse?> GetAsync<TResponse>(string url, string accessToken)
        {
            try
            {
                var httpClient = new HttpClient();
                if (accessToken != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await httpClient.GetAsync(url);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    if (typeof(TResponse) == typeof(Stream))
                    {
                        return (TResponse)(object)await response.Content.ReadAsStreamAsync();
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TResponse>(responseContent);
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }

            await Console.Out.WriteLineAsync("RETURN DEFAULT");
            return default;
        }

        public static async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest? data, string accessToken)
        {
            try
            {
                var httpClient = new HttpClient();
                if (accessToken != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (typeof(TResponse) == typeof(string))
                    {
                        return (TResponse)(object)responseContent;
                    }
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
            return default;
        }

        public static async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest? data, string accessToken)
        {
            try
            {
                var httpClient = new HttpClient();
                if (accessToken != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync(url, httpContent);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
            return default;
        }

        public static async Task<TResponse?> DeleteAsync<TResponse>(string url, string accessToken)
        {
            try
            {
                var httpClient = new HttpClient();
                if (accessToken != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
            return default;
        }
    }
}
