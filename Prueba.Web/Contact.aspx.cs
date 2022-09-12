using Prueba.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba.Web
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }

        public void CargarTabla()
        {
            try
            {
                var lstCity = UtilApi.ObtenerCity();
                TablaValores.DataSource = lstCity.OrderBy(x => x.Code);
                TablaValores.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MessageSalida", "swal.fire('Error','" + ex.Message + "','error');", true);
            }
        }
    }
}