using Entidad;
using Logica;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace PresentacionGUI
{
    public partial class Form1 : Form
    {
        ClienteService servicio = new ClienteService();
        Contservice servicio3 = new Contservice();
        Establecimiento producto = new Establecimiento();
        Cont contador = new Cont();
        Logica.ClienteServiceBD clienteservicio=new ClienteServiceBD();
        EstablecimientoService establecimientoservicio =new EstablecimientoService();
        public Form1()
        {
            InitializeComponent();
        }
        double total = 0;


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            pictureBox7.Visible = true;
            pictureBox8.Visible = false;
            groupBox1.Visible = true;
            pictureBox5.Visible = false;
            if (comboBox1.Text == "Diamante")
            {
                FALSEAR();
                pictureBox1.Visible = true;
            }
            if (comboBox1.Text == "Rubi")
            {
                FALSEAR();
                pictureBox2.Visible = true;
            }
            if (comboBox1.Text == "Zafiro")
            {
                FALSEAR();
                pictureBox3.Visible = true;
            }
            if (comboBox1.Text == "Esmeralda")
            {
                FALSEAR();
                pictureBox4.Visible = true;
            }

        }

        void FALSEAR()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            button2.Enabled = true;
            double preciodiamante = 500;
            double preciorubi = 100;
            double preciozafiro = 200;
            double precioesmeralda = 350;

            if (comboBox1.Text == "Diamante")
            {

                if (comboBox2.Text == "0.25 quilates")
                {
                    textBox1.Text = " ";
                    preciodiamante = (preciodiamante * 25);
                    textBox1.Text = Convert.ToString(preciodiamante);
                }
                if (comboBox2.Text == "0.5 quilates")
                {
                    textBox1.Text = " ";
                    preciodiamante = (preciodiamante * 50);
                    textBox1.Text = Convert.ToString(preciodiamante);
                }
                if (comboBox2.Text == "1 quilates")
                {
                    textBox1.Text = " ";
                    preciodiamante = (preciodiamante * 100);
                    textBox1.Text = Convert.ToString(preciodiamante);
                }


            }

            if (comboBox1.Text == "Rubi")
            {
                if (comboBox2.Text == "0.25 quilates")
                {
                    textBox1.Text = " ";
                    preciorubi = (preciorubi * 25);
                    textBox1.Text = Convert.ToString(preciorubi);
                }
                if (comboBox2.Text == "0.5 quilates")
                {
                    textBox1.Text = " ";
                    preciorubi = (preciorubi * 50);
                    textBox1.Text = Convert.ToString(preciorubi);
                }
                if (comboBox2.Text == "1 quilates")
                {
                    textBox1.Text = " ";
                    preciorubi = (preciorubi * 100);
                    textBox1.Text = Convert.ToString(preciorubi);
                }
            }

            if (comboBox1.Text == "Zafiro")
            {

                if (comboBox2.Text == "0.25 quilates")
                {
                    textBox1.Text = " ";
                    preciozafiro = (preciozafiro * 10);
                    textBox1.Text = Convert.ToString(preciozafiro);
                }
                if (comboBox2.Text == "0.5 quilates")
                {
                    textBox1.Text = " ";
                    preciozafiro = (preciozafiro * 23);
                    textBox1.Text = Convert.ToString(preciozafiro);
                }
                if (comboBox2.Text == "1 quilates")
                {
                    textBox1.Text = " ";
                    preciozafiro = (preciozafiro * 30);
                    textBox1.Text = Convert.ToString(preciozafiro);
                }
            }

            if (comboBox1.Text == "Esmeralda")
            {

                if (comboBox2.Text == "0.25 quilates")
                {
                    textBox1.Text = " ";
                    precioesmeralda = (precioesmeralda * 23);
                    textBox1.Text = Convert.ToString(precioesmeralda);
                }
                if (comboBox2.Text == "0.5 quilates")
                {
                    textBox1.Text = " ";
                    precioesmeralda = (precioesmeralda * 42);
                    textBox1.Text = Convert.ToString(precioesmeralda);
                }
                if (comboBox2.Text == "1 quilates")
                {
                    textBox1.Text = " ";
                    precioesmeralda = (precioesmeralda * 87);
                    textBox1.Text = Convert.ToString(precioesmeralda);
                }
            }
        }
        void AbrirForm(Form form)
        {
            form.ShowDialog();
        }
        void CerrarForm(Form form) 
        { 
            form.Close();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            INICIO();
            AbrirForm(new INVENTARIO());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((comboBox2.Text == "")||(comboBox2.Text == null)) 
            {
                MessageBox.Show("No has seleccionado ningun articulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                               
                    double precio = Convert.ToDouble(textBox1.Text);
                    total = total + precio;
                    textBox2.Text = Convert.ToString(total);
                    tabla();
                   
                    
                    if (comboBox1.Text == "Diamante")
                    {               
                        establecimientoservicio.DescontarProducto(producto, "Diamante", 1) ;

                    }else if(comboBox1.Text == "Rubi")
                    {
                        establecimientoservicio.DescontarProducto(producto, "Rubi", 1);
                    }
                    else if(comboBox1.Text == "Zafiro")
                    {
                        establecimientoservicio.DescontarProducto(producto, "Zafiro", 1);
                    }
                    else if(comboBox1.Text == "Esmeralda")
                    {
                        establecimientoservicio.DescontarProducto(producto, "Esmeralda", 1);
                    }
                    
                    comboBox2.Text = " ";
                    textBox1.Text = " ";

            }
        }
        void Guardar(Cliente cliente)
        {
            var msg2 = clienteservicio.Insertar(cliente); 
            var msg = servicio.GuardarRegistros(cliente);          
            
            MessageBox.Show(msg);

        }
        void Guardar2(Cont cont)
        {
            var msg = servicio3.GuardarRegistros(cont);
        }
        
        
        public void tabla()
        {
            dataGridView1.Rows.Add(comboBox1.Text, comboBox2.Text, textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("No has añadido nada al carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            { 
                if ((textBox3.Text != "") || (textBox4.Text != ""))
                {
                    //aca
                    string ID = textBox4.Text;
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        // Verificar si la fila no es nueva y no está siendo eliminada
                        if (!fila.IsNewRow && fila.Visible)
                        {
                            // Obtener los valores de las celdas en las columnas deseadas
                            string Joya = Convert.ToString(fila.Cells[0].Value);
                            string Quilates = Convert.ToString((fila.Cells[1].Value));
                            double Precio = Convert.ToDouble(fila.Cells[2].Value);

                            Guardar2(new Cont(ID, Joya, Quilates, Precio));

                        }
                    }

                    //hasta aca

                    Guardar(new Cliente(textBox4.Text, textBox3.Text, textBox5.Text,textBox6.Text, double.Parse(textBox2.Text)));

                    

                    groupBox2.Visible = false;
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox2.Clear();

                }
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "")||(textBox2.Text == "0"))
            {
                MessageBox.Show("No has añadido nada al carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox2.Visible = true;
            }
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47)||(e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("La cedula no puede llevar texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("El nombre no puede llevar Numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("El numero no puede llevar texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Eliga opciones con el mouse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            comboBox2.Text = null;
            return;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Eliga opciones con el mouse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            comboBox2.Text = "";
            return;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            button5.Visible = false;
        }
        
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            INICIO();
            
        }
        void INICIO()
        {
            comboBox1.Text = "";
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;
            groupBox1.Visible = false;
            pictureBox5.Visible = true;
            groupBox4.Visible = false;
            button5.Visible = true;
            groupBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No hay articulos en el carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox2.Text = "";
                return;
            }
            else
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                // Obtén el valor de la celda en la tercera columna
                object cellValue = dataGridView1.Rows[rowIndex].Cells[2].Value;
                if (cellValue != null) 
                {
                textBox7.Text = cellValue.ToString();
                total = total - Convert.ToDouble(textBox7.Text);
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                textBox2.Text = Convert.ToString(total);
                }
                else
                {
                   MessageBox.Show("Seleccione un articulo de su carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            button2.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            INICIO();
            AbrirForm(new ADMINISTRAR());
        }
    }
}
