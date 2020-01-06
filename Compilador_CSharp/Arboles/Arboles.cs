using System.Windows.Forms;
using System.Collections.Generic;

namespace Compilador_CSharp
{

    public class NodoArbol
    {
        #region Nodos
        public NodoArbol Hermano;
        public NodoArbol HijoIzquierdo;
        public NodoArbol HijoCentro;
        public NodoArbol HijoDerecho;
        #endregion

        #region Propiedades del Arbol
        public string lexema;
        public string operador;
        public int puntero;

        public List<ListaToken> miListaDeTokens;
        public TablaSimbolos miTablaDeSimbolos;

        public tipoExpresion miTipoExpresion;
        public TipoDato miTipoValor;
        public tipoSentencia miTipoSentencia;
        public tipoOperacion miTipoOperacion;
        #endregion

        #region Comprobacion de Tipos
        public TipoDato tipoValorHijoIzquierdo;
        public TipoDato tipoValorHijoDerecho;
        #endregion

        #region Constructores
        public NodoArbol(List<ListaToken> lt, TablaSimbolos ts)
        {
            puntero = 0;
            this.miListaDeTokens = lt;
            this.miTablaDeSimbolos = ts;
        }
        
        public NodoArbol()
        { }
        #endregion

        #region Metodos de Arbol
        public void GenerarArbol()
        {

        }
        #endregion

        #region Metodos Arbol de Expresion
        public NodoArbol SimpleExpresion()
        {
            NodoArbol nodoRaiz = Termino();
            while (miListaDeTokens[puntero].Lexema.Equals("+")
                || miListaDeTokens[puntero].Lexema.Equals("-"))
            {
                NodoArbol nodoTemp = NuevoNodoExpresion(tipoExpresion.Aritmetica);
                nodoTemp.HijoIzquierdo = nodoRaiz;
                if (miListaDeTokens[puntero].Lexema.Equals("+"))
                {
                    nodoTemp.miTipoOperacion = tipoOperacion.Suma;
                }
                else if (miListaDeTokens[puntero].Lexema.Equals("-"))
                {
                    nodoTemp.miTipoOperacion = tipoOperacion.Resta;
                }
                nodoTemp.lexema = miListaDeTokens[puntero].Lexema;
                nodoRaiz = nodoTemp;
                puntero++;
                nodoRaiz.HijoDerecho = Termino();
            }

            return nodoRaiz;
        }
        
        public NodoArbol Termino()
        {
            NodoArbol t = Factor();
            while (miListaDeTokens[puntero].Lexema.Equals("*")
                 || miListaDeTokens[puntero].Lexema.Equals("/"))
            {
                NodoArbol p = NuevoNodoExpresion(tipoExpresion.Aritmetica);
                p.HijoIzquierdo = t;
                p.miTipoOperacion = miListaDeTokens[puntero].Lexema.Equals("*")
                    ? tipoOperacion.Multiplicacion
                    : tipoOperacion.Division;
                t.lexema = miListaDeTokens[puntero].Lexema;
                t = p;
                puntero++;
                t.HijoDerecho = Factor();
            }
            return t;
        }
        
        public NodoArbol Factor()
        {
            NodoArbol t = new NodoArbol();

            if (miListaDeTokens[puntero].Token == 2) // Numero entero
            {
                t = NuevoNodoExpresion(tipoExpresion.Constante);
                t.miTipoValor = TipoDato.Entero;
                t.lexema = miListaDeTokens[puntero].Lexema;
                puntero++;
            }
            if (miListaDeTokens[puntero].Token == 3) // Numero con decimal
            {
                t = NuevoNodoExpresion(tipoExpresion.Constante);
                t.lexema = miListaDeTokens[puntero].Lexema;
                t.miTipoValor = TipoDato.Flotante;
                puntero++;
            }

            else if (miListaDeTokens[puntero].Token == 1)  // Identificador
            {
                t = NuevoNodoExpresion(tipoExpresion.Identificador);
                t.lexema = miListaDeTokens[puntero].Lexema;
                //t.miTipoValor =  TABLA DE SIMBOLOS si existe la variable y sacar su valor
                t.miTipoValor = miTablaDeSimbolos.ObtenerTipoDato(t.lexema);
                puntero++;
            }
            else if (miListaDeTokens[puntero].Lexema.Equals("("))  // Parametro
            {
                puntero++;
                t = SimpleExpresion();
                puntero++;
            }
            return t;
        }
        
        public NodoArbol NuevoNodoExpresion(tipoExpresion tipo)
        {
            NodoArbol t = new NodoArbol();
            t.miTipoExpresion = tipo;
            t.miTipoSentencia = tipoSentencia.Vacio;
            t.miTipoValor = TipoDato.Vacio;
            t.tipoValorHijoDerecho = TipoDato.Vacio;
            t.tipoValorHijoIzquierdo = TipoDato.Vacio;
            t.miTipoOperacion = tipoOperacion.Vacio;
            return t;
        }
        
        public NodoArbol NuevoNodoSentencia(tipoSentencia tipo)
        {
            NodoArbol t = new NodoArbol();
            t.miTipoSentencia = tipo;
            t.miTipoValor = TipoDato.Vacio;
            t.tipoValorHijoDerecho = TipoDato.Vacio;
            t.tipoValorHijoIzquierdo = TipoDato.Vacio;
            t.miTipoOperacion = tipoOperacion.Vacio;
            t.miTipoExpresion = tipoExpresion.Vacio;

            return t;
        }
        #endregion

        #region Metodos Arbol de Asignacion
        public NodoArbol SentenciaAsignacion()
        {
            var sentenciaAsignacion = NuevoNodoSentencia(tipoSentencia.Asignacion);
            sentenciaAsignacion.lexema = miListaDeTokens[puntero].Lexema;
            puntero += 2;
            sentenciaAsignacion.HijoIzquierdo = SimpleExpresion();
            return sentenciaAsignacion;
        }
        #endregion
    }

}
