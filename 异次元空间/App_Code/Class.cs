using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;
/// <summary>
/// Class 的摘要说明
/// </summary>
public class Class
{
    static string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
    public Class()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static int Put(string sql)
    {
        try
        {
           
            SqlConnection conn = new SqlConnection(str);
            DataTable ds = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
            return 0;
        }
    }
    public static string Search(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][1].ToString();
    }
    public static string Search7(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][4].ToString();
    }
    public static string Search8(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][16].ToString();
    }
    public static string Search3(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][2].ToString();
    }
    public static string Search1(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][5].ToString();
    }
    public static string Search6(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][8].ToString();
    }
    public static string Search4(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][0].ToString();
    }
    public static bool IsCorrenctIP(string ip)
    {
        string emailPattern = @"^([a-z0-9A-Z]+[-|\.]?)+[a-z0-9A-Z]@([a-z0-9A-Z]+(-[a-z0-9A-Z]+)?\.)+[a-zA-Z]{2,}$";
        bool match = Regex.IsMatch(ip, emailPattern);
        if (match)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int exist(string sql)
    {
        try
        {
            SqlConnection conn = new SqlConnection(str);
            DataTable dt = new DataTable();
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            int count = dt.Rows.Count;
            conn.Close();
            if (count > 0)
            {
                return 1;
            }
            else return 0;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }

    }
    public static int exist2(string sql)
    {
        try
        {
            SqlConnection conn = new SqlConnection(str);
            DataTable dt = new DataTable();
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            int count = dt.Rows.Count;
            conn.Close();
            if (count > 0)
            {
                return count;
            }
            else return 0;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }

    }
    public class HashEncode
    {
        public HashEncode()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 得到随机哈希加密字符串
        /// </summary>
        /// <returns></returns>
        public static string GetSecurity()
        {
            string Security = HashEncoding(GetRandomValue());
            return Security;
        }
        /// <summary>
        /// 得到一个随机数值
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {
            Random Seed = new Random();
            string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
            return RandomVaule;
        }
        /// <summary>
        /// 哈希加密一个字符串，outofmemory.cn
        /// </summary>
        /// <param name="Security"></param>
        /// <returns></returns>
        public static string HashEncoding(string Security)
        {
            byte[] Value;
            UnicodeEncoding Code = new UnicodeEncoding();
            byte[] Message = Code.GetBytes(Security);
            SHA512Managed Arithmetic = new SHA512Managed();
            Value = Arithmetic.ComputeHash(Message);
            Security = "";
            foreach (byte o in Value)
            {
                Security += (int)o + "O";
            }
            return Security;
        }
    }
    public class Send : System.Web.UI.Page
    {
        /// <summary> 
        /// 发送电子邮件 
        /// </summary> 
        /// <param name="MessageFrom">发件人邮箱地址 </param> 
        /// <param name="MessageTo">收件人邮箱地址 </param> 
        /// <param name="MessageSubject">邮件主题 </param> 
        /// <param name="MessageBody">邮件内容 </param> 
        /// <returns> </returns> 
        public static bool Sendemails(string MessageFrom, string MessageTo, string MessageSubject, string MessageBody)
        {
            MailMessage message = new MailMessage();
            MailAddress from = new MailAddress(MessageFrom);
            message.From = from;
            MailAddress messageto = new MailAddress(MessageTo);
            message.To.Add(messageto);              //收件人邮箱地址可以是多个以实现群发 
            message.Subject = MessageSubject;
            message.Body = MessageBody;
            message.IsBodyHtml = true;              //是否为html格式 
            message.Priority = MailPriority.High;   //发送邮件的优先等级
                                                    //指定发送邮件的服务器地址或IP 
                                                    //指定发送邮件端口
            SmtpClient client = new SmtpClient("smtp.qq.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("736768307@qq.com", "bhhiygsqeryzbcdd"); //指定登录服务器的用户名和密码  
            //sc.Credentials = new System.Net.NetworkCredential("736768307@qq.com", "bhhiygsqeryzbcdd"); //指定登录服务器的用户名和密码  


            client.Send(message);       //发送邮件                              
            return true;
        }
    }
    public static DataTable Table(string sql)
    {

        SqlConnection conn = new SqlConnection(str);
        DataTable ds = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public static string Search2(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][0].ToString();
    }
    public static string Search5(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt.Rows[0][7].ToString();
    }
    public static int exist1(string sql)
    {
        try
        {
            SqlConnection conn = new SqlConnection(str);
            DataTable dt = new DataTable();
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            int count = dt.Rows.Count;
            conn.Close();
            if (count > 0)
            {
                return count;
            }
            else return 0;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }

    }
}



