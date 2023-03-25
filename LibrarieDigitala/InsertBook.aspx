<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertBook.aspx.cs" Inherits="LibrarieDigitala.InsertBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Introduceti datele" Font-Size="Large" Font-Bold="true" Font-Italic="true"></asp:Label>

    <div>
        <table>
            <tr>
                <td>Title:</td>
                <td>
                    <asp:TextBox ID="AddTitle" runat="server" Width="159px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="titluvalidator" runat="server" ControlToValidate="AddTitle" ErrorMessage="Titlul este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Editura:</td>
                <td>
                    <asp:TextBox ID="AddPublishing_House" runat="server" MaxLength="50" Width="157px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="edituravalidator" runat="server" ControlToValidate="AddPublishing_House" ErrorMessage="Editura este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Publishing_Date</td>
                <td>

                    <asp:TextBox ID="Data" runat="server" TextMode="Date" ReadOnly="false" Width="157px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="datavalidator" runat="server" ControlToValidate="Data" ErrorMessage="Data este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Price</td>
                <td>
                    <asp:TextBox ID="AddPrice" runat="server" TextMode="Number" min="1" max="100" step="0.01" Width="154px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="pretvalidator" runat="server" ControlToValidate="AddPrice" ErrorMessage="Pretul este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>No_Pages</td>
                <td>
                    <asp:TextBox ID="AddNoPages" runat="server" TextMode="Number" min="1" max="10000" step="1" Width="158px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AddNoPages" ErrorMessage="Numarul de pagini este obligatoriu!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Image</td>
                <td>
                    <asp:FileUpload ID="AddImage" runat="server" Width="302px" />
                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                        ControlToValidate="AddImage"
                        ErrorMessage="Va rugam sa alegeti o poza de tip .png, .gif, .jpeg , .bmp , .tiff" ForeColor="Red"
                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|WEBP|GIF)$">>
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="AddDescription" runat="server" MaxLength="150" Width="157px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="descriptionvalidator" runat="server" ControlToValidate="AddDescription" ErrorMessage="Descrierea este obligatorie!" ForeColor="Red"> </asp:RequiredFieldValidator>
                </td>
            </tr>

        </table>
    </div>
    <asp:Button ID="Insert" runat="server" Text="Adauga Carte " OnClick="AddProductButton_Click" CausesValidation="true" />
</asp:Content>
