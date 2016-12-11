using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net.Mail;

public partial class Updatepwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        ImageButton1.ImageUrl = "verification.aspx";
    }


    protected void update_Click(object sender, EventArgs e)
    {
        string ID = txtID.Text;
        string pwd = txtpwd.Text;
        string pwd1 = txtpwd1.Text;
        string hspwd1 = Class.HashEncode.HashEncoding(pwd);
        string vcode = Vcode.Text;
        question.Text = question.SelectedValue;
        string question1 = question.Text;
        string answerpwd1 = answerpwd.Text;
        string hsanswer = Class.HashEncode.HashEncoding(answerpwd1);
        if (ID.Length == 0 || pwd.Length == 0)
        {
            Response.Write("<script>alert('失败，不为空！')</script>");
            return;
        }
        else if (pwd != pwd1)
        {
            Response.Write("<script>alert('确认密码不正确！')</script>");
            return;
        }
        if (pwd.Length < 6 || pwd.Length > 20)//密码长度大于六且小于二十
        {
            Response.Write("<script>alert('密码长度有误！')</script>");
            return;
        }
        else if (Session["Vnum"].ToString() != Vcode.Text.Trim())
        {
            Response.Write("<script>alert('失败，请检查验证码！')</script>");
            return;
        }
        string sql = "select * from tabUsers where ID='" + ID + "'and hsanswer='" + hsanswer + "'";
        int result = Class.exist(sql);
        if (result != 1)
        {
            Response.Write("<script>alert('失败，问题或答案不正确！')</script>");
            return;
        }
        if (result == 1)
        {
            string sql1 = "update tabUsers set hspwd='" + hspwd1 + "' where ID='" + ID + "'";
            int result2 = Class.Put(sql1);
            if (result2 == 1)
                Binddata();
            else
            {
                Response.Write("<script>alert('失败！')</script>");
                return;
            }

        }
    }
    protected void Binddata()
    {

        // this.mytext.InnerHtml="三秒后页面跳转<div id=\"aa\"></div>";
        Response.Write("成功！三秒后页面跳转<div id=\"aa\"></div>");//先生成一个用来显示时间倒计时的DIV

        StringBuilder sb = new StringBuilder();//注意添加using引用 System.Text
        sb.Append("<script langage=\"javascript\">"); //用\"转义'

        sb.Append("var i=4;");

        sb.Append("function out()");

        sb.Append("{");

        sb.Append("if(i>0){ ");

        sb.Append("i--;}");

        sb.Append("else {");

        sb.Append("location.href=\"Login.aspx\";}");


        sb.Append("document.getElementById(\"aa\").innerHTML=i; }");

        sb.Append("setInterval(\"out()\",1000); "); //每隔一秒发生

        sb.Append("</script>");

        this.Page.Controls.Add(new LiteralControl(sb.ToString()));

    }
   
    protected void update0_Click(object sender, EventArgs e)
    {
        string ID = txtID.Text;
         Random ran = new Random();
        int n = ran.Next(100000, 999999);
        string sql = "select * from tabUsers where ID='" + ID + "'";
        string address = Class.Search1(sql);
        bool re = Class.Send.Sendemails(@"736768307@qq.com", address, "异次元空间修改密码", "您正在修改密码，如非本人操作，请忽略或致电13730974672官方客服；验证码为：" + n + "");
        Session["n"] =Convert.ToString(n);
        if (re == false)
        {
            Response.Write("<script>alert('失败！')</script>");
           
        }

    }

    protected void update1_Click(object sender, EventArgs e)
    {
        string ID = txtID.Text;
        string pwd = txtpwd2.Text;
        string pwd3 = txtpwd3.Text;
        string hspwd1 = Class.HashEncode.HashEncoding(pwd);
        long vcode = Convert.ToInt64(Vcode0.Text);
        if (ID.Length == 0 || pwd.Length == 0)
        {
            Response.Write("<script>alert('失败，不为空！')</script>");
            return;
        }
        else if (pwd != pwd3)
        {
            Response.Write("<script>alert('确认密码不正确！')</script>");
            return;
        }
        if (pwd.Length < 6 || pwd.Length > 20)//密码长度大于六且小于二十
        {
            Response.Write("<script>alert('密码长度有误！')</script>");
            return;
        }       
        string n=Convert.ToString( Session["n"]);
        if (vcode ==Convert.ToInt64( n))
        {
            string sql1 = "update tabUsers set hspwd='" + hspwd1 + "' where ID='" + ID + "'";
            int result2 = Class.Put(sql1);
            if (result2 == 1)
                Binddata();
            else
            {
                Response.Write("<script>alert('失败！')</script>");
                return;
            }

        }
        else
        {
            Response.Write("<script>alert('失败！')</script>");
            return;
        }
    }
}