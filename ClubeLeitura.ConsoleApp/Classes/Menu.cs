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
            Console.WriteLine("Opções:\n\n1-  Registrar Novo Empréstimo\n2-  Exibir Registro de Empréstimos\n3-  Exibir Movimentação do Mês\n4-  Exibir Registros em Aberto\n\n5-  Registrar nova Revista\n6-  Exibir Revistas Cadastradas\n\n7-  Registrar Novo Amigo\n8-  Exibir Amigos Cadastrados\n\n9-  Registrar Nova Caixa\n10- Exibir Caixas Cadastradas\n\n11- Sair\n");
        }
    }
}
