<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyContactsMasterEdition.index" %>

<%@ Register Src="~/TestUserControl.ascx" TagPrefix="uc1" TagName="TestUserControl" %>


<asp:Content ID="Content4" ContentPlaceHolderID="CPHMain" runat="server">

    <script>
        $(document).ready(function () {
            $('#trashCan').toggle();
            // $('#myModal').modal('show');
        });
        //Skickar upp modal med ID från sender i en textbox
        function myFunction(sender) {
            var CID = (sender.attr("class"));
            var $moda = $('#myModal');
            $userName = $modal.find('#CPHMain_userID');
            $userName.val(CID);
            __doPostBack();

        }

        function allowDrop(ev) {
            ev.preventDefault();
        }

        function drag(ev, sender) {
            ev.dataTransfer.setData("text", ev.target.className);
            $('#trashCan').toggle();
        }

        function drop(ev) {
            ev.preventDefault();
            var mydiv = ev.dataTransfer.getData("text");
            $("." + mydiv).remove();
            $('#CPHMain_deleteSignal').val(mydiv);
            //Aktivera när borttagning urdatabas är up and running.
            // __doPostBack();
        }

        function dragEnd() {
            $('#trashCan').toggle();
        }
    </script>
    <asp:HiddenField ID="deleteSignal" runat="server" OnValueChanged="deleteSignal_ValueChanged" />
    <asp:Literal ID="Scriptbox" runat="server"></asp:Literal>
    <div id="trashCan" ondragover="allowDrop(event)" ondrop="drop(event)">
        <img src="Images/trashcan.png" />
    </div>



    <!-- Modal -->
    <style>
        #myModal .modal-dialog {
            width: 80%; /* your width */
        }

        .label-Head {
            font-size: 30px;
            text-align: center;
        }
    </style>

    <div id="myModal" class="modal fade wrapper_main" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">

                <div class="label-Head">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <asp:Label ID="lblFirstName" CssClass="label-Head" float="left" runat="server" Text="User"></asp:Label>
                    <asp:Label ID="lblLastName" CssClass="label-Head" float="left" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="modal-body wrapper_main">
                    <asp:TextBox ID="userID" runat="server" AutoPostBack="true" OnTextChanged="userID_TextChanged" style="display:none"></asp:TextBox>
                    <!-- <p>ID:<asp:TextBox ID="CID" runat="server" CssClass="form-control"></asp:TextBox></p>-->
                    <div id="left" class="wrapper_modal" runat="server">
                    </div>
                    <div id="innerleft" class="wrapper_modal" runat="server">
                    </div>
                    <div id="innerright" class="wrapper_modal" runat="server">
                    </div>
                    <div id="right" class="wrapper_modal" runat="server">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" runat="server" class="btn btn-default button1" data-dismiss="modal">Edit</button>                   
                    <button type="button" runat="server" class="btn btn-default button1" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>






