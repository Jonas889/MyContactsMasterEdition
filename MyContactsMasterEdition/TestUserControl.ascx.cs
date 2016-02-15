using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyContactsMasterEdition
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void addContactCard(string firstName, string LastName, string type, string phoneNumber, string image, string ID)
        {
                      
            Contact.Text += "<div class=" + ID + " id=\"f1_container\" onclick=\"myFunction($(this))\" draggable=\"true\" ondragstart=\"drag(event, this)\" ondragend=\"dragEnd(event)\">";
            Contact.Text += "<div id=\"f1_card\" class=\"shadow img\">";
            Contact.Text += "<div class=\"front face\">";
            Contact.Text += $"<img src=\"Images/{image}\"/ draggable=\"false\">";
            Contact.Text += "</div>";
            Contact.Text += "<div class=\"back face center\">";
            Contact.Text += $"<p>{firstName}</p>";
            Contact.Text += $"<p>{LastName}</p>";
            Contact.Text += $"<p>{type}: </p>";
            Contact.Text += $"<p>{phoneNumber}: </p>";
            Contact.Text += "</div>";
            Contact.Text += "</div>";
            Contact.Text += "</div>";
        }
    }
}