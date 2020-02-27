using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Configuration;
namespace Datos
{
    public class Acceso
    {

        private SqliteCommand _Comando;
        private string _cadenaConexion;


        public Acceso()
        {
            //_cadenaConexion = System.Configuration.ConfigurationManager.AppSettings.Get("CadenaConexion").ToString();
            _cadenaConexion = "Data Source=empleado.db;";
            _Comando = new SqliteCommand();
        }

        public DataTable EjecutaConsulta(string Consulta) 
        {
          

            using (SqliteConnection _Conexion = new SqliteConnection())
            {
                try
                {
                    _Conexion.ConnectionString = this._cadenaConexion;
                    while (_Conexion.State != ConnectionState.Open)
                        _Conexion.Open();

                    _Comando.Connection = _Conexion;
                    _Comando.Connection.EnableExtensions(true);
                    _Comando.Cancel();
                    _Comando.CommandText = Consulta;

                    DataTable dt = new DataTable("Empleado");

                    using (SqliteDataReader reader = _Comando.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();
                     }
                        
                    return dt; 
                }
                catch (SqliteException ex)
                {
                   
                    throw ex;
                }
                catch (Exception exc)
                {
                    
                    throw exc;
                }
                finally
                {
                    _Conexion.Close();
                }
            }
        }


   
        public int EjecutarComando(string Comando)
        {
            int respuesta = 0;

            using (SqliteConnection _Conexion = new SqliteConnection())
            {
                try
                {
                    _Conexion.ConnectionString = this._cadenaConexion;
                    while (_Conexion.State != ConnectionState.Open)
                        _Conexion.Open();

                    _Comando.Connection = _Conexion;
                    _Comando.Cancel();
                    _Comando.CommandText = Comando;
                    _Comando.Prepare();
                    respuesta = _Comando.ExecuteNonQuery();
                }
                catch (Exception exc)
                {

                    throw exc;
                }
                finally
                {
                    _Conexion.Close();
                
             
                }
            }

            return respuesta;
        }



        #region Dispose
        /// <summary>
        /// Variable para controlar el dispose
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Método que realiza el limpiado de objetos
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _cadenaConexion = null;
                    _Comando = null;
                }
            }
            this.disposed = true;
        }
        /// <summary>
        /// Implementación del método Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

    }
}
