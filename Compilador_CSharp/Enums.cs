using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_CSharp
{
    public enum Estado
    {
        Insertado,
        Duplicado,
        DuplicadoAtributoConClase,
        DuplicadoMetodoConClase,
        Actualizado
    }

    public enum TipoDato
    {
        Entero,
        Flotante,
        Doble,
        Booleano,
        Cadena,
        Caracter,
        Objeto,
        Vacio
    }
    
    public enum Alcance
    {
        publico,
        privado,
        estatico
    }
    
    public enum TipoVariable
    {
        VariableLocal,
        Parametro
    }

    public enum tipoExpresion
    {
        Aritmetica,
        Comparacion,
        Identificador,
        Constante,
        Cadena,
        Vacio
    }
    public enum tipoSentencia
    {
        Expresion,
        Asignacion,
        If,
        For,
        Incremento,
        Leer,
        Escribir,
        Vacio
    }
    public enum tipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        // Modulo, No hay modulo en la matriz de transicion
        Vacio
    }
}
