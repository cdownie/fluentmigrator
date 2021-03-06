#region License
// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.Schema.Index
{
	public class SchemaIndexQuery : ISchemaIndexSyntax
	{
	    private readonly string _schemaName;
	    private readonly string _tableName;
		private readonly string _indexName;
		private readonly IMigrationContext _context;

        public SchemaIndexQuery(string schemaName, string tableName, string indexName, IMigrationContext context)
		{
            _schemaName = schemaName;
            _tableName = tableName;
            _indexName = indexName;
			_context = context;
		}

		public bool Exists()
		{
			return _context.QuerySchema.IndexExists(_schemaName, _tableName, _indexName);
		}
	}
}