using System;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Input_Output
    {
        int aux = 0;
        Historico hist = new();

        //Empréstimo
        public void InputarEmprestimo(Emprestimo emp)
        {
            emp.ID = aux;
            int indice;

            Validacao valida = new();

            //Amigo
            emp.AmigoQPegou = new();

            if (hist.HistoricoAmigos[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Histórico de amigos vazio");
                return;
            }
            else
            {
                hist.ExibirAmigosRegistrados();
            }

            Console.WriteLine("\nAmigos: ");
            Console.Write("\nEscolha um índice: ");
            while (true)
            {
                try { indice = int.Parse(Console.ReadLine()); break; } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }
            }

            InputarAmigoNoEmprestimo(emp, indice);
            //============================================ fim Amigo


            //Revista
            emp.RevistaEmprestada = new();

            if (hist.HistoricoRevistas[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Histórico de revistas vazio");
                return;
            }
            else
            { 
                hist.ExibirRevistasRegistradas();
            }

            Console.WriteLine("\nRevistas: ");
            Console.Write("\nEscolha um índice: ");
            while (true)
            {
                try { indice = int.Parse(Console.ReadLine()); break; } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }
            }

            InputarRevistaNoEmprestimo(emp, indice);
            //========================================== fim Revista


            //DataQegou
            while (true)
            {
                Console.Write("\nData que pegou: ");
                DateTime.TryParse(Console.ReadLine(), out emp.dataQpegou);
                
                if(valida.ValidarInputData(emp.dataQpegou, emp.dataDevolucao) == false)
                {
                    break;
                }
            }
            //========================================== fim dataQpegou


            //DataDevolucao
            while (true)
            {
                Console.Write("\nData que devolveu: ");
                DateTime.TryParse(Console.ReadLine(), out emp.dataDevolucao);
                
                if(valida.ValidarInputData(emp.dataQpegou, emp.dataDevolucao) == false)
                {
                    break;
                }
            }
            //========================================= fim DataDevolucao


            //Status
            while (true)
            {
                Console.WriteLine("\nStatus:\n");
                Console.WriteLine("1- {0}", Emprestimo.Status.Aberto);
                Console.WriteLine("2- {0}", Emprestimo.Status.Fechado);

                char opcao = Console.ReadKey().KeyChar;

                switch (opcao)
                {
                    case '1':
                        emp.StatusDoEmprestimo = Emprestimo.Status.Aberto;
                        break;
                    case '2':
                        emp.StatusDoEmprestimo = Emprestimo.Status.Fechado;
                        break;
                }

                if (valida.ValidarInputStatusEmprestimo(opcao) == false)
                {
                    break;
                }
            }
                Console.WriteLine("\nStatus: " + emp.StatusDoEmprestimo);
         
            //============================================== fim Status

           
            emp.ID++;
            aux = emp.ID;

            hist.GuardarRegistro(emp, emp.dataQpegou.Month);

            hist.ExcluirRevistaEmprestadaDoRegistro(indice);

            Console.WriteLine("\nEmpréstimo registrado.");
            Console.ReadKey();
        }
        //============================================ fim Empréstimo


        //Menu
        public void InputarOpcao(string opcao)
        {
            Console.Write("Digite um número > ");
            opcao = Console.ReadLine();

            Validacao valida = new();

            valida.ValidarInputOpcaoMenu(opcao);

            Emprestimo emprestimo = new Emprestimo();

            switch (opcao)
            {
                case "1":
                    //podia iniciar aqui
                    InputarEmprestimo(emprestimo);
                    break;
                case "2":
                    hist.ExibirHistorico();
                    Console.ReadKey();
                    break;
                case "3":
                    hist.ExibirEmprestimosMensais(DateTime.Today.Month);
                    Console.ReadKey();
                    break;
                case "4":
                    hist.FiltrarParaEmprestimosEmAberto();
                    Console.ReadKey();
                    break;
                case "5":
                    CadastrarRevistas();
                    Console.ReadKey();
                    break;
                case "6":
                    hist.ExibirRevistasRegistradas();
                    Console.ReadKey();
                    break;
                case "7":
                    CadastrarAmigos();
                    Console.ReadKey();
                    break;
                case "8":
                    hist.ExibirAmigosRegistrados();
                    Console.ReadKey();
                    break;
                    break;
                case "9":
                    CadastrarCaixas();
                    Console.ReadKey();
                    break; break;
                case "10":
                    hist.ExibirCaixasRegistradas();
                    Console.ReadKey();
                    break;
                case "11":
                    Console.Clear();
                    Console.WriteLine("Programa Finalizado");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
        //============================================


        //Cadastros
        public void CadastrarRevistas()
        {
            Revista revista = new();
            Validacao valida = new();
            int indice;

            Console.Clear();
            Console.WriteLine("-- Cadastrando Revistas -- \n");

            revista.TipoColecao = EntradaDeStringValidada("Tipo Coleção: ", revista.TipoColecao, valida);

            revista.NumeroEdicao = EntradaDeIntValidada("Edição Nº: ", revista.NumeroEdicao, valida);

            revista.Ano = EntradaDeDataAnoValidada("Ano: ", revista.Ano, valida);

            Console.WriteLine("\nCaixa ");

            if (hist.HistoricoCaixas[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Histórico de caixas vazio");
                return;
            }
            else
            {
                hist.ExibirCaixasRegistradas();
            }

            Console.WriteLine("\nCaixas: ");
            Console.Write("\nEscolha um índice: ");
            while (true)
            {
                try { indice = int.Parse(Console.ReadLine()); break; } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }
            }

            InputarCaixaNaRevista(revista, indice);
            //====================================================================

            hist.GuardarRegistroRevistas(revista);

            Console.WriteLine("\nRevista Registrada");
        }

        public void CadastrarAmigos()
        {
            Amigo amigo = new();
            Validacao valida = new();

            Console.Clear();
            Console.WriteLine("-- Cadastrando Amigos -- \n");

            amigo.Nome = EntradaDeStringValidada("Nome do amigo: ", amigo.Nome, valida);

            amigo.NomeResponsavel = EntradaDeStringValidada("Nome do responsável: ", amigo.NomeResponsavel, valida);

            amigo.Telefone = EntradaDeTelefoneValidada("Telefone: ",amigo.Telefone, valida);

            Console.WriteLine("\nEndereço:\n");

            amigo.Endereco.Rua = EntradaDeStringValidada("Rua: ", amigo.Endereco.Rua, valida);

            amigo.Endereco.Bairro = EntradaDeStringValidada("Bairro: ", amigo.Endereco.Bairro, valida);

            amigo.Endereco.NumeroCasa = EntradaDeIntValidada("Casa Nº: ", amigo.Endereco.NumeroCasa, valida);

            hist.GuardarRegistroAmigos(amigo);

            Console.WriteLine("\nAmigo Registrado");
        }

        public void CadastrarCaixas()
        {
            Caixa caixa = new();
            Validacao valida = new();

            Console.Clear();
            Console.WriteLine("-- Cadastrando Caixas -- \n");

            caixa.Cor = EntradaDeStringValidada("Cor: ", caixa.Cor, valida);

            caixa.Etiqueta = EntradaDeStringValidada("Etiqueta: ", caixa.Etiqueta, valida);

            caixa.Numero = EntradaDeIntValidada("Número: ", caixa.Numero, valida);

            hist.GuardarRegistroCaixas(caixa);

            Console.WriteLine("\nCaixa Registrada");
        }
        //================================


        //Inputs de objetos em outros
        private void InputarRevistaNoEmprestimo(Emprestimo emp, int i)
        {
            emp.RevistaEmprestada.TipoColecao = hist.HistoricoRevistas[i].TipoColecao;
            emp.RevistaEmprestada.NumeroEdicao = hist.HistoricoRevistas[i].NumeroEdicao;
            emp.RevistaEmprestada.Ano = hist.HistoricoRevistas[i].Ano;
            emp.RevistaEmprestada.Caixa.Cor = hist.HistoricoRevistas[i].Caixa.Cor;
            emp.RevistaEmprestada.Caixa.Etiqueta = hist.HistoricoRevistas[i].Caixa.Etiqueta;
            emp.RevistaEmprestada.Caixa.Numero = hist.HistoricoRevistas[i].Caixa.Numero;
        }

        private void InputarAmigoNoEmprestimo(Emprestimo emp, int i)
        {
            while (true)
            {
                emp.AmigoQPegou.Nome = hist.HistoricoAmigos[i].Nome;

                if (VerificarNomeRepetido(emp.AmigoQPegou.Nome) == false)
                    break;
            }
            emp.AmigoQPegou.NomeResponsavel = hist.HistoricoAmigos[i].NomeResponsavel;
            emp.AmigoQPegou.Telefone = hist.HistoricoAmigos[i].Telefone;
            emp.AmigoQPegou.Endereco.Rua = hist.HistoricoAmigos[i].Endereco.Rua;
            emp.AmigoQPegou.Endereco.Bairro = hist.HistoricoAmigos[i].Endereco.Bairro;
            emp.AmigoQPegou.Endereco.NumeroCasa = hist.HistoricoAmigos[i].Endereco.NumeroCasa;
        }

        private void InputarCaixaNaRevista(Revista revista, int i)
        {
            revista.Caixa.Cor = hist.HistoricoCaixas[i].Cor;
            revista.Caixa.Etiqueta = hist.HistoricoCaixas[i].Etiqueta;
            revista.Caixa.Numero = hist.HistoricoCaixas[i].Numero;
        }
        //===============================================================


        //entradas de dados validadas
        private string EntradaDeStringValidada(string texto, string propriedade, Validacao valida)
        {
            while (true)
            {
                Console.Write(texto);
                propriedade = Console.ReadLine();

                if (valida.ValidarInputString(propriedade) == false)
                {
                    break;
                }
            }

            return propriedade;
        }

        private int EntradaDeIntValidada(string texto, int propriedade, Validacao valida)
        {
            while (true)
            {
                Console.Write(texto);
                try { propriedade = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; };

                if (valida.ValidarInputInt(propriedade) == false)
                {
                    break;
                }
            }
            return propriedade;
        }

        private int EntradaDeDataAnoValidada(string texto, int ano, Validacao valida)
        {
            while (true)
            {
                Console.Write(texto);
                try { ano = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }

                if (valida.ValidarInputDataAno(ano) == false)
                {
                    break;
                }
            }

            return ano;
        }

        private int EntradaDeTelefoneValidada(string texto, int telefone, Validacao valida)
        {
            while (true)
            {
                Console.Write(texto);
                try { telefone = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido"); continue; }

                if (valida.ValidarInputTelefone(telefone) == false)
                {
                    break;
                };
            }

            return telefone;
        }
        //===========================================================================================

        //verifica nome repetido no empréstimo
        public bool VerificarNomeRepetido(string nomeAtual)
        {
            for (int i = 0; i < hist.HistoricoEmprestimos.Length; i++)
            {
                if (hist.HistoricoEmprestimos[i] != null)
                {
                    if (nomeAtual == hist.HistoricoEmprestimos[i].AmigoQPegou.Nome)
                    {
                        Console.WriteLine("Proibido o mesmo amigo fazer mais de um empréstimo");
                        return true;
                    }
                    else
                        continue;
                }
                else
                    break;
            }
            return false;
        }
        //=====================================================
    }
}