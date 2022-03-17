using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Revista
    {
        string _tipoColecao;
        int _numeroEdicao;
        int _ano;
        Caixa _caixa = new();

        public string TipoColecao
        {
            get { return _tipoColecao; }
            set { _tipoColecao = value; }
        }

        public int NumeroEdicao
        {
            get { return _numeroEdicao; }
            set { _numeroEdicao = value; }
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        public Caixa Caixa
        {
            get { return _caixa;}
            set { _caixa = value; }
        }

    }
}
