using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class updateinf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            string ID = Session["ID1"].ToString();
            lbname.Text = ID;

            string sql = "select * from tabUsers where ID='" + ID + "'";
            DataTable dt = new DataTable();

            dt = Class.Table(sql);
            string mail = dt.Rows[0][5].ToString();

            txtname.Text = name;
            txtmail.Text = mail;
            string sex = dt.Rows[0][3].ToString();

            radlSex.SelectedValue = sex;
            string year = dt.Rows[0][4].ToString();

            Year.SelectedValue = year;
            string picture = dt.Rows[0][5].ToString();
            string question1 = dt.Rows[0][6].ToString();
            question.SelectedValue = question1;

            DataTable dt1 = new DataTable();
            dt1 = Class.Table(sql);
            rptinf.DataSource = dt1;
            rptinf.DataBind();
        }
        else Response.Write("<script>alert('请先登录！'),location=='Login.aspx'</script>");
    }

    protected void update1_Click(object sender, EventArgs e)//分为是否修改头像和密保两种大类
    {
        string ID = Session["ID1"].ToString();
        lbname.Text = ID;
        string name = Request.Form[txtname.UniqueID];
        Session["ID1"] = ID;
        Session["name"] = name;
        string mail1 = Request.Form[txtmail.UniqueID];
        string mail = mail1.Trim();
        string sex = Request.Form[radlSex.UniqueID];
        string year = Request.Form[Year.UniqueID];
        string question1 = Request.Form[question.UniqueID];
        string answerpwd1 = answerpwd.Text;
        if (name.Length == 0 || mail.Length == 0)//判断输入都不为空
        {
            Response.Write("<script>alert('信息不为空！')");
            return;
        }
        else
        {
            bool result = Class.IsCorrenctIP(mail);
            if (result == false)
            {
                Response.Write("<script>alert('邮箱地址不正确！')</script>");
                return;
            }
            else
            {
                if (upload1.HasFile)//判断控件是否有文件路径
                {
                    if (answerpwd1.Length == 0)
                    {
                        string filename = upload1.FileName;//取得文件名
                        filename = filename.Substring(filename.LastIndexOf(".") + 1);//取得后缀
                        if (filename.ToLower() == "jpg" || filename.ToLower() == "gif")//判断类型
                        {
                            DateTime currentTime = System.DateTime.Now;
                            int age = Convert.ToInt32(currentTime.Year) - Convert.ToInt32(year);
                            string img = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + filename;
                            upload1.SaveAs(Server.MapPath("images/") + img);
                            string picture = ("images/") + img;
                            //传到根目录的images文件夹+重命名的文件名，也可以用原来的图片的名称，自己定。上传成功；
                            string sql1 = "update tabUsers set name = '" + name + "',sex = '" + sex + "',mail = '" + mail + "',year = '" + year + "',picture='" + picture + "',age='" + age + "' where ID = '" + ID + "'";
                            string sql2 = "update inf set picture='" + picture + "' where userID='" + ID + "'";
                           string sql3= "update Friend set picture='" + picture + "' where friendID='" + ID + "'";
                            int result3 = Class.Put(sql2);
                            int result2 = Class.Put(sql1);
                            int result4 = Class.Put(sql3);
                            if (result2 == 1 && result3 == 1&&result4 ==1)
                                Response.Write("<script>alert('修改成功！');location='Information.aspx'</script>");

                            else if (result2 != 1)
                            {
                                Response.Write("<script>alert('修改失败！');</script>");
                                return;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('图片格式只支持jpg和gif');</script>");
                            return;//提示错误
                        }
                    }
                    if(answerpwd1 .Length !=0)
                    {
                        string answerpwd2 = Class.HashEncode.HashEncoding(answerpwd1);

                        string filename = upload1.FileName;//取得文件名
                        filename = filename.Substring(filename.LastIndexOf(".") + 1);//取得后缀
                        if (filename.ToLower() == "jpg" || filename.ToLower() == "gif")//判断类型
                        {
                            DateTime currentTime = System.DateTime.Now;
                            int age = Convert.ToInt32(currentTime.Year) - Convert.ToInt32(year);
                            string img = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + filename;
                            upload1.SaveAs(Server.MapPath("images/") + img);
                            string picture = ("images/") + img;
                            //传到根目录的images文件夹+重命名的文件名，也可以用原来的图片的名称，自己定。上传成功；
                            string sql1 = "update tabUsers set name = '" + name + "',sex = '" + sex + "',mail = '" + mail + "',year = '" + year + "',picture='" + picture + "',age='" + age + "',question='" + question1 + "',hsanswer='" + answerpwd2 + "' where ID = '" + ID + "'";
                            string sql2 = "update inf set picture='" + picture + "' where userID='" + ID + "'";
                            int result3 = Class.Put(sql2);
                            int result2 = Class.Put(sql1);
                            if (result2 == 1 && result3 == 1)
                                Response.Write("<script>alert('修改成功！');location='Information.aspx'</script>");

                            else if (result2 != 1)
                            {
                                Response.Write("<script>alert('修改失败！');</script>");
                                return;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('图片格式只支持jpg和gif');</script>");
                            return;//提示错误
                        }

                    }
                }

                else
                {
                    if (answerpwd1.Length == 0)
                    {
                        DateTime currentTime = System.DateTime.Now;
                        int age = Convert.ToInt32(currentTime.Year) - Convert.ToInt32(year);
                        string sql = "update tabUsers set name='" + name + "',sex='" + sex + "',mail='" + mail + "',year='" + year + "',age='" + age + "' where ID='" + ID + "'";

                        int result1 = Class.Put(sql);
                        if (result1 == 1)
                            Response.Write("<script>alert('修改成功！');location='Information.aspx'</script>");
                        else
                            Response.Write("<script>alert('修改失败！');location='Updateinf.aspx'</script>");

                    }
                    if (answerpwd1.Length != 0)
                    {
                        string answerpwd2 = Class.HashEncode.HashEncoding(answerpwd1);
                        DateTime currentTime = System.DateTime.Now;
                        int age = Convert.ToInt32(currentTime.Year) - Convert.ToInt32(year);
                        string sql = "update tabUsers set name='" + name + "',sex='" + sex + "',mail='" + mail + "',year='" + year + "',age='" + age + "',question='" + question1 + "',hsanswer='" + answerpwd2 + "' where ID='" + ID + "'";

                        int result1 = Class.Put(sql);
                        if (result1 == 1)
                            Response.Write("<script>alert('修改成功！');location='Information.aspx'</script>");
                        else
                            Response.Write("<script>alert('修改失败！');location='Updateinf.aspx'</script>");
                    }
                }
            }
        }
    }
}