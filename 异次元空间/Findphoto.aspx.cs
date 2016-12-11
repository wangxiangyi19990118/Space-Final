using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Findphoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
           
            string name = Session["name"].ToString();
            string ID = Session["ID1"].ToString();
            int id = Convert.ToInt32(Request.QueryString["id1"]);
            string sql1 = "select * from Photo where id1='" + id + "'";
            string album = Class.Search(sql1);
            string sql = "select * from Photo1 where ID='" + ID + "' and album='"+album+ "'order by datetime desc";//按照时间降序排列
            repeaterdiary.Visible = true;
            page1.Visible = true;
          
            DataBindToRepeater(1, sql);
        }
        else Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
    }
    protected void lbtDelete_Click(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        string sql1 = "delete from Photo1 where id1='" + ID + "'";
        int result = Class.Put(sql1);
        if (result == 1)
        {
            Response.Write("<script>alert('删除成功！');</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('删除失败！');</script>");
            return;
        }

    }

    protected void newalbum3_Click(object sender, EventArgs e)
    {
        repeaterdiary.Visible = true;
        page1.Visible = true;
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id1"]);
        string sql1 = "select * from Photo where id1='" + id + "'";
        string album = Class.Search(sql1);
        string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";
        DataBindToRepeater(1, sql);
    }
    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql1 = "select * from Photo where id='" + id + "'";
        string album = Class.Search(sql1);
        string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);

    }
    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql1 = "select * from Photo where id='" + id + "'";
        string album = Class.Search(sql1);
        string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";

        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lblCurrentPage.Text), sql);


    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql1 = "select * from Photo where id='" + id + "'";
        string album = Class.Search(sql1);
        string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";
        lblCurrentPage.Text = "1";
        DataBindToRepeater(1, sql);
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        string ID = Session["ID1"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sql1 = "select * from Photo where id='" + id + "'";
        string album = Class.Search(sql1);
        string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql1 = "select * from Photo where id='" + id + "'";
            string album = Class.Search(sql1);
            int papercount = Convert.ToInt32(paper.Text);
            string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql1 = "select * from Photo where id='" + id + "'";
            string album = Class.Search(sql1);
            string sql = "select * from Photo1 where ID='" + ID + "'and album='" + album + "'order by datetime desc";
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

    protected void newphoto_Click(object sender, EventArgs e)
    {
        if (upload1.HasFile)//判断控件是否有文件路径
        {
            string ID = Session["ID1"].ToString();
            int id = Convert.ToInt32(Request.QueryString["id1"]);
            string sql1 = "select * from Photo where ID='" +ID + "'";
            string sql2 = "select *from Photo where id1='" + id + "'";
            string album = Class.Search(sql2);
            string photoid= Class.Search3(sql2);
            string filename = upload1.FileName;//取得文件名
            filename = filename.Substring(filename.LastIndexOf(".") + 1);//取得后缀
            if (filename.ToLower() == "jpg" || filename.ToLower() == "gif")//判断类型
            {
                string img = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + filename;
                upload1.SaveAs(Server.MapPath("images/") + img);
                string picture = ("images/") + img;
                //传到根目录的images文件夹+重命名的文件名，也可以用原来的图片的名称，自己定。上传成功；
                string sql = "insert into Photo1(ID,album,photo) values('" + ID + "','" + album + "','" + picture + "')";
                int result2 = Class.Put(sql);
                if (result2 == 1)
                {
                    Response.Write("<script>alert('添加成功！');</script>");
                    return;
                }
                else if (result2 != 1)
                {
                    Response.Write("<script>alert('添加失败！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('图片格式只支持jpg和gif');</script>");
                return;//提示错误
            }
        }
        else
        {
            Response.Write("<script>alert('请选相片！');</script>");
            return;//提示错误
        }


    }

}
    
