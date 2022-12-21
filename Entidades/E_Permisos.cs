using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Permisos
    {
        public int IdPermisos { get; set; }

        public int RolUsuario { get; set; }

        public int OpcionId { get; set; }

        public bool Permitido { get; set; }
    }
}
