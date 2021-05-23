using ADOEstado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InputText : Form
    {
        public bool actualizado { get; internal set; }

        public InputText()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            actualizado = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("No se puede guardar un estado sin nombre","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                ConeccionADO_Estado ado = new ConeccionADO_Estado();
                string nvoEdo = this.textBox1.Text;
                int x = ado.AgregarEstado(nvoEdo);
                if(x==1)
                {
                    MessageBox.Show("Agregado correctamente","Informacion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    actualizado = true;
                }
                else
                {
                    MessageBox.Show("El estado no se  pudeo agregar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
        }
    }
}
