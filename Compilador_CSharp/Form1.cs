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

        public Form1()
        {
            InitializeComponent();
        }

        List<ListaToken> tokens = new List<ListaToken>();
        TablaSimbolos tabla_simbolos = new TablaSimbolos();
        private void Compilar_btn_Click(object sender, EventArgs e)
        {
            String codigoFuente = codigoTexto_txb.Text;

            Lexico lexico = new Lexico(codigoFuente);
            tokens = lexico.AnalisisLexico();
            tabla.DataSource = tokens;

            Sintactico sintactico = new Sintactico(tokens);
            tabla_simbolos = sintactico.AnalizadorSintactico();

            ArbolSintactico arbol_sintactico = new ArbolSintactico();
            Nodo nodo = arbol_sintactico.GenerarArbol(tokens, tabla_simbolos);
            arbol_sintactico.RecorridoPostOrden(nodo);
        }

        private void infoSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
          switch (infoSelector.Text)
          {
            case "Lista de Tokens":
  		           tabla.DataSource = tokens;
                break;
            case "Errores de TS":
                tabla.DataSource = tabla_simbolos.lista_errores_semanticos;
                break;
            default:
                break;
          }
        }

        private void infoSelector_Click(object sender, EventArgs e)
        {
            infoSelector.DroppedDown = true;
        }
    }
}
