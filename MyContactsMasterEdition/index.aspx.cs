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
    public partial class index : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY024-VM;Initial Catalog=TestContactsDB;Integrated Security=SSPI;MultipleActiveResultSets=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateContactList();
        }

        private void PopulateContactList()
        {



            SqlConnection myCon = new SqlConnection(CON_STR);
            // SqlCommand myRequest = new SqlCommand("select * from contact order by Lastname", myCon
            SqlCommand myRequest = new SqlCommand("select * from AddContactCard order by Lastname", myCon);
            ContentPlaceHolder CPHMain = Page.Master.FindControl("CPHMain") as ContentPlaceHolder;
            try
            {
                myCon.Open();
                SqlDataReader myReader = myRequest.ExecuteReader();
                while (myReader.Read())
                {
                    //ListItem tmpItem = new ListItem(myReader["Firstname"].ToString() + " " + myReader["Lastname"].ToString(), myReader["CID"].ToString());
                    //LBoxContact.Items.Add(tmpItem);
                    // Create instance of the UserControl SimpleControl
                    WebUserControl1 contactCard = (WebUserControl1)Page.LoadControl("~/TestUserControl.ascx");



                    //Add the SimpleControl to Placeholder

                    contactCard.addContactCard(myReader["Firstname"].ToString(), myReader["Lastname"].ToString(), myReader["Type"].ToString(), myReader["Phonenumber"].ToString(), myReader["Image"].ToString(), myReader["CID"].ToString());

                    CPHMain.Controls.Add(contactCard);
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

        protected void userID_TextChanged(object sender, EventArgs e)
        {
            innerleft.InnerHtml = "";
            innerright.InnerHtml = "";
            right.InnerHtml = "";

            Scriptbox.Text += "<script>$('document').ready(function() {$('#myModal').modal('show');});</script>";
            PopulateContactList();

            {
                SqlConnection myCon = new SqlConnection(CON_STR);
                SqlCommand myRequestUser = new SqlCommand($"select * from Contact left join ConAdr on CID=IDC where IDC is null and CID = '{userID.Text}'", myCon);
                SqlCommand myRequest = new SqlCommand($"select * from ContactAdress where idc = '{userID.Text}'", myCon);
                SqlCommand myRequestT = new SqlCommand($"select * from ContactPhone where cid = '{userID.Text}'", myCon);
                SqlCommand myRequestEM = new SqlCommand($"select * from ContactEmail where cid = '{userID.Text}'", myCon);
                try
                {
                    myCon.Open();

                    //Request for adresses
                    SqlDataReader myReaderUser = myRequestUser.ExecuteReader();

                    while (myReaderUser.Read())
                    {
                        lblFirstName.Text = myReaderUser["Firstname"].ToString();
                        lblLastName.Text = myReaderUser["Lastname"].ToString();
                        left.InnerHtml = "Namn: <br />" + myReaderUser["Firstname"].ToString() + "<br />" + myReaderUser["Lastname"].ToString();

                    }

                    SqlDataReader myReader = myRequest.ExecuteReader();
                    int count = 0;
                    while (myReader.Read())
                    {
                        if (count == 0)
                        {
                            lblFirstName.Text = myReader["Firstname"].ToString();
                            lblLastName.Text = myReader["Lastname"].ToString();
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
                    userID.Text = "";
                    myCon.Close();
                }
            }
        }

        protected void deleteSignal_ValueChanged(object sender, EventArgs e)
        {
           // PopulateContactList();
            //Scriptbox.Text = "<script>$('document').ready(function() {alert('Meddelande från backend att användare med ID: " + deleteSignal.Value +" ' )}</script>";
        }
    }

}









