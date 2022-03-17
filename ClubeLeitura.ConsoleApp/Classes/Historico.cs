using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClubeLeitura.ConsoleApp.Classes
{
    internal class Historico
    {
        Emprestimo[] _historico = new Emprestimo[100];
        Revista[] _historicoRevistas = new Revista[200];
        Amigo[] _historicoAmigos = new Amigo[50];
        Caixa[] _historicoCaixas = new Caixa[10];

        public Emprestimo[] HistoricoEmprestimos { get { return _historico; } set { _historico = value; } }
        public Revista[] HistoricoRevistas { get { return _historicoRevistas; } set { _historicoRevistas = value; } }
        public Amigo[] HistoricoAmigos
        {
            get { return _historicoAmigos; }
            set { _historicoAmigos = value;}    
        }
        public Caixa[] HistoricoCaixas
        {
            get
            {
                return _historicoCaixas;
            }
            set
            {
                _historicoCaixas = value;
            }
        }



        public void ExibirHistorico()
        {
            Console.Clear();

            if (_historico[0] == null)
            {
                Console.WriteLine("Histórico de empréstimos vazio");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (var registro in _historico)
                {
                    if (registro != null)
                    {
                        Console.WriteLine( 

                           $"===============================================                   \n\r" +
                           $"Registro Número......:  {registro.ID}                             \n\r" +
                           $"Nome de quem Pegou...:  {registro.AmigoQPegou.Nome}               \n\r" +
                           $"Nome do Responsável..:  {registro.AmigoQPegou.NomeResponsavel}    \n\r" +
                           $"Telefone.............:  {registro.AmigoQPegou.Telefone}           \n\r" +
                           $"                                                                  \n\r" +
                           $"Endereço:                                                         \n\r" +
                           $"Rua..................:  {registro.AmigoQPegou.Endereco.Rua}       \n\r" +
                           $"Bairro...............:  {registro.AmigoQPegou.Endereco.Bairro}    \n\r" +
                           $"Casa Nº..............:  {registro.AmigoQPegou.Endereco.NumeroCasa} \n\r" +
                           $"                                                                    \n\r" +
                           $"Coleção..............:  {registro.RevistaEmprestada.TipoColecao}    \n\r" +
                           $"Edição Nº............:  {registro.RevistaEmprestada.NumeroEdicao}    \n\r" +
                           $"Ano..................:  {registro.RevistaEmprestada.Ano}                 \n\r" +
                           $"                                                                          \n\r" +
                           $"Caixa:                                                                     \n\r" +
                           $"Caixa Nº.............:  {registro.RevistaEmprestada.Caixa.Numero}        \n\r" +
                           $"Etiqueta.............:  {registro.RevistaEmprestada.Caixa.Etiqueta}      \n\r" +
                           $"Cor da Caixa.........:  {registro.RevistaEmprestada.Caixa.Cor}           \n\r" +
                           $"                                                                  \n\r" +
                           $"Data que Pegou.......:  {registro.dataQpegou:dd/MM/yyyy}          \n\r" +
                           $"Data de Devolução....:  {registro.dataDevolucao:dd/MM/yyyy}       \n\r" +
                           $"                                                                  \n\r" +
                           $"Status...............:  {registro.StatusDoEmprestimo}             \n\r" +
                           $"==============================================="
                            
                        );
                    }
                    else
                        break;
                }
                Console.ResetColor();
            }
            
        }

        int count = 0;
        public void GuardarRegistro(Emprestimo registro, int mes)
        {
            HistoricoEmprestimos[count] = registro;
            count++;

            GuardarHistoricoMes(mes);
        }

        public void ExibirEmprestimosMensais(int mes) 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (mes)
            {
                case 1:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes01");
                    break;
                case 2:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes02");
                    break;
                case 3:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes03");
                    break;
                case 4:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes04");
                    break;
                case 5:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes05");
                    break;
                case 6:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes06");
                    break;
                case 7:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes07");
                    break;
                case 8:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes08");
                    break;
                case 9:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes09");
                    break;
                case 10:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes10");
                    break;
                case 11:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes11");
                    break;
                case 12:
                    LerArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes12");
                    break;
            }
            Console.ResetColor();
        }

        public void FiltrarParaEmprestimosEmAberto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (_historico[0] == null)
            {
                Console.WriteLine("Histórico vazio");
                return;
            }
            else
            {
                foreach (var registro in _historico)
                {
                    if (registro != null && registro.StatusDoEmprestimo == Emprestimo.Status.Aberto)
                    {
                        Console.WriteLine(

                          $"===============================================                   \n\r" +
                          $"Registro Número......:  {registro.ID}                             \n\r" +
                          $"Nome de quem Pegou...:  {registro.AmigoQPegou.Nome}               \n\r" +
                          $"Nome do Responsável..:  {registro.AmigoQPegou.NomeResponsavel}    \n\r" +
                          $"Telefone.............:  {registro.AmigoQPegou.Telefone}           \n\r" +
                          $"                                                                  \n\r" +
                          $"Endereço:                                                         \n\r" +
                          $"Rua..................:  {registro.AmigoQPegou.Endereco.Rua}       \n\r" +
                          $"Bairro...............:  {registro.AmigoQPegou.Endereco.Bairro}     \n\r" +
                          $"Casa Nº..............:  {registro.AmigoQPegou.Endereco.NumeroCasa} \n\r" +
                          $"                                                                    \n\r" +
                          $"Coleção..............:  {registro.RevistaEmprestada.TipoColecao}    \n\r" +
                          $"Edição Nº............:  {registro.RevistaEmprestada.NumeroEdicao}    \n\r" +
                          $"Ano..................:  {registro.RevistaEmprestada.Ano}                 \n\r" +
                          $"                                                                          \n\r" +
                          $"Caixa:                                                                     \n\r" +
                          $"Caixa Nº.............:  {registro.RevistaEmprestada.Caixa.Numero}        \n\r" +
                          $"Etiqueta.............:  {registro.RevistaEmprestada.Caixa.Etiqueta}      \n\r" +
                          $"Cor da Caixa.........:  {registro.RevistaEmprestada.Caixa.Cor}           \n\r" +
                          $"                                                                  \n\r" +
                          $"Data que Pegou.......:  {registro.dataQpegou:dd/MM/yyyy}          \n\r" +
                          $"Data de Devolução....:  {registro.dataDevolucao:dd/MM/yyyy}       \n\r" +
                          $"                                                                  \n\r" +
                          $"Status...............:  {registro.StatusDoEmprestimo}             \n\r" +
                          $"==============================================="
                       );
                    }
                    else
                        break;
                }
            }
            Console.ResetColor();
        }



  
        private void GuardarHistoricoMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes01");
                    break;
                case 2:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes02");
                    break;
                case 3:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes03");
                    break;
                case 4:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes04");
                    break;
                case 5:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes05");
                    break;
                case 6:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes06");
                    break;
                case 7:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes07");
                    break;
                case 8:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes08");
                    break;
                case 9:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes09");
                    break;
                case 10:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes10");
                    break;
                case 11:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes11");
                    break;
                case 12:
                    EscreverArquivoTxt(@"C:\Users\Thais\OneDrive\Área de Trabalho\Cantinho do William\Meus Projetos\ClubeLeitura\ClubeLeitura.ConsoleApp\BaseDadosMeses\Mes12");
                    break;
            }
         }

        int countRev = 0;
        public void GuardarRegistroRevistas(Revista rev)
        {
            HistoricoRevistas[countRev] = rev;
            countRev++;
        }

        int countAmigo = 0;
        public void GuardarRegistroAmigos(Amigo amigo)
        {
            HistoricoAmigos[countAmigo] = amigo;
            countAmigo++;
        }

        int countCaixa = 0;
        public void GuardarRegistroCaixas(Caixa caixa)
        {
            HistoricoCaixas[countCaixa] = caixa;
            countCaixa++;
        }




        public void ExibirRevistasRegistradas()
        {
            Console.Clear();
           
            if (_historicoRevistas[0] == null)
            {
                Console.WriteLine("Histórico de revistas está vazio");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                for(int i = 0; i < HistoricoRevistas.Length; i++)
                {
                    if (HistoricoRevistas[i] != null)
                    {
                        Console.WriteLine( $"============================================             \n\r"+
                                           $"Índice............: {i}                                  \n\r"+                                          
                                           $"                                                         \n\r"+
                                           $"Tipo da Coleção...: {HistoricoRevistas[i].TipoColecao}   \n\r"+
                                           $"Edição Nº.........: {HistoricoRevistas[i].NumeroEdicao}  \n\r"+
                                           $"Ano...............: {HistoricoRevistas[i].Ano}           \n\r"+
                                           $"                                                         \n\r"+
                                           $"Caixa                                                    \n\r"+
                                           $"Cor...............: {HistoricoRevistas[i].Caixa.Cor}     \n\r"+
                                           $"Etiqueta..........: {HistoricoRevistas[i].Caixa.Etiqueta}\n\r"+
                                           $"Número............: {HistoricoRevistas[i].Caixa.Numero}  \n\r"+
                                           $"============================================"
                         ); 
                    }
                    
                    else
                        break;
                }
                Console.ResetColor();

            }
           
        }

        public void ExibirCaixasRegistradas()
        {
            Console.Clear();

            if (_historicoCaixas[0] == null)
            {
                Console.WriteLine("Histórico de caixas está vazio");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int i = 0; i < HistoricoCaixas.Length; i++)
                {
                    if (HistoricoCaixas[i] != null)
                    {
                        Console.WriteLine($"============================================      \n\r" +
                                           $"Índice............: {i}                           \n\r" +
                                           $"                                                  \n\r" +
                                           $"Cor...............: {HistoricoCaixas[i].Cor}      \n\r" +
                                           $"Etiqueta..........: {HistoricoCaixas[i].Etiqueta} \n\r" +
                                           $"Número............: {HistoricoCaixas[i].Numero}   \n\r" +
                                           $"============================================"
                         );
                    }

                    else
                        break;
                }
                Console.ResetColor();

            }
        }

        public void ExibirAmigosRegistrados()
        {
            Console.Clear();

            if (_historicoAmigos[0] == null)
            {
                Console.WriteLine("Histórico de amigos está vazio");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int i = 0; i < HistoricoAmigos.Length; i++)
                {
                    if (HistoricoAmigos[i] != null)
                    {
                        Console.WriteLine($"============================================                     \n\r" +
                                           $"Índice...............: {i}                                      \n\r" +
                                           $"                                                                \n\r" +
                                           $"Nome do Amigo........: {HistoricoAmigos[i].Nome}                \n\r" +
                                           $"Nome do Responsável..: {HistoricoAmigos[i].NomeResponsavel}     \n\r" +
                                           $"Telefone.............: {HistoricoAmigos[i].Telefone}            \n\r" +
                                           $"                                                                \n\r" +
                                           $"Endereço                                                        \n\r" +
                                           $"Rua..................: {HistoricoAmigos[i].Endereco.Rua}        \n\r" +
                                           $"Bairro:..............: {HistoricoAmigos[i].Endereco.Bairro}     \n\r" +
                                           $"Número:..............: {HistoricoAmigos[i].Endereco.NumeroCasa} \n\r" +
                                           $"============================================"
                         );
                    }

                    else
                        break;
                }
                Console.ResetColor();
            }
        }




        public void ExcluirRevistaEmprestadaDoRegistro(int indice)
        {
            Revista[] auxiliar = new Revista[HistoricoRevistas.Length];

            int contAux = 0;

            for (int i = 0; i < HistoricoRevistas.Length; i++)
            {
                if (HistoricoRevistas[i] != null)
                {
                    if (i != indice)
                    {
                        auxiliar[contAux] = HistoricoRevistas[i];

                        contAux++;
                    }
                }
                else
                    break;
            }

            // devolvendo do auxiliar para o registro normal
            for (int i = 0; i < HistoricoRevistas.Length; i++)
            {
                HistoricoRevistas[i] = null;
            }

            int conAuxReg = 0;
            for (int i = 0; i < HistoricoRevistas.Length; i++)
            {
                if (auxiliar[i] != null)
                {
                    HistoricoRevistas[conAuxReg] = auxiliar[i];
                    conAuxReg++;
                }
                else
                    break;
            }
        }




        private void LerArquivoTxt(string diretorio) 
        {
            try
            {
                using (StreamReader sr = File.OpenText(diretorio))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\nRegistro inexistente\n");
            }
        }

        private void EscreverArquivoTxt(string diretorio)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(diretorio))
                {
                    foreach (var registro in HistoricoEmprestimos)
                    {
                        if (registro != null)
                        {
                            sw.WriteLine(

                               $"===============================================                   \n\r" +
                               $"Registro Número......:  {registro.ID}                             \n\r" +
                               $"Nome de quem Pegou...:  {registro.AmigoQPegou.Nome}               \n\r" +
                               $"Nome do Responsável..:  {registro.AmigoQPegou.NomeResponsavel}    \n\r" +
                               $"Telefone.............:  {registro.AmigoQPegou.Telefone}           \n\r" +
                               $"                                                                  \n\r" +
                               $"Endereço:                                                         \n\r" +
                               $"Rua..................:  {registro.AmigoQPegou.Endereco.Rua}       \n\r" +
                               $"Bairro...............:  {registro.AmigoQPegou.Endereco.Bairro}    \n\r" +
                               $"Casa Nº..............:  {registro.AmigoQPegou.Endereco.NumeroCasa}\n\r" +
                               $"                                                                  \n\r" +
                               $"Coleção..............:  {registro.RevistaEmprestada.TipoColecao}    \n\r" +
                               $"Edição Nº............:  {registro.RevistaEmprestada.NumeroEdicao}    \n\r" +
                               $"Ano..................:  {registro.RevistaEmprestada.Ano}                 \n\r" +
                               $"                                                                          \n\r" +
                               $"Caixa:                                                                     \n\r" +
                               $"Caixa Nº.............:  {registro.RevistaEmprestada.Caixa.Numero}        \n\r" +
                               $"Etiqueta.............:  {registro.RevistaEmprestada.Caixa.Etiqueta}      \n\r" +
                               $"Cor da Caixa.........:  {registro.RevistaEmprestada.Caixa.Cor}           \n\r" +
                               $"                                                                  \n\r" +
                               $"Data que Pegou.......:  {registro.dataQpegou:dd/MM/yyyy}          \n\r" +
                               $"Data de Devolução....:  {registro.dataDevolucao:dd/MM/yyyy}       \n\r" +
                               $"                                                                  \n\r" +
                               $"Status...............:  {registro.StatusDoEmprestimo}             \n\r" +
                               $"==============================================="

                            );
                        }
                        else
                            break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nHouve um erro na tentativa de registrar informações no arquivo .txt\n");
            }
        }

    }
}
