<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneazaCarti.aspx.cs" Inherits="LibrarieDigitala.Gestioneaza_carti" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3  style="text-align:center; font-family: Georgia, serif;">Toate cartile aflate in gestiune</h3>
    <br />
    <asp:Button ID="insert" Text="Adauga o carte" runat="server" OnClick="insertredirect" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text=" " Enabled="false"></asp:Label>
    <asp:GridView ID="grid1" runat="server"  PageSize="3" DataKeyNames="Book_id" ItemType="LibrarieDigitala.Entities.Book" AllowPaging="True" OnPageIndexChanging="OnPaging" AutoGenerateColumns="False" OnRowDeleting="grid1_RowDeleting" BackColor="#022a50" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="#022a50" >
        <Columns>
            <asp:BoundField DataField="Book_id" HeaderText="ID" Visible="false" HeaderStyle-VerticalAlign="Middle"/>
            <asp:BoundField DataField="Title" HeaderText="Titlu"></asp:BoundField>
            <asp:BoundField DataField="Publishing_house" HeaderText="Editura"></asp:BoundField>
            <asp:BoundField DataField="Publishing_date" HeaderText="Data publicarii" />
            <asp:BoundField DataField="Price" HeaderText="Pret" />
            <asp:BoundField DataField="No_pages" HeaderText="Numar pagini" />
            <asp:BoundField DataField="Description" HeaderText="Descriere" />
            <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true" />
            <asp:TemplateField>
                <ItemTemplate>
                   <asp:HyperLink ID="updclick" runat="server" NavigateUrl='<%# string.Format("~/EditBook.aspx?Book_id={0}", Eval("Book_id").ToString()) %>' Text="Update"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Yellow" />
        <HeaderStyle BackColor="#022a50" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#022a50" ForeColor="White" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</asp:Content>
