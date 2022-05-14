using OpenQA.Selenium.Chrome;
using Selenium_w_Tinsoft.Modules;

namespace Selenium_w_Tinsoft
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Mảng chứa Proxy sau khi đã lấy từ Tinsoft (chỉ chứa Proxy live)
        /// </summary>
        private string[]? ProxyList;
        /// <summary>
        /// List chứa các điều khiển Chrome của Selenium
        /// </summary>
        private readonly List<ChromeDriver> ListChrome = new();
        public MainForm()
        { InitializeComponent(); }

        /// <summary>
        /// Sự kiện khi nhấp nút kiểm tra Api
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            #region Save-Proxy-To-List
            // Lấy dữ liệu từng dòng của Rich Text Box về
            var lines = rtbTinsoftKey.Text.Split('\n');
            if (lines.Length > 0)
            {
                //Sau khi kiểm tra thì bỏ vào Array các api còn sống và xuất sẵn ra Proxy
                ProxyList = TinsoftProxy.GetMultipleProxyTinSoft(lines);

                //Xuất hiện lên màn hình số Proxy lấy được
                lblLiveCount.Text = ProxyList?.Length.ToString();
            }
            #endregion Save-Proxy-To-List

            #region Load-Result
            if (ProxyList != null)
            {
                //Hiển thị các Proxy lấy được bỏ lên Rich Text Box chứa kết quả
                rtbResult.Text = string.Empty;
                foreach (var item in ProxyList)
                {
                    if (!string.IsNullOrWhiteSpace(rtbResult.Text))
                    { rtbResult.AppendText("\r\n" + item); }
                    else
                    { rtbResult.AppendText(item); }
                    rtbResult.ScrollToCaret();
                }
            }
            #endregion Load-Result

            #region STOP-CHECK-FAST
            //Chờ đợi 6s sẽ kiểm tra tiếp
            //Không thì Tinsoft sẽ khóa API nhé
            Invoke(new Action(async () =>
            {
                btnCheck.Enabled = false;
                await Task.Delay(TimeSpan.FromSeconds(6));
                btnCheck.Enabled = true;
            }));
            #endregion STOP-CHECK-FAST
        }
        /// <summary>
        /// Sự kiện khi nhấp nút Gán vào Selenium, phần CHECK-CONDITION là mình làm theo ý mình
        /// </summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            #region CHECK-CONDITION
            //Chỗ này mình check theo ý mình
            int ProxyLiveCount;

            //Đếm số ProxyLive
            _ = ProxyList == null ? ProxyLiveCount = 0 : ProxyLiveCount = ProxyList.Length;

            //Tổng số Thread có thể chạy trên số ProxyLive và số luồng trên Proxy
            int TotalThreadAccept = ProxyLiveCount * (int)numThreadPerProxy.Value;

            //Xét kỹ trước khi chạy
            if ((int)numThreadTotal.Value > TotalThreadAccept)
            {
                MessageBox.Show($"Bạn có {ProxyLiveCount} key (proxy) sống, mong muốn là {(int)numThreadPerProxy.Value} luồng trên mỗi key (proxy). " +
                    $"Có nghĩa rằng bạn chỉ có thể chạy tối đa {TotalThreadAccept} luồng. " +
                    $"Mà chạy tận {(int)numThreadTotal.Value} luồng thì hơi vô lý nhé !!!");
            }
            #endregion CHECK-CONDITION

            #region FOR-TASK
            else
            {
                for (int i = 1; i <= (int)numThreadTotal.Value; i++)
                {
                    //Xác định chrome nào chạy key nào
                    decimal tmp = decimal.Divide(i, (int)numThreadPerProxy.Value);
                    int orderNo = (int)Math.Ceiling(tmp);
                    string? proxy = ProxyList?[orderNo - 1]?.ToString();

                    SeleniumHelper sele = new();

                    //Gán Proxy thông qua ChromeOpetions
                    ChromeOptions driverOptions = sele.GetChromeOption(true, proxy);
                    ChromeDriverService driverServices = sele.GetChromeService();

                    //Mình không làm luồng Thread hay Task nhé, chạy trên luồng chính luôn vì chỉ test mà
                    ListChrome.Add(new ChromeDriver(driverServices, driverOptions));
                }
            }

            foreach (var driver in ListChrome)
            {
                //Di chuyển đến trang này để kiểm tra Proxy đã nhập chưa
                driver.Navigate().GoToUrl(@"https://api.myip.com/");
            }
            #endregion FOR-TASK
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var driver in ListChrome)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}