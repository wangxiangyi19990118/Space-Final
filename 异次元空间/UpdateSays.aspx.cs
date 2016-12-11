using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UpdateSays : System.Web.UI.Page
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
                string sql = "select * from inf where id='" + id + "'and id2='"+1+"'";

                DataTable dt = new DataTable();

                dt = Class.Table(sql);

               
                string matter = dt.Rows[0][5].ToString();

                txtmatter.Text = matter;

            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！')</script>");
            Response.Redirect("Login.aspx");
        }
    }
    protected void insert_Click(object sender, EventArgs e)
    {
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);

        string matter = Request.Form[txtmatter.UniqueID];
        
        if (matter.Length == 0 )//判断输入都不为空
        {
            Response.Write("<script>alert('信息不为空！')");
            return;
        }
        else
        {
            string sql = "update inf set matter='" + matter + "' where id='" + id + "'";
            int result1 = Class.Put(sql);
            if (result1 == 1)
                Response.Write("<script>alert('修改成功！');location='Says.aspx'</script>");
            else
            {
                Response.Write("<script>alert('修改失败！');</script>");
                return;
            }

        }
    }
}