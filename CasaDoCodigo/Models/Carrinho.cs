using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Models
{
    public class Carrinho
    {
        public ICollection<ItemCompra> ItensDeCompra { get; set; }
        public decimal ValorFrete { get; set; }
        public string CepDestino { get; set; }
        public Pagamento Pagamento { get; set; }

        public Carrinho()
        {
            this.ItensDeCompra = new SortedSet<ItemCompra>();
        }

        public List<ItemCompra> GetItensCompra()
        {
            return new List<ItemCompra>(this.ItensDeCompra);
        }

        public void AdicionarOuIncremantarQuantidadeDoItem(Livro livro, Formato formato)
        {
            ItemCompra item = new ItemCompra(livro, formato);

            if (JaExisteItem(item))
            {
                ItemCompra itemCarrinho = this.ProcurarItem(item);
                itemCarrinho.IncrementaQuantidade(item.Quantidade);
            }
            else
            {
                this.ItensDeCompra.Add(item);
            }

            CancelarPagamento();
        }

        public void RemoverItemPeloCodigoEFormato(string codigo, Formato formato)
        {
            ItemCompra itemARemover = ProcurarItemPeloId(codigo, formato);

            if (itemARemover != null)
            {
                this.ItensDeCompra.Remove(itemARemover);
            }

            if (!this.IsComLivrosImpressos())
            {
                this.ValorFrete = 0;
            }

            CancelarPagamento();
        }

        public Pagamento CriarPagamento(String numeroCartao, String nomeTitular)
        {
            Transacao transacao = new Transacao();
            transacao.Numero = numeroCartao;
            transacao.Titular = nomeTitular;
            transacao.Valor = this.GetTotal();

            //TODO: aqui, fazer a chamada pra um client REST...mas como eu ainda não cheguei 
            //em rest, vou deixar comentado pra ver o que fazer depois
            //this.Pagamento = this.clienteRest.criarPagamento(transacao);

            return this.Pagamento;
        }

        public Pedido FinalizarPedido()
        {
            Pedido pedido = new Pedido();
		    pedido.Data = DateTime.Now;
		    pedido.Itens = new SortedSet<ItemCompra>(this.ItensDeCompra);

            //TODO: possível chamada pra um client REST que ainda não saiu, deixando comentado
		    //this.pagamento = this.clienteRest.confirmarPagamento(pagamento);
		    
            
            pedido.Pagamento = this.Pagamento;

            //TODO: chamada pro JMS que ainda não sei o que é, mas provavelmente vou implementar um aqui
            //this.enviador.enviar(pedido);

		    this.LimparCarrinho();

		    return pedido;
        }

        public void AtualizarFrete(string novoCepDestino)
        {
            this.CepDestino = novoCepDestino;

            //TODO: criar a classe pra consumir o serviço dos Correios
            //ConsumidorServicoCorreios consumidorServicoCorreios = new ConsumidorServicoCorreios();
            //this.valorFrete = consumidorServicoCorreios.calculaFrete(novoCepDestino);
        }


        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (ItemCompra item in this.ItensDeCompra)
            {
                total += item.GetTotal();
            }

            return total + this.ValorFrete;
        }

        public bool IsFreteCalculado()
        {
            return !this.ValorFrete.Equals(0) || !this.IsComLivrosImpressos();
        }

        public bool IsComLivrosImpressos()
        {
            foreach (ItemCompra itemCompra in this.ItensDeCompra) 
            {
			    if (itemCompra.isImpresso()) 
                {
				    return true;
			    }

		    }
		    return false;
        }

        public bool IsPagamentoCriado()
        {
            if(this.Pagamento == null)
            {
                return false;
            }
            return this.Pagamento.EhCriado();
        }

        public bool IsProntoPraSerFinalizado()
        {
            return this.IsFreteCalculado() && this.IsPagamentoCriado();
        }


        

        

        private void LimparCarrinho()
        {
            this.ItensDeCompra = null;
            this.ValorFrete = 0;
        }

   

        private ItemCompra ProcurarItem(ItemCompra itemProcurado)
        {
            foreach (ItemCompra item in this.ItensDeCompra)
            {
                if(item.Equals(itemProcurado))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("Item não encontrado"); 
        }

        private ItemCompra ProcurarItemPeloId(string codigo, Formato formato)
        {
            foreach (ItemCompra item in this.ItensDeCompra)
            {
                if(item.Livro.Codigo.Equals(codigo) && item.Formato.Equals(formato))
                {
                    return item;
                }
            }

            return null;
        }

        //TODO: adicionar chamada para cancelar pagamento na api rest provavelmente
        private void CancelarPagamento()
        {
            this.Pagamento = null;
        }

        private bool JaExisteItem(ItemCompra item)
        {
            return this.ItensDeCompra.Contains(item);
        }

        private List<string> GetCodigosDosItensImpressos()
        {
            List<string> codigos = new List<string>();

            foreach (ItemCompra item in this.ItensDeCompra)
            {
                if(item.isImpresso())
                {
                    codigos.Add(item.Livro.Codigo);
                }
            }

            return codigos;
        }

        public void VerificarDisponibilidadeDosItensComSoap() 
        {
            //TODO CAFUSO: Ver se tem como melhorar esse cara aqui
            //EstoqueWSClient estoqueWS = new EstoqueWSClient();
            //List<string> codigos = this.GetCodigosDosItensImpressos();

            //string[] arrayCodigos = new string[10];

            //for (int i = 0; i < codigos.Count; i++)
            //{
            //    arrayCodigos[i] = codigos[1];
            //}

            //ServicoEstoque.ItemEstoque[] itens = estoqueWS.GetQuantidade(arrayCodigos);

            //foreach (ServicoEstoque.ItemEstoque item in itens)
            //{
            //    AtualizarQuantidadeDisponivelDoItemCompra(item);
            //}

            EstoqueWSClient estoqueWS = new EstoqueWSClient();
            //List<string> codigos = this.GetCodigosDosItensImpressos();

            string[] arrayCodigos = new string[this.ItensDeCompra.Count];

            for(int i = 0; i < this.ItensDeCompra.Count; i++)
            {
                arrayCodigos[i] = (this.ItensDeCompra.ToArray())[i].Livro.Codigo;
            }

            //for (int i = 0; i < codigos.Count; i++)
            //{
            //    arrayCodigos[i] = codigos[1];
            //}

            ServicoEstoque.ItemEstoque[] itens = estoqueWS.GetQuantidade(arrayCodigos);

            foreach (ServicoEstoque.ItemEstoque item in itens)
            {
                AtualizarQuantidadeDisponivelDoItemCompra(item);
            }
	    }

        private void AtualizarQuantidadeDisponivelDoItemCompra(ServicoEstoque.ItemEstoque itemEstoque)
        {
            //TODO CAFUSO: Ao testar, vamo ver se tatu do bem
            //

            ItemCompra item = this.ItensDeCompra.Where( i =>  i.TemCodigo(itemEstoque.Codigo  )).First(); //Iterables.find(this.itensDeCompra, new Predicate<ItemCompra>() {

           
            //@Override
            //public boolean apply(ItemCompra item) {
            //    return item.temCodigo(itemEstoque.getCodigo());
            //}

            item.QuantidadeEstoque = itemEstoque.Quantidade;
        }

    }
}