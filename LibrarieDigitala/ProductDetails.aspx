<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="LibrarieDigitala.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <asp:Label ID="detaliicarte" runat="server" Text=""></asp:Label>
     <asp:FormView ID="form1" runat="server" ItemType="LibrarieDigitala.Entities.Book" DataKeyNames="Book_id" >
          <ItemTemplate>
              <div>
                  <h1 style="text-align:center; font-family: Georgia, serif;"><%#: Item.Title %></h1>
              </div>
              <table>
                  <tr>
                    <td>
                        <asp:Image runat="server" Width="260px" Height="200px" ImageAlign="Middle" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' />
                    </td>
                  <td> &nbsp;</td>
                  <td style="vertical-align:top; text-align:left;">
                      <b style="visibility:hidden"> ID</b><span style="display: none;"><%#: Item.Book_id %></span>
                      <br />
                      <b>Editura: </b><%#:Item.Publishing_house %>
                      <br />
                      <b>Data Publicarii: </b><%#:String.Format("{0:dd.MM.yyyy}", Item.Publishing_date) %>
                      <br />
                      <b>Pret: </b><%#:Item.Price %>
                      <br />
                      <b>Numar Pagini: </b><%#:Item.No_pages %>
                      <br />
                      <b>Descriere:</b> <%#: Item.Description %>
                      <br />
                      <br />
                      <a href="AddToCart.aspx?book_id=<%#: Item.Book_id %>" class="btn btn-primary">Adauga in cos</a>
                  </td>
                  </td>
                  </tr>
              </table>
          </ItemTemplate>
         </asp:FormView>
</asp:Content>
