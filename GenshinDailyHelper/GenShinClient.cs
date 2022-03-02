using System;
using System.Net.Http;
using System.Threading.Tasks;
using GenshinDailyHelper.Client;
using Newtonsoft.Json;

namespace GenshinDailyHelper
{
    public class GenShinClient
    {
        /// <summary>
        /// 米游社登录Cookie
        /// </summary>
        public string Cookie { get; }

        protected string OpenApi => "https://api-takumi.mihoyo.com/";

        private HttpClient Client { get; }

        public GenShinClient(string cookie)
        {
            if (string.IsNullOrEmpty(cookie))
            {
                throw new ArgumentException("必须设置cookie后才能请求");
            }

            Cookie = cookie;
            Client = new HttpClient(new HttpClientHandler{UseCookies = false});
        }

        /// <summary>
        /// 对外做出Get请求
        /// </summary>
        /// <param name="path">请求接口路由</param>
        /// <param name="parameters">查询参数</param>
        /// <returns></returns>
        public async Task<T> GetExecuteRequest<T>(string path, string parameters = "")
        {
            var req = new Uri($"{OpenApi}{path}{parameters}");
            return await ExecuteRequest<T>(req, HttpMethod.Get);
        }

        /// <summary>
        /// 对外做出Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        public async Task<T> PostExecuteRequest<T>(string path, string parameters = "",JsonContent jsonContent = null)
        {
            var req = new Uri($"{OpenApi}{path}{parameters}");
            return await ExecuteRequest<T>(req, HttpMethod.Post, jsonContent);
        }

        /// <summary>
        /// 对外做出请求
        /// </summary>
        /// <param name="uri">请求接口</param>
        /// <param name="method">请求方式</param>
        /// <param name="content">请求数据实体</param>
        /// <returns>返回实体对象<see cref="T"/></returns>
        private async Task<T> ExecuteRequest<T>(Uri uri, HttpMethod method, HttpContent content = null)
        {
            using var requestMessage = BuildHttpRequestMessage(uri, method, content);

            var response = await Client.SendAsync(requestMessage);

            var rawResult = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(rawResult);

            return result;
        }

        private HttpRequestMessage BuildHttpRequestMessage(Uri uri, HttpMethod method, HttpContent content = null)
        {
            var requestMessage = new GenshinHttpRequestMessage(method, uri,Cookie);

            if (content != null)
            {
                requestMessage.Content = content;
            }

            return requestMessage;
        }
    }
}
