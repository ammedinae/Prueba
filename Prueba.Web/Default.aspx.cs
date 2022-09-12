using Prueba.Web.Models;
using Prueba.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                CargarSelect();
            }
        }

        public void CargarDatos()
        {
            try
            {
                var lstSeller = UtilApi.ObtenerSeller();

                TablaValores.DataSource = lstSeller.OrderBy(x => x.Code);
                TablaValores.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }

        public void CargarSelect()
        {
            try
            {
                var lstCity = UtilApi.ObtenerCity();

                if (lstCity.Count > 0)
                {
                    ddlCity.DataSource = lstCity;
                    ddlCity.DataValueField = "Code";
                    ddlCity.DataTextField = "Description";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("Seleccione una opcion", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }

        protected void linkCrear_Click(object sender, EventArgs e)
        {
            try
            {
                exampleModalLabel1.InnerText = "Crear Seller";
                updateModal.Update();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function(){$('#myModal').modal();});", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }

        protected void linkConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkGuardar = sender as LinkButton;
                string splitId = linkGuardar.CommandArgument;
                long id = 0;

                if (splitId != "") id = Convert.ToInt64(splitId);

                var seller = UtilApi.ObtenerSellerId(id);

                if (seller.Code > 0)
                {
                    txtCode.Visible = true;
                    txtCode.Text = seller.Code.ToString();
                    txtCode.Enabled = false;
                    txtNames.Text = seller.Names;
                    txtNames.Enabled = false;
                    txtLastName.Text = seller.Last_Name;
                    txtLastName.Enabled = false;
                    txtDocument.Text = seller.Document.ToString();
                    txtDocument.Enabled = false;
                    ddlCity.SelectedValue = seller.City_Id.ToString();
                    ddlCity.Enabled = false;
                    linkCrearSeller.Visible = false;

                    exampleModalLabel1.InnerText = "Consultar Seller";
                    updateModal.Update();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function(){$('#myModal').modal();});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','Algo ocurrio intenta nuevamente','error');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }

        protected void linkEditar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkGuardar = sender as LinkButton;
                string splitId = linkGuardar.CommandArgument;
                long id = 0;

                if (splitId != "") id = Convert.ToInt64(splitId);

                var seller = UtilApi.ObtenerSellerId(id);

                if (seller.Code > 0)
                {
                    txtCode.Visible = true;
                    txtCode.Text = seller.Code.ToString();
                    txtCode.Enabled = false;
                    txtNames.Text = seller.Names;
                    txtLastName.Text = seller.Last_Name;
                    txtDocument.Text = seller.Document.ToString();
                    txtDocument.Enabled = false;
                    ddlCity.SelectedValue = seller.City_Id.ToString();

                    exampleModalLabel1.InnerText = "Editar Seller";
                    updateModal.Update();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function(){$('#myModal').modal();});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','Algo ocurrio intenta nuevamente','error');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }            
        }

        protected void linkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkGuardar = sender as LinkButton;
                string splitId = linkGuardar.CommandArgument;
                long id = 0;

                if (splitId != "") id = Convert.ToInt64(splitId);

                bool valida = UtilApi.EliminarSeller(id);

                if (valida)
                {
                    string mensajes = "swal.fire({" +
                        "title: 'Correcto'," +
                        "text: 'Datos eliminados correctamente.'," +
                        "icon: 'success'," +
                        "confirmButtonColor: '#3085d6'," +
                        "confirmButtonText: 'Aceptar'" +
                        "}).then((result)=> {" +
                        "if(result.value){" +
                        "window.location.href = 'Default.aspx'" +
                        "}" +
                        "setTimeout(() => location.href = 'Default.aspx', 10000);" +
                        "});";
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Message", mensajes, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','Algo ocurrio intenta nuevamente','error');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }

        protected void linkCrearSeller_Click(object sender, EventArgs e)
        {
            try
            {
                long document = Convert.ToInt64(txtDocument.Text);
                long cityId = Convert.ToInt64(ddlCity.SelectedValue);

                SellerDto sellerDto = new SellerDto()
                {
                    Names = txtNames.Text,
                    Last_Name = txtLastName.Text,
                    Document = document,
                    City_Id = cityId,
                };

                bool valida = UtilApi.CrearSeller(sellerDto);

                if (valida)
                {
                    string mensajes = "swal.fire({" +
                        "title: 'Correcto'," +
                        "text: 'Datos guardados correctamente.'," +
                        "icon: 'success'," +
                        "confirmButtonColor: '#3085d6'," +
                        "confirmButtonText: 'Aceptar'" +
                        "}).then((result)=> {" +
                        "if(result.value){" +
                        "window.location.href = 'Default.aspx'" +
                        "}" +
                        "setTimeout(() => location.href = 'Default.aspx', 10000);" +
                        "});";
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Message", mensajes, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','Algo ocurrio intenta nuevamente','error');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }
    }
}