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

namespace PresentacionGUI
{
    public partial class Form1 : Form
    {
        ClienteService servicio = new ClienteService();
        public Form1()
        {
            InitializeComponent();
        }
        double total = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
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
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new INVENTARIO());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double precio = Convert.ToDouble(textBox1.Text);
            total = total + precio;
            textBox2.Text = Convert.ToString(total);
            tabla();          
            comboBox2.Text = " ";
            textBox1.Text = " ";
        }
        void Guardar(Cliente cliente)
        {

            var msg = servicio.GuardarRegistros(cliente);
            MessageBox.Show(msg);

        }
        public void tabla()
        {
            dataGridView1.Rows.Add(comboBox1.Text, comboBox2.Text, textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != "")||(textBox4.Text != ""))
            {
                Guardar(new Cliente(textBox4.Text, textBox3.Text, double.Parse(textBox2.Text) )) ;

            }
            
        }
    }
}
