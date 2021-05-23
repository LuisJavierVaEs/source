using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOEstado;

namespace WindowsFormsApp1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            llenarComboBox();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void actualizarCombo()
        {
            this.cmbxEstado.DataSource = null;
            this.cmbxEstado.Items.Clear();
            this.llenarComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = cmbxEstado.SelectedItem.ToString();
        }

        private void llenarComboBox()
        {
            ConeccionADO_Estado ado = new ConeccionADO_Estado();
            DataTable dt = new DataTable();
            dt = ado.Consultar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nombreS = dt.Rows[i]["Nombre"].ToString();
                cmbxEstado.Items.Add(nombreS);
            }
            cmbxEstado.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valorTxtB = textBox1.Text;
            string valorCMBX = cmbxEstado.SelectedItem.ToString();
            if(valorCMBX==valorTxtB)
            btnActualizar.Enabled = false;
            else
            btnActualizar.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConeccionADO_Estado ado = new ConeccionADO_Estado();
            string idBuscado="", edoName = cmbxEstado.SelectedItem.ToString();
            string edoNvoName = textBox1.Text; int id=0;
            DataTable dt = new DataTable();
            dt = ado.Consultar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nameToCompare = dt.Rows[i]["Nombre"].ToString();
                if (nameToCompare == edoName)
                idBuscado = dt.Rows[i]["id"].ToString();
            }

            id = Convert.ToInt32(idBuscado);
            var result = MessageBox.Show($"Esta seguro de que desea actualizar el estado: {edoName} por: {edoNvoName}","Confirmar Edición", 
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ado.Actualizar(id, edoNvoName);
                MessageBox.Show("El estado se ha actualizado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.actualizarCombo();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InputText input = new InputText();
            input.StartPosition = FormStartPosition.CenterScreen;
            this.Visible = false;
            _ = input.ShowDialog();
            this.Visible = true;
            if(input.actualizado)
            {
                this.actualizarCombo();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConeccionADO_Estado ado = new ConeccionADO_Estado();
            string idBuscado = "", edoName = cmbxEstado.SelectedItem.ToString();
            DataTable dt = new DataTable(); int id;
            dt = ado.Consultar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nameToCompare = dt.Rows[i]["Nombre"].ToString();
                if (nameToCompare == edoName)
                    idBuscado = dt.Rows[i]["id"].ToString();
            }
            id = Convert.ToInt32(idBuscado);
            var result = MessageBox.Show($"¿Esta seguro de que desea eliminar el estado: {edoName}?", "Confirmar Eliminación",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                ado.Eliminar(id);
                MessageBox.Show("El estado se ha eliminado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.actualizarCombo();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
