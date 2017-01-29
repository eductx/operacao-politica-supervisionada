﻿using OPS.Core;
using System.Data;
using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace OPS.Dao
{
	public static class ComandoSqlDao
	{
		/// <summary>
		/// Retorna resumo (8 Itens) dos parlamentares mais e menos gastadores
		/// 4 Deputados MAIS gastadores (CEAP)
		/// 4 Senadores MAIS gastadores (CEAPS)
		/// </summary>
		/// <returns></returns>
		internal static object RecuperarCardsIndicadores()
		{
			using (Banco banco = new Banco())
			{
				var strSql = new StringBuilder();

				strSql.Append(@"
					SELECT id_cf_deputado, id_cadastro, nome_parlamentar, valor_total, sigla_partido, sigla_estado
					FROM cf_deputado_campeao_gasto
					order by valor_total desc; "
				);

				strSql.Append(@"
					SELECT id_sf_senador, nome_parlamentar, valor_total, sigla_partido, sigla_estado
					FROM sf_senador_campeao_gasto
					order by valor_total desc; "
				);

				var lstDeputados = new List<dynamic>();
				var lstSenadores = new List<dynamic>();
				using (MySqlDataReader reader = banco.ExecuteReader(strSql.ToString()))
				{
					while (reader.Read())
					{
						lstDeputados.Add(new
						{
							id_cf_deputado = reader["id_cf_deputado"],
							id_cadastro = reader["id_cadastro"],
							nome_parlamentar = reader["nome_parlamentar"].ToString(),
							valor_total = "R$ " + Utils.FormataValor(reader["valor_total"]),
							sigla_partido_estado = string.Format("{0} / {1}", reader["sigla_partido"], reader["sigla_estado"])
						});
					}

					reader.NextResult();
					while (reader.Read())
					{
						lstSenadores.Add(new
						{
							id_sf_senador = reader["id_sf_senador"],
							nome_parlamentar = reader["nome_parlamentar"].ToString(),
							valor_total = "R$ " + Utils.FormataValor(reader["valor_total"]),
							sigla_partido_estado = string.Format("{0} / {1}", reader["sigla_partido"], reader["sigla_estado"])
						});
					}

					return new
					{
						CamaraFederal = lstDeputados,
						Senado = lstSenadores
					};
				}
			}
		}
	}
}