using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{

    internal class Validacao
    {
        //Validações da Data de Devolução
        public bool ValidarInputData(DateTime dataPegou, DateTime dataDevolve)
        {
            if (dataDevolve.Equals("00/00/0000"))
            {
                Console.WriteLine("\nFormato inválido.\n");
                return true;
            }
            else
                return false;

            if (!dataDevolve.Equals(0) && dataDevolve < dataPegou)
            {
                Console.WriteLine("\nData de devolução anterior a data que pegou. Mantenha o status aberto\n");
                return true;
            }
            else
                return false;
        }

        //Validação de Ano
        public bool ValidarInputDataAno(int input)
        {
            if (input.ToString().Length != 4)
            {
                Console.WriteLine("\nFormato inválido.\n");
                return true;
            }
            return false;
        }
        //===========================================

        //Validação de campo String
        public bool ValidarInputString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nNão pode ser vazio\n");
                return true;
            }
            else
                return false;
        }
        //=============================================

        //Validação de campo Telefone
        public bool ValidarInputTelefone(int input)
        {
            if (input.ToString().Length != 9)
            {
                Console.WriteLine("\nFormato de telefone inválido (ex. 999112233).\n");
                return true;
            }
            else
                return false;
        }
        //============================================

        //Validação de campo Int
        public bool ValidarInputInt(int input)
        {
            if (String.IsNullOrEmpty(input.ToString()) || input < 1)
            {
                Console.WriteLine("\nFormato inválido\n");
                return true;
            }
            else
                return false;
        }
        //========================================

        //Validação Opção Status Empréstimo
        public bool ValidarInputStatusEmprestimo(char input)
        {
            if (input != '1' && input != '2')
            {
                Console.WriteLine("\nOpção inválida\n");
                return true;
            }
            else
                return false;
        }
        //======================================================

        //Validação Input Opções do Menu
        public void ValidarInputOpcaoMenu(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "7" && opcao != "8" && opcao != "9" && opcao != "10" && opcao != "11")
            {
                Console.WriteLine("\nOpção inválida\n");
                Console.ReadKey();
                
            }
            
        }
        //===============================================

    }
}
