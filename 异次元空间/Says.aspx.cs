using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Says : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            repeaterdiary.Visible = true;
            page1.Visible = true;
            string ID = Session["ID1"].ToString();

            string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='"+0+"' order by datetime desc";//按照时间排序
            DataBindToRepeater(1, sql);
        }
        else Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
    }
    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);

    }
    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);


    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";
        lblCurrentPage.Text = "1";
        DataBindToRepeater(1, sql);
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";
        lblCurrentPage.Text = "1";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 10;

        pds.DataSource = dt.DefaultView;
        int Count = pds.PageCount;
        labPage.Text = Count.ToString();
        lblCurrentPage.Text = Count.ToString();
        DataBindToRepeater(Count, sql);
    }
    protected void paperturn_Click(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            string ID = Session["ID1"].ToString();
            int papercount = Convert.ToInt32(paper.Text);
            string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";
            DataTable dt = new DataTable();

            dt = Class.Table(sql);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;

            pds.PageSize = 10;

            pds.DataSource = dt.DefaultView;
            int Count = pds.PageCount;
            labPage.Text = Count.ToString();
            if (papercount == 0 || papercount > Count)
            {
                Response.Write("<script>alert('操作无效')</script>");
                DataBindToRepeater(1, sql);
            }
            else
            {
                lblCurrentPage.Text = papercount.ToString();
                DataBindToRepeater(papercount, sql);
            }

        }
        else
        {
            string ID = Session["ID1"].ToString();
            string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater(1, sql);
        }
    }
    void DataBindToRepeater(int currentPage, string sql)
    {

        DataTable dt = new DataTable();

        dt = Class.Table(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 10;

        pds.DataSource = dt.DefaultView;
        int Count = pds.PageCount;
        if (Count == 1)
        {
            currentPage = 1;
            btnBefore.Enabled = false;
            btnNext.Enabled = false;
        }
        else if (currentPage == Count)
        {
            btnBefore.Enabled = true;
            btnNext.Enabled = false;

        }
        else if (currentPage == 1)
        {
            btnBefore.Enabled = false;
            btnNext.Enabled = true;

        }
        else
        {
            btnBefore.Enabled = true;
            btnNext.Enabled = true;
        }
        lblCurrentPage.Text = currentPage.ToString();
        labPage.Text = Count.ToString();
        pds.CurrentPageIndex = currentPage - 1;

        repeaterdiary.DataSource = pds;

        repeaterdiary.DataBind();

    }

    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
        string sql1 = "delete from inf where id='" + id + "'";
       string sql2= "delete from inf where id1='" + id + "'";
        int result = Class.Put(sql1);
        int result1 = Class.Put(sql2);
        if (result == 1&&result1 ==1)
            Response.Write("<script>alert('删除成功！');location='Says.aspx'</script>");
        else
            Response.Write("<script>alert('删除失败！');location='Says.aspx'</script>");

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        repeaterdiary.Visible = true;
        page1.Visible = true;
        string ID = Session["ID1"].ToString();

        string sql = "select * from inf where userID='" + ID + "'and id2='" + 1 + "'and id3='" + 0 + "' order by datetime desc";
        DataBindToRepeater(1, sql);
    }

    protected void repeaterdiary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["userID"]);
            string result = Convert.ToString(rowv["id"]);
            //找到对应ID下的Book
            string select = "select * from inf where userID='" + ID + "'and id1='" + result + "' and id3='" + 1 + "' and id2='" +1+ "'order by datetime DESC";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("friend2");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }

    protected void repeaterdiary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "yes")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "select*from inf where id='" + id + "'";

            DataTable dt = new DataTable();

            dt = Class.Table(sql);
            string zan = dt.Rows[0][17].ToString();
            string sql2 = "select*from inf where good1 like'%" + ID + "%' and id='" + id + "'";
            int result3 = Class.exist(sql2);

            if (result3 > 0)
                Response.Write("<script>alert('一个用户只能赞一次！'),location='Says.aspx'</script>");
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
                    Response.Write("<script>alert('赞成功！'),location='Says.aspx'</script>");
                else
                    Response.Write("<script>alert('赞失败！'),location='Says.aspx'</script>");

            }

        }
    }
}
