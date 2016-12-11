using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Repete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string username = Session["name"].ToString();
            string ID = Session["ID1"].ToString();
        }
        else
        {
            Response.Write("<script>alert('请先登录！')</script>");
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Session["ID1"] = ID;
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        if (id == 0)
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
        else
        {
            string sql = "select * from inf where id='" + id + "'";

            DataTable dt = new DataTable();

            dt = Class.Table(sql);
            string userID = dt.Rows[0][1].ToString();

            string title = dt.Rows[0][2].ToString();

           
            string matter = dt.Rows[0][5].ToString();

            
            string tip = dt.Rows[0][4].ToString();

           
            string class1 = dt.Rows[0][3].ToString();

            string name;
            name =Convert .ToString ( Session["name"]);
            string id3 = dt.Rows[0][10].ToString();
            string rpt = rpt1.Text;
            string sql1 = "select*from tabUsers where ID='" + ID + "'";
            string picture = Class.Search6(sql1);
            string sql3 = "insert into inf (userID,title,tip,class,matter,name,id1,id2,id3,rptmatter,picture,id0,picture1,good) values('" + userID + "','" + title + "','" + tip + "','" + class1 + "','" + matter + "','" + name + "','" + id + "','" + id3 + "','" + 1 + "','" + rpt + "','" + picture + "','" + ID + "','" + picture + "','"+0+"')";
           
            int result = Class.Put(sql3);
           
            if (result == 1)
                Response.Write("<script>alert('发表成功！');</script>");
            else if (result != 1)
            {
                Response.Write("<script>alert('发表失败！');</script>");
                return;
            }
        }
    }
}