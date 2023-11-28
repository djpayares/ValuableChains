using Entidad;
using Logica;
using System;
using System.CodeDom;
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
        Logica.ClienteServiceBD servicio2 = new Logica.ClienteServiceBD();
        Contservice servicio3 = new Contservice();
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                textBox2.Visible = true;
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                button1.Visible = false;
                button2.Visible = false;
                CargarEstablecimientos2();
                cargarGrillaPersonas();
                cargargrillapersonas2();
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                
            }
        }
        private void CargarEstablecimientosFiltrado(string filtro)
        {
            dataGridView2.DataSource = servicio.ConsultarFiltrado(filtro);
        }
        private void cargargrillapersonas2()
        {
            dataGridView3.DataSource = servicio3.ObtenerTodos();
            dataGridView3.Columns[2].Visible = true;
            dataGridView3.Columns[3].DefaultCellStyle.Format = "#,#";
        }
        private void cargarGrillaPersonas()
        {
            dataGridView2.DataSource = servicio2.ObtenerTodos();
            dataGridView2.Columns[4].DefaultCellStyle.Format = "#,#";

        }
        private void CargarEstablecimientos2()
        {
            var lista = servicio.ConsultarTodos();

            foreach (var item in lista)
            {
                dataGridView1.Rows.Add(item.Id,item.Name,item.Telefono,item.Direccion,item.Total
                    );
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
        }
        
        void Eliminar(string id)
        {
            var msg = servicio2.Eliminar(id);
            MessageBox.Show(msg);

        }
             

        private void dataGridView2_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dataGridView2.Rows[e.RowIndex];
            Cliente cliente = new Cliente
            {
                Id = Convert.ToString(fila.Cells[0].Value),
                Name = fila.Cells[1].Value.ToString(),
                Telefono = fila.Cells[2].Value.ToString(),
                Direccion = fila.Cells[3].Value.ToString(),
                Total = Convert.ToDouble(fila.Cells[4].Value)

            };
            var respuesta = MessageBox.Show("desea actualizar los datos ", "actualizar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                servicio2.Actualizar(cliente);
                MessageBox.Show("datos actualizados");
                cargarGrillaPersonas();
            }
            cargarGrillaPersonas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminar(Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value));
            cargarGrillaPersonas();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                dataGridView2.CurrentCell = null;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Visible = false;

                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if ((cell.Value.ToString().ToUpper()).IndexOf(textBox2.Text.ToUpper()) == 0)
                        {
                            row.Visible = true;
                            break;
                        }                    

                    }

                }
                dataGridView3.CurrentCell = null;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Visible = false;

                }
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if ((cell.Value.ToString().ToUpper()).IndexOf(textBox2.Text.ToUpper()) == 0)
                        {
                            row.Visible = true;
                            groupBox3.Visible = true;
                            break;
                        }

                    }

                }

            }
            else
            {
                cargarGrillaPersonas();
            }
        }

        
    }
}
