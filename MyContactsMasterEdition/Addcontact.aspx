<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Addcontact.aspx.cs" Inherits="MyContactsMasterEdition.WebForm2" %>



<asp:Content ID="Content4" ContentPlaceHolderID="CPHMain" runat="server">

    <div class="wrapper_main">
        <br />
        Förnamn:<br />
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<br />Förnamn krävs!" ControlToValidate="txtFirstName" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        Efternamn:<br />
        <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<br />Efternamn krävs!" ControlToValidate="txtLastName" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="btn-success" Text="Post" OnClick="Button1_Click"></asp:Button>
        <asp:Button ID="Button2" runat="server" CssClass="btn-danger" Text="Cancel" OnClick="Button2_Click"></asp:Button>
    </div>
    <div class="wrapper_main">
        Adresser:<br />
        Gata:<br />
        <asp:TextBox ID="txtStreet" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        Stad:<br />
        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        Adress 2:<br />
        Gata:<br />
        <asp:TextBox ID="txtStreet2" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        Stad:<br />
        <asp:TextBox ID="txtCity2" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
    </div>
    <div class="wrapper_main">
        Telefonnummer:<br />
        Mobil:<br />
        <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        Arbete:<br />
        <asp:TextBox ID="txtWork" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        Hem:<br />
        <asp:TextBox ID="txtHome" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
    </div>
    <div class="wrapper_main">
        E-mail:<br />
        Arbete:<br />
        <asp:TextBox ID="txtEMWork" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<br />Inte giltig E-post!" ControlToValidate="txtEMWork"  ValidationExpression="\S+@\S+\.\S+\w+" EnableClientScript="false" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        Privat:<br />
        <asp:TextBox ID="txtEMPrivat" runat="server" CssClass="textbox"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="<br />Inte giltig E-post!" ControlToValidate="txtEMPrivat" EnableClientScript="false" ForeColor="Red" ValidationExpression="\S+@\S+\.\S+\w+"></asp:RegularExpressionValidator>
    </div>
</asp:Content>

