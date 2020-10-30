using LojaAPI3D2.BLL;
using LojaAPI3D2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI3D2.Controllers
{
    // Definição da Rota para acesso ao Endpoint do Cliente
    [RoutePrefix("api/cliente")]

    public class ClienteController : ApiController
    {
        tblClienteBLL bllCliente = new tblClienteBLL();

        // Array para inserir e excluir dados 
        // Será substituido por Crud no Mysql
        private static List<ClienteModel> listaClientes = new List<ClienteModel>();

        // Metodo para Cadastrar um Cliente
        [AcceptVerbs("POST")]
        [Route("cadastrarCliente")]
        public string cadastrarCliente(ClienteModel cliente)
        {
            listaClientes.Add(cliente);

            bllCliente.InserirCliente(cliente);

            return "Cliente inserido com sucesso";

        }

        // Metodo para Listar todos os clientes do banco
        [AcceptVerbs("GET")]
        [Route("listarClientes")]
        public List<ClienteModel> listarClientes()
        {
            return listaClientes;
        }

        // Metodo para Listar Cliente pelo Codigo
        [AcceptVerbs("GET")]
        [Route("listarClientesPorCodigo/{codigo}")]
        public ClienteModel listarClientesPorCodigo(int codigo)
        {
            ClienteModel cliente = listaClientes.Where(n => n.Id_cliente == codigo)
                                                .Select(n => n)
                                                .FirstOrDefault();
            return cliente;
        }

        //Metodo para Excluir Cliente
        [AcceptVerbs("DELETE")]
        [Route("excluirClientes/{id_cliente}")]
        public string excluirCliente(int id_cliente)
        {
           
           ClienteModel cliente = listaClientes.Where(n => n.Id_cliente == id_cliente)
                                               .Select(n => n)
                                               .First();
            listaClientes.Remove(cliente);
            bllCliente.ExcluirCliente(id_cliente);
            return "Cliente excluido com sucesso.";

        }

        // Metodo para ALterar os dados do cliente
        [AcceptVerbs("PUT")]
        [Route("alterarCliente")]
        public string alterarCliente(ClienteModel cliente)
        {
            bllCliente.AlterarCliente(cliente);
            return "Cliente alterado com sucesso.";
        }

    }
}
