using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmEmpleados : Form
    {
        private bool IsNew = false;

        private bool IsEdit = false;


        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txt_codigo.Text = string.Empty;
            this.txt_nombre.Text = string.Empty;
            this.txt_apellido.Text = string.Empty;
            this.txt_cedula.Text = string.Empty;
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
  
        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleados.Mostrar();
            this.OcultarColumnas();
            lbl_total.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NEmpleados.BuscarNombre(this.txt_buscar.Text);
            this.OcultarColumnas();
            lbl_total.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            this.IsNew = true;
            this.IsEdit = false;

            try
            {
                string rpta = "";
                if (this.txt_nombre.Text == string.Empty)
                {
                    MessageBox.Show("Error falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNew)
                    {
                       
                        rpta = NEmpleados.Insertar(this.txt_nombre.Text.Trim(), this.txt_apellido.Text.Trim(),
                        Convert.ToInt32(this.txt_cedula.Text.Trim()));
                        MessageBox.Show("Usuario insertado con exito","Empleados",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Limpiar();
                    }
                    else
                    {

                        rpta = NEmpleados.Editar(Convert.ToInt32(this.txt_codigo.Text), this.txt_nombre.Text.Trim(), this.txt_apellido.Text.Trim(),
                        Convert.ToInt32(this.txt_cedula.Text.Trim()));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Mostrar();

        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txt_codigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cod_empleado"].Value);
            this.txt_nombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_empleado"].Value);
            this.txt_apellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido_empleado"].Value);
            this.txt_cedula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula_empleado"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (!this.txt_codigo.Text.Equals(""))
            {
                string rpta = "";
                this.IsEdit = true;
                rpta = NEmpleados.Editar(Convert.ToInt32(this.txt_codigo.Text), this.txt_nombre.Text.Trim(), this.txt_apellido.Text.Trim(),
                        Convert.ToInt32(this.txt_cedula.Text.Trim()));
                MessageBox.Show("El usuario se edito de una forma correcta", "Empleado", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Limpiar();
              
            }
            else
            {
                MessageBox.Show("Debe de selecionar primero el empelado a editar");
            }
            this.Mostrar();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void chb_eliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_eliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index) 
            {
                DataGridViewCheckBoxCell chb_eliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chb_eliminar.Value = !Convert.ToBoolean(chb_eliminar.Value);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Empleados",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NEmpleados.Eliminar(Convert.ToInt32(Codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

            this.Mostrar();
            this.chb_eliminar.Checked = false;
        }
    }
}
