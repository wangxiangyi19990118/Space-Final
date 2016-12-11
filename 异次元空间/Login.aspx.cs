using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton1.ImageUrl = "verification.aspx";
    }
    protected void btnRegester_Click(object sender, EventArgs e)
    {
        string ID = txtID.Text.Trim ();
        string pwd = txtpwd.Text;
        string hspwd1 = Class.HashEncode.HashEncoding(pwd);
        string vcode = Vcode.Text;
        //string sql = "select * from tabUsers where ID=@ID and hspwd=@hspwd";
        if (ID.Length == 0 || pwd.Length == 0)
        {
            Response.Write("<script>alert('登录失败，账号、密码不为空！')</script>");
            return;
        }
        else if (Session["Vnum"].ToString() != Vcode.Text.Trim())
        {
            Response.Write("<script>alert('登录失败，请检查验证码！')</script>");
            return;
        }
        else
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID=@ID and hspwd=@hspwd";
                        Cmd.Parameters.Add(new SqlParameter("@ID", ID));
                        Cmd.Parameters.Add(new SqlParameter("@hspwd", hspwd1));
                        int count = Convert.ToInt32(Cmd.ExecuteScalar());

                        if (count > 0)
                        { 
                            Session["ID1"] = ID;
                            string sql = "select*from tabUsers where id='" + ID + "'";
                            string name = Class.Search(sql);
                            Session["name"] = name;
                            Response.Write("<script>alert('登录成功！');location='Space.aspx'</script>");
                        }
                        else
                            Response.Write("<script>alert('登录失败，请正确填写账号、密码！')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            /*else
                    {
                        int result = Class.exist(sql);
                        if (result != 1)
                        {
                            Response.Write("<script>alert('登录失败，请正确填写账号、密码！')</script>");
                            return;

                        }
                        else
                        {  
                            string name = Class.Search(sql);
                            string ID1 = txtID.Text;
                            /*HttpCookie myCookie = new HttpCookie("someCookie");
                            HttpCookie getCookie = Request.Cookies["someCookie"];
                            myCookie.Values.Add("auth", "admin");
                            Response.Cookies.Add(myCookie);
                            myCookie.Expires = DateTime.Now.AddDays(3);
                            myCookie.Values["auth"];
                            Session["name"] = name;
                            Session["ID1"] = ID;
                            Response.Write("<script>alert('登录成功！');location='Space.aspx'</script>");

                        }
                    }
                }*/

        }
    }
}
