<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prueba.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br />
        <br />
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <asp:LinkButton ID="linkCrear" runat="server" CssClass="btn btn-success" OnClick="linkCrear_Click">Crear</asp:LinkButton>
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col-md-12">
                <table class="table table-hover">
                    <thead style="background-color: #094fa3; color: #FFF">
                        <tr class="text-center">
                            <th>Id</th>
                            <th>Names</th>
                            <th>Document</th>
                            <th>Ciudad</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="TablaValores" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Code") %></td>
                                    <td><%# Eval("Names") %></td>
                                    <td><%# Eval("Document") %></td>
                                    <td><%# Eval("City_Description") %></td>
                                    <td>
                                        <asp:LinkButton ID="linkConsultar" runat="server" CommandArgument='<%# Eval("Code") %>' ToolTip="Consultar" OnClick="linkConsultar_Click"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
  <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"/>
</svg></asp:LinkButton>
                                        <asp:LinkButton ID="linkEditar" runat="server" CommandArgument='<%# Eval("Code") %>' ToolTip="Editar" OnClick="linkEditar_Click"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
  <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
  <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
</svg></asp:LinkButton>
                                        <asp:LinkButton ID="linkEliminar" runat="server" CommandArgument='<%# Eval("Code") %>' ToolTip="Eliminar" OnClick="linkEliminar_Click"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
  <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
</svg></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="Administrador de Reglas" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <asp:UpdatePanel ID="updateModal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel1" runat="server"></h5>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row justify-content-center">
                                <div class="col-md-12">
                                    <div class="from-group row" id="divCode" visible="false" runat="server">
                                        <label for="txt_Placa" class="col-sm-4 col-form-label">Code*:</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obligatorio"
                                                ControlToValidate="txtCode" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="Registrar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="from-group row">
                                        <label for="txt_Placa" class="col-sm-4 col-form-label">Names*:</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtNames" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio"
                                                ControlToValidate="txtNames" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="Registrar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="from-group row">
                                        <label for="txt_Placa" class="col-sm-8 col-form-label">Last Name*:</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio"
                                                ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="Registrar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="from-group row">
                                        <label for="txt_Placa" class="col-sm-4 col-form-label">Document*:</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtDocument" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio"
                                                ControlToValidate="txtDocument" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="Registrar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="from-group row">
                                        <label for="txt_Placa" class="col-sm-4 col-form-label">City*:</label>
                                        <div class="col-sm-12">
                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Seleccione una opción"
                                                ControlToValidate="ddlCity" InitialValue="0" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="Registrar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="linkCrearSeller" runat="server" ValidationGroup="Registrar" OnClick="linkCrearSeller_Click" class="btn btn-primary btn-block ">Guardar </asp:LinkButton>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
