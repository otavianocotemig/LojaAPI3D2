using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAPI3D2.Models
{
    public class ClienteModel
    {
        private int id_cliente;
        private string nome_cliente;
        private string sobrenome_cliente;
        private string email_cliente;
        private string senha_cliente;

        public ClienteModel()
        {

        }

        public ClienteModel(int id_cliente, string nome_cliente, string sobrenome_cliente, string email_cliente)
        {
            this.id_cliente = id_cliente;
            this.nome_cliente = nome_cliente;
            this.sobrenome_cliente = sobrenome_cliente;
            this.email_cliente = email_cliente;
        }

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nome_cliente { get => nome_cliente; set => nome_cliente = value; }
        public string Sobrenome_cliente { get => sobrenome_cliente; set => sobrenome_cliente = value; }
        public string Email_cliente { get => email_cliente; set => email_cliente = value; }
        public string Senha_cliente { get => senha_cliente; set => senha_cliente = value; }
    }
}