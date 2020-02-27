using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEmpleado.Code
{
  
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
