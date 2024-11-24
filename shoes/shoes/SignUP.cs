using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace shoes
{
    public partial class SignUP : Form
    {
        private mysql dbHelper;     //msql ایجاد شئ از کلاس
        public SignUP()
        {
            InitializeComponent();
            dbHelper = new mysql();  // مقداردهی به dbHelper
        }

        private void SignUP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullname = textBox1.Text.Trim();
            string username = textBox2.Text.Trim(); // دریافت مقدار از textBox6 (username)
            string phone = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();

            // اعتبار سنجی فیلدها
            if (string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password)
                ) // اضافه کردن اعتبارسنجی برای username
            {
                MessageBox.Show("لطفاً تمام فیلدها را پر کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // بررسی نام کاربری
            bool isUsernameTaken = dbHelper.IsUsernameTaken(username);
            if (isUsernameTaken)
            {
                MessageBox.Show("این نام کاربری قبلاً استفاده شده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // اعتبار سنجی پیچیدگی پسورد
            //if (!IsPasswordComplex(password))
            //{
            //    MessageBox.Show("رمز عبور باید حداقل5 کاراکتر باشد و شامل حروف بزرگ، کوچک، عدد و کاراکتر خاص باشد.",
            //                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // بررسی تطابق پسوردها
            if (password != textBox5.Text)
            {
                MessageBox.Show("رمز عبور و تأییدیه آن مطابقت ندارند.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // فراخوانی متد درج اطلاعات
                dbHelper.SignupCustomer(fullname, email, phone, password, username); // ارسال username به متد
                MessageBox.Show("ثبت‌نام با موفقیت انجام شد!", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Sigin form = new Sigin();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ثبت اطلاعات: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // اعتبارسنجی رمز عبور
        //private bool IsPasswordComplex(string password)
        //{
        //    if (password.Length < 5)
        //        return false;

        //    if (!password.Any(char.IsLower))
        //        return false;

        //    if (!password.Any(char.IsUpper))
        //        return false;

        //    if (!password.Any(char.IsDigit))
        //        return false;

        //    if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
        //        return false;

        //    return true;
        //}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;  // جلوگیری از وارد کردن غیر عدد
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
