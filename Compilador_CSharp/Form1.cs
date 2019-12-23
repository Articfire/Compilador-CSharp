using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_CSharp
{
    public partial class Form1 : Form
    {

        TablaSimbolos tablasimbolos;
        public Form1()
        {
            InitializeComponent();
            tablasimbolos = new TablaSimbolos();
        }

        private void Compilar_btn_Click(object sender, EventArgs e)
        {
            String codigoFuente = codigoTexto_txb.Text;
            List<ListaToken> tokens;

            Lexico lexico = new Lexico(codigoFuente);
            tokens = lexico.AnalisisLexico();
            tabla.DataSource = tokens;

            Sintactico sintactico = new Sintactico(tokens);
            TablaSimbolos tabla_simbolos = sintactico.AnalizadorSintactico();

        }
    }
}

