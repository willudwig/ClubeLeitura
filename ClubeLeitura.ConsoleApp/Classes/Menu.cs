using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Menu
    {
        public void ApresentarOpcoes() 
        {
            Console.Clear();
            Console.WriteLine($"Opções:\n\n1-  Registrar Novo Empréstimo\n" +
                                         $"2-  Exibir Registro de Empréstimos\n" +
                                         $"3-  Exibir Movimentação do Mês\n" +
                                         $"4-  Exibir Registros em Aberto\n\n" +

                                         $"5-  Registrar nova Revista\n" +
                                         $"6-  Exibir Revistas Cadastradas\n\n" +
                                    
                                         $"7-  Registrar Novo Amigo\n" +
                                         $"8-  Exibir Amigos Cadastrados\n" +
                                         $"9-  Exibir Amigos com Multa Pendente\n" +
                                         $"10- Quitar Multas\n\n" +

                                         $"11- Registrar Nova Caixa\n" +
                                         $"12- Exibir Caixas Cadastradas\n\n" +

                                         $"13- Fazer Uma Nova Reserva\n" +
                                         $"14- Exibir Reservas\n\n" +

                                         $"15- Sair\n");
        }
    }
}
