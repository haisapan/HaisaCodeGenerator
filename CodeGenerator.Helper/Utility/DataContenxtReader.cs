using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeGenerator.Helper.Utility
{
    public static class DataContenxtReader
    {
        /// <summary>
        /// get all DBContext in current solution
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllDataContextTypes()
        {
            var type = typeof(DbContext);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.FullName.Contains("System.Data.Entity"));  
            //if some dbcontext class in System.Data.Entity, then they are not what we want.

            return types;
        }

        /// <summary>
        /// get all datasets of one dbcontext
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllDataSets(DbContext dbContext)
        {
            var dbContextType = dbContext.GetType();
            var currentNameSpace = dbContextType.Namespace;
            var allDataSets = dbContextType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return allDataSets.Where(p => p.DeclaringType != null && p.DeclaringType.Namespace == currentNameSpace).Select(p => p.Name);
            //only the dataset in namespace of dbContext are what we should use.

        }
    }
}
