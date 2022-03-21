using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Reserva
    {
        Emprestimo _emprestimo;
       
        public Emprestimo Emprestimo
        {
            get { return _emprestimo; }
            set { _emprestimo = value; }    
        }
      
    }
}
