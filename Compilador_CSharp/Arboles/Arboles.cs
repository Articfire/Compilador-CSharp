namespace Compilador_CSharp
{
    #region Enumeradores
    public enum tipoExpresion
    {
        Aritmetica,
        Comparacion,
        Identificador,
        Constante,
        Cadena,
        Vacio
    }
    public enum tipoValor
    {
        Entero,
        Flotante,
        Booleano,
        Cadena,
        Vacio
    }
    public enum tipoSentencia
    {
        Asignacion,
        If,
        For,
        Incremento,
        Vacio
    }
    public enum operaciones
    {
        suma,
        resta,
        multiplicacion,
        division,
        vacio
    }
    #endregion

	public class NodoArbol
    {
        public NodoArbol hermano;
        public NodoArbol hijoIzquierdo;
        public NodoArbol hijoCentro;
        public NodoArbol hijoDerecho;

        public string lexema;
        public string operador;
        public tipoExpresion miTipoExpresion;
        public tipoSentencia miTipoSentencia;
        public tipoValor miTipoValor;
        public operaciones miTipoOperacion;
        public tipoValor tipoValorHijoIzquierdo;
        public tipoValor tipoValorHijoDerecho;
    }

    public class ArbolSintactico
    {

    }

}