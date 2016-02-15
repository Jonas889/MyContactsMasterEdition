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
    public partial class WebForm2 : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY024-VM;Initial Catalog=TestContactsDB;Integrated Security=SSPI;MultipleActiveResultSets=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtStreet2.Text = "";
            txtCity2.Text = "";
            txtMobile.Text = "";
            txtWork.Text = "";
            txtHome.Text = "";
            txtEMWork.Text = "";
            txtEMPrivat.Text = "";

            Response.Redirect("./index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                Response.Write($"<script>alert('Skriv in både förnamn och efernamn');</script>");
            }
            else
            {
                SqlConnection myCon = new SqlConnection(CON_STR);
                try
                {
                    myCon.Open();

                    SqlCommand myCommand = new SqlCommand("SpAddContact", myCon);
                    myCommand.Parameters.AddWithValue("@Firstname", txtFirstName.Text);
                    myCommand.Parameters.AddWithValue("@Lastname", txtLastName.Text);

                    SqlParameter NewId = new SqlParameter();
                    NewId.ParameterName = "@New_Id";
                    NewId.DbType = DbType.Int32;
                    NewId.Direction = ParameterDirection.Output;
                    myCommand.Parameters.Add(NewId);

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.ExecuteNonQuery();

                    string outPut = myCommand.Parameters["@New_Id"].Value.ToString();
                    myCon.Close();
                    if (txtStreet.Text != "" && txtCity.Text != "")
                    {
                        AddAdress(txtStreet.Text, txtCity.Text, outPut);
                    }
                    if (txtStreet2.Text != "" && txtCity2.Text != "")
                    {
                        AddAdress(txtStreet2.Text, txtCity2.Text, outPut);
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
        }

        private void AddAdress(string street, string city, string cid)
        {
            SqlConnection myCon2 = new SqlConnection(CON_STR);
            try
            {

                myCon2.Open();

                SqlCommand myAdress = new SqlCommand("SpAddAdress", myCon2);
                myAdress.Parameters.AddWithValue("@Street", street);
                myAdress.Parameters.AddWithValue("@City", city);

                SqlParameter NewId = new SqlParameter();
                NewId.ParameterName = "@New_ID";
                NewId.DbType = DbType.Int32;
                NewId.Direction = ParameterDirection.Output;
                myAdress.Parameters.Add(NewId);

                SqlParameter BoolNew = new SqlParameter();
                BoolNew.ParameterName = "@bool_new";
                BoolNew.DbType = DbType.Int32;
                BoolNew.Direction = ParameterDirection.Output;
                myAdress.Parameters.Add(BoolNew);

                myAdress.CommandType = CommandType.StoredProcedure;
                myAdress.ExecuteNonQuery();

                string outPut = myAdress.Parameters["@New_ID"].Value.ToString();
                string isNew = myAdress.Parameters["@bool_new"].Value.ToString();
                if (isNew == "1")
                {
                    SqlCommand myInsertCom = new SqlCommand($"update ConAdr set IDC = '{cid}' where IDA='{outPut}'" , myCon2);
                    myInsertCom.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand myInsertCom = new SqlCommand($"insert into ConAdr (idc,ida) values('{cid}','{outPut}')", myCon2);
                    myInsertCom.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myCon2.Close();
            }
        }

    }
}
