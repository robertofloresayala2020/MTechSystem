using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using System.Data;
using System.Globalization;
namespace BussinesCore
{
    public class Empleado :IDisposable
    {

        

        public Empleado()
        {
        }



        public int ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string RFC { get; set; }

        public DateTime BornDate { get; set; }

        public int Status { get; set; }



        public List<Empleado> GetEmpleados(string filtro )
        {

            string consulta = string.Empty;
            if (filtro != string.Empty &&  filtro != null) consulta += " select * from Empleado where name like '%" + filtro + "%'";
            else consulta = " SELECT * FROM   empleado ";

            Acceso data = new Acceso();
            List<Empleado> lempleado = new List<Empleado>();


            // lempleado = Comunes.ConvertDataTable<Empleado>(data.EjecutaConsulta(consulta)); Debido  a que la base de datos maneja datos text y int64 no es posible tipearlos

            /*En su lugar colocamos el siguiente ciclo*/
            DataTable dt = data.EjecutaConsulta(consulta);
            CultureInfo culture = new CultureInfo("en-US");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               

                Empleado emp = new Empleado();
                emp.ID= Convert.ToInt32(dt.Rows[i]["ID"]);
                emp.Name = dt.Rows[i]["Name"].ToString();
                emp.LastName = dt.Rows[i]["LastName"].ToString();
                emp.RFC = dt.Rows[i]["RFC"].ToString();
                emp.BornDate= dt.Rows[i]["BornDate"]!= null ? DateTime.Parse( dt.Rows[i]["BornDate"].ToString().Substring(0,10),culture):System.DateTime.MinValue;
                emp.Status = Convert.ToInt32(dt.Rows[i]["status"]);
                lempleado.Add(emp);
            }


            return lempleado.OrderBy(x => x.BornDate).ToList();

        }


        public int AddEmpleados(Empleado empleado)
        {
            string valores = "'" + empleado.Name +"'," + "'" + empleado.LastName + "'," + "'" + empleado.RFC + "'," + "'" + empleado.BornDate + "'," + empleado.Status;
            Acceso data = new Acceso();
            int respuesta = data.EjecutarComando("Insert into Empleado(Name,LastName,RFC,BornDate,Status) values("+valores+")");

            return respuesta;


        }



        public bool ValidaRFCUnico(Empleado empleado)
        {

            Acceso data = new Acceso();
            if (data.EjecutaConsulta("select * from Empleado where RFC ='" + empleado.RFC + "'").Rows.Count > 0)
                return false;
            else return true;



        }


        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                  //  this._repositorio.Dispose();


                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion
    }
}
