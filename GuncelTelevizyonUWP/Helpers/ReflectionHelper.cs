using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
#if PORTALBE
using Tcm.Sfa.FileSystem;
#elif WINDOWS_APP
using Windows.Storage;
#endif
namespace GuncelTelevizyonUWP.Helpers
{
    public static class ReflectionHelper
    {
        private static Dictionary<Type, PropertyInfo[]> getPropertiesCache = new Dictionary<Type, PropertyInfo[]>();
        private static Dictionary<string, Type> typeNameCache = new Dictionary<string, Type>();
        private static Assembly[] assemblyCache = null;

        public static IDictionary<string, object> ToExpando(object anonymousObject) => ToExpando(anonymousObject, null);


        public static IDictionary<string, object> ToExpando(object anonymousObject, Predicate<PropertyInfo> predicate)
        {
            IDictionary<string, object> expando = null;

            if (anonymousObject != null)
            {
                if (anonymousObject is IDictionary<string, object>)
                    expando = anonymousObject as IDictionary<string, object>;
                else
                {
                    expando = new Dictionary<string, object>();
                    foreach (var property in GetProperties(anonymousObject))
                        if (predicate == null || predicate(property))
                            expando.Add(property.Name, property.GetValue(anonymousObject));
                }
            }

            return expando;
        }

        public static IDictionary<string, string> ToExpandoString(object anonymousObject)
        {
            var exp = ToExpando(anonymousObject);

            IDictionary<string, string> expando = new Dictionary<string, string>();

            foreach (var item in exp)
                expando.Add(item.Key, item.Value.ToString());

            return expando;
        }

        public static IList<string> ToExpandoKeys(object anonymousObject)
        {
            List<string> keys = new List<string>();

            if (anonymousObject != null)
            {
                foreach (var property in GetProperties(anonymousObject))
                {
                    keys.Add(property.Name);
                }
            }

            return keys;
        }

        public static IEnumerable<PropertyInfo> GetProperties(object o)
        {
            if (o == null) return null;

            var type = o.GetType();

            return GetProperties(type);
        }

        public static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            if (getPropertiesCache.ContainsKey(type))
                return getPropertiesCache[type].AsEnumerable();

            var properties = type
                .GetTypeInfo()
                .DeclaredProperties;

            getPropertiesCache.Add(type, properties.ToArray());

            return getPropertiesCache[type].AsEnumerable();
        }

        public static Type GetTableType(Type t)
        {
            if (t.IsArray)
                return t.GetElementType();

            return t;
        }

        public static Type GetType(string type)
        {
            if (typeNameCache.ContainsKey(type)) return typeNameCache[type];
            Assembly[] assemblies;

            assemblies = GetAssemblies().Where(i => i.FullName.StartsWith("GuncelTelevizyonUWP")).ToArray();

            foreach (var a in assemblies)
            {
                Type t = null;
                t = a.GetType(type);
                if (t != null)
                {
                    typeNameCache[type] = t;
                    return t;
                }
            }

            return null;
        }


        public static IEnumerable<Assembly> GetAssemblies()
        {
            if (assemblyCache != null)
                return assemblyCache;

            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var result = new List<Assembly>();

            var getFilesTask = folder.GetFilesAsync().AsTask();
            getFilesTask.Wait();
            var assemblies = getFilesTask.Result;

            foreach (StorageFile file in assemblies)
            {
                if (file.FileType == ".dll" || file.FileType == ".exe")
                {
                    try
                    {
                        var n = Path.GetFileNameWithoutExtension(file.Name);
                        AssemblyName name = new AssemblyName() { Name = n };
                        Assembly asm = Assembly.Load(name);
                        result.Add(asm);
                    }
                    catch (Exception) { }
                }
            }

            assemblyCache = result.ToArray();

            return assemblyCache;
        }
    }
}
