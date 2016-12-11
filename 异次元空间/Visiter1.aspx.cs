using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Visiter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            //string ID = Class.Search6(sql);
            string name = Class.Search(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string visiterid = Session["ID1"].ToString();
            string sql1 = "select* from friend where ID = '" + visiterid + "'and friendID='" + id + "'";
            string quanxian = Class.Search7(sql1);
            if (quanxian == "0")
            {
                Response.Write("<script>alert('您没有访问权限！'),location='Space.aspx'</script>");

            }
            Session["ID1"] = visiterid;
        }
        else
        {
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
        }
    }

    protected void itsays1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["userID"]);
            string result = Convert.ToString(rowv["id"]);
            //找到对应ID下的Book
            string select = "select * from inf where userID='" + ID + "'and id1='" + result + "' and id3='" + 1 + "'";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("friend2");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }

    protected void says_Click(object sender, EventArgs e)
    {
        itSays.Visible = true;
        page1.Visible = true;
        itdiary .Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where id0='" +id + "'and id3='" +0+ "'and id2='"+1+"'";
        DataBindToRepeater(1, sql1);
    }
    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        itSays.Visible = true;
        page1.Visible = true;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
       
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
       
        //string sql1 = "select * from inf where id0='" + userID + "'and id3='" + 0 + "'and id2='" + 1 + "'";

        string sql1 = "select* from inf where id0 = '" + id + "'and id3 = '" +0+ "'and id2='"+1+"'order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql1);

    }
    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        itSays.Visible = true;
        page1.Visible = true;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select* from inf where id0 = '" + id + "'and id3 = '" + 0 + "'and id2='" + 1 + "'order by datetime desc";
        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql1);


    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        itSays.Visible = true;
        page1.Visible = true;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select* from inf where id0 = '" +id+ "'and id3 = '" + 0 + "'and id2='" + 1 + "'order by datetime desc";

        lblCurrentPage.Text = "1";
        DataBindToRepeater(1, sql1);
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        itSays.Visible = true;
        page1.Visible = true;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select* from inf where id0 = '" + id + "'and id3 = '" + 0 + "'and id2='" + 1 + "'order by datetime desc";

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
            itSays.Visible = true;
            page1.Visible = true;
            itdiary.Visible = false;
            page2.Visible = false;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = false;
            page3.Visible = false;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();

            string sql1 = "select* from inf where id0 = '" + id + "'and id3 = '" + 0 + "'and id2='" + 1 + "'order by datetime desc";
            int papercount = Convert.ToInt32(paper.Text);
           
            DataTable dt = new DataTable();

            dt = Class.Table(sql1);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;

            pds.PageSize = 10;

            pds.DataSource = dt.DefaultView;
            int Count = pds.PageCount;
            labPage.Text = Count.ToString();
            if (papercount == 0 || papercount > Count)
            {
                Response.Write("<script>alert('操作无效')</script>");
                DataBindToRepeater(1, sql1);
            }
            else
            {
                lblCurrentPage.Text = papercount.ToString();
                DataBindToRepeater(papercount, sql1);
            }

        }
        else
        {
            itSays.Visible = true;
            page1.Visible = true;
            itdiary.Visible = false;
            page2.Visible = false;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = false;
            page3.Visible = false;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string sql1 = "select* from inf where id0= '" + id + "'and id3 = '" + 0 + "'and id2='" + 1 + "'order by datetime desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater(1, sql1);
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

        itsays1.DataSource = pds;

        itsays1.DataBind();

    }
    protected void dairy_Click(object sender, EventArgs e)
    {
        itSays.Visible = false ;
        page1.Visible =false ;
        itdiary .Visible = true ;
        page2.Visible = true;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where id0='" + id + "'and id3='" +0+ "'and id2='"+0+"'";
        DataBindToRepeater1(1, sql1);
    }

    protected void inf_Click(object sender, EventArgs e)
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = true ;
        massage1.Visible = false;
        massage2.Visible = false ;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from tabUsers where ID= '" + id + "'";
        DataTable dt = new DataTable();
        dt = Class.Table(sql1);
        rptinf.DataSource = dt;
        rptinf.DataBind();
        
    }

    protected void photo_Click(object sender, EventArgs e)
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false ;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = true ;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        //string ID = Session["ID"].ToString();
        string sql1 = "select*from Photo where ID='" + id + "'";
        DataTable dt = new DataTable();
        dt = Class.Table(sql1);
        picture2.DataSource = dt;
        picture2.DataBind();
    }

    protected void massage_Click(object sender, EventArgs e)
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = true;
        massage2.Visible = true;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        //string ID = Session["ID"].ToString();
        string sql1 = "select*from massage where ID1='" + id + "'order by datetime desc";
        DataTable dt = new DataTable();
        dt = Class.Table(sql1);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

    }

    protected void repeaterdiary_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["userID"]);
            string result = Convert.ToString(rowv["id"]);
            //找到对应ID下的Book
            string select = "select * from inf where userID='"+ ID + "'and id1='" + result + "' and id3='" + 1 + "'";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("friend3");
            //数据绑定
            rept.DataSource = Class.Table(select);
            rept.DataBind();
        }
    }

 
    protected void btnBefore_Click1(object sender, EventArgs e)//上一页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = true;
        page2.Visible = true;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";


       // string sql1 = "select* from inf where userID = '" + userID + "'and id2 = '" + 1 + "' order by datetime desc";

        lblCurrentPage1.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage1.Text) - 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql1);

    }
    protected void btnNext_Click1(object sender, EventArgs e)//下一页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = true;
        page2.Visible = true;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";
        lblCurrentPage1.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage1.Text) + 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql1);


    }
    protected void butTop_Click1(object sender, EventArgs e)//首页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = true;
        page2.Visible = true;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";
        lblCurrentPage1.Text = "1";
        DataBindToRepeater1(1, sql1);
    }
    protected void btnFinal_Click1(object sender, EventArgs e)//尾页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = true;
        page2.Visible = true;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = false;
        page3.Visible = false;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";

        lblCurrentPage1.Text = "1";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 10;

        pds.DataSource = dt.DefaultView;
        int Count = pds.PageCount;
        labPage1.Text = Count.ToString();
        lblCurrentPage1.Text = Count.ToString();
        DataBindToRepeater1(Count, sql1);
    }
    protected void paperturn_Click1(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            itSays.Visible = false;
            page1.Visible = false;
            itdiary.Visible = true;
            page2.Visible = true;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = false;
            page3.Visible = false;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";
            int papercount = Convert.ToInt32(paper.Text);
            //string sql1 = "select * from inf where userID='" + ID + "'and id2='" + 1 + "' order by datetime desc";
            DataTable dt = new DataTable();

            dt = Class.Table(sql1);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;

            pds.PageSize = 10;

            pds.DataSource = dt.DefaultView;
            int Count = pds.PageCount;
            labPage.Text = Count.ToString();
            if (papercount == 0 || papercount > Count)
            {
                Response.Write("<script>alert('操作无效')</script>");
                DataBindToRepeater1(1, sql1);
            }
            else
            {
                lblCurrentPage.Text = papercount.ToString();
                DataBindToRepeater1(papercount, sql1);
            }

        }
        else
        {
            itSays.Visible = false;
            page1.Visible = false;
            itdiary.Visible = true;
            page2.Visible = true;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = false;
            page3.Visible = false;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string sql1 = "select * from inf where userID='" + id + "'and id3='" + 0 + "'and id2='" + 0 + "'order by datetime desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater1(1, sql1);
        }
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

        repeaterdiary.DataSource = pds;

        repeaterdiary.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string ID = Session["ID1"].ToString();
        string massage = massage2.Text;
        string sql2 = "insert into massage(ID1,ID2,name,massagematter,picture) values('" + id+ "','" + ID + "','" + visiter + "','" + massage + "','"+picture+"')";
        int result2 = Class.Put(sql2);
        if (result2 == 1)
        {
            Response.Write("<script>alert('发表成功！');</script>");
            return;
        }
        else if (result2 != 1)
        {
            Response.Write("<script>alert('发表失败！');</script>");
            return;
        }
    }

    protected void btnBefore_Click2(object sender, EventArgs e)
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false ;
        massage2.Visible = false;
        picture.Visible = true;
        page3.Visible = true;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from Photo where userID='" + id + "'order by datetime desc";


        // string sql1 = "select* from inf where userID = '" + userID + "'and id2 = '" + 1 + "' order by datetime desc";

        lblCurrentPage1.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage1.Text) - 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql1);

    }
    protected void btnNext_Click2(object sender, EventArgs e)//下一页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = true;
        page3.Visible = true;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from Photo where userID='" +id + "'order by datetime desc";
        lblCurrentPage1.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage1.Text) + 1);
        DataBindToRepeater1(Convert.ToInt32(lblCurrentPage.Text), sql1);


    }
    protected void butTop_Click2(object sender, EventArgs e)//首页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = true;
        page3.Visible = true;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from Photo where userID='" + id + "'order by datetime desc";
        lblCurrentPage1.Text = "1";
        DataBindToRepeater1(1, sql1);
    }
    protected void btnFinal_Click2(object sender, EventArgs e)//尾页
    {
        itSays.Visible = false;
        page1.Visible = false;
        itdiary.Visible = false;
        page2.Visible = false;
        inf1.Visible = false;
        massage1.Visible = false;
        massage2.Visible = false;
        picture.Visible = true;
        page3.Visible = true;
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "select * from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql);
        //string userID = Class.Search6(sql);
        Label1.Text = name;
        string visiter = Session["name"].ToString();
        string sql1 = "select * from Photo where userID='" + id + "'order by datetime desc";
        lblCurrentPage1.Text = "1";
        DataTable dt = new DataTable();

        dt = Class.Table(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 10;

        pds.DataSource = dt.DefaultView;
        int Count = pds.PageCount;
        labPage1.Text = Count.ToString();
        lblCurrentPage1.Text = Count.ToString();
        DataBindToRepeater1(Count, sql1);
    
}

   
    protected void paperturn2_Click(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            itSays.Visible = false;
            page1.Visible = false;
            itdiary.Visible = false;
            page2.Visible = false;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = true;
            page3.Visible = true;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string sql1 = "select * from Photo where userID='" + id + "'order by datetime desc";
            int papercount = Convert.ToInt32(paper.Text);
            //string sql1 = "select * from inf where userID='" + ID + "'and id2='" + 1 + "' order by datetime desc";
            DataTable dt = new DataTable();

            dt = Class.Table(sql1);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;

            pds.PageSize = 10;

            pds.DataSource = dt.DefaultView;
            int Count = pds.PageCount;
            labPage.Text = Count.ToString();
            if (papercount == 0 || papercount > Count)
            {
                Response.Write("<script>alert('操作无效')</script>");
                DataBindToRepeater2(1, sql1);
            }
            else
            {
                lblCurrentPage.Text = papercount.ToString();
                DataBindToRepeater2(papercount, sql1);
            }

        }
        else
        {
            itSays.Visible = false;
            page1.Visible = false;
            itdiary.Visible = false;
            page2.Visible = false;
            inf1.Visible = false;
            massage1.Visible = false;
            massage2.Visible = false;
            picture.Visible = true;
            page3.Visible = true;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from tabUsers where ID='" + id + "'";
            string name = Class.Search(sql);
            //string userID = Class.Search6(sql);
            Label1.Text = name;
            string visiter = Session["name"].ToString();
            string sql1 = "select * from Photo where userID='" + id + "'order by datetime desc";
            Response.Write("<script>alert('数量为数字！')</script>");
            DataBindToRepeater2(1, sql1);
        }
    }

    void DataBindToRepeater2(int currentPage, string sql)
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

        picture2.DataSource = pds;

        picture2.DataBind();

    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

        string ID = Session["ID1"].ToString();
        string sql = "select*from inf where id='" + id + "'";

        DataTable dt = new DataTable();

        dt = Class.Table(sql);
        string zan = dt.Rows[0][17].ToString();
        string sql2 = "select*from inf where good1 like'%" + ID + "%' and id='" + id + "'";
        int result3 = Class.exist(sql2);

        if (result3 > 0)
            Response.Write("<script>alert('一个用户只能赞一次！')</script>");
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
                Response.Write("<script>alert('赞成功！')</script>");
            else
                Response.Write("<script>alert('赞失败！')</script>");

        }
    }
}

