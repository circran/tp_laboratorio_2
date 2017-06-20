using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se obtendra una lista con las paginas desde el achivo de texto, esta lista sera mostrada en pantalla 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            List<string> paginas = new List<string>();
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            archivos.leer(out paginas);

            foreach (string url in paginas)
            {
                lstHistorial.Items.Add(url);
            }
        }
    }
}
