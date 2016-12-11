using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreeTextBoxControls;
using FreeTextBoxControls.Design;

public partial class Space : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            string ID = Session["ID1"].ToString();
            lbname.Text = name;
            string sql = "select*from inf where userID in( select ID from tabUsers where ID in(select friendID from Friend where ID='" + ID + "'and quanxian='"+1+ "'and special='" + 0 + "'))and id3='" + 0+"' order by datetime DESC";
            DataTable dt = new DataTable();
            dt = Class.Table(sql);
            friend1.DataSource = dt;
            friend1.DataBind();
            string sql2 = "select*from inf where userID in( select ID from tabUsers where ID in(select friendID from Friend where ID='" + ID + "'and quanxian='" + 1 + "'and special='"+1+"'))and id3='" + 0 + "' order by datetime DESC";
            DataTable dt2 = new DataTable();
            dt2 = Class.Table(sql2);
            Repeater2.DataSource = dt2;
            Repeater2.DataBind();
            Session["ID1"] = ID;
            Session["name"] = name;
            string sql1 = "select*from ask where friendID='" + ID + "'";
            int result = Class.exist(sql1);
            if (result > 0)
            {
                Repeater1.Visible = true;
                DataTable dt1 = new DataTable();
                dt1 = Class.Table(sql1);
                Repeater1.DataSource = dt1;
                Repeater1.DataBind();

            }
            string sql3 = "select* from Friend where friendID='" + ID + "'and special='" + 1 + "'";
            int count = Class.exist2(sql3);
            Lacount.Text =Convert .ToString ( count);

        }
        else
        {
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>alert('退出成功！');location='Space.aspx'</script>");
    }

   protected void friend1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
             int ID = Convert.ToInt32(rowv["userID"]);
            string result = Convert.ToString(rowv["id"]);
            //找到对应ID下的Book
            string select = "select * from inf where userID='" + ID + "'and id1='"+result+"' and id3='"+1+ "'order by datetime DESC";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("friend2");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }

   
    protected void Button2_Click(object sender, EventArgs e)
    {
        string name = Session["name"].ToString();
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "'";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);
        friend1.DataSource = dt;
        friend1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "no")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "delete from ask where ID='" + id + "'and friendID='" + ID + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
            {
                
                string sql1 = "select*from ask where friendID='" + ID + "'";
                int result = Class.exist(sql1);
                if (result > 0)
                {
                    Repeater1.Visible = true;
                    DataTable dt1 = new DataTable();
                    dt1 = Class.Table(sql1);
                    Repeater1.DataSource = dt1;
                    Repeater1.DataBind();

                }
                Response.Write("<script>alert('拒绝成功！'),location='Space.aspx'</script>");
                
            }
            else
            {
                Response.Write("<script>alert('拒绝失败！'),location='Space.aspx'</script>");
                string sql1 = "select*from ask where friendID='" + ID + "'";
                int result = Class.exist(sql1);
                if (result > 0)
                {
                    Repeater1.Visible = true;
                    DataTable dt1 = new DataTable();
                    dt1 = Class.Table(sql1);
                    Repeater1.DataSource = dt1;
                    Repeater1.DataBind();

                }
                

            }
        }
        if (e.CommandName == "yes")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string name1 = Session["name"].ToString();
            string sql1 = "delete from ask where ID='" + id + "'and friendID='" + ID + "'";
            string sql2 = "select*from tabUsers  where ID='" + id + "'";
            DataTable dt = new DataTable();

            dt = Class.Table(sql2);
            string picture = dt.Rows[0][8].ToString();
            string name= dt.Rows[0][1].ToString();
            string sql3 = "select*from tabUsers  where ID='" + ID + "'";
            DataTable dt1 = new DataTable();

            dt1 = Class.Table(sql3);
            string picture1= dt.Rows[0][8].ToString();
            string sql =  "insert into Friend (ID,friendID,friendname,picture,quanxian,special) values('" + id + "','" + ID + "','" + name1 + "','" + picture + "','" + 1 + "','"+0+"')";
            string sql4 = "insert into Friend (ID,friendID,friendname,picture,quanxian,special) values('" + ID + "','" + id + "','" + name + "','" + picture1 + "','" + 1 + "','"+0+"')";
            int result2 = Class.Put(sql);
            int result1 = Class.Put(sql1);
            int resulr3 = Class.Put(sql4);
            if (result2 == 1 && result1 == 1 && resulr3 == 1)
            {
               
               /* string sql5 = "select*from ask where friendID='" + ID + "'";
                int result = Class.exist(sql5);
                if (result > 0)
                {
                    Repeater1.Visible = true;
                    DataTable dt2= new DataTable();
                    dt2 = Class.Table(sql1);
                    Repeater1.DataSource = dt2;
                    Repeater1.DataBind();

                }*/
                Response.Write("<script>alert('添加成功！'),location='Space.aspx'</script>");
                return;
            }
            else
            { Response.Write("<script>alert('添加失败！'),location='Space.aspx'</script>");
                string sql5 = "select*from ask where friendID='" + ID + "'";
                int result = Class.exist(sql5);
                /*if (result > 0)
                {
                    Repeater1.Visible = true;
                    DataTable dt2 = new DataTable();
                    dt2 = Class.Table(sql1);
                    Repeater1.DataSource = dt2;
                    Repeater1.DataBind();

                }*/
               
            }
        }
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            Repeater rept = (Repeater)e.Item.FindControl("friend02");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "yes")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            //int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string ID = Session["ID1"].ToString();
            string sql = "select*from inf where id='" + id + "'";
           
            DataTable dt = new DataTable();

            dt = Class.Table(sql);
            string zan = dt.Rows[0][17].ToString();
            string sql2 = "select*from inf where good1 like'%" + ID + "%' and id='" + id + "'";
            int result3 = Class.exist(sql2);

            if (result3 > 0)
                Response.Write("<script>alert('一个用户只能赞一次！'),location='Space.aspx'</script>");
            else
            {
                string zan1 = zan + ID + ' ';
                string result2 = Class.Search8(sql);
                int good = Convert.ToInt32(result2) + 1;
                string sql1 = "update inf set good='" + good + "' where id='" + id + "'";
                string sql3 = "update inf set good1='" + zan1 + "' where id='" + id + "'";

                int result = Class.Put(sql1);
                int result1 = Class.Put(sql3);
                if (result > 0 && result1 > 0)
                    Response.Write("<script>alert('赞成功！'),location='Space.aspx'</script>");
                else
                    Response.Write("<script>alert('赞失败！'),location='Space.aspx'</script>");

            }

        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
        string ID = Session["ID1"].ToString();
        string sql = "select*from inf where id='" + id + "'";
        //string sql4 = "select*from inf1 where id='" + id + "'";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);
        string zan = dt.Rows[0][17].ToString();    
        string sql2 = "select*from inf where good1 like'%" + ID + "%' and id='" + id + "'";
        int result3 = Class.exist(sql2);

        if (result3 > 0)
            Response.Write("<script>alert('一个用户只能赞一次！'),location='Space.aspx'</script>");
        else
        {
            string zan1 = zan + ID + ' ';
            string result2 = Class.Search8(sql);
            int good = Convert.ToInt32(result2) + 1;
            string sql1 = "update inf set good='" + good + "' where id='" + id + "'";
            string sql3 = "update inf set good1='" +zan1 + "' where id='" + id + "'";

            int result = Class.Put(sql1);
            int result1 = Class.Put(sql3);
            if (result > 0&&result1>0)
                Response.Write("<script>alert('赞成功！'),location='Space.aspx'</script>");
            else
                Response.Write("<script>alert('赞失败！'),location='Space.aspx'</script>");

        }

    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
       
        string ID = Session["ID1"].ToString();
        string name = Session["name"].ToString();
        string sql = "select*from inf where id='" + id + "'";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);
        string title= dt.Rows[0][2].ToString();
        string class2 = dt.Rows[0][3].ToString();
        string tip = dt.Rows[0][4].ToString();
        string  matter= dt.Rows[0][5].ToString();
        string id1 = dt.Rows[0][9].ToString();
        string id2 = dt.Rows[0][10].ToString();
        string id3 = dt.Rows[0][11].ToString();
        string sql2 = "select*from tabUsers where ID='" + ID + "'";
        string picture = Class.Search6(sql2);
        string sql1= "insert into inf(userID, title, tip,class,matter,name,id2,id3,id4,picture,id0,picture1,good) values('" + ID + "','" +title + "','" + tip + "','" +class2 + "','" + matter + "','"+name+"','"+id2+"','"+0+"','"+"转载"+"','"+picture+"','"+ID+"','"+picture+"','"+0+"')";
        //string sql3 = "insert into inf1(picture1) values('" + picture + "')";
        int result1 = Class.Put(sql1);
       
        if ( result1 > 0)
            Response.Write("<script>alert('转载成功！'),location='Space.aspx'</script>");
        else
            Response.Write("<script>alert('转载失败！'),location='Space.aspx'</script>");
    }
}

