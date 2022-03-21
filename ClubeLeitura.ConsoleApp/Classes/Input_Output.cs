using System;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Input_Output
    {
        int aux = 0;
        int auxReserva = 0;

        Historico hist = new();
        Categoria categ = new();

        //Empréstimo
        public void InputarEmprestimo(Emprestimo emp)
        {
            emp.ID = aux;
            int indice = 0;

            Validacao valida = new();

            Console.Clear();
            Console.WriteLine("-- Registrando Novo Empréstimo\n");
            
            //Amigo
            emp.AmigoQPegou = new();

            while (true)
            {
                if (hist.HistoricoAmigos[0] == null)
                {
                    Console.Clear();
                    Console.WriteLine("Não há amigos disponíveis");
                    return;
                }
                else
                {
                    hist.ExibirAmigosSemMultas();
                }

                Console.WriteLine("\nAmigos: ");

                indice = EntradaIndiceAmigoValidada(indice, valida);

                if (InputarAmigoNoEmprestimo(emp, indice) == true)
                {
                    continue;
                }
                else
                    break;

            }

            if (VerificarCondicaoAmigoReservado(emp) == true)
            {
                #region
                emp.ID++;
                aux = emp.ID;

                Console.WriteLine("\nRevista da reserva adicionada ao empréstimo\n");

                while (true)
                {
                    emp.dataQpegou = DateTime.Today;

                    Console.Write($"Data que pegou: {emp.dataQpegou:dd/MM/yyyy}");

                    if (valida.ValidarInputData(emp.dataQpegou, emp.dataDevolucao) == false)
                    {
                        break;
                    }
                }
                //========================================== fim dataQpegou


                //DataDevolucao
                while (true)
                {
                    Console.Write("\n\nData que devolveu: ");
                    DateTime.TryParse(Console.ReadLine(), out emp.dataDevolucao);

                    if (valida.ValidarInputData(emp.dataQpegou, emp.dataDevolucao) == false)
                    {
                        break;
                    }
                }
                //========================================= fim DataDevolucao


                //Status
                if (string.IsNullOrEmpty(emp.dataDevolucao.ToString()))
                {
                    emp.StatusDoEmprestimo = Emprestimo.Status.Aberto;
                    Console.WriteLine($"Status: {emp.StatusDoEmprestimo}");
                }
                else if (emp.dataDevolucao > emp.dataQpegou)
                {
                    emp.StatusDoEmprestimo = Emprestimo.Status.Fechado;
                }
                //============================================== fim Status


                hist.GuardarRegistroEmprestimo(emp, emp.dataQpegou.Month);

                hist.ExcluirReservaDoRegistro(indice);

                hist.ExcluirRevistaEmprestadaDoRegistro(indice);

                Console.WriteLine("\nEmpréstimo registrado.");
                Console.ReadKey();
                #endregion

                return; // encerrando aqui o emprestimo pela reserva
            };
            //============================================ fim Amigo


            //Revista

            if (hist.HistoricoRevistas[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Não há revistas disponíveis");
                return;
            }
            else
            {
                Console.WriteLine();
                hist.ExibirRevistasRegistradas();
            }

            emp.RevistaEmprestada = new();

            Console.WriteLine("\nRevistas: ");

            indice = EntradaIndiceRevistaValidada(indice, valida);

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
            if( string.IsNullOrEmpty(emp.dataDevolucao.ToString())) 
            {
                emp.StatusDoEmprestimo = Emprestimo.Status.Aberto;
            }
            else if (emp.dataDevolucao > emp.dataQpegou)
            {
                emp.StatusDoEmprestimo = Emprestimo.Status.Fechado;
            }
            //============================================== fim Status
           
            emp.ID++;
            aux = emp.ID;

            hist.GuardarRegistroEmprestimo(emp, emp.dataQpegou.Month);

            hist.ExcluirRevistaEmprestadaDoRegistro(indice);

            Console.WriteLine("\nEmpréstimo registrado.");
            Console.ReadKey();
        }
        //============================================== fim Empréstimo

        //Reserva
        public void EfetuarReserva(Reserva reserva)
        {
            reserva.Emprestimo = new();

            reserva.Emprestimo.ID = auxReserva;
            int indice = 0;

            Validacao valida = new();

            Console.Clear();
            Console.WriteLine("-- Efetuando Nova Reserva --\n");

            //Amigo
            reserva.Emprestimo.AmigoQPegou = new();

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

            indice = EntradaIndiceAmigoValidada(indice, valida);

            InputarAmigoNoEmprestimo(reserva.Emprestimo, indice);
            //============================================ fim Amigo


            //Revista
            reserva.Emprestimo.RevistaEmprestada = new();

            if (hist.HistoricoRevistas[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Histórico de revistas vazio");
                return;
            }
            else
            {
                Console.WriteLine();    
                hist.ExibirRevistasRegistradas();
            }

            Console.WriteLine("\nRevistas: ");

            indice = EntradaIndiceRevistaValidada(indice, valida);

            InputarRevistaNoEmprestimo(reserva.Emprestimo, indice);
            //===================================================== fim Revista

            VerificarRevistaJaReservada(reserva.Emprestimo.RevistaEmprestada);

            //DataQegou
            reserva.Emprestimo.dataQpegou = DateTime.Today;
               
            Console.WriteLine($"\nData da reserva: {reserva.Emprestimo.dataQpegou:dd/MM/yyy}");
            reserva.Emprestimo.DataValidade = reserva.Emprestimo.dataQpegou.AddDays(2);
            reserva.Emprestimo.dataDevolucao = reserva.Emprestimo.DataValidade;
            Console.WriteLine($"\nVálido até: {reserva.Emprestimo.dataDevolucao:dd/MM/yyy}");

            VerificarRevistaJaReservada(reserva.Emprestimo.RevistaEmprestada);

            reserva.Emprestimo.RevistaEmprestada.disponibilidade = "Reservado";
            
            reserva.Emprestimo.ID++;
            aux = reserva.Emprestimo.ID;

            hist.GuardarRegistroDasReservas(reserva.Emprestimo);

            Console.WriteLine("\nReserva registrada.");
        }
        //============================================== fim Reserva


        //Menu
        public void InputarOpcao(string opcao)
        {
            Console.Write("Digite um número > ");
            opcao = Console.ReadLine();

            Validacao valida = new();

            valida.ValidarInputOpcaoMenu(opcao);

            Emprestimo emprestimo = new Emprestimo();

            VerificarTempoDaReserva();

            switch (opcao)
            {
                case "1":
                    InputarEmprestimo(emprestimo);
                    break;
                case "2":
                    Console.Clear();
                    hist.ExibirHistoricoEmprestimos();
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
                    Console.Clear();
                    hist.ExibirRevistasRegistradas();
                    Console.ReadKey();
                    break;
                case "7":
                    CadastrarAmigos();
                    Console.ReadKey();
                    break;
                case "8":
                    Console.Clear();
                    hist.ExibirAmigosRegistrados();
                    Console.ReadKey();
                    break;

                case "9":
                    Console.Clear();

                    if (VerificarEmprestimoCategoriaConservada(emprestimo, categ.RevistasConservadas) == false)
                    {
                        return;
                    }

                    hist.ExibirAmigosComMultaPendente();
                    Console.ReadKey();
                    break;
                case "10":
                    Console.Clear();

                    if (VerificarEmprestimoCategoriaConservada(emprestimo, categ.RevistasConservadas) == false)
                    {
                        return;
                    }

                    QuitarMulta();

                    Console.ReadKey();
                    break;
                case "11":
                    CadastrarCaixas();
                    Console.ReadKey();
                    break; 
                case "12":
                    Console.Clear();
                    hist.ExibirCaixasRegistradas();
                    Console.ReadKey();
                    break;
                case "13":
                    Reserva novaReserva = new();
                    EfetuarReserva(novaReserva);
                    Console.ReadKey();
                    break;
                case "14":
                    Console.Clear();    
                    hist.ExibirHistoricoReservas();
                    Console.ReadKey();
                    break;
                case "15":
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
            int indice = 0;

            Console.Clear();
            Console.WriteLine("-- Cadastrando Revistas -- \n");

            revista.TipoColecao = EntradaDeStringValidada("Tipo Coleção: ", revista.TipoColecao, valida);

            revista.NumeroEdicao = EntradaDeIntValidada("Edição Nº: ", revista.NumeroEdicao, valida);

            revista.Ano = EntradaDeDataAnoValidada("Ano: ", revista.Ano, valida);

            if (hist.HistoricoCaixas[0] == null)
            {
                Console.Clear();
                Console.WriteLine("Histórico de caixas vazio");
                return;
            }
            else
            {
                Console.WriteLine();
                hist.ExibirCaixasRegistradas();
            }

            //Caixa
            Console.WriteLine("\nCaixas: ");

            indice = EntradaIndiceCaixaValidada(indice, valida);

            InputarCaixaNaRevista(revista, indice);
            //================================================= fim Caixa


            //Categoria
            while (true) 
            {
                Console.WriteLine("\nCategoria:\n\n1- Conservada\n2- Desgastada");
                Console.Write("\nDigite um número: ");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    revista.CategRevista.CadastrarCategoriaConservada(revista);
                    revista.CategRevista.NomeCategoria = Categoria.EstadoRevista.Conservada;
                    break;
                }
                else if (opcao == "2")
                {
                    revista.CategRevista.CadastrarCategoriaDesgastada(revista);
                    revista.CategRevista.NomeCategoria = Categoria.EstadoRevista.Desgastada;
                    break;
                }
                else
                {
                    Console.WriteLine("\nOpção inválida\n");
                    continue;
                }
                    
            }
            //================================================= fim Categoria
            
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

        private bool InputarAmigoNoEmprestimo(Emprestimo emp, int i)
        {
            while (true)
            {
                emp.AmigoQPegou.Nome = hist.HistoricoAmigos[i].Nome;

                if (VerificarNomeRepetido(emp.AmigoQPegou.Nome) == false)
                    break;
                else
                    return true;
            }

            emp.AmigoQPegou.NomeResponsavel = hist.HistoricoAmigos[i].NomeResponsavel;
            emp.AmigoQPegou.Telefone = hist.HistoricoAmigos[i].Telefone;
            emp.AmigoQPegou.Endereco.Rua = hist.HistoricoAmigos[i].Endereco.Rua;
            emp.AmigoQPegou.Endereco.Bairro = hist.HistoricoAmigos[i].Endereco.Bairro;
            emp.AmigoQPegou.Endereco.NumeroCasa = hist.HistoricoAmigos[i].Endereco.NumeroCasa;
            
            return false;
        }

        private void InputarCaixaNaRevista(Revista revista, int i)
        {
            revista.Caixa.Cor = hist.HistoricoCaixas[i].Cor;
            revista.Caixa.Etiqueta = hist.HistoricoCaixas[i].Etiqueta;
            revista.Caixa.Numero = hist.HistoricoCaixas[i].Numero;
        }
        //===============================================================


        //Entradas de dados validadas
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

        private int EntradaIndiceAmigoValidada(int indice, Validacao valida) 
        {
            while (true)
            {
                Console.Write("\nEscolha um índice: ");

                try { indice = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }

                if (valida.ValidarIndiceAmigoSelecionado(indice, hist.HistoricoAmigos) == false)
                {
                    break;
                }
                else
                    Console.WriteLine("\nÍndice inválido\n");
                    continue;
            }
            return indice;
        }

        private int EntradaIndiceRevistaValidada(int indice, Validacao valida)
        {
            while (true)
            {
                Console.Write("\nEscolha um índice: ");

                try { indice = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }

                if (valida.ValidarIndiceRevistaSelecionada(indice, hist.HistoricoRevistas) == false)
                {
                    break;
                }
                else
                    Console.WriteLine("\nÍndice inválido\n");
                    continue;
            }
            return indice;
        }

        private int EntradaIndiceCaixaValidada(int indice, Validacao valida)
        {
            while (true)
            {
                Console.Write("\nEscolha um índice: ");

                try { indice = int.Parse(Console.ReadLine()); } catch (Exception) { Console.WriteLine("\nFormato inválido\n"); continue; }

                if (valida.ValidarIndiceRevistaSelecionada(indice, hist.HistoricoCaixas) == false)
                {
                    break;
                }
                else
                    Console.WriteLine("\nÍndice inválido\n");
                    continue;
            }
            return indice;
        }

        //===========================================================================================


       //Veridicações
        private bool VerificarNomeRepetido(string nomeAtual)
        {
            for (int i = 0; i < hist.HistoricoEmprestimos.Length; i++)
            {
                if (hist.HistoricoEmprestimos[i] != null)
                {
                    if (nomeAtual == hist.HistoricoEmprestimos[i].AmigoQPegou.Nome)
                    {
                        Console.WriteLine("\nProibido o mesmo amigo fazer mais de um empréstimo\n");
                        Console.ReadKey();
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

        private void VerificarTempoDaReserva() 
        {
            for (int i = 0; i < hist.HistoricoDasReservas.Length; i++)
            {
                if (hist.HistoricoDasReservas[i] != null)
                {
                    if (DateTime.Today > hist.HistoricoDasReservas[i].DataValidade)
                    {
                        hist.ExcluirReservaDoRegistro(i);
                    }
                }
                else
                    break;
            }
        }

        private void VerificarRevistaJaReservada(Revista revista)
        {
            if (revista.disponibilidade == "Reservada")
            {
                Console.WriteLine("\nA revista escolhida já está reservada\n");
                return;
            }
        }

        private bool VerificarCondicaoAmigoReservado(Emprestimo emp)
        {
            for (int i = 0; i < hist.HistoricoDasReservas.Length; i++)
            {
                if (hist.HistoricoDasReservas[i] != null)
                {
                    if (emp.AmigoQPegou.Nome == hist.HistoricoDasReservas[i].AmigoQPegou.Nome)
                    {
                        if (emp.dataQpegou <= hist.HistoricoDasReservas[i].dataQpegou)
                        {
                            
                            emp.RevistaEmprestada = new();

                            emp.RevistaEmprestada = hist.HistoricoDasReservas[i].RevistaEmprestada;

                            return true;
                        }
                        else
                            hist.HistoricoDasReservas[i].RevistaEmprestada.disponibilidade = "Liberado";
                            break;
                    }
                    else
                        continue;
                }
                else
                    break;
            }
            return false;
        }

        private bool VerificarEmprestimoCategoriaConservada(Emprestimo emp, Revista[] categ)
        {

            if (categ != null)
            {
                foreach (Revista item in categ)
                {
                
                    if (DateTime.Today <= emp.dataQpegou.AddDays(3))
                    {
                        continue;
                    }
                    else
                        emp.AmigoQPegou.CobrarMulta = Amigo.Multa.Sim;
                }
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCategoria 'Conservada' está vazia");
                Console.ResetColor();
                Console.ReadKey();
                return false;
            }
                
        }
        //======================================================================================

        private void QuitarMulta()
        {
            Validacao valida = new();
            int indice = 0;

            if (hist.HistoricoAmigos[0] == null)
            {
                Console.WriteLine("Histórico de amigos está vazio");
                return;
            }
            else
            {
                hist.ExibirAmigosComMultaPendente();
            }

            indice = EntradaIndiceAmigoValidada(indice, valida);

            hist.HistoricoAmigos[indice].CobrarMulta = Amigo.Multa.Não;
        }
    }

}
