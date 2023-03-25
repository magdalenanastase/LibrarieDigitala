<%@ Page Title="Librarie Digitala" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="LibrarieDigitala.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2 style="text-align: center; font-family: Georgia, serif;"><%: Page.Title %></h2>
            </hgroup>
            <asp:Button ID="SortByPriceButton" runat="server" Text="Sorteaza crescator dupa pret" CssClass="btn btn-outline-secondary" OnClick="SortByPriceButton_Click" />
            <asp:Button ID="SortByPriceDescendingButton" runat="server" Text="Sorteaza descrescator dupa pret" CssClass="btn btn-outline-secondary" OnClick="SortByPriceDescendingButton_Click" />
            <asp:ListView ID="lista_carti" runat="server" DataKeyNames="Book_id" GroupItemCount="3" ItemType="LibrarieDigitala.Entities.Book">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>Nu au fost furnizate date.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <td />
                </EditItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <p style="visibility: hidden"><%#: Item.Book_id %></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href='<%# "ProductDetails.aspx?book_id=" + Item.Book_id %>'>
                                        <asp:Image runat="server" Width="334px" Height="234px" ImageAlign="Middle" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; align-content: center">
                                    <a href='<%# "ProductDetails.aspx?book_id=" + Item.Book_id %>'><span><%#:Item.Title %></span></a><br />
                                    <b>Pret: <b><span><%#:Item.Price %></span><br />
                                        <a href="AddToCart.aspx?book_id=<%#:Item.Book_id %>" style="align-items: center;"><b>Adauga in cos<b></a></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
