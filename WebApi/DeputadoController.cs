﻿using OPS.Core;
using OPS.Dao;
using System.Web.Http;

namespace OPS.WebApi
{
	public class DeputadoController : ApiController
	{
		DeputadoDao dao;

		public DeputadoController()
		{
			dao = new DeputadoDao();
		}

		[HttpGet]
		[ActionName("Get")]
		public dynamic Consultar(int id)
		{
			return dao.Consultar(id);
		}

		[HttpGet]
		public dynamic Pesquisa()
		{
			return dao.Pesquisa();
		}

		[HttpGet]
		public dynamic Lancamentos([FromUri]FiltroParlamentarDTO filtro)
		{
			return dao.Lancamentos(filtro);
		}

		[HttpGet]
		public dynamic TipoDespesa()
		{
			return dao.TipoDespesa();
		}

		[HttpGet]
		public dynamic Secretarios([FromUri]FiltroParlamentarDTO filtro)
		{
			return dao.Secretarios(filtro);
		}

		[HttpGet]
		public dynamic SecretariosPorDeputado(int id)
		{
			return dao.SecretariosPorDeputado(id);
		}

		[HttpGet]
		public dynamic GastosMensaisPorAno(int id)
		{
			return dao.GastosMensaisPorAno(id);
		}

		[HttpGet]
		public dynamic Documento(int id)
		{
			return dao.Documento(id);
		}

		[HttpGet]
		public dynamic MaioresNotas(int id)
		{
			return dao.MaioresNotas(id);
		}

		[HttpGet]
		public dynamic MaioresFornecedores(int id)
		{
			return dao.MaioresFornecedores(id);
		}
	}
}
