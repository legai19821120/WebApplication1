﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

namespace ASPNet
{
    public partial class _28Member_Registeration : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MySystemConnectionString1"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MySystemConnectionString1"].ConnectionString);
                SqlCommand Cmd = new SqlCommand("select * from Edu order by EduLevel_Code desc", Conn);

                SqlDataReader rd;
                Conn.Open();
                rd = Cmd.ExecuteReader();
                ListItem item;
                while (rd.Read())
                {
                    item = new ListItem(rd["EduLevel"].ToString(), rd["EduLevel_Code"].ToString());
                    ddlEduLevel.Items.Add(item);
                }
                Conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           if(this.IsValid)
           {
                try
                {
                    SqlCommand Cmd = new SqlCommand("insert into members values(@account,hashbytes('sha2_256',@pwd),@name,@birthday,@email,@gender,@edu,@note,@photo)", Conn);
                    Cmd.Parameters.AddWithValue("@account", txtAccount.Text);
                    Cmd.Parameters.AddWithValue("@pwd", txtPwd.Text);
                    Cmd.Parameters.AddWithValue("@name", txtName.Text);
                    Cmd.Parameters.AddWithValue("@birthday", txtBirthday.Text);
                    Cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    Cmd.Parameters.AddWithValue("@gender", rblGender.SelectedValue);
                    Cmd.Parameters.AddWithValue("@edu", ddlEduLevel.SelectedValue);
                    Cmd.Parameters.AddWithValue("@note", txtNote.Text);

                    if (fulPhoto.PostedFile.ContentType == "application/octet-stream")
                    {
                        Cmd.Parameters.AddWithValue("@photo", null);
                    }
                    else
                    {
                        Cmd.Parameters.AddWithValue("@photo", fulPhoto.FileBytes);
                    }

                    Conn.Open();
                    if (fulPhoto.PostedFile.ContentType == "image/jpeg")
                    {
                        Cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        lblPhoto.Text = "照片格式錯誤!!!!";
                    }
                    Conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
           }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlCommand Cmd = new SqlCommand("select dbo.fnCheckMemberAccount(@account)", Conn);
            Cmd.Parameters.AddWithValue("@account", txtAccount.Text);

            SqlDataReader rd;
            Conn.Open();
            rd = Cmd.ExecuteReader();

            rd.Read();
            if (rd[0].ToString()=="0")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            Conn.Close();
        }
    }
}