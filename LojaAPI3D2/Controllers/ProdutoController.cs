using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using LojaAPI3D2.BLL;
using LojaAPI3D2.DAL;
using LojaAPI3D2.Models;
using Newtonsoft.Json;

namespace LojaAPI3D2.Controllers
{
    
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        DALMysql daoBanco = new DALMysql();

        [AcceptVerbs("GET")]
        [Route("listarProdutoCodigo/{codigoProduto}")]
        public string listarClientesPorCodigo(int codigoProduto)
        {
            string consulta = string.Format($@"SELECT * from tbl_produto where id = " + codigoProduto + ";");
            string jsonString = string.Empty;
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(daoBanco.executarConsulta(consulta), Formatting.Indented);
            return jsonString;
        }


        [AcceptVerbs("GET")]
        [Route("listarProdutoCategoria/{codigoCategoria}")]
        public string listarClientesPorCategoria(int codigoCategoria)
        {
            string consulta = string.Format($@"SELECT * from tbl_produto where tbl_categoria_id = " + codigoCategoria + ";");
            string jsonString = string.Empty;
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(daoBanco.executarConsulta(consulta), Formatting.Indented);
            return jsonString;
        }

        [AcceptVerbs("POST")]
        [Route("verificaDisponibilidaEstoque")]
        public string verificarUsuario(ProdutoModel produto)
        {
            // Regra de Negócio
            string consulta = string.Format($@"select * from tbl_produto where id = '{produto.Id}';");
            DataTable dt = daoBanco.executarConsulta(consulta);
            if (dt.Rows.Count == 1)
            {
                int qtdeEstoque = Convert.ToInt32(dt.Rows[0]["quantidade"].ToString());
                if (qtdeEstoque >= produto.Quantidade)
                {
                    string sql = string.Format($@"UPDATE tbl_produto set quantidade = quantidade - '{produto.Quantidade}'
                                                where id = '{produto.Id}';");
                    daoBanco.executarComando(sql);

                    return "OK";
                }
                else
                {
                    return "Quantidade em Estoque Insuficiente";
                }
                
            }
            else
            {
                return "Produto não Localizado";
            }
        }

    }
}
