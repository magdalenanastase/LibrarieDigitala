<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="LibrarieDigitala.EditBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Informatiile despre cartea selectata sunt:" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <table>
        <tr>
            <td>Title:</td>
            <td>
                <asp:TextBox ID="UpdateTitle" runat="server" Width="207px" MaxLength="50" Height="22px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="titluvalidator" runat="server" ControlToValidate="UpdateTitle" ErrorMessage="Titlul este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Editura:</td>
            <td>
                <asp:TextBox ID="UpdatePublishing_House" runat="server" MaxLength="50" Height="22px" Width="207px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="edituravalidator" runat="server" ControlToValidate="UpdatePublishing_House" ErrorMessage="Editura este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Publishing_Date</td>
            <td>
                <asp:TextBox ID="UpdateData" runat="server"  DataFormatString="{0:MM/dd/yyyy}"  Height="22px" Width="206px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="datavalidator" runat="server" ControlToValidate="UpdateData" ErrorMessage="Data este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Price</td>
            <td>
                <asp:TextBox ID="UpdatePrice" runat="server" Height="22px" Width="207px" TextMode="Number" min="1" max="100" step="0.01"  ClientIDMode="Static"></asp:TextBox>
                <asp:RequiredFieldValidator ID="pretvalidator" runat="server" ControlToValidate="UpdatePrice" ErrorMessage="Pretul este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>No_Pages</td>
            <td>
                <asp:TextBox ID="UpdateNoPages" runat="server"  TextMode="Number" min="1" max="10000" step="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UpdateNoPages" ErrorMessage="Numarul de pagini este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Image</td>
            <td>
                <asp:FileUpload ID="AddImage" runat="server" />
                <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="AddImage" ErrorMessage="Va rugam sa alegeti o poza de tip .png, .gif, .jpeg , .bmp , .tiff" ForeColor="Red"                      ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$">   </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Description</td>
            <td>
                <asp:TextBox ID="UpdateDescription" runat="server" MaxLength="150" Height="32px" Width="545px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="descriptionvalidator" runat="server" ControlToValidate="UpdateDescription" ErrorMessage="Descrierea este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
            </td>
        </tr>

    </table>
    <br />
    <br />
        <asp:Button ID="UpdateBook" runat="server" Text="Updateaza cartea"  CausesValidation="true" OnClick="editbook"/>
</asp:Content>
