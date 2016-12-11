﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class massage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)//查看留言
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            repeaterdiary.Visible = true;
            page1.Visible = true;
            string ID = Session["ID1"].ToString();

            string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
            DataBindToRepeater(1, sql);

        }
        else Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
    }
    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);

    }
    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);


    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
        lblCurrentPage.Text = "1";
        DataBindToRepeater(1, sql);
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        string ID = Session["ID1"].ToString();

        string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
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
            string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
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
            string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
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

    protected void repeaterdiary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql2 = "delete from massage where id='" + id + "'";
            
            int result2 = Class.Put(sql2);
            if ( result2 == 1)
                Response.Write("<script>alert('删除成功！');location='massage.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败！');location='massage.aspx'</script>");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        repeaterdiary.Visible = true;
        page1.Visible = true;
        string ID = Session["ID1"].ToString();

        string sql = "select * from massage where ID1='" + ID + "'order by datetime desc";
        DataBindToRepeater(1, sql);
    }
}
  