using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WriteDiary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string name = Session["name"].ToString();
            Session["name"] = name;
            string ID = Session["ID1"].ToString();
            Session["ID1"] = ID;

        }
        else
        {
            Response.Write("<script>alert('请先登录！'),location='Login.aspx'</script>");

        }
    }


    protected void insert_Click(object sender, EventArgs e)
    {
        string userID = Session["ID1"].ToString();
        string name = Session["name"].ToString();
        string title = txttitle.Text;
        string tip = txttip.Text;
        class1.Text = class1.SelectedValue;
        string class2 = class1.Text;
        string matter = txtmatter.Text;
        string sql1 = "select*from tabUsers where ID='" + userID + "'";
        string picture = Class.Search6(sql1);
        string sql= "insert into inf (userID,title,tip,class,matter,name,id2,id3,picture,id0,picture1,good) values('" + userID + "','" +title + "','" + tip + "','" +class2 + "','" + matter + "','"+name+"','"+0+"','"+0+"','"+picture+"','"+userID+"','"+picture+"','"+0+"')";
        //string sql3 = "insert into inf1 (picture1) values('" + picture + "')";
       
        if (title.Length == 0 || tip.Length == 0 || class2.Length == 0 || matter.Length == 0 )//判断输入都不为空
        {
            Response.Write("<script>alert('输入不为空！')</script>");
            return;
        }
        else
        {
            int result2 = Class.Put(sql);
            //int result3 = Class.Put(sql3);
            if (result2 == 1)
                Response.Write("<script>alert('发表成功！');location='Dairy.aspx'</script>");
            else if (result2 != 1)
            {
                Response.Write("<script>alert('发表失败！');</script>");
                return;
            }
        }
    }
}