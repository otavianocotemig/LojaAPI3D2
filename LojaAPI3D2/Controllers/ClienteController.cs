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
        // Array para inserir e excluir dados 
        // Será substituido por Crud no Mysql
        private static List<ClienteModel> listaClientes = new List<ClienteModel>();

        // Metodo para Cadastrar um Cliente
        [AcceptVerbs("POST")]
        [Route("cadastrarCliente")]
        public string cadastrarCliente(ClienteModel cliente)
        {
            listaClientes.Add(cliente);
            return "Cliente inserido com sucesso";

        }

        // Metodo para Listar todos os clientes do banco
        [AcceptVerbs("GET")]
        [Route("listarClientes")]
        public List<ClienteModel> listarClientes()
        {
            return listaClientes;
        }

    }
}
