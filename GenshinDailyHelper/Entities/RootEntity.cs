﻿using System;
using System.Threading;
using GenshinDailyHelper.Exception;
using Newtonsoft.Json;

namespace GenshinDailyHelper.Entities
{
    /// <summary>
    /// 返回头部信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RootEntity<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("retcode")]
        public int Retcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; } = Activator.CreateInstance<T>();

        /// <summary>
        /// 判断返回码并延迟
        /// </summary>
        /// <returns></returns>
        public virtual string CheckOutCodeAndSleep()
        {
            Random ran = new Random();
            int randKey = ran.Next(500, 2000);
            Thread.Sleep(randKey);

            switch (Retcode)
            {
                case 0:
                    return "执行成功";
                case -5003:
                    return "已经签到";
                default:
                    throw new GenShinException($"请求异常{Message}");
            }
        }

        public override string ToString()
        {
            return $"返回码为{Retcode}";
        }
    }
}
