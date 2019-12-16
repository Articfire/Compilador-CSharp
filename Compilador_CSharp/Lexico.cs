using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_CSharp
{
    class Lexico
    {
        string lexema = "";
        List<ListaToken> miListaToken = new List<ListaToken>();

        char caracterTexto;
        int numeroLinea = 1;
        int estado = 0;
        int caracterASCIIL = 0;
        int numeroCaracteres;
        int numeroCaracterActual = 0;

        private String codigoFuente;

        public Lexico(String codigo)
        {
            codigoFuente = codigo;
            codigoFuente += (char)32;
            numeroCaracteres = codigoFuente.Length;
        }

        public List<ListaToken> AnalisisLexico()
        {
            while (numeroCaracterActual < numeroCaracteres)
            {
                caracterASCIIL = codigoFuente[numeroCaracterActual];

                if ((Char.IsLetter(codigoFuente[numeroCaracterActual])))
                {
                    LeerCadena();
                }
                else if (Char.IsNumber(codigoFuente[numeroCaracterActual]))
                {
                    LeerNumero();
                }
                else
                {
                    switch (caracterASCIIL)
                    {
                        case 34:// "
                        case 39:// '
                        case 123:// {
                        case 125:// }
                        case 91:// [
                        case 93:// ]
                        case 40:// (
                        case 41:// )
                        case 59:// ;
                        case 126:// ~
                        case 44:// ,
                        case 63:// ?
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;
                            InsertarSimbolo();
                            break;

                        case 35:// #
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if (PreguntarSiguiente('#'))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 58:// :
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente(':')) || (PreguntarSiguiente('>')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 42:// *
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('=')) || PreguntarSiguiente('/'))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 94:// ^
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if (PreguntarSiguiente('='))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 38:// &
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('&')) || (PreguntarSiguiente('=')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 124:// |
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('|')) || (PreguntarSiguiente('=')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 61:// =
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if (estado == 2)
                            {
                                InsertarSimbolo();
                            }
                            else
                            {
                                if (PreguntarSiguiente('='))
                                {
                                    numeroCaracterActual++;
                                    AnalisisLexico();
                                }
                                else
                                {
                                    InsertarSimbolo();
                                }
                            }
                            break;

                        case 33:// !
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('!')) || (PreguntarSiguiente('=')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 43:// +
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('+')) || (PreguntarSiguiente('=')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        //-------------------------------------------------------------------------------------------------------------------
                        case 60:// <
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('=')) || (PreguntarSiguiente('%')) || (PreguntarSiguiente(':')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else if (PreguntarSiguiente('<'))
                            {
                                estado = 2;
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 37:// %
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('=')) || (PreguntarSiguiente('>')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else if (PreguntarSiguiente(':'))
                            {
                                estado = 2;
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 46:// .
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('*')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else if (PreguntarSiguiente('.'))
                            {
                                estado = 2;
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 45:// -
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('=')) || (PreguntarSiguiente('-')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else if (PreguntarSiguiente('>'))
                            {
                                estado = 2;
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 62:// >
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if (PreguntarSiguiente('='))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else if (PreguntarSiguiente('>'))
                            {
                                estado = 2;
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;

                        case 47:// /
                            caracterTexto = (char)caracterASCIIL;
                            lexema += caracterTexto;

                            if ((PreguntarSiguiente('*')) || (PreguntarSiguiente('=')) || (PreguntarSiguiente('/')))
                            {
                                numeroCaracterActual++;
                                AnalisisLexico();
                            }
                            else
                            {
                                InsertarSimbolo();
                            }
                            break;
                    }
                }
                if (caracterASCIIL == 13) numeroLinea++;
                numeroCaracterActual++;
            }

            return miListaToken;
        }
        Boolean PreguntarSiguiente(char letra)
        {
            int ascii = letra;
            if (codigoFuente[numeroCaracterActual + 1] == ascii)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void InsertarSimbolo()
        {
            if (lexema == "//")
            {
                LeerComentario();
            }
            else if (lexema == "/*") {
                LeerComentarioMultilinea();
            }
            else if (lexema == "\"")
            {
                LeerString();
            }
            else if (lexema == "\'")
            {
                LeerChar();
            }
            else
            {
                string[] detalleToken = ObtenerTokenSimbolo(lexema);
                miListaToken.Add(new ListaToken(Convert.ToInt32(detalleToken[0]), lexema, "Simple", numeroLinea.ToString()));
                Inicializar();
            }
            
        }
        void InsertarPalabra()
        {
            if (ConfirmarReservada(lexema))
            {
                string[] detalleToken = ObtenerTokenReservada(lexema);
                miListaToken.Add(new ListaToken(Convert.ToInt32(detalleToken[0]), lexema, "Reservada", numeroLinea.ToString()));
            }
            else
            {
                miListaToken.Add(new ListaToken(100, lexema, "Cadena", numeroLinea.ToString()));
            }
            Inicializar();
        }
        void LeerCadena()
        {
            caracterASCIIL = codigoFuente[numeroCaracterActual];
            caracterTexto = (char)caracterASCIIL;
            lexema += caracterTexto;
            if ((Char.IsLetter(codigoFuente[numeroCaracterActual + 1])) || (Char.IsNumber(codigoFuente[numeroCaracterActual + 1])))
            {
                numeroCaracterActual++;
                LeerCadena();
            }
            else
            {
                InsertarPalabra();
            }
        }
        void LeerNumero()
        {
            caracterASCIIL = codigoFuente[numeroCaracterActual];
            caracterTexto = (char)caracterASCIIL;
            lexema += caracterTexto;
            if (Char.IsNumber(codigoFuente[numeroCaracterActual + 1]))
            {
                numeroCaracterActual++;
                LeerNumero();
            }
            else if ((codigoFuente[numeroCaracterActual + 1] == '.') && (estado == 0))
            {
                estado = 1;
                numeroCaracterActual++;
                LeerNumero();
            }
            else if ((codigoFuente[numeroCaracterActual + 1] == '.') && (estado == 1))
            {
                MessageBox.Show("ERRORNUMEROS");
            }
            else if (estado == 0)
            {
                miListaToken.Add(new ListaToken(101, lexema, "Numero Entero", numeroLinea.ToString()));
                Inicializar();
            }
            else if (estado == 1)
            {
                miListaToken.Add(new ListaToken(102, lexema, "Numero Decimal", numeroLinea.ToString()));
                Inicializar();
            }
        }
        string[] ObtenerTokenSimbolo(string simbolo)
        {
            string[] token = new string[2];
            try
            {
                int t = Simbolos[simbolo];

                token[0] = t.ToString();
                token[1] = simbolo;
            }
            catch
            {
                MessageBox.Show("Meter error jeje");
            }
            return token;
        }
        string[] ObtenerTokenReservada(string palabra)
        {
            string[] token = new string[2];
            int t = PalabrasReservadas[palabra];
            token[0] = t.ToString();
            token[1] = palabra;
            return token;
        }
        Boolean ConfirmarReservada(string palabra)
        {
            if (PalabrasReservadas.ContainsKey(palabra))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void LeerComentario()
        {
            if (caracterASCIIL == 13) {
                //INSERTAR COMENTARIO
                miListaToken.Add(new ListaToken(498, lexema, "Comentario", numeroLinea.ToString()));
                Inicializar();
            }
            else
            {
                numeroCaracterActual++;
                caracterASCIIL = codigoFuente[numeroCaracterActual];
                caracterTexto = (char)caracterASCIIL;
                lexema += caracterTexto;

                LeerComentario();
            }
            AnalisisLexico();

        }
        void LeerComentarioMultilinea()
        {
            if (caracterTexto == '*')
            {
                if (PreguntarSiguiente('/'))
                {
                    numeroCaracterActual++;
                    caracterASCIIL = codigoFuente[numeroCaracterActual];
                    caracterTexto = (char)caracterASCIIL;
                    lexema += caracterTexto;

                    miListaToken.Add(new ListaToken(499, lexema, "Comentario Multilinea", numeroLinea.ToString()));
                    Inicializar();
                }
                else
                {
                    numeroCaracterActual++;
                    caracterASCIIL = codigoFuente[numeroCaracterActual];
                    caracterTexto = (char)caracterASCIIL;
                    lexema += caracterTexto;

                    LeerComentarioMultilinea();
                }
            }
            else
            {
                numeroCaracterActual++;
                caracterASCIIL = codigoFuente[numeroCaracterActual];
                caracterTexto = (char)caracterASCIIL;
                lexema += caracterTexto;

                LeerComentarioMultilinea();
            }
        }
        void LeerString()
        {
            numeroCaracterActual++;
            caracterASCIIL = codigoFuente[numeroCaracterActual];
            caracterTexto = (char)caracterASCIIL;
            lexema += caracterTexto;
            if (caracterTexto=='"')
            {
               

                miListaToken.Add(new ListaToken(497, lexema, "String", numeroLinea.ToString()));
                Inicializar();
            }
            else
            {
                LeerString();
            }
        }
        void LeerChar()
        {
            numeroCaracterActual++;
            caracterASCIIL = codigoFuente[numeroCaracterActual];
            caracterTexto = (char)caracterASCIIL;
            lexema += caracterTexto;
            if (lexema.Length <= 3)
            {
                if (caracterTexto == '\'')
                {
                    miListaToken.Add(new ListaToken(496, lexema, "Char", numeroLinea.ToString()));
                    Inicializar();
                }
                else
                {
                    LeerChar();
                }
            }
            else
            {
                MessageBox.Show("Error de char");
            }

        }
        Dictionary<String, int> Simbolos = new Dictionary<String, int>()
        {
                {"{",103},
                {"}",104},
                {"[",105},
                {"]",106},
                {"(",107},
                {")",108},
                {":",109},
                {";",110},
                {",",111},
                {".",112},
                {"'",113},
                {"\"",114},
                {"\\",115},
                {"=",116},
                {"==",117},
                {"!",118},
                {"!=",119},
                {"+",120},
                {"++",121},
                {"+=",122},
                {"-",123},
                {"--",124},
                {"-=",125},
                {"|",126},
                {"|=",127},
                {"||",128},
                {"&",129},
                {"&=",130},
                {"&&",131},
                {"&^",132},
                {"&^=",133},
                {"<",134},
                {"<=",135},
                {"<<",136},
                {"<<=",137},
                {"^",138},
                {"^=",139},
                {"*",140},
                {"*=",141},
                {"/",142},
                {"/=",143},
                {"//",144},
                {"%",145},
                {"%=",146},
                {">",147},
                {">=",148},
                {">>",149},
                {">>=",150},
                {"/*",151},
                {"*/",152}


        };
        Dictionary<String, int> PalabrasReservadas = new Dictionary<String, int>()
        {
                {"abstract"     ,200},
                {"as"           ,201},
                {"base"         ,202},
                {"bool"         ,203},
                {"break"        ,204},
                {"byte"         ,205},
                {"case"         ,206},
                {"catch"        ,207},
                {"char"         ,208},
                {"checked"      ,209},
                {"class"        ,210},
                {"const"        ,211},
                {"continue"     ,212},
                {"decimal"      ,213},
                {"default"      ,214},
                {"delegate"     ,215},
                {"do"           ,216},
                {"double"       ,217},
                {"else"         ,218},
                {"enum"         ,219},
                {"event"        ,220},
                {"explicit"     ,221},
                {"extern"       ,222},
                {"finally"      ,223},
                {"Fixed"        ,224},
                {"float"        ,225},
                {"for"          ,226},
                {"foreach"      ,227},
                {"goto"         ,228},
                {"if"           ,229},
                {"implicit"     ,230},
                {"in"           ,231},
                {"int"          ,232},
                {"interface"    ,233},
                {"internal"     ,234},
                {"is"           ,235},
                {"lock"         ,236},
                {"long"         ,237},
                {"namespace"    ,238},
                {"new"          ,239},
                {"null"         ,240},
                {"object"       ,241},
                {"operator"     ,242},
                {"out"          ,243},
                {"override"     ,244},
                {"params"       ,245},
                {"private"      ,246},
                {"protected"    ,247},
                {"public"       ,248},
                {"readonly"     ,249},
                {"ref"          ,250},
                {"return"       ,251},
                {"sbyte"        ,252},
                {"sealed"       ,253},
                {"short"        ,254},
                {"sizeof"       ,255},
                {"stackalloc"   ,256},
                {"static"       ,257},
                {"string"       ,258},
                {"struct"       ,259},
                {"switch"       ,260},
                {"this"         ,261},
                {"throw"        ,262},
                {"try"          ,263},
                {"typeof"       ,264},
                {"uint"         ,265},
                {"ulong"        ,266},
                {"unchecked"    ,267},
                {"unsafe"       ,268},
                {"ushort"       ,269},
                {"using"        ,270},
                {"virtual"      ,271},
                {"void"         ,272},
                {"while"        ,273},
                {"true"         ,274},
                {"false"        ,275},
                {"Console"      ,276},
                {"WriteLine"    ,277}
        };
        void Inicializar()
        {
            lexema = "";
            estado = 0;
        }
    }
}
