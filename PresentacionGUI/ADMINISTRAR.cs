using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class ADMINISTRAR : Form
    {
        public ADMINISTRAR()
        {
            InitializeComponent();
        }
        ClienteService servicio = new ClienteService(); 
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                dataGridView1.Visible = true;
                CargarEstablecimientos2();
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                
            }
        }

        private void CargarEstablecimientos2()
        {
            var lista = servicio.ConsultarTodos();

            foreach (var item in lista)
            {
                dataGridView1.Rows.Add(item.Id,item.Name,item.Total
                    );
            }
        }
    }
}
