using Newtonsoft.Json;

namespace Selenium_w_Tinsoft.Modules
{
    public class TinsoftProxy
    {
        /// <summary>
        /// Đối tượng chứa các thuộc tính từ kết quả của Tinsoft
        /// </summary>
        private class TinsoftJson
        {
            public bool success { get; set; }
            public string? proxy { get; set; }
            public string? description { get; set; }
        }
        /// <summary>
        /// Kiểm tra 1 key duy nhất, dùng cho các mục đích khác
        /// </summary>
        /// <param name="apiKey">Api key Tinsoft</param>
        internal static string? GetOneTinsoftProxy(string apiKey)
        {

            if (string.IsNullOrWhiteSpace(apiKey)) return null;

            var resultTinsoft = GetProxy<TinsoftJson>(apiKey, 1);

            if (resultTinsoft.success && !string.IsNullOrWhiteSpace(resultTinsoft.proxy))
            { return resultTinsoft.proxy; }
            else if (resultTinsoft.description == "wrong key!")
            { MessageBox.Show("Key Tinsoft của bạn nhập sai hoặc key không tồn tại!!!"); }
            else if (resultTinsoft.description == "key expired!")
            { MessageBox.Show("Key Tinsoft của bạn đã hết hạn rồi!!!"); }
            else if (!string.IsNullOrWhiteSpace(resultTinsoft.description) && resultTinsoft.description.StartsWith("wait "))
            {
                var requestTinsoft = GetProxy<TinsoftJson>(apiKey, 2);
                if (requestTinsoft.success && !string.IsNullOrWhiteSpace(requestTinsoft.proxy))
                { return requestTinsoft.proxy; }
                else if (requestTinsoft.description == "proxy not found!")
                { MessageBox.Show("Proxy đã tạo ra trước đó từ Key này vừa hết hạn sử dụng. Vui lòng thao tác lại để cấp mới."); }
            }
            else if (resultTinsoft.description == "Request so fast, fix your code or be banned (wait 6s per key)!")
            { MessageBox.Show("Cảnh báo của Tinsoft, bạn có thể bị khóa Key nếu tiếp tục thao tác"); }
            return null;
        }
        /// <summary>
        /// Nhập vào mảng chứa các API Key sau đó lấy Proxy từ đó rồi trả về mảng
        /// </summary>
        /// <param name="apiKeys">Mảng string[] chứa các ApiKey cần lấy Proxy</param>
        internal static string[]? GetMultipleProxyTinSoft(string[] apiKeys)
        {
            if (apiKeys.Length > 0)
            {
                List<string> list = new();
                foreach (var apiKey in apiKeys)
                {
                    if (string.IsNullOrWhiteSpace(apiKey)) continue;

                    var resultTinsoft = GetProxy<TinsoftJson>(apiKey, 1);
                    if (resultTinsoft.success && !string.IsNullOrWhiteSpace(resultTinsoft.proxy))
                    { list.Add(resultTinsoft.proxy); }
                    else if (!string.IsNullOrWhiteSpace(resultTinsoft.description) && resultTinsoft.description.StartsWith("wait "))
                    {
                        resultTinsoft = GetProxy<TinsoftJson>(apiKey, 2);
                        if (resultTinsoft.success && !string.IsNullOrWhiteSpace(resultTinsoft.proxy))
                        { list.Add(resultTinsoft.proxy); }
                    }
                }
                return list.ToArray();
            }
            return null;
        }
        /// <summary>
        /// Truy vấn đến máy chủ Tinsoft để lấy Proxy từ API key
        /// </summary>
        /// <typeparam name="T">Đối tượng cần dùng để trả ra ví dụ <see cref="TinsoftJson"/></typeparam>
        /// <param name="apiKey">API key được cấp từ Tinsoft</param>
        /// <param name="task">Cấp mới sẽ là 1 và cấp lại sẽ nhập 2</param>
        private static T GetProxy<T>(string apiKey, int task, int location = 0) where T : new()
        {
            string url = string.Empty;
            if (task == 1)
            //Lấy Proxy từ API, mặc định không điền thì location = 0 tức là Random
            //Lấy các mã Location tại http://proxy.tinsoftsv.com/api/getLocations.php
            //Cần sửa lại cú pháp nhập mảng và phân tách mảng nếu cần thiết để nhập location
            { url = @"http://proxy.tinsoftsv.com/api/changeProxy.php?key=" + apiKey + @"&location=" + location; }
            else if (task == 2)
            //Với trường hợp này thì không cần Location nữa vì nó lấy lại IP được cấp thì đã được gán location lúc tạo Proxy
            { url = @"http://proxy.tinsoftsv.com/api/getProxy.php?key=" + apiKey; }

            if (!string.IsNullOrEmpty(url))
            {
                //Dùng HttpClient để lấy dữ liệu về, nếu có dùng xNet nên dùng tại đây tránh khởi tạo quá nhiều tài nguyên cùng chức năng
                using HttpClient web = new();
                HttpResponseMessage? response = web.GetAsync(url).Result;
                string? json_data = response?.Content?.ReadAsStringAsync().Result;

                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
            return new T();
        }
    }
}