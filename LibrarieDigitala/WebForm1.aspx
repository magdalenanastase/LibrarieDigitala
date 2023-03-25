<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LibrarieDigitala.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:GridView ID="grid2" runat="server"  DataKeyNames="Book_id" ItemType="LibrarieDigitala.Entities.Book" AllowPaging="True"  AutoGenerateColumns="False"
         BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
<%--            <asp:BoundField DataField="Fk_book_id" HeaderText="Bookid" />--%>
            <asp:BoundField DataField="Book_id" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="Title" HeaderText="Titlu"></asp:BoundField>
            <asp:BoundField DataField="Publishing_house" HeaderText="Editura"></asp:BoundField>
            <asp:BoundField DataField="Publishing_date" HeaderText="Data publicarii" />
            <asp:BoundField DataField="Price" HeaderText="Pret" />
            <asp:BoundField DataField="No_pages" HeaderText="Numar pagini" />
            <asp:BoundField DataField="Description" HeaderText="Descriere" />
            <asp:BoundField DataField="Fk_book_id" HeaderText="Fk" />
            
            <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true" />
          
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</asp:Content>
