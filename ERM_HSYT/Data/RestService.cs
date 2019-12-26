using ERM_HSYT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ERM_HSYT.Data
{
    public class RestService
    {
        HttpClient _client;
        HospitalInformation _baseHospital;
        public RestService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public RestService(HospitalInformation hospital) : this()
        {
            _baseHospital = hospital.Clone();
        }

        public async Task<Token> Login(LoginUser user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", _baseHospital.grantType));
            postData.Add(new KeyValuePair<string, string>("client_id", _baseHospital.clientId));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponse<Token>(_baseHospital.LoginUrl, content);

            return response;
        }

        public async Task<T> PostResponse<T>(string weburl, FormUrlEncodedContent content)
        {
            var response = await _client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);

            return responseObject;
        }

        // change password
        public async Task<bool> ChangePassword(string url, string accessToken, ChangePasswordRequest changePasswordRequest)
        {
            try
            {
                var request = JsonConvert.SerializeObject(changePasswordRequest);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

                var response = await _client.PostAsync(url, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> PostLichHen(string weburl, LichHenPost postData)
        {
            var Token = App.TokenDatabase.GetToken();
            try
            {

                var test = postData;
                var jsonLichHenPost = JsonConvert.SerializeObject(postData);
                /*JavaScriptSerializer serializer = new JavaScriptSerializer();
                var jsonLichHenPost = serializer.Serialize(postData);*/
                var content = new StringContent(jsonLichHenPost, Encoding.UTF8, "application/json");
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);

                var response = await _client.PostAsync(weburl, content);
                Trace.Write("Lich Hen: " + response);
                Trace.Write("JSON: " + jsonLichHenPost);
                /*if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonResult;
                }*/
                return response.IsSuccessStatusCode;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var Result = await _client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }


        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var response = await _client.GetAsync(weburl);
                Trace.Write(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    Trace.Write(JsonResult);
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        Trace.Write("Ham Get Response");
                        Trace.Write(ContentResp);
                        return ContentResp;
                    }
                    catch (Exception e)
                    {
                        Trace.Write(e);
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

    }
}
