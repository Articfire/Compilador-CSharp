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

        #region METODOS TS Clases
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

        public bool ExisteClase(string lexema)
        {
            if (tablaSimbolosClase.ContainsKey(lexema))
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("error semantico 3245: no existe la clase a heredar ");
            }

        }

        #endregion

        #region Metodos TS Atributos

        public Estado InsertarNodoAtributo(NodoAtributo nodo, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.lexema != nodo.lexema)
            {
                if (!nodoClaseActiva.TablaSimbolosAtributos.ContainsKey(nodo.lexema))
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

        public bool ExisteAtributo(string lexema, NodoClase nodoClaseActiva) {
            var atributos = nodoClaseActiva.TablaSimbolosAtributos;
            foreach (var atributo in atributos.Values)
            {
                if (atributo.lexema == lexema)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region METODOS TS Metodos
        public Estado InsertarNodoMetodo(NodoMetodo nodo, List<NodoVariables> misParametros, NodoClase nodoClaseActiva)
        {
            if (nodoClaseActiva.lexema != nodo.lexema)
            {
                // para verificar que no exista un nombre de atributo
                // igual que mi metodo

                /*foreach (var metodo in nodoClaseActiva.TablaSimbolosMetodos)
                {
                    if (metodo.lexema == nodo.lexema)
                    {
                        return Estado.Duplicado;
                    }
                }*/
                foreach (var parametro in misParametros)
                {
                    // nodo.TablaSimbolosVariables.Add(parametro.lexema, parametro);
                    nodo.TablaSimbolosVariables.Add(parametro.lexema, parametro);
                }
                nodoClaseActiva.TablaSimbolosMetodos.Add(nodo);
                return Estado.Insertado;

                
            }
            else
            {
                return Estado.DuplicadoMetodoConClase;
            }
        }

        public List<NodoVariables> ObtenerParametrosMetodo(string lexema, NodoClase nodoClaseActiva)
        {
            var nodo = ObtenerNodoMetodo(lexema, nodoClaseActiva);
            var nodoVariables = nodo.TablaSimbolosVariables;
            // return nodoVariables.Values.ToList();
            return nodoVariables.Values.ToList();
        }

        public NodoMetodo ObtenerNodoMetodo(string lexema, NodoClase nodoClaseActiva)
        {
            foreach (var metodo in nodoClaseActiva.TablaSimbolosMetodos)
            {
                if (metodo.lexema == lexema && metodo.TablaSimbolosVariables.Values.ToList() == ObtenerParametrosMetodo(lexema, nodoClaseActiva))
                {
                    return metodo;
                }
            }
            throw new Exception("Nodo metodo no encontrado");
        }

        public bool ExisteMetodo(string lexema, List<NodoVariables> misParametros, NodoClase nodoClaseActiva) {
            var metodos = nodoClaseActiva.TablaSimbolosMetodos;
            foreach (var metodo in metodos)
            {
                if (metodo.lexema == lexema && metodo.TablaSimbolosVariables.Values.ToList().Equals(misParametros))
                {
                    return true;
                }
            }
            return false;
        
        }
        
        public bool ExisteMetodo(string lexema, NodoClase nodoClaseActiva) {
            var metodos = nodoClaseActiva.TablaSimbolosMetodos;
            foreach (var metodo in metodos)
            {
                if (metodo.lexema == lexema)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region METODOS TS Variables
        public bool ExisteVariable(string lexema, NodoMetodo nodoMetodo) {
            var variables = nodoMetodo.TablaSimbolosVariables;
            foreach (var variable in variables.Values)
            {
                if (variable.lexema == lexema)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }

    public class NodoClase
    {
        public string lexema;
        public Alcance miAlcance;
        public NodoClase herencia;
        public Dictionary<object, NodoAtributo> TablaSimbolosAtributos = new Dictionary<object, NodoAtributo>();
        // public Dictionary<object, NodoMetodo> TablaSimbolosMetodos = new Dictionary<object, NodoMetodo>();
        public List<NodoMetodo> TablaSimbolosMetodos = new List<NodoMetodo>();
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
        DuplicadoMetodoConClase,
        Actualizado
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
