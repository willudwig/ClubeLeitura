using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Amigo
    {
        string _nome;
        string _nomeResponsavel;
        int _telefone;
        Localizacao _endereco = new ();

        public string Nome 
        { 
            get 
            { 
                return _nome; 
            } 
            set 
            {
                _nome = value; 
            } 
        }

        public string NomeResponsavel 
        { 
            get 
            { 
                return _nomeResponsavel; 
            } 
            set 
            {
                _nomeResponsavel = value;
            } 
        }

        public int Telefone 
        { 
            get 
            { 
                return _telefone; 
            } 
            set 
            {
                _telefone = value; 
            } 
        }
        public Localizacao Endereco { get { return _endereco; } set { _endereco = value; } }
    }
}
