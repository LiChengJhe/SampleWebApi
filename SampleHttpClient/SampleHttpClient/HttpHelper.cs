using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleHttpClient
{
    public class HttpConnection : IDisposable
    {
        private string _MediaType;
        private string _Url;
        private HttpClient _Client;
        public HttpConnection(string url, string mediaType = "application/json")
        {
            this._MediaType = mediaType;
            this._Url = url;
            this._Client = new HttpClient();
        }
        public async Task<T> PostAsync<T>(T obj)
        {
            T result = default(T);
            try
            {
                HttpResponseMessage response = null;
                this._Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this._MediaType));
                this._Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", this._MediaType);
                string json = JsonConvert.SerializeObject(obj);
                using (StringContent content = new StringContent(json, Encoding.UTF8, this._MediaType))
                {
                    response = await this._Client.PostAsync(this._Url, content).ConfigureAwait(false);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            String strResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            result = JsonConvert.DeserializeObject<T>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                        }
                        else throw new Exception(JsonConvert.SerializeObject(response));
                    }
                    else throw new Exception("Web API Response Error");
                }


            }
            catch
            {
                throw;
            }
            return result;
        }
        public async Task<T> PutAsync<T>(T obj)
        {
            T result = default(T);
            try
            {


                HttpResponseMessage response = null;
                this._Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this._MediaType));
                this._Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", this._MediaType);
                string json = JsonConvert.SerializeObject(obj);
                using (StringContent content = new StringContent(json, Encoding.UTF8, this._MediaType))
                {
                    response = await this._Client.PutAsync(this._Url, content).ConfigureAwait(false);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            String strResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            result = JsonConvert.DeserializeObject<T>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                        }
                        else throw new Exception(JsonConvert.SerializeObject(response));
                    }
                    else throw new Exception("Web API Response Error");
                }


            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<T> PatchAsync<T>(T obj)
        {
            T result = default(T);
            try
            {


                HttpResponseMessage response = null;
                this._Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this._MediaType));
                this._Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", this._MediaType);
                string json = JsonConvert.SerializeObject(obj);
                using (StringContent content = new StringContent(json, Encoding.UTF8, this._MediaType))
                {
                    response = await this._Client.PatchAsync(this._Url, content).ConfigureAwait(false);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            String strResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            result = JsonConvert.DeserializeObject<T>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                        }
                        else throw new Exception(JsonConvert.SerializeObject(response));
                    }
                    else throw new Exception("Web API Response Error");
                }


            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<T> GetAsync<T>()
        {
            T result = default(T);
            try
            {


                HttpResponseMessage response = null;
                this._Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this._MediaType));
                this._Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", this._MediaType);
                response = await this._Client.GetAsync(this._Url).ConfigureAwait(false);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        String strResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<T>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                    }
                    else throw new Exception(JsonConvert.SerializeObject(response));
                }
                else throw new Exception("Web API Response Error");

            }
            catch
            {
                throw;
            }
            return result;
        }
        public async Task<T> DeleteAsync<T>()
        {
            T result = default(T);
            try
            {

                HttpResponseMessage response = null;
                this._Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this._MediaType));
                this._Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", this._MediaType);
                response = await this._Client.DeleteAsync(this._Url).ConfigureAwait(false);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        String strResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<T>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                    }
                    else throw new Exception(JsonConvert.SerializeObject(response));
                }
                else throw new Exception("Web API Response Error");

            }
            catch
            {
                throw;
            }
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。
                if (this._Client != null) this._Client.Dispose();
                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        ~HttpConnection()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(false);
        }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            GC.SuppressFinalize(this);
        }
        #endregion


    }
    public static class HttpHelper
    {
        public static HttpConnection GetConnection(string url, string mediaType = "application/json")
        {
            return new HttpConnection(url, mediaType);
        }
    }
}
