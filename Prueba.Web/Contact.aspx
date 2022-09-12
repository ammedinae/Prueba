<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Prueba.Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <div class="row justify-content-center">
        <div class="col-md-12">
            <table class="table table-hover">
                <thead style="background-color: #094fa3; color: #FFF">
                    <tr class="text-center">
                        <th>Code</th>
                        <th>Desciption</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="TablaValores" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Code") %></td>
                                <td><%# Eval("Description") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
