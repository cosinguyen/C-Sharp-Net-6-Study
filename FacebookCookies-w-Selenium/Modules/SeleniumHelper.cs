using FacebookCookies_w_Selenium.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace FacebookCookies_w_Selenium.Modules
{
    internal class SeleniumHelper
    {
        private readonly Regex regUID = new(@"(?<=c_user=)([^;]+)");
        private readonly Regex regXS = new(@"(?<=xs=)([^;]+)");
        private readonly Regex regDATR = new(@"(?<=datr=)([^;]+)");
        private readonly Regex regFR = new(@"(?<=fr=)([^;]+)");
        private readonly Regex regWD = new(@"(?<=wd=)([^;]+)");
        private readonly Regex regSPIN = new(@"(?<=spin=)([^;]+)");
        private readonly Regex regLOCALE = new(@"(?<=locale=)([^;]+)");
        private readonly Regex regSB = new(@"(?<=sb=)([^;]+)");
        /// <summary>
        /// Biến ChromeDriver
        /// </summary>
        private ChromeDriver driver;
        /// <summary>
        /// Biến Random dùng để Random các UserAgent
        /// </summary>
        private readonly Random random = new();
        /// <summary>
        /// Danh sách cách UserAgent lấy từ trang https://developers.whatismybrowser.com/useragents/explore/
        /// </summary>
        private readonly string[] ua = new string[]
        {
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.129 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.122 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.113 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.122 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.87 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.116 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.106 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36"
        };
        /// <summary>
        /// Khởi tạo Chrome
        /// </summary>
        /// <param name="_ua">Bật hay tắt chức năng Fake UA</param>
        /// <param name="_proxy">Nhập Proxy vào hoặc bỏ qua sẽ dùng IP của mạng</param>
        internal SeleniumHelper(bool _ua, string? _proxy = null)
        {
            ChromeOptions driverOptions = GetChromeOption(_ua, _proxy);
            ChromeDriverService driverServices = GetChromeService();
            this.driver = new ChromeDriver(driverServices, driverOptions);
        }

        private ChromeOptions GetChromeOption(bool _ua, string? _proxy = null)
        {
            ChromeOptions options = new();
            options.AddArguments("--mute-audio", "--blink-settings=imagesEnabled=false", "--disable-notifications", "--ignore-certificate-errors", "--disable-gpu");
            options.AddExcludedArgument("enable-automation");
            if (_ua)
            {
                //Nếu người dùng nạp vô True thì fake UA bằng đống UA random ở trên, fail thì dùng UA gốc của máy
                options.AddArgument("user-agent=" + GetUA());
            }
            if (!string.IsNullOrWhiteSpace(_proxy))
            {
                //Nếu có proxy đã nhập ở trên thì nạp vô cho Chrome luôn
                options.AddArgument("--proxy-server=" + _proxy);
            }
            return options;
        }
        private string GetUA()
        {
            int uaIndex = random.Next(0, ua.Length);
            return ua[uaIndex].ToString();
        }
        private ChromeDriverService GetChromeService()
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            return driverService;
        }
        /// <summary>
        /// Tắt Chrome
        /// </summary>
        internal void Dispose()
        {
            this.driver?.Quit();
            this.driver?.Dispose();
        }
        /// <summary>
        /// Import Facebook Cookies vào Chrome
        /// </summary>
        /// <param name="cookies">Đối tượng Facebook Cookies</param>
        internal void ImportFacebookCookie(string cookiesString)
        {
            this.driver.Navigate().GoToUrl(@"https://m.facebook.com");
            this.driver.Manage().Cookies.DeleteAllCookies();
            this.driver.Navigate().Refresh();

            FacebookCookies cookies = StringToFacebookCookies(cookiesString);

            if (cookies.c_user != null)
            {
                Cookie c_user = new("c_user", cookies.c_user.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, false, "None");
                this.driver.Manage().Cookies.AddCookie(c_user);
            }
            if (cookies.fr != null)
            {
                Cookie fr = new("fr", cookies.fr.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, true, "None");
                this.driver.Manage().Cookies.AddCookie(fr);
            }
            if (cookies.xs != null)
            {
                Cookie xs = new("xs", cookies.xs.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, true, "None");
                this.driver.Manage().Cookies.AddCookie(xs);
            }
            if (cookies.datr != null)
            {
                Cookie datr = new("datr", cookies.datr.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, true, "None");
                this.driver.Manage().Cookies.AddCookie(datr);
            }
            if (cookies.wd != null)
            {
                Cookie wd = new("wd", cookies.wd.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, false, "Lax");
                this.driver.Manage().Cookies.AddCookie(wd);
            }
            if (cookies.spin != null)
            {
                Cookie spin = new("spin", cookies.spin.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, true, "None");
                this.driver.Manage().Cookies.AddCookie(spin);
            }
            if (cookies.locale != null)
            {
                Cookie locale = new("locale", cookies.locale.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, false, "None");
                this.driver.Manage().Cookies.AddCookie(locale);
            }
            if (cookies.sb != null)
            {
                Cookie sb = new("sb", cookies.sb.ToString(), @".facebook.com", @"/", DateTime.Now.AddDays(5), true, true, "None");
                this.driver.Manage().Cookies.AddCookie(sb);
            }

            this.driver.Navigate().Refresh();
        }

        private FacebookCookies StringToFacebookCookies(string cookieString)
        {
            FacebookCookies cookies = new();
            if (cookieString != null)
            {
                cookies.c_user = regUID.Match(cookieString).ToString();
                cookies.datr = regDATR.Match(cookieString).ToString();
                cookies.xs = regXS.Match(cookieString).ToString();
                cookies.fr = regFR.Match(cookieString).ToString();
                cookies.wd = regWD.Match(cookieString).ToString();
                cookies.spin = regSPIN.Match(cookieString).ToString();
                cookies.locale = regLOCALE.Match(cookieString).ToString();
                cookies.sb = regSB.Match(cookieString).ToString();
            }
            return cookies;
        }

        /// <summary>
        /// Lấy Cookies Facebook từ Chrome
        /// </summary>
        internal FacebookCookies GetCookies()
        {
            this.driver.Navigate().GoToUrl(@"https://m.facebook.com");
            var cookie = this.driver.Manage().Cookies.AllCookies;

            FacebookCookies cookies = new();
            foreach (var item in cookie)
            {
                if (item.Domain == @".facebook.com" && item.Name == "wd")
                { cookies.wd = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "spin")
                { cookies.spin = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "fr")
                { cookies.fr = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "xs")
                { cookies.xs = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "c_user")
                { cookies.c_user = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "locale")
                { cookies.locale = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "datr")
                { cookies.datr = item.Value; continue; }
                if (item.Domain == @".facebook.com" && item.Name == "sb")
                { cookies.sb = item.Value; continue; }
            }
            return cookies;
        }
    }
}
