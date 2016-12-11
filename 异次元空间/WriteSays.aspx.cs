using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WriteSays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            Session["name"] = name;
            string ID = Session["ID1"].ToString();
            Session["ID1"] = ID;
            txtmatter.ImageGalleryPath = "image/ ";
        }
        else
        {
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");

        }
    }
    protected void insert_Click(object sender, EventArgs e)
    {
        string userID = Session["ID1"].ToString();
        string name = Session["name"].ToString();
        string matter = txtmatter.Text;
        string sql1 = "select*from tabUsers where ID='" + userID + "'";
        string picture = Class.Search6(sql1);
        string sql = "insert into inf (userID,matter,name,id2,id3,picture,id0,picture1,good) values('" + userID + "','" + matter + "','"+name+"','"+1+"','"+0+"','"+picture+"','"+userID+"','"+picture+"','"+0+"')";
       
        if ( matter.Length == 0)//判断输入都不为空
        {
            Response.Write("<script>alert('输入不为空！')</script>");
            return;
        }
        else
        {
            int result2 = Class.Put(sql);

            if (result2 == 1)
                Response.Write("<script>alert('发表成功！');location='Says.aspx'</script>");
            else
            {
                Response.Write("<script>alert('发表失败！');</script>");
                return;
            }
        }
    }
    public string GetPath()
    {
        string path = "image/"; //事先创建的虚拟目录
        DateTime now = DateTime.Now; // 定义时间变量并赋值为当前时间
        string year = now.Year.ToString().Trim();// 获取当前时间的年份，下同
        string month = now.Month.ToString().Trim();
        string day = now.Day.ToString().Trim();
        string hour = now.Hour.ToString().Trim();
        string filepath = path + year + "_" + month + "/" + day;// 获取括号内的虚拟路径对应的物理路径
        if (!System.IO.Directory.Exists(Server.MapPath(filepath)))
            System.IO.Directory.CreateDirectory(Server.MapPath(filepath));
        return filepath;
    }
}