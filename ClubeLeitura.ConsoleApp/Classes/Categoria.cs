using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Categoria
    {
        Revista[] _revistasConservadas = new Revista[100];
        Revista[] _revistasDesgastadas = new Revista[100];
        
        public EstadoRevista NomeCategoria = new();
        public Revista[] RevistasConservadas
        {
            get { return _revistasConservadas; }
            set { _revistasConservadas = value; }
        }
        public Revista[] RevistasDesgastadas
        {
            get { return _revistasDesgastadas; }
            set { _revistasDesgastadas = value; }
        }



        public enum EstadoRevista { Conservada, Desgastada } // revista na categoria 'Conservada' pode ser emprestada apenas por 3 dias


        int countConserv = 0;
        public void CadastrarCategoriaConservada(Revista rev)
        {
            _revistasConservadas[countConserv] = rev;
            countConserv++;
        }

        int countDesg = 0;
        public void CadastrarCategoriaDesgastada(Revista rev)
        {
            _revistasConservadas[countDesg] = rev;
            countDesg++;
        }
    }
}
