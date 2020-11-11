using LojaAPI3D2.BLL;
using LojaAPI3D2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
        // Lista Provisória para Armazenar os clientes
        private static List<ClienteModel> listaClientes = new List<ClienteModel>();
        tblClienteBLL bllCliente = new tblClienteBLL();


         /// <summary>
         ///  Verifica se Cliente Existe.
        ///  </summary>
        [AcceptVerbs("POST")]
        [Route("verificarUsuario")]
        public Boolean verificarUsuario(ClienteModel cliente)
        {
            return bllCliente.Autenticar(cliente);
        }

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
        public string listarClientes()
        {
           DataTable dt = bllCliente.ListarClientes();
           return   JsonConvert.SerializeObject(dt);
          
            //return listaClientes;
        }

        // Metodo para Listar Cliente pelo Codigo
        [AcceptVerbs("GET")]
        [Route("listarClientesPorCodigo/{codigo}")]
        public List<ClienteModel> listarClientesPorCodigo(int codigo)
        {
            DataTable dt = bllCliente.ListarClientes(codigo);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);
            // return jsonString;
            return listaClientes;
        }

        //Metodo para Excluir Cliente
        [AcceptVerbs("DELETE")]
        [Route("excluirClientes/{id_cliente}")]
        public string excluirCliente(int id_cliente)
        {
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
