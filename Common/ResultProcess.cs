using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Clase que utilizada para indicar el estatus de un proceso y un mensaje
    /// </summary>
    public class ResultProcess
    {
        public ResultProcess()
        {
            //Default estado exitoso.
            Success = true;
        }
        /// <summary>
        /// Propiedad que indica el estado de un proceso
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Propiedad utilizada para regresar un mensaje.
        /// </summary>
        public string Message { get; set; }
    }
}