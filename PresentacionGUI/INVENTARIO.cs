using Datos;
using Entidad;
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
using static PresentacionGUI.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentacionGUI
{
    public partial class INVENTARIO : Form
    {
        Logica.EstablecimientoService servicio2 = new EstablecimientoService();
        Form1 contadores = new Form1();
        public INVENTARIO()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                groupBox2.Visible = true;
                cargarGrillaPersonas();
                VerificarValoresEnPrimeraFila();
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA");
                groupBox2.Visible = false;
            }          
        }
        private void VerificarValoresEnPrimeraFila()
        {
            // Verificar si hay al menos una fila
            if (dataGridView1.Rows.Count > 0)
            {
                // Obtener la primera fila
                DataGridViewRow primeraFila = dataGridView1.Rows[0];

                // Verificar si las columnas 2, 3, 4 y 5 tienen valores y son mayores que 3
                if (VerificarValorYMayorQueTres(primeraFila.Cells[1]) &&
                    VerificarValorYMayorQueTres(primeraFila.Cells[2]) &&
                    VerificarValorYMayorQueTres(primeraFila.Cells[3]) &&
                    VerificarValorYMayorQueTres(primeraFila.Cells[4]))
                {
                    // Todos los valores son mayores que 3
                    MessageBox.Show("Todos los productos tienen una cantidad optima para vender");
                }
                else
                {
                    // Al menos uno de los valores no es mayor que 3
                    MessageBox.Show("Las existencias de un producto se estan agotando");
                }
            }
            else
            {
                // No hay filas en el DataGridView
                MessageBox.Show("El DataGridView está vacío.");
            }
        }

        private bool VerificarValorYMayorQueTres(DataGridViewCell celda)
        {
            // Verificar si la celda tiene un valor válido y es mayor que 3
            return celda != null && celda.Value != null && int.TryParse(celda.Value.ToString(), out int valor) && valor > 3;
        }
        void Guardar(Establecimiento producto)
        {
            var msg = servicio2.Insertar(producto);
            MessageBox.Show(msg);
        }
        private void cargarGrillaPersonas()
        {
            dataGridView1.DataSource = servicio2.ObtenerTodos();
            dataGridView1.Columns[0].Visible = false;
                      
        }

        void AbrirForm(Form form)
        {
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button1.Visible = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dataGridView1.Rows[e.RowIndex];
            Establecimiento producto = new Establecimiento
            {
                Idproducto = Convert.ToString(fila.Cells[0].Value),
                Diamante = Convert.ToInt32(fila.Cells[1].Value),
                Rubi = Convert.ToInt32(fila.Cells[2].Value),
                Zafiro = Convert.ToInt32(fila.Cells[3].Value),
                Esmeralda = Convert.ToInt32(fila.Cells[4].Value)


            };
            var respuesta = MessageBox.Show("desea actualizar la cantidad? ", "actualizar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                servicio2.Actualizar(producto);
                MessageBox.Show("cantidad actualizada");
                cargarGrillaPersonas();
            }
            cargarGrillaPersonas();
        }            
        public void INVENTARIO_Load(object sender, EventArgs e)
        {          
            
        }
        public void pictureBox7_Click(object sender, EventArgs e)
        {          
          groupBox2.Visible = false;
        }
    }
}
