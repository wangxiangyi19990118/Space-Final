using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class Newfriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            lbname.Text = name;
            string ID = Session["ID1"].ToString();
        }
        else Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");
    }
    protected void insert(object sender, EventArgs e)
    {
        friend1.Visible = true;
        page1.Visible = true;
        string ID = Session["ID1"].ToString();
        string massage = txtinput.Text;
        string class1 = dropProv.SelectedValue;
        string massage1 = "%" + massage + "%";
        if (massage.Length == 0)
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";

                        int count = Convert.ToInt32(Cmd.ExecuteScalar());
                        int currentPage = 1;
                        DataTable dt = new DataTable();

                        dt = Class.Table(Cmd.CommandText);

                        PagedDataSource pds = new PagedDataSource();

                        pds.AllowPaging = true;

                        pds.PageSize = 5;

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

                        rptinsert.DataSource = pds;

                        rptinsert.DataBind();

                        Conn.Close(); //关闭数据库
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }

        else
        {
            if (dropProv.SelectedValue == "账号")
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID=@ID";
                            Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {
                                int count = Convert.ToInt32(Class.exist("select * from tabUsers where ID='" + massage + "'"));
                                int currentPage = 1;
                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }

            }


        }
        if (dropProv.SelectedValue == "昵称")
        {
            string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str1))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        //string massage2 = "%" + massage + "%";
                        Cmd.CommandText = "select*from tabUsers where name like @name ";
                        Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                        int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                        int currentPage = 1;
                        if (count2 != 0)
                        {
                            DataTable dt = new DataTable();

                            dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");

                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();


                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        if (dropProv.SelectedValue == "出生日期")
        {
            string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str2))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where year like @year ";
                        Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                        int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                        int currentPage = 1;
                        if (count2 != 0)
                        {
                            DataTable dt = new DataTable();

                            dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");

                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();


                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        if (dropProv.SelectedValue == "性别")
        {
            string str3 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str3))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                        Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                        int count = Convert.ToInt32(Cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            int currentPage = 1;
                            DataTable dt = new DataTable();

                            dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");

                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();

                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }





    protected void rptinsert_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "insert")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql1 = "select *from tabUsers where id='" + id + "'";
            string name = Class.Search(sql1);
            int ID = Convert.ToInt32(Session["ID1"].ToString());
            if (id == ID)
            {
                Response.Write("<script>alert('好友不能是自己！');</script>");
                return;
            }
            string sql = "insert into Friend (ID,friendID,friendname) values('" + ID + "','" + id + "','" + name + "')";

            int result = Class.Put(sql);
            if (result == 1)
                Response.Write("<script>alert('添加成功！');location='Newfriend.aspx'</script>");
            else
                Response.Write("<script>alert('添加失败！');location='Newfriend.aspx'</script>");

        }
    }

    protected void btnBefore_Click(object sender, EventArgs e)//上一页
    {
        string ID = Session["ID1"].ToString();
        string massage = txtinput.Text;
        string class1 = dropProv.SelectedValue;
        if (massage.Length == 0)
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";

                        int count = Convert.ToInt32(Cmd.ExecuteScalar());
                        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
                        int currentPage = (Convert.ToInt32(lblCurrentPage.Text));
                        DataTable dt = new DataTable();

                        dt = Class.Table(Cmd.CommandText);

                        PagedDataSource pds = new PagedDataSource();

                        pds.AllowPaging = true;

                        pds.PageSize = 5;

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

                        rptinsert.DataSource = pds;

                        rptinsert.DataBind();

                        Conn.Close(); //关闭数据库
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }
        else
        {
            if (dropProv.SelectedValue == "账号")
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID='+@ID+ '";
                            Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {
                                lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
                                int currentPage = (Convert.ToInt32(lblCurrentPage.Text));
                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }


            }
            if (dropProv.SelectedValue == "昵称")
            {
                string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str1))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            //string massage2 = "%" + massage + "%";
                            Cmd.CommandText = "select*from tabUsers where name like @name ";
                            Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            int currentPage = 1;
                            if (count2 != 0)
                            {
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();


                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
        if (dropProv.SelectedValue == "出生日期")
        {
            string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str2))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where year like @year ";
                        Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                        int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                        if (count2 > 0)
                        {
                            lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
                            int currentPage = (Convert.ToInt32(lblCurrentPage.Text));
                            DataTable dt = new DataTable();

                            dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");
                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();


                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

        }
        if (dropProv.SelectedValue == "性别")
        {
            string str3 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str3))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                        Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                        int count = Convert.ToInt32(Cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
                            int currentPage = (Convert.ToInt32(lblCurrentPage.Text));
                            DataTable dt = new DataTable();

                            dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");
                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();

                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }

    protected void btnNext_Click(object sender, EventArgs e)//下一页
    {
        string ID = Session["ID1"].ToString();
        string massage = txtinput.Text;
        string class1 = dropProv.SelectedValue;
        if (massage.Length == 0)
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";

                        int count = Convert.ToInt32(Cmd.ExecuteScalar());
                        lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
                        int currentPage = (Convert.ToInt32(lblCurrentPage.Text));

                        DataTable dt = new DataTable();

                        dt = Class.Table(Cmd.CommandText);

                        PagedDataSource pds = new PagedDataSource();

                        pds.AllowPaging = true;

                        pds.PageSize = 5;

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

                        rptinsert.DataSource = pds;

                        rptinsert.DataBind();

                        Conn.Close(); //关闭数据库
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }


        }
        else
        {
            if (dropProv.SelectedValue == "账号")
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID='+@ID+ '";
                            Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {
                                lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
                                int currentPage = (Convert.ToInt32(lblCurrentPage.Text));

                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }


            }
            if (dropProv.SelectedValue == "昵称")
            {
                string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str1))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {

                            Cmd.CommandText = "select*from tabUsers where name like @name ";
                            Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            int currentPage = 1;
                            if (count2 != 0)
                            {
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();


                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            if (dropProv.SelectedValue == "出生日期")
            {
                string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str2))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where year like @year ";
                            Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {
                                lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
                                int currentPage = (Convert.ToInt32(lblCurrentPage.Text));
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();


                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }


            }
            if (dropProv.SelectedValue == "性别")
            {
                string str3 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str3))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                            Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                            int count = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) + 1);
                                int currentPage = (Convert.ToInt32(lblCurrentPage.Text));

                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
    }
    protected void butTop_Click(object sender, EventArgs e)//首页
    {
        string ID = Session["ID1"].ToString();
        string massage = txtinput.Text;
        string class1 = dropProv.SelectedValue;
        if (massage.Length == 0)
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";

                        int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                        if (count2 > 0)
                        {
                            lblCurrentPage.Text = "+1+";
                            int currentPage = 1;

                            DataTable dt = new DataTable();

                            dt = Class.Table(Cmd.CommandText);

                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

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

                            rptinsert.DataSource = pds;

                            rptinsert.DataBind();

                            Conn.Close(); //关闭数据库
                        }
                        else
                        {
                            Response.Write("<script>alert('没有相关信息！');</script>");
                            friend1.Visible = false;
                            page1.Visible = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }
        else
        {
            if (dropProv.SelectedValue == "账号")
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID='+@ID+ '";
                            Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                            int count = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                lblCurrentPage.Text = "+1+";
                                int currentPage = 1;

                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }


            }
            if (dropProv.SelectedValue == "昵称")
            {
                string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str1))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            //string massage2 = "%" + massage + "%";
                            Cmd.CommandText = "select*from tabUsers where name like @name ";
                            Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            int currentPage = 1;
                            if (count2 != 0)
                            {
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");
                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();


                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            if (dropProv.SelectedValue == "出生日期")
            {
                string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str2))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where year like @year ";
                            Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {
                                lblCurrentPage.Text = "+1+";
                                int currentPage = 1;
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            if (dropProv.SelectedValue == "性别")
            {
                string str3 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str3))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                            Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                            int count = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                lblCurrentPage.Text = "+1+";
                                int currentPage = 1;
                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
    }
    protected void btnFinal_Click(object sender, EventArgs e)//尾页
    {
        string ID = Session["ID1"].ToString();
        string massage = txtinput.Text;
        string class1 = dropProv.SelectedValue;
        if (massage.Length == 0)
        {
            string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
            using (SqlConnection Conn = new SqlConnection(str))
            {
                Conn.Open(); //打开数据库 
                try
                {
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";

                        int count1 = Convert.ToInt32(Cmd.ExecuteScalar());

                        DataTable dt = new DataTable();

                        dt = Class.Table(Cmd.CommandText);

                        PagedDataSource pds = new PagedDataSource();

                        pds.AllowPaging = true;

                        pds.PageSize = 5;

                        pds.DataSource = dt.DefaultView;
                        int Count = pds.PageCount;
                        labPage.Text = Count.ToString();
                        lblCurrentPage.Text = Count.ToString();
                        int currentPage = Count;
                        DataTable dt1 = new DataTable();

                        dt1 = Class.Table(Cmd.CommandText);

                        PagedDataSource pds1 = new PagedDataSource();

                        pds1.AllowPaging = true;

                        pds1.PageSize = 5;

                        pds1.DataSource = dt.DefaultView;
                        int Count1 = pds1.PageCount;
                        if (Count1 == 1)
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

                        rptinsert.DataSource = pds;

                        rptinsert.DataBind();

                        Conn.Close(); //关闭数据库
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }
        else
        {
            if (dropProv.SelectedValue == "账号")
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID='+@ID+ '";
                            Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {

                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

                                pds.DataSource = dt.DefaultView;
                                int Count = pds.PageCount;
                                labPage.Text = Count.ToString();
                                lblCurrentPage.Text = Count.ToString();
                                int currentPage = Count;
                                DataTable dt1 = new DataTable();

                                dt1 = Class.Table(Cmd.CommandText);

                                PagedDataSource pds1 = new PagedDataSource();

                                pds1.AllowPaging = true;

                                pds1.PageSize = 5;

                                pds1.DataSource = dt.DefaultView;
                                int Count1 = pds1.PageCount;
                                if (Count1 == 1)
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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
            }
            if (dropProv.SelectedValue == "昵称")
            {
                string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str1))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            //string massage2 = "%" + massage + "%";
                            Cmd.CommandText = "select*from tabUsers where name like @name ";
                            Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());

                            if (count2 != 0)
                            {
                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");


                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

                                pds.DataSource = dt.DefaultView;
                                int Count = pds.PageCount;
                                labPage.Text = Count.ToString();
                                lblCurrentPage.Text = Count.ToString();
                                int currentPage = Count;
                                DataTable dt1 = new DataTable();

                                dt1 = Class.Table(Cmd.CommandText);

                                PagedDataSource pds1 = new PagedDataSource();

                                pds1.AllowPaging = true;

                                pds1.PageSize = 5;

                                pds1.DataSource = dt.DefaultView;
                                int Count1 = pds1.PageCount;
                                if (Count1 == 1)
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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }

            }
            if (dropProv.SelectedValue == "出生日期")
            {
                string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str2))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where year like @year ";
                            Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                            int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count2 > 0)
                            {

                                DataTable dt = new DataTable();

                                dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

                                pds.DataSource = dt.DefaultView;
                                int Count = pds.PageCount;
                                labPage.Text = Count.ToString();
                                lblCurrentPage.Text = Count.ToString();
                                int currentPage = Count;
                                DataTable dt1 = new DataTable();

                                dt1 = Class.Table(Cmd.CommandText);

                                PagedDataSource pds1 = new PagedDataSource();

                                pds1.AllowPaging = true;

                                pds1.PageSize = 5;

                                pds1.DataSource = dt.DefaultView;
                                int Count1 = pds1.PageCount;
                                if (Count1 == 1)
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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();
                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }
            }
            if (dropProv.SelectedValue == "性别")
            {
                string str3 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str3))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                            Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                            int count = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (count > 0)
                            {

                                DataTable dt = new DataTable();

                                dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");

                                PagedDataSource pds = new PagedDataSource();

                                pds.AllowPaging = true;

                                pds.PageSize = 5;

                                pds.DataSource = dt.DefaultView;
                                int Count = pds.PageCount;
                                labPage.Text = Count.ToString();
                                lblCurrentPage.Text = Count.ToString();
                                int currentPage = Count;
                                DataTable dt1 = new DataTable();

                                dt1 = Class.Table(Cmd.CommandText);

                                PagedDataSource pds1 = new PagedDataSource();

                                pds1.AllowPaging = true;

                                pds1.PageSize = 5;

                                pds1.DataSource = dt.DefaultView;
                                int Count1 = pds1.PageCount;
                                if (Count1 == 1)
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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();
                                Conn.Close(); //关闭数据库
                            }
                            else
                            {
                                Response.Write("<script>alert('没有相关信息！');</script>");
                                friend1.Visible = false;
                                page1.Visible = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
            }
        }
    }




    protected void paperturn_Click(object sender, EventArgs e)
    {
        int num = 0;

        if (int.TryParse(Request.Form[paper.UniqueID], out num))
        {
            string ID = Session["ID1"].ToString();
            string massage = txtinput.Text;
            string class1 = dropProv.SelectedValue;
            int papercount = Convert.ToInt32(paper.Text);
            if (massage.Length == 0)
            {
                string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                using (SqlConnection Conn = new SqlConnection(str))
                {
                    Conn.Open(); //打开数据库 
                    try
                    {
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "select * from tabUsers where ID!='" + ID + "'";
                            int count1 = Convert.ToInt32(Cmd.ExecuteScalar());

                            DataTable dt = new DataTable();

                            dt = Class.Table(Cmd.CommandText);

                            PagedDataSource pds = new PagedDataSource();

                            pds.AllowPaging = true;

                            pds.PageSize = 5;

                            pds.DataSource = dt.DefaultView;
                            int Count = pds.PageCount;
                            labPage.Text = Count.ToString();
                            if (papercount == 0 || papercount > Count)
                            {
                                Response.Write("<script>alert('操作无效')</script>");
                            }
                            else
                            {
                                lblCurrentPage.Text = papercount.ToString();

                                DataTable dt1 = new DataTable();

                                dt1 = Class.Table(Cmd.CommandText);

                                PagedDataSource pds1 = new PagedDataSource();

                                pds1.AllowPaging = true;

                                pds1.PageSize = 5;

                                pds1.DataSource = dt.DefaultView;
                                int Count1 = pds1.PageCount;
                                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                                if (Count1 == 1)
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

                                rptinsert.DataSource = pds;

                                rptinsert.DataBind();

                                Conn.Close(); //关闭数据库
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
            }

            else
            {
                if (dropProv.SelectedValue == "账号")
                {
                    string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                    using (SqlConnection Conn = new SqlConnection(str))
                    {
                        Conn.Open(); //打开数据库 
                        try
                        {
                            using (SqlCommand Cmd = Conn.CreateCommand())
                            {
                                Cmd.CommandText = "select * from tabUsers where ID='+@ID+ '";
                                Cmd.Parameters.Add(new SqlParameter("@ID", massage));
                                int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                                if (count2 > 0)
                                {

                                    DataTable dt = new DataTable();

                                    dt = Class.Table("select * from tabUsers where ID='" + massage + "'");

                                    PagedDataSource pds = new PagedDataSource();

                                    pds.AllowPaging = true;

                                    pds.PageSize = 5;

                                    pds.DataSource = dt.DefaultView;
                                    int Count = pds.PageCount;
                                    labPage.Text = Count.ToString();
                                    if (papercount == 0 || papercount > Count)
                                    {
                                        Response.Write("<script>alert('操作无效')</script>");
                                    }
                                    else
                                    {
                                        lblCurrentPage.Text = papercount.ToString();

                                        DataTable dt1 = new DataTable();

                                        dt1 = Class.Table(Cmd.CommandText);

                                        PagedDataSource pds1 = new PagedDataSource();

                                        pds1.AllowPaging = true;

                                        pds1.PageSize = 5;

                                        pds1.DataSource = dt.DefaultView;
                                        int Count1 = pds1.PageCount;
                                        int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                                        if (Count1 == 1)
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

                                        rptinsert.DataSource = pds;

                                        rptinsert.DataBind();

                                        Conn.Close(); //关闭数据库
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('没有相关信息！');</script>");
                                    friend1.Visible = false;
                                    page1.Visible = false;
                                    return;
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                    }
                }
                if (dropProv.SelectedValue == "昵称")
                {
                    string str1 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                    using (SqlConnection Conn = new SqlConnection(str1))
                    {
                        Conn.Open(); //打开数据库 
                        try
                        {
                            using (SqlCommand Cmd = Conn.CreateCommand())
                            {
                                //string massage2 = "%" + massage + "%";
                                Cmd.CommandText = "select*from tabUsers where name like @name ";
                                Cmd.Parameters.Add(new SqlParameter("@name", "%" + massage + "%"));
                                int count2 = Convert.ToInt32(Cmd.ExecuteScalar());

                                if (count2 != 0)
                                {
                                    DataTable dt = new DataTable();

                                    dt = Class.Table("select*from tabUsers where name like '%" + massage + "%' and ID!='" + ID + "'");

                                    PagedDataSource pds = new PagedDataSource();

                                    pds.AllowPaging = true;

                                    pds.PageSize = 5;

                                    pds.DataSource = dt.DefaultView;
                                    int Count = pds.PageCount;
                                    labPage.Text = Count.ToString();
                                    if (papercount == 0 || papercount > Count)
                                    {
                                        Response.Write("<script>alert('操作无效')</script>");
                                    }
                                    else
                                    {
                                        lblCurrentPage.Text = papercount.ToString();

                                        DataTable dt1 = new DataTable();

                                        dt1 = Class.Table(Cmd.CommandText);

                                        PagedDataSource pds1 = new PagedDataSource();

                                        pds1.AllowPaging = true;

                                        pds1.PageSize = 5;

                                        pds1.DataSource = dt.DefaultView;
                                        int Count1 = pds1.PageCount;
                                        int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                                        if (Count1 == 1)
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

                                        rptinsert.DataSource = pds;

                                        rptinsert.DataBind();

                                        Conn.Close(); //关闭数据库
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                    }
                }
                if (dropProv.SelectedValue == "出生日期")
                {
                    string str2 = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                    using (SqlConnection Conn = new SqlConnection(str2))
                    {
                        Conn.Open(); //打开数据库 
                        try
                        {
                            using (SqlCommand Cmd = Conn.CreateCommand())
                            {
                                Cmd.CommandText = "select * from tabUsers where year like @year ";
                                Cmd.Parameters.Add(new SqlParameter("@year", "%" + massage + "%"));
                                int count2 = Convert.ToInt32(Cmd.ExecuteScalar());
                                if (count2 > 0)
                                {

                                    DataTable dt = new DataTable();

                                    dt = Class.Table("select*from tabUsers where year like '%" + massage + "%' and ID!='" + ID + "'");

                                    PagedDataSource pds = new PagedDataSource();

                                    pds.AllowPaging = true;

                                    pds.PageSize = 5;

                                    pds.DataSource = dt.DefaultView;
                                    int Count = pds.PageCount;
                                    labPage.Text = Count.ToString();
                                    if (papercount == 0 || papercount > Count)
                                    {
                                        Response.Write("<script>alert('操作无效')</script>");
                                    }
                                    else
                                    {
                                        lblCurrentPage.Text = papercount.ToString();

                                        DataTable dt1 = new DataTable();

                                        dt1 = Class.Table(Cmd.CommandText);

                                        PagedDataSource pds1 = new PagedDataSource();

                                        pds1.AllowPaging = true;

                                        pds1.PageSize = 5;

                                        pds1.DataSource = dt.DefaultView;
                                        int Count1 = pds1.PageCount;
                                        int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                                        if (Count1 == 1)
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

                                        rptinsert.DataSource = pds;

                                        rptinsert.DataBind();

                                        Conn.Close(); //关闭数据库
                                    }

                                }
                                else
                                {
                                    Response.Write("<script>alert('没有相关信息！');</script>");
                                    friend1.Visible = false;
                                    page1.Visible = false;
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                    }
                }
                if (dropProv.SelectedValue == "性别")
                {
                    string str = @"server=LAPTOP-CM9CUARS;Integrated Security=SSPI;database=Space;";
                    using (SqlConnection Conn = new SqlConnection(str))
                    {
                        Conn.Open(); //打开数据库 
                        try
                        {
                            using (SqlCommand Cmd = Conn.CreateCommand())
                            {
                                Cmd.CommandText = "select * from tabUsers where sex=@sex ";
                                Cmd.Parameters.Add(new SqlParameter("@sex", massage));
                                int count = Convert.ToInt32(Cmd.ExecuteScalar());
                                if (count > 0)
                                {

                                    DataTable dt = new DataTable();

                                    dt = Class.Table("select * from tabUsers where sex='" + massage + "' and ID!='" + ID + "'");

                                    PagedDataSource pds = new PagedDataSource();

                                    pds.AllowPaging = true;

                                    pds.PageSize = 5;

                                    pds.DataSource = dt.DefaultView;
                                    int Count = pds.PageCount;
                                    labPage.Text = Count.ToString();
                                    if (papercount == 0 || papercount > Count)
                                    {
                                        Response.Write("<script>alert('操作无效')</script>");
                                    }
                                    else
                                    {
                                        lblCurrentPage.Text = papercount.ToString();

                                        DataTable dt1 = new DataTable();

                                        dt1 = Class.Table(Cmd.CommandText);

                                        PagedDataSource pds1 = new PagedDataSource();

                                        pds1.AllowPaging = true;

                                        pds1.PageSize = 5;

                                        pds1.DataSource = dt.DefaultView;
                                        int Count1 = pds1.PageCount;
                                        int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                                        if (Count1 == 1)
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

                                        rptinsert.DataSource = pds;

                                        rptinsert.DataBind();

                                        Conn.Close(); //关闭数据库
                                    }
                                }

                                else
                                {
                                    Response.Write("<script>alert('没有相关信息！');</script>");
                                    friend1.Visible = false;
                                    page1.Visible = false;
                                    return;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                    }
                }
            }
        }
        else Response.Write("<script>alert('数量为数字！')</script>");
    }


    protected void insert_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
        string sql1 = "select *from tabUsers where ID='" + id + "'";
        string name = Class.Search(sql1);
        int ID = Convert.ToInt32(Session["ID1"].ToString());
        string picture1 = Class.Search6("select *from tabUsers where ID='" + ID + "'");
        string massage1 = ask1.Text;
        string name1 = Session["name"].ToString();
        //int ID = Convert.ToInt32(Session["ID1"].ToString());
        string picture = Class.Search6(sql1);
        if (id == ID)
        {
            Response.Write("<script>alert('好友不能是自己！');</script>");
            return;
        }
        string sql3 = "select*from Friend where ID='" + ID + "'and friendID='" + id + "'";
        int result2 = Class.exist(sql3);
        if (result2 == 0)
        {
            string sql2 = "insert into ask(ID,name,friendID,friendname,picture,picture1,quanxian,massage) values('" + ID + "','" + name1 + "','" + id + "','" + name + "','" + picture1 + "','" + picture + "','" + 1 + "','" + massage1 + "')";
            int result1 = Class.Put(sql2);
            if (result1 == 1)
            {
                Response.Write("<script>alert('发送请求成功！');</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert('发送请求失败！');</script>");
                return;
            }

        }
        if(result2 == 1)
        {
            Response.Write("<script>alert('该好友已经添加！');</script>");
            return;
        }
    }
}