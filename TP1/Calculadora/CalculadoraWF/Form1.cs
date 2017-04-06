using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numero;
using Calculadora;

namespace CalculadoraWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero.numero numero1 = new numero(txtNumero1.Text);
            Numero.numero numero2 = new numero(txtNumero2.Text);
            //Realiza operacion y la guarda en el objeto resultado
            Numero.numero resultado = new numero(Calculadora.calculadora.Operar(numero1, numero2, cmbOperacion.Text));
            lblResultado.Text = Convert.ToString(resultado.getNumero());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";
            lblResultado.Text = "";
        }
    }
}
