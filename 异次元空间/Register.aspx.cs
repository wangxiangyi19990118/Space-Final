using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string name = txtname.Text;
        string pwd = txtpwd.Text;
        string repwd = txtpwd1.Text;
        string hspwd = Class.HashEncode.HashEncoding(pwd);
        string sex = radlSex.SelectedValue;
        string mail =txtmail.Text;
        question.Text = question.SelectedValue;
        Year.Text = Year.SelectedValue;
        string question1 = question.Text;
        string answerpwd1 = answerpwd.Text;
        string hsanswer = Class.HashEncode.HashEncoding(answerpwd1);
        string year = Year.Text;

        if (name.Length == 0 || pwd.Length == 0 || answerpwd1.Length == 0 || mail.Length == 0 || repwd.Length == 0)//判断输入都不为空
        {
            Response.Write("<script>alert('输入不为空！'),location=='Register.aspx'</script>");
        }
        else { bool result = Class.IsCorrenctIP(mail);
            if (result == false)
            {
                Response.Write("<script>alert('邮箱地址不正确！')</script>");
                return;
            }
           
            else if (pwd.Length < 6 || pwd.Length > 20)//密码长度大于六且小于二十
            {
                Response.Write("<script>alert('密码长度有误！'),location='Register.aspx'</script>");
            }
            else if (pwd != repwd)
            {
                Response.Write("<script>alert('确认密码不正确！'),location='Register.aspx'</script>");
            }
            else
            {
                int result1;
                string ID;
                do
                {
                    ID = GenerateRandomNumber(9);
                    string sql1 = "select * from tabUsers where ID='" + ID + "'";
                    result1 = Class.exist(sql1);
                } while (result1 != 0);
                if (upload1.HasFile)//判断控件是否有文件路径
                {
                    DateTime currentTime = System.DateTime.Now;
                    int age = Convert.ToInt32(currentTime.Year) - Convert.ToInt32(year);
                    string filename = upload1.FileName;//取得文件名
                    filename = filename.Substring(filename.LastIndexOf(".") + 1);//取得后缀
                    if (filename.ToLower() == "jpg" || filename.ToLower() == "gif")//判断类型
                    {
                        string img = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + filename;
                        upload1.SaveAs(Server.MapPath("images/") + img);
                        string picture = ("images/") + img;
                        //传到根目录的images文件夹+重命名的文件名，也可以用原来的图片的名称，自己定。上传成功；
                        string sql = "insert into tabUsers values('" + ID + "','" + name + "','" + hspwd + "','" + sex + "','" + year+ "','"+mail+"','" + question1 + "','" + hsanswer + "','" + picture + "','"+age+"')";
                        int result2 = Class.Put(sql);
                        if (result2 == 1)
                        {
                            newRegister.Visible = true;
                            newRegister.Text = ID;
                            Binddata();
                        }
                        else if (result2 != 1)
                        {
                            Response.Write("<script>alert('注册失败！');</script>");
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('图片格式只支持jpg和gif');</script>");
                        return;//提示错误
                    }
                }
                else {
                    DateTime  currentTime = System.DateTime.Now;
                    int age =Convert .ToInt32 ( currentTime.Year) - Convert.ToInt32(year);
                    string sql = "insert into tabUsers(ID,name,hspwd,sex,year,mail,question,hsanswer,age) values('" + ID + "','" + name + "','" + hspwd + "','" + sex + "','" + year + "','" + mail + "','" + question1 + "','" + hsanswer + "','"+age+"')";
                    int result2 = Class.Put(sql);
                    if (result2 == 1)
                    {
                        newRegister.Visible = true;
                        newRegister.Text = ID;
                        Binddata();
                    }
                    else if (result2 != 1)
                    {
                        Response.Write("<script>alert('注册失败！');</script>");
                        return;
                    }
                   
                }    
                }

            }

        }
    private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public static string GenerateRandomNumber(int Length)
    {
        System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(10)]);
        }
        return newRandom.ToString();
    }
    protected void Binddata()
    {

        // this.mytext.InnerHtml="三秒后页面跳转<div id=\"aa\"></div>";
        Response.Write("注册成功！您的账号显示在页面下方，三秒后页面跳转<div id=\"aa\"></div>");//先生成一个用来显示时间倒计时的DIV

        StringBuilder sb = new StringBuilder();//注意添加using引用 System.Text
        sb.Append("<script langage=\"javascript\">"); //用\"转义'
        string  ID=newRegister.Text;
        Session["ID1"] = ID;
        string name = txtname.Text;
        Session["name"] = name;

        sb.Append("var i=4;");

        sb.Append("function out()");

        sb.Append("{");

        sb.Append("if(i>0){ ");

        sb.Append("i--;}");

        sb.Append("else {");

        sb.Append("location.href=\"Space.aspx\";}");


        sb.Append("document.getElementById(\"aa\").innerHTML=i; }");

        sb.Append("setInterval(\"out()\",1000); "); //每隔一秒发生

        sb.Append("</script>");

        this.Page.Controls.Add(new LiteralControl(sb.ToString()));

    }
}