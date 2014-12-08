using LoginCol.Huellitas.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class GeneradorLlaveUnica<T> : IDatabaseInitializer<T> where T : DbContext
    {
        public void InitializeDatabase(T context)
        {
            var fatherPropertyNames = typeof(DbContext).GetProperties().Select(pi => pi.Name).ToList(); 
           //Loop each dbset's T 
            foreach (PropertyInfo item in typeof(T).GetProperties().Where(p => fatherPropertyNames.IndexOf(p.Name) < 0).Select(p => p))
            {
                Type entityModelType = item.PropertyType.GetGenericArguments()[0];
                var camposUnique = from prop in entityModelType.GetProperties()
                                    where prop.GetCustomAttributes(typeof(UniqueKeyAttribute), true).Count() > 0
                                    select prop.Name;
                foreach (string campo in camposUnique)
                {
                    StringBuilder sql = new StringBuilder();

                    sql.AppendFormat("IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND name = N'IX_Unique_{0}{1}') ", entityModelType.Name, campo);
                    sql.AppendLine();
                    sql.AppendFormat("ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [IX_Unique_{0}{1}] UNIQUE NONCLUSTERED ( [{1}] ASC )", entityModelType.Name, campo);

                    context.Database.ExecuteSqlCommand(sql.ToString());
                } 
            }


        }
    }
}
