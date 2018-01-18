using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dempleados
    {
        private int _cod_empleado;
        private string _nombre_empleado;
        private string _apellido_empleado;
        private int _cedula_empleado;
        private string _textoBuscar;


        public int Cod_empleado
        {
            get { return _cod_empleado; }
            set { _cod_empleado = value; }
        }


        public string Nombre_empleado
        {
            get { return _nombre_empleado; }
            set { _nombre_empleado = value; }
        }


        public string Apellido_empleado
        {
            get { return _apellido_empleado; }
            set { _apellido_empleado = value; }
        }


        public int Cedula_empleado
        {
            get { return _cedula_empleado; }
            set { _cedula_empleado = value; }
        }


        public string TextoBuscar
        {
            get { return _textoBuscar; }
            set { _textoBuscar = value; }
        }


        public Dempleados()
        {
 
        }
        
        //Constructor de parametros
        public Dempleados(int cod_empleado, string nombre_empleado, string apellido_empleado, int cedula_empleado)
        {
            this._cod_empleado = cod_empleado;
            this._nombre_empleado = nombre_empleado;
            this._apellido_empleado = apellido_empleado;
            this._cedula_empleado = cedula_empleado;
        }

        //Mètodo insertar
        public string Insertar(Dempleados Empleados)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Còdigo
                SqlCon.ConnectionString = conexion.cn;
                SqlCon.Open();
                //Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "insertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNomEmpleado = new SqlParameter();
                ParNomEmpleado.ParameterName = "@nombre";
                ParNomEmpleado.SqlDbType = SqlDbType.VarChar;
                ParNomEmpleado.Size = 30;
                ParNomEmpleado.Value = Empleados.Nombre_empleado;
                SqlCmd.Parameters.Add(ParNomEmpleado);

                SqlParameter ParApeEmpelado = new SqlParameter();
                ParApeEmpelado.ParameterName = "@apellido";
                ParApeEmpelado.SqlDbType = SqlDbType.VarChar;
                ParApeEmpelado.Size = 30;
                ParApeEmpelado.Value = Empleados.Apellido_empleado;
                SqlCmd.Parameters.Add(ParApeEmpelado);

                SqlParameter ParCedEmpleado = new SqlParameter();
                ParCedEmpleado.ParameterName = "@cedula";
                ParCedEmpleado.SqlDbType = SqlDbType.Int;
                ParCedEmpleado.Value = Empleados.Cedula_empleado;
                SqlCmd.Parameters.Add(ParCedEmpleado);

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Mètodo editar
        public string Editar(Dempleados Empleados)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Còdigo
                SqlCon.ConnectionString = conexion.cn;
                SqlCon.Open();
                //Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "editar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodEmpleado = new SqlParameter();
                ParCodEmpleado.ParameterName = "@codempleado";
                ParCodEmpleado.SqlDbType = SqlDbType.Int;
                ParCodEmpleado.Value= Empleados.Cod_empleado;
                SqlCmd.Parameters.Add(ParCodEmpleado);

                SqlParameter ParNomEmpleado = new SqlParameter();
                ParNomEmpleado.ParameterName = "@nombre";
                ParNomEmpleado.SqlDbType = SqlDbType.VarChar;
                ParNomEmpleado.Size = 30;
                ParNomEmpleado.Value = Empleados.Nombre_empleado;
                SqlCmd.Parameters.Add(ParNomEmpleado);

                SqlParameter ParApeEmpelado = new SqlParameter();
                ParApeEmpelado.ParameterName = "@apellido";
                ParApeEmpelado.SqlDbType = SqlDbType.VarChar;
                ParApeEmpelado.Size = 30;
                ParApeEmpelado.Value = Empleados.Apellido_empleado;
                SqlCmd.Parameters.Add(ParApeEmpelado);

                SqlParameter ParCedEmpleado = new SqlParameter();
                ParCedEmpleado.ParameterName = "@cedula";
                ParCedEmpleado.SqlDbType = SqlDbType.Int;
                ParCedEmpleado.Value = Empleados.Cedula_empleado;
                SqlCmd.Parameters.Add(ParCedEmpleado);

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Mètodo eliminar
        public string Eliminar(Dempleados Empleados)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Còdigo
                SqlCon.ConnectionString = conexion.cn;
                SqlCon.Open();
                //Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "eliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodEmpleado = new SqlParameter();
                ParCodEmpleado.ParameterName = "@codempleado";
                ParCodEmpleado.SqlDbType = SqlDbType.Int;
                ParCodEmpleado.Value = Empleados.Cod_empleado;
                SqlCmd.Parameters.Add(ParCodEmpleado);

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Mètodo mostrar
        public DataTable Mostrar()
        {
            DataTable DtResul = new DataTable("empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResul);

            }
            catch (Exception ex)
            {
                DtResul = null;

            }
            return DtResul;
        }

        //Mètodo buscar
        public DataTable BuscarNombre(Dempleados Empleados)
        {
            DataTable DtResul = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 30;
                ParTextoBuscar.Value = Empleados.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResul);

            }
            catch (Exception ex)
            {
                DtResul = null;

            }
            return DtResul;
        }

    }
}
