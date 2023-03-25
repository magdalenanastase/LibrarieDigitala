<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="LibrarieDigitala.AddToCart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="CartList" DataKeyNames="ID" AutoGenerateColumns="false" ShowFooter="True" ItemType="LibrarieDigitala.Entities.CartItem" OnRowDeleting="CartList_RowDeleting">
         <Columns>
            <asp:BoundField DataField="ID" Visible="false" />
            <asp:BoundField DataField="Title" HeaderText="Titlu carte" />
            <asp:BoundField DataField="Publishing_House" HeaderText="Editura" />
            <asp:BoundField DataField="Price" HeaderText="Pret" />
            <asp:TemplateField HeaderText="Cantitate">
                <ItemTemplate>
                    <asp:TextBox ID="quantity" runat="server" TextMode="Number" Text="<%#: Item.Cantitate%>"> </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <%#: ((Convert.ToDouble(Item.Cantitate)) *  Convert.ToDouble(Item.Price))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="UpdateButton" runat="server" Text="Editeaza" OnClick="UpdateButton_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="DeleteElemets" runat="server" Text="Stergere produs" OnClick="DeleteElemets_Click" />
                 </ItemTemplate>
             </asp:TemplateField>
            <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true"  DeleteText="Diminueaza cantitatea"/>
        </Columns>
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" ></asp:Label>
        </strong>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Cartea a fost adaugata in cos"></asp:Label>
    <a href="Comanda.aspx" class="btn btn-primary">Comanda</a>

</asp:Content>
