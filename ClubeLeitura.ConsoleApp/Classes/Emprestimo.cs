using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Emprestimo
    {
        //Campos Privados
        Amigo _amigoQpegou = new();
        Status _status;
        int _id;
        //====================================

        //Públicos
        public enum Status { Aberto, Fechado }
        public DateTime dataQpegou = new();
        public DateTime dataDevolucao = new();

        public Revista RevistaEmprestada;
        //====================================


        //Propriedades
        public Amigo AmigoQPegou 
        {
            get { return _amigoQpegou; }
            set { _amigoQpegou = value; }
        }
      
        public Status StatusDoEmprestimo
        {
            get { return _status; }
            set { _status = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //==================================
      
    }
}
