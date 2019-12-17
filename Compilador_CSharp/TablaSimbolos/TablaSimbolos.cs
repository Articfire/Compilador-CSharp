using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Compilador_CSharp
{
    public class TablaSimbolos
    {
        public Dictionary<object, NodoClase> tablaSimbolosClase =
            new Dictionary<object, NodoClase>();

        #region METODOS TS CLASE
        public Estado InsertarNodoClase(NodoClase miNodoClase)
        {
            if (!tablaSimbolosClase.ContainsKey(miNodoClase.lexema))
            {
                tablaSimbolosClase.Add(miNodoClase.lexema, miNodoClase);
                return Estado.Insertado;
            }
            else
            {
                return Estado.Duplicado;
            }

        }

        public NodoClase ObtenerNodoClase(string lexema)
        {
            if (tablaSimbolosClase.ContainsKey(lexema))
                return tablaSimbolosClase.SingleOrDefault(x => x.Key.ToString() == lexema).Value;
            else
                throw new Exception("Error Semantico: No existe el nombre de la Clase");
        }

        public bool ExisteClaseHeredada(string lexema)
        {
            if (tablaSimbolosClase.ContainsKey(lexema))
            {
                return true;
            }
            else
            {
                return false;
                throw
                    new Exception("error semantico 3245: no existe la clase a heredar ");
            }

        }

        #endregion

        #region Metodos TS Atributos

        public Estado InsertarNodoAtributo(NodoAtributo nodo, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.lexema != nodo.lexema)
            {
                if (!nodoClaseActiva.TablaSimbolosAtributos
                    .ContainsKey(nodo.lexema))
                {
                    nodoClaseActiva.TablaSimbolosAtributos
                        .Add(nodo.lexema, nodo);
                    return Estado.Insertado;
                }
                else
                {
                    return Estado.Duplicado;
                    //mandamos un error de atributo duplicado.
                }
            }
            else
            {
                return Estado.DuplicadoAtributoConClase;
            }
        }

        public NodoAtributo ObtenerNodoAtributo(string lexema, NodoClase nodoClaseActiva)
        {

            if (nodoClaseActiva.TablaSimbolosAtributos
                .ContainsKey(lexema))
                return nodoClaseActiva
                    .TablaSimbolosAtributos
                    .SingleOrDefault(x => x.Key.ToString() == lexema).Value;
            else
                throw new Exception("Nodo atributo no encontrado");
        }
        //La clase del 12/09/2019
        public TipoDato ObtenerTipoDato(string lexema, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.TablaSimbolosAtributos
                .ContainsKey(lexema))
                return nodoClaseActiva
                    .TablaSimbolosAtributos
                    .SingleOrDefault(x => x.Key.ToString() == lexema).Value.miTipo;
            else
                throw new Exception("Nodo atributo no encontrado");
        }

        #endregion

        #region METODOS TS METODOS
        public Estado InsertarNodoMetodo(NodoMetodo nodo, List<NodoVariables> misParametros, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.lexema != nodo.lexema)
            {
                // para verificar que no exista un nombre de atributo
                //igual que mi metodo

                if (!nodoClaseActiva.TablaSimbolosMetodos.ContainsKey(nodo.lexema))
                {
                    foreach (var item in misParametros)
                    {
                        nodo.TablaSimbolosVariables.Add(item.lexema, item);
                    }
                    nodoClaseActiva.TablaSimbolosMetodos.Add(nodo.lexema, nodo);
                    return Estado.Insertado;
                }
                else
                {
                    // trabajar con sobrecarga de metodos
                    return Estado.Duplicado;
                }
            }
            else
            {
                return Estado.DuplicadoMetodoConClase;
            }
        }

        public List<NodoVariables> ObtenerParametrosMetodo(string lexema, NodoClase nodoClaseActiva)
        {
            var nodo =
                nodoClaseActiva.TablaSimbolosMetodos.FirstOrDefault
                    (x => x.Key.ToString() == lexema);
            var nodoVariables = nodo.Value.TablaSimbolosVariables;
            return nodoVariables.Values.ToList();
        }

        public NodoMetodo ObtenerNodoMetodo(string lexema, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.TablaSimbolosMetodos
                .ContainsKey(lexema))
                return nodoClaseActiva
                    .TablaSimbolosMetodos
                    .SingleOrDefault(x => x.Key.ToString() == lexema).Value;
            else
                throw new Exception("Nodo metodo no encontrado");
        }

        #endregion

    }

    public class NodoClase
    {
        public string lexema;
        public Alcance miAlcance;
        public NodoClase herencia;
        public Dictionary<object, NodoAtributo> TablaSimbolosAtributos = new Dictionary<object, NodoAtributo>();
        public Dictionary<object, NodoMetodo> TablaSimbolosMetodos = new Dictionary<object, NodoMetodo>();
    }

    public class NodoAtributo
    {
        public string lexema;
        public Alcance miAlcance;
        public TipoDato miTipo;
        public string valor;
        public string memoria;
    }

    public class NodoMetodo
    {
        public string lexema;
        public Alcance miAlcance;
        public Regreso miRegreso;
        public Dictionary<object, NodoVariables> TablaSimbolosVariables = new Dictionary<object, NodoVariables>();
    }

    public class NodoVariables
    {
        public Alcance miAlcance;
        public string lexema;
        public TipoDato miTipo;
        public string valor;
        public TipoVariable tipoVariable;
    }

    public enum Estado
    {
        Insertado,
        Duplicado,
        DuplicadoAtributoConClase,
        DuplicadoMetodoConClase
    }

    public enum Regreso
    {
        Vacio,
        Entero,
        Flotante,
        Cadena,
        Caracter,
        Doble,
        Booleano
    }

    public enum TipoDato
    {
        Entero,
        Cadena,
        Flotante,
        Caracter,
        Doble,
        Booleano,
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

}
