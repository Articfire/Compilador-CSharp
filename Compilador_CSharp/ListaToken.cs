using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_CSharp
{
    public class ListaToken
    {
        int _token;
        string _lexema;
        string _descripcionToken;
        string _numeroLinea;

        public int Token
        {
            get
            {
                return this._token;
            }
            set
            {
                this._token = value;
            }
        }
        public string Lexema
        {
            get
            {
                return this._lexema;
            }
            set
            {
                this._lexema = value;
            }
        }
        public string DescripcionToken
        {
            get
            {
                return this._descripcionToken;
            }
            set
            {
                this._descripcionToken = value;
            }
        }
        public string NumeroLinea
        {
            get
            {
                return this._numeroLinea;
            }
            set
            {
                this._numeroLinea = value;
            }
        }
        public ListaToken(int token, string lexema, string descripcionToken, string numeroLinea)
        {
            this._token = token;
            this._lexema = lexema;
            this._descripcionToken = descripcionToken;
            this._numeroLinea = numeroLinea;
        }
    }
}
