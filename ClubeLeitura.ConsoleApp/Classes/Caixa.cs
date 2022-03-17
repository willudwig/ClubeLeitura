using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Caixa
    {
        string _cor;
        string _etiqueta;
        int _numero;

        public string Cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

        public string Etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value;}
        }

        public int Numero
        {
            get { return _numero; }
            set { _numero = value;}
        }
    }
}
