using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Entidad copn la cual se puede regresar un tipo de dato genérico
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public class ResultObjectProcess<T> : ResultProcess
    {
        public ResultObjectProcess()
        {
            Entity = Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Entidad Genérica
        /// </summary>
        public T Entity
        {
            get; set;
        }
    }
}