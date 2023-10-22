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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentacionGUI
{
    public partial class AGREGAR : Form
    {
        public AGREGAR()
        {
            InitializeComponent();
        }

        Establecimiento establecimiento = new Establecimiento();
        EstablecimientoService servicio = new EstablecimientoService();

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Diamante")
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("No ha introducido Nuevo material");
                }
                else
                {
                    establecimiento.Diamante = establecimiento.Diamante + int.Parse(textBox2.Text);
                }

            }
            if (comboBox1.Text == "Rubi")
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("No ha introducido Nuevo material");
                }
                else
                {
                    establecimiento.Rubi = establecimiento.Rubi + int.Parse(textBox2.Text);
                }
            }
            if (comboBox1.Text == "Zafiro")
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("No ha introducido Nuevo material");
                }
                else
                {
                    establecimiento.Zafiro = establecimiento.Zafiro + int.Parse(textBox2.Text);
                }
            }
            if (comboBox1.Text == "Esmeralda") 
            { 
                if (textBox2.Text == "")
                {
                    MessageBox.Show("No ha introducido Nuevo material");
                }
                else
                {
                    establecimiento.Esmeralda = establecimiento.Esmeralda + int.Parse(textBox2.Text);
                }
            }

            Guardar(new Establecimiento(
              establecimiento.Diamante,
              establecimiento.Rubi,
              establecimiento.Zafiro,
              establecimiento.Esmeralda
              ));
        }

        void Guardar(Establecimiento establecimiento)
        {

            var msg = servicio.GuardarRegistros(establecimiento);
            MessageBox.Show(msg);

        }
    }


}

