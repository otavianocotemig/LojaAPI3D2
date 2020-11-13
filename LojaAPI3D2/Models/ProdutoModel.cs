using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAPI3D2.Models
{
    public class ProdutoModel
    {
        private int id, quantidade, tbl_categoria_id;
        private String nomeProduto, descricao;
        private String foto;
        private Double preco, peso;

        public ProdutoModel()
        {

        }

        public ProdutoModel(int id, int quantidade, int tbl_categoria_id, string nomeProduto, string descricao, string foto, double preco, double peso)
        {
            this.id = id;
            this.quantidade = quantidade;
            this.tbl_categoria_id = tbl_categoria_id;
            this.nomeProduto = nomeProduto;
            this.descricao = descricao;
            this.foto = foto;
            this.preco = preco;
            this.peso = peso;
        }

        public int Id { get => id; set => id = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int Tbl_categoria_id { get => tbl_categoria_id; set => tbl_categoria_id = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Foto { get => foto; set => foto = value; }
        public double Preco { get => preco; set => preco = value; }
        public double Peso { get => peso; set => peso = value; }
    }
}