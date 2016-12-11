using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Firend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            string ID = Session["ID1"].ToString();

            repeaterdiary.Visible = true;
            page1.Visible = true;
            Div1.Visible = true;
            repeater1.Visible = true;
           
            string sql = "select * from Friend where ID='" + ID + "' and special='" + 1 + "'order by friendID desc";
            DataBindToRepeater1(1, sql);
            string sql1 = "select * from Friend where ID='" + ID + "' and special='" + 0 + "'order by friendID desc";
            DataBindToRepeater(1, sql1);
        }
        else Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
    }

    protected void repeaterdiary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "delete from Friend where ID='" + ID + "'and friendID='" + id + "'";
            string sql2 = "delete from Friend  where ID='" + id + "'and friendID='" + ID + "'";
            int result1 = Class.Put(sql);
            int result2 = Class.Put(sql2);
            if (result1 == 1 && result2 == 1)
                Response.Write("<script>alert('删除成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='Friend.aspx'</script>");
        }
        if (e.CommandName == "no")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 0+ "' where ID='" + id + "'and friendID='" + ID + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "yes")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 1 + "' where ID='" + id + "'and friendID='" + ID + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");
        }

            if (e.CommandName == "no1")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                string ID = Session["ID1"].ToString();
                string sql = "update Friend set quanxian='" + 0 + "' where ID='" + ID + "'and friendID='" + id + "'";
                int result2 = Class.Put(sql);
                if (result2 == 1)
                    Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
                else
                    Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

            }
            if (e.CommandName == "yes1")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                string ID = Session["ID1"].ToString();
                string sql = "update Friend set quanxian='" + 1 + "' where ID='" +ID + "'and friendID='" +id+ "'";
                int result2 = Class.Put(sql);
                if (result2 == 1)
                    Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
                else
                    Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

            }
        if (e.CommandName == "s1")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set special='" + 1 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "s2")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set special='" + 0 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
    }
    

    protected void newalbum3_Click(object sender, EventArgs e)
    {
        repeaterdiary.Visible = true;
        page1.Visible = true;
        Div1.Visible = true;
        repeater1.Visible = true;
        string ID = Session["ID1"].ToString();
        string sql = "select * from Friend where ID='" + ID + "' and special='"+1+"'order by friendID desc";
        DataBindToRepeater1(1, sql);
        string sql1= "select * from Friend where ID='" + ID + "' and special='" + 0 + "'order by friendID desc";
        DataBindToRepeater(1, sql1);
    }
    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "and special='" + 1 + "'order by friendID desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql);

    }
    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "and special='" + 1 + "'order by friendID desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql);


    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "and special='" + 1 + "'order by friendID desc";
        lblCurrentPage.Text = "1";
        DataBindToRepeater1(1, sql);
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "and special='" + 1 + "'order by friendID desc";
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
        DataBindToRepeater1(Count, sql);
    }
    protected void paperturn_Click(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            string ID = Session["ID1"].ToString();
            int papercount = Convert.ToInt32(paper.Text);
            string sql = "select * from Friend where ID='" + ID + "'and special='"+1+"'order by friendID desc";
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
                DataBindToRepeater1(1, sql);
            }
            else
            {
                lblCurrentPage.Text = papercount.ToString();
                DataBindToRepeater1(papercount, sql);
            }

        }
        else
        {
            string ID = Session["ID1"].ToString();
            string sql = "select * from Friend where ID='" + ID + "' and special='" + 1+ "'order by friendID desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater1(1, sql);
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

        repeater1 .DataSource = pds;

        repeater1 .DataBind();

    }

    void DataBindToRepeater1(int currentPage, string sql)
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
            btnBefore1.Enabled = false;
            btnNext1.Enabled = false;
        }
        else if (currentPage == Count)
        {
            btnBefore1.Enabled = true;
            btnNext1.Enabled = false;

        }
        else if (currentPage == 1)
        {
            btnBefore1.Enabled = false;
            btnNext1.Enabled = true;

        }
        else
        {
            btnBefore1.Enabled = true;
            btnNext1.Enabled = true;
        }
        lblCurrentPage1.Text = currentPage.ToString();
        labPage1.Text = Count.ToString();
        pds.CurrentPageIndex = currentPage - 1;

        repeaterdiary .DataSource = pds;

       repeaterdiary .DataBind();

    }

    protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "delete from Friend where ID='" + ID + "'and friendID='" + id + "'";
            string sql2 = "delete from Friend  where ID='" + id + "'and friendID='" + ID + "'";
            int result1 = Class.Put(sql);
            int result2 = Class.Put(sql2);
            if (result1 == 1 && result2 == 1)
                Response.Write("<script>alert('删除成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='Friend.aspx'</script>");
        }
        if (e.CommandName == "no")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 0 + "' where ID='" + id + "'and friendID='" + ID + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "yes")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 1 + "' where ID='" + id + "'and friendID='" + ID + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");
        }

        if (e.CommandName == "no1")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 0 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "yes1")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set quanxian='" + 1 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "s1")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set special='" + 1 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
        if (e.CommandName == "s2")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string ID = Session["ID1"].ToString();
            string sql = "update Friend set special='" + 0 + "' where ID='" + ID + "'and friendID='" + id + "'";
            int result2 = Class.Put(sql);
            if (result2 == 1)
                Response.Write("<script>alert('成功！');location='Friend.aspx'</script>");
            else
                Response.Write("<script>alert('失败！');location='Friend.aspx'</script>");

        }
    }

    protected void paperturn1_Click(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            string ID = Session["ID1"].ToString();
            int papercount = Convert.ToInt32(paper1.Text);
            string sql = "select * from Friend where ID='" + ID + "'order by friendID desc";
            DataTable dt = new DataTable();

            dt = Class.Table(sql);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;

            pds.PageSize = 10;

            pds.DataSource = dt.DefaultView;
            int Count = pds.PageCount;
            labPage1.Text = Count.ToString();
            if (papercount == 0 || papercount > Count)
            {
                Response.Write("<script>alert('操作无效')</script>");
                DataBindToRepeater1(1, sql);
            }
            else
            {
                lblCurrentPage1.Text = papercount.ToString();
                DataBindToRepeater1(papercount, sql);
            }

        }
        else
        {
            string ID = Session["ID1"].ToString();
            string sql = "select * from Friend where ID='" + ID + "' and special='"+0+"'order by friendID desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater1(1, sql);
        }
    }

    protected void btnBefore1_Click(object sender, EventArgs e)
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "'order by friendID desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);
    }

    protected void btnNext1_Click(object sender, EventArgs e)
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "'order by friendID desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);
    }

    protected void butTop1_Click(object sender, EventArgs e)
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "'order by friendID desc";
        lblCurrentPage.Text = "1";
        DataBindToRepeater(1, sql);
    }

    protected void btnFinal1_Click(object sender, EventArgs e)
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from Friend where ID='" + ID + "'order by friendID desc";
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
}