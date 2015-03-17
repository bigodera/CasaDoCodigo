using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServicoEstoque;

namespace WsEstoqueClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botaoEstoque_Click(object sender, EventArgs e)
        {
            EstoqueWSClient client  = new EstoqueWSClient();

            string[] codigos = new string[2];
            codigos[0] = "ARQ";
            codigos[1] = "TDD"; 

            ItemEstoque[] itens = client.GetQuantidade(codigos);

            foreach (var item in itens)
            {
                MessageBox.Show("Item: " + item.Codigo + "Quantidade" + item.Quantidade);   
            }
        }
    }
}
