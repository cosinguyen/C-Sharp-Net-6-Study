using FacebookCookies_w_Selenium.Modules;

namespace FacebookCookies_w_Selenium
{
    public partial class MainForm : Form
    {
        SeleniumHelper? sele;

        public MainForm()
        { InitializeComponent(); }
        protected override void OnFormClosing(FormClosingEventArgs e)
        { this.sele?.Dispose(); }
        private void btnOpenChrome_Click(object sender, EventArgs e)
        {
            this.sele?.Dispose();
            this.sele = new(true);
        }

        private void btnGetCookies_Click(object sender, EventArgs e)
        {
            if (this.sele == null) return;

            var cookie = this.sele.GetCookies();
            txtOutput.Text = string.Format("c_user={0};xs={1};datr={2};fr={3};wd={4};spin={5};locale={6};sb={7}",
                cookie.c_user, cookie.xs, cookie.datr, cookie.fr, cookie.wd, cookie.spin, cookie.locale, cookie.sb);
        }

        private void btnLoadCookies_Click(object sender, EventArgs e)
        {
            if (this.sele == null) return;

            //Nạp dữ liệu vô biến từ chỗ nhập Cookies
            string cookiesString = txtInput.Text.Trim().ToString();

            //Kiểm tra nếu không rỗng thì xử lý tiếp
            if (!string.IsNullOrWhiteSpace(cookiesString))
            {
                //Gọi phương thức nhập Cookies vào driver
                this.sele?.ImportFacebookCookie(cookiesString);
            }
        }
    }
}