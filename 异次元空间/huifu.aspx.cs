using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class huifu : System.Web.UI.Page
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
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
            //Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        if (id == 0)
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
        else
        {
            string sql = "select * from inf where id='" + id + "'";

            DataTable dt = new DataTable();

            dt = Class.Table(sql);
            string ID = Session["ID1"].ToString();
            string sql1 = "select*from tabUsers where ID='" + ID + "'";
            string picture1 = Class.Search6(sql1);
            string userID = dt.Rows[0][1].ToString();

            string title = dt.Rows[0][2].ToString();


            string matter = dt.Rows[0][5].ToString();


            string tip = dt.Rows[0][4].ToString();


            string class1 = dt.Rows[0][3].ToString();

            string name;
            name = Convert.ToString(Session["name"]);
            string id1 = dt.Rows[0][9].ToString();
            string id3 = dt.Rows[0][10].ToString();
            string rpt = rpt1.Text;
            string sql2 = "select*from tabUsers where ID='" + ID + "'";
            string picture = Class.Search6(sql2);
            string sql3 = "insert into inf (userID,title,tip,class,matter,name,id1,id2,id3,rptmatter,picture,id0,picture1,good) values('" + ID + "','" + title + "','" + tip + "','" + class1 + "','" + matter + "','" + name + "','" + id1 + "','" + id3 + "','" + 1 + "','" + rpt + "','" + picture + "','" + ID + "','" + picture1 + "','" + 0 + "')";

            int result = Class.Put(sql3);

            if (result == 1)
                Response.Write("<script>alert('发表成功！'),location='Space.aspx'</script>");
            else if (result != 1)
            {
                Response.Write("<script>alert('发表失败！'),location='Space.aspx'</script>");
                return;
            }
        }
    }
}