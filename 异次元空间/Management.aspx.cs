using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from inf where id3='"+0+"' order by datetime desc";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);
        inf.DataSource = dt;
        inf.DataBind();
        string sql1 = "select * from tabUsers ";
        DataTable dt1 = new DataTable();

        dt1 = Class.Table(sql1);
        users.DataSource = dt1;
        users.DataBind();
      

    }

    protected void inf_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["userID"]);
            string result = Convert.ToString(rowv["id"]);
            //找到对应ID下的Book
            string select = "select * from inf where userID='" + ID + "'and id1='" + result + "' and id3='" + 1 + "'order by datetime DESC";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("friend2");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }


    protected void inf_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql1 = "delete from inf where id='" + id + "'";

            int result = Class.Put(sql1);

            if (result == 1)
                Response.Write("<script>alert('删除成功！');location='Management.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='Management.aspx'</script>");
        }
    }

    protected void friend2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql1 = "delete from inf where id='" + id + "'";

            int result = Class.Put(sql1);

            if (result == 1)
                Response.Write("<script>alert('删除成功！');location='Management.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='Management.aspx'</script>");
        }
    }

    protected void users_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql1 = "delete from tabUsers where ID='" + id + "'";

            int result = Class.Put(sql1);

            if (result == 1)
                Response.Write("<script>alert('删除成功！');location='Management.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='Management.aspx'</script>");
        }
    }

    protected void friend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}