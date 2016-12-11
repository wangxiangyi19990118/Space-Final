using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateDiary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string username = Session["name"].ToString();
            int id =Convert.ToInt32( Session["id"].ToString());
            if (id ==0)
                Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
            else
            {
                string sql = "select * from inf where id='" + id + "'and id2='"+0+"'";

                DataTable dt = new DataTable();

                dt = Class.Table(sql);

                string title = dt.Rows[0][2].ToString();

                txttitle.Text = title;
                string matter = dt.Rows[0][5].ToString();

                txtmatter.Text = matter;
                string tip = dt.Rows[0][4].ToString();

                txttip.Text = tip;
                string class1 = dt.Rows[0][3].ToString();

                class10.SelectedValue = class1;

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

        //string id = Class.Search2(sql);
        string title = Request.Form[txttitle.UniqueID];
        Session["ID1"] = ID;
        string matter = Request.Form[txtmatter.UniqueID];
        string tip = Request.Form[txttip.UniqueID];
        string class1 = Request.Form[class10.UniqueID];
        if (title.Length == 0 || matter.Length == 0|| tip.Length == 0)//判断输入都不为空
        {
            Response.Write("<script>alert('信息不为空！')");
            return;
        }
        else
        {
            string sql = "update inf set title='" + title + "',matter='" +matter + "',tip='" + tip + "',class='" + class1 + "' where id='" + id + "'";
            //string sql1 = "update inf1 set title='" + title + "',matter='" + matter + "',tip='" + tip + "',class='" + class1 + "' where id='" + id + "'";
            int result1 = Class.Put(sql);
           // int result2 = Class.Put(sql1);
            if (result1 == 1)
                Response.Write("<script>alert('修改成功！');location='Dairy.aspx'</script>");
            else
            {
                Response.Write("<script>alert('修改失败！');</script>");
                return;
            }

        }
    }
}
