﻿using FluentMigrator.Model;
using FluentMigrator.Runner.Generators.Base;

namespace FluentMigrator.Runner.Generators.SqlServer
{
	internal class SqlServerColumn : ColumnBase
	{
		public SqlServerColumn(ITypeMap typeMap) : base(typeMap, new SqlServerQuoter())
		{
		}

		protected override string FormatDefaultValue(ColumnDefinition column)
		{
			var defaultValue = base.FormatDefaultValue(column);

			if(!string.IsNullOrEmpty(defaultValue))
				return string.Format("CONSTRAINT DF_{0}_{1} ", column.TableName, column.Name) + defaultValue;

			return string.Empty;
		}

		protected override string FormatIdentity(ColumnDefinition column)
		{
			return column.IsIdentity ? "IDENTITY(" + (column.Seed > 0 ? column.Seed.ToString(): "1") + ",1)" : string.Empty;
		}

        protected override string FormatSystemMethods(SystemMethods systemMethod)
        {
            switch (systemMethod)
            {
                case SystemMethods.NewGuid:
                    return "NEWID()";
                case SystemMethods.CurrentDateTime:
                    return "GETDATE()";
            }

            return null;
        }
	}
}
