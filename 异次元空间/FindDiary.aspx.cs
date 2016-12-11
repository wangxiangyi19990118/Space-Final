using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class FindDiary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string username = Session["name"].ToString();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == 0)
                Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
            else
            {
                string sql = "select * from inf where id='" + id + "'";

                DataTable dt = new DataTable();

                dt = Class.Table(sql);

                string title = dt.Rows[0][2].ToString();

                txttitle.Text = title;
                string matter = dt.Rows[0][5].ToString();

                txtmatter.Text = matter;
                string tip = dt.Rows[0][4].ToString();

                txttip.Text = tip;
                string class1 = dt.Rows[0][3].ToString();

                class10.Text = class1;
                Session["name"] = username;
                Session["id"] = id;
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！')</script>");
            Response.Redirect("Login.aspx");
        }

    }
}
