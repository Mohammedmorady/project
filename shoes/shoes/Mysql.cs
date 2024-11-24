using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace shoes
{
    public class mysql
    {
        // متغیر اتصال به دیتابیس
        private MySqlConnection connection;

        // کانستراکتور برای مقداردهی به اتصال به دیتابیس
        public mysql()
        {
            string connectionString = "Server=localhost;Database=kafsh;User ID=root;Password=Mohammad1383@@;";
            connection = new MySqlConnection(connectionString);
        }

        // متد برای ثبت‌نام مشتری جدید
        public void SignupCustomer(string name_kamel, string email, string phone, string password, string username)
        {
            // دستور SQL برای ثبت نام مشتری جدید
            string query = "INSERT INTO moshtary (FullName, Email, Phone, Password, Username) VALUES (@FullName, @Email, @Phone, @Password, @Username)";

            // ایجاد شیء MySqlCommand برای اجرای دستور SQL
            MySqlCommand cmd = new MySqlCommand(query, connection);

            // اضافه کردن پارامترها به دستور SQL
            cmd.Parameters.AddWithValue("@FullName", name_kamel);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                // باز کردن اتصال به دیتابیس
                connection.Open();

                // اجرای دستور SQL
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // در صورت بروز خطا، پیغام خطا نمایش داده می‌شود
                throw new Exception("خطا در ثبت اطلاعات: " + ex.Message);
            }
            finally
            {
                // بستن اتصال به دیتابیس
                connection.Close();
            }
        }
        public bool IsUsernameTaken(string username)
        {
            string query = "SELECT COUNT(1) FROM moshtary WHERE Username = @username UNION SELECT COUNT(1) FROM modir WHERE Username = @username";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    // باز کردن اتصال به دیتابیس
                    connection.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0; // اگر مقدار بیشتر از 0 باشد، یعنی username تکراری است
                }
                catch (Exception ex)
                {
                    throw new Exception("خطا در بررسی نام کاربری: " + ex.Message);
                }
                finally
                {
                    // بستن اتصال به دیتابیس
                    connection.Close();
                }
            }
        }
    }

}
