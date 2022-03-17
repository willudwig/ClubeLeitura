using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Localizacao
    {
        string _rua;
        string _bairro;
        int _numeroCasa;

        public string Rua 
        { 
            get 
            { 
                return _rua; 
            } 
            set 
            {
               _rua = value; 
            } 
        }    
        public string Bairro { get { return _bairro; } set { _bairro = value; } } 
        public int NumeroCasa { get { return _numeroCasa; } set { _numeroCasa = value; } }   
    }
}
