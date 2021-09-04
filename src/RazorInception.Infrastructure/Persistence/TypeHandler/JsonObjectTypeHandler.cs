using Dapper;
using System;
using System.Data;
using System.Text.Json;

namespace RazorInception.Infrastructure.Persistence.TypeHandler
{
	public class JsonObjectTypeHandler : SqlMapper.ITypeHandler
	{
		public void SetValue(IDbDataParameter parameter, object value)
		{
			parameter.Value = (value == null)
				? (object)DBNull.Value
				: JsonSerializer.Serialize(value);
			parameter.DbType = DbType.String;
		}

		public object Parse(Type destinationType, object value)
		{
			return JsonSerializer.Deserialize(value.ToString(), destinationType);
		}
	}
}
