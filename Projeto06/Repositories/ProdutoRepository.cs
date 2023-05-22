using Projeto06.Abstracts;
using Projeto06.Entities;
using Projeto06.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Repositories
{
    public class ProdutoRepository : ProdutoRepositoryAbstract
    {
        public override void Create(Produto produto)
        {
            var qtd = produtos.Count(p => p.IdProduto == produto.IdProduto);

            if (qtd == 0)
            {
                produtos.Add(produto);
            }
            else
            {
                throw new Exception("O produto já existe! ");
            }
        }

        public override void Update(Produto produto)
        {
            var registro = produtos.FirstOrDefault(p => p.IdProduto == produto.IdProduto);

            if (registro != null)
            {
                registro.Nome = produto.Nome;
                registro.Preco = produto.Preco;
                registro.Status = produto.Status;
            }
            else
            {
                throw new Exception("Produto não encontrado");
            }
        }

        public override void Delete(Produto produto)
        {
            var registro = produtos.FirstOrDefault(p => p.IdProduto == produto.IdProduto);

            if (registro != null)
            {
                produtos.Remove(registro);
            }
            else
            {
                throw new Exception("Produto não encontrado");
            }
        }

        public override List<Produto> GetAll()
        {
            return produtos.OrderBy(p => p.IdProduto)
                           .ToList();
        }

        public override List<Produto> GetByNome(string nome)
        {
            return produtos.Where(p => p.Nome.Contains(nome))
                           .OrderBy(p => p.IdProduto).ToList();
        }

        public override List<Produto> GetByPreco(decimal precoMin, decimal precoMax)
        {
            return produtos .Where(p => p.Preco >= precoMin && p.Preco <= precoMax)
                            .OrderBy(p => p.IdProduto)
                            .ToList();
        }

        public override List<Produto> GetByStatus(Status status)
        {
            return produtos.Where(p => p.Status == status)
                           .OrderBy(p => p.IdProduto)
                           .ToList();
        }

        public override Produto GetById(int id)
        {
            return produtos.FirstOrDefault(p => p.IdProduto == id);
        }
    }
}
