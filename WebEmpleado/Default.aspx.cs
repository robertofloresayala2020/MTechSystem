using System;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace WebEmpleado
{

    public partial class Default : System.Web.UI.Page
    {
        public void FindClicked(object sender, EventArgs args)
        {
            Code.ResultObjectProcess<List<Code.Empleado>> resultado = new Code.ResultObjectProcess<List<Code.Empleado>>();


            Code.Empleado empleado = new Code.Empleado();
            empleado.Name = Name.Text;
           
            var jsonenvia = Newtonsoft.Json.JsonConvert.SerializeObject(empleado);
            var data = new StringContent(jsonenvia, Encoding.UTF8, "application/json");

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5002/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("api/empleado/ConsultaEmpleado",data).Result;
               
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                    resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Code.ResultObjectProcess<List<Code.Empleado>>>(responseString);

                    if (!resultado.Success)
                    {
                        EmpleadosGrid.DataSource = null;
                        EmpleadosGrid.DataBind();
                        LError.Text = "Ocurrio un error:" + resultado.Message;


                    }
                    else
                    {
                        EmpleadosGrid.DataSource = resultado.Entity;
                        EmpleadosGrid.DataBind();
                        LError.Text = "Consulta exitosa";

                    }
                }
            }


        }


        public void AddClicked(object sender, EventArgs args)
        {
            Code.ResultObjectProcess<int> resultado = new Code.ResultObjectProcess<int>();
            Code.Empleado empleado = new Code.Empleado();
            CultureInfo culture = new CultureInfo("es-ES");


               empleado.Name = Name.Text;
                empleado.LastName = LastName.Text;
                empleado.RFC = RFC.Text;
                empleado.BornDate = DateTime.Parse(BornDate.Text,culture);
                empleado.Status = Convert.ToInt32(Status.SelectedValue) ;

                var jsonenvia = Newtonsoft.Json.JsonConvert.SerializeObject(empleado);
                var data = new StringContent(jsonenvia, Encoding.UTF8, "application/json");

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5002/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("api/empleado/AgregaEmpleado", data).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                        resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Code.ResultObjectProcess<int>>(responseString);

                    if (!resultado.Success)
                        LError.Text = "Ocurrio un error:" + resultado.Message;
                    else
                    {
                        LError.Text = "Se agregó al empleado correctamente";
                        this.FindClicked(null,null);
                    }


                    }
                }
            

        }
    }
}
