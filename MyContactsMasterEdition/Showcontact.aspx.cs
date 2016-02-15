using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MyContactsMasterEdition
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY024-VM;Initial Catalog=TestContactsDB;Integrated Security=SSPI;MultipleActiveResultSets=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CID"] != "undefined" && Request.QueryString["CID"] != "null")
            {
                SqlConnection myCon = new SqlConnection(CON_STR);
                SqlCommand myRequestUser = new SqlCommand($"select * from Contact left join ConAdr on CID=IDC where IDC is null and CID = '{Request.QueryString["CID"]}'", myCon);
                SqlCommand myRequest = new SqlCommand($"select * from ContactAdress where idc = '{Request.QueryString["CID"]}'", myCon);
                SqlCommand myRequestT = new SqlCommand($"select * from ContactPhone where cid = '{Request.QueryString["CID"]}'", myCon);
                SqlCommand myRequestEM = new SqlCommand($"select * from ContactEmail where cid = '{Request.QueryString["CID"]}'", myCon);
                try
                {
                    myCon.Open();

                    //Request for adresses
                    SqlDataReader myReaderUser = myRequestUser.ExecuteReader();

                    while (myReaderUser.Read())
                    {

                        left.InnerHtml = "Namn: <br />" + myReaderUser["Firstname"].ToString() + "<br />" + myReaderUser["Lastname"].ToString();

                    }

                    SqlDataReader myReader = myRequest.ExecuteReader();
                    int count = 0;
                    while (myReader.Read())
                    {
                        if (count == 0)
                        {
                            left.InnerHtml = "Namn: <br />" + myReader["Firstname"].ToString() + "<br />" + myReader["Lastname"].ToString();
                            innerleft.InnerHtml += "Adresser: <br />" + myReader["Street"].ToString() + "<br />" + myReader["City"].ToString();
                            count++;
                        }
                        else
                            innerleft.InnerHtml += "<br /><br />" + myReader["Street"].ToString() + "<br />" + myReader["City"].ToString();


                    }


                    //Request for phonenumbers
                    SqlDataReader myReaderT = myRequestT.ExecuteReader();
                    count = 0;
                    while (myReaderT.Read())
                    {
                        if (count == 0)
                        {
                            innerright.InnerHtml = "Telefonnummer: <br />" + myReaderT["Type"].ToString() + ": " + myReaderT["Phonenumber"].ToString();
                            count++;
                        }
                        else
                            innerleft.InnerHtml += "<br /><br />" + myReaderT["Type"].ToString() + "<br />" + myReaderT["Phonenumber"].ToString();
                    }
                    //Request for emailadresses
                    SqlDataReader myReaderEM = myRequestEM.ExecuteReader();
                    count = 0;
                    while (myReaderEM.Read())
                    {
                        if (count == 0)
                        {
                            right.InnerHtml = "Email: <br />" + myReaderEM["Email"].ToString();
                            count++;
                        }
                        else
                            left.InnerHtml += "<br /><br />" + myReaderEM["Email"].ToString();
                    }


                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}');</script>");
                }
                finally
                {
                    myCon.Close();
                }
            }
            else
            {
                Response.Redirect("./index.aspx");
                Response.Write("<script>alert('Välj person att visa i listboxen')</script>");
            }
        }

    }
}
