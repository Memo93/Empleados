using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NEmpleados
    {
        public static string Insertar(string nombre, string apellido, int cedula)
        {
            Dempleados Obj = new Dempleados();
            Obj.Nombre_empleado = nombre;
            Obj.Apellido_empleado=apellido;
            Obj.Cedula_empleado=cedula;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int codempleado,string nombre, string apellido, int cedula)
        {
            Dempleados Obj = new Dempleados();
            Obj.Cod_empleado = codempleado;
            Obj.Nombre_empleado = nombre;
            Obj.Apellido_empleado = apellido;
            Obj.Cedula_empleado = cedula;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int codempleado)
        {
            Dempleados Obj = new Dempleados();
            Obj.Cod_empleado = codempleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new Dempleados().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            Dempleados Obj = new Dempleados();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
