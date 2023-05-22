using Projeto06.Entities;
using Projeto06.Enums;
using Projeto06.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController()
        {
            produtoRepository = new ProdutoRepository();
        }

        public void CadastrarProduto()
        {
            try
            {
                var produto = new Produto();

                Console.Write("Informe o id do produto............: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                Console.Write("Informe o nome do produto..........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o preço do produto.........: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o status do produto........: ");
                var status = int.Parse(Console.ReadLine());


                switch (status)
                {
                    case 0:
                        produto.Status = Status.Esgotado;
                        break;

                        case 1:
                        produto.Status = Status.Disponivel;
                        break;
                    default:

                        throw new Exception("Status inválido! ");
                }
                produtoRepository.Create(produto);
                Console.WriteLine("\nProduto cadastrado com sucesso! ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }

        public void AtualizarProduto()
        {
            try
            {
                var produto = new Produto();

                Console.Write("Informe o id do produto............: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                Console.Write("Informe o nome do produto..........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o preço do produto.........: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o status do produto........: ");
                var status = int.Parse(Console.ReadLine());


                switch (status)
                {
                    case 0:
                        produto.Status = Status.Esgotado;
                        break;

                    case 1:
                        produto.Status = Status.Disponivel;
                        break;
                    default:

                        throw new Exception("Status inválido! ");
                }
                produtoRepository.Update(produto);
                Console.WriteLine("\nProduto atualizado com sucesso! ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }

        public void ExcluirProduto()
        {
            try
            {
                var produto = new Produto();

                Console.Write("Informe o id do produto............: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                produtoRepository.Delete(produto);

                Console.WriteLine("\nProduto excluído com sucesso! ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }

        public void ConsultarProdutos()
        {
            try
            {
                foreach (var item in produtoRepository.GetAll())
                {
                        Console.WriteLine("Id do produto..................: " + item.IdProduto);
                        Console.WriteLine("Nome do produto................: " + item.Nome);
                        Console.WriteLine("Preço..........................: " + item.Preco);
                        Console.WriteLine("Status.........................: " + item.Status);
                }                            
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
       
    }
}
