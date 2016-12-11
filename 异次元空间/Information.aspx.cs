using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Information : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string username = Session["name"].ToString();
            string ID = Session["ID1"].ToString();
            Session["name"] = username;
            string sql= "select * from tabUsers where ID= '"+ID+"'";
            DataTable dt = new DataTable();
            dt = Class.Table(sql);
            rptinf.DataSource = dt;
            rptinf.DataBind();
            string rood = Class.Search(sql);
            //static Image.ImageUrl = (rood, rood);
            
        }
        else
        {
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
           
        }
    }
}