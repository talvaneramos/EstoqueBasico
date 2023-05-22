using Projeto06.Controllers;
using System;

namespace Projeto06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var produtoController = new ProdutoController();
            Executar(produtoController);
        }

        private static void Executar(ProdutoController produtoController)
        {
            try
            {
                Console.Write("\n(1) - Cadastar Produto ");
                Console.Write("\n(2) - Atualizar Produto ");
                Console.Write("\n(3) - Excluir Produto ");
                Console.Write("\n(4) - Consultar Produto ");

                Console.WriteLine("");
                Console.WriteLine("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao) 
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        break;

                    case 2:
                        produtoController.AtualizarProduto();
                        break;

                    case 3:
                        produtoController.ExcluirProduto();
                        break;

                    case 4:                       
                        produtoController.ConsultarProdutos();                        
                        break;

                    default:
                        throw new Exception("\nOpção inválida! ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
            finally
            {
                Console.Write("\nDeseja realizar outra operação? (S, N): ");

                var opcao = Console.ReadLine().ToUpper();

                if (opcao.Equals("S"))
                {
                    Console.Clear();
                    Executar(produtoController);
                }
                else
                {
                    Console.WriteLine("\nFim do programa! ");
                    Console.ReadKey();
                }
            }
        }
    }
}
