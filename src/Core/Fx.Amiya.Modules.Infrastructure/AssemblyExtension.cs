using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Modules.Infrastructure
{
    public static class AssemblyExtension
    {
        public static Dictionary<MatchType, Func<Type, string, bool>> map = new Dictionary<MatchType, Func<Type, string, bool>>()
        {
            { MatchType.StartsWith,(type,keyword)=>{ return type.Name.StartsWith(keyword,true,null); } },
            { MatchType.EndsWith,(type,keyword)=>{ return type.Name.EndsWith(keyword,true,null); } },

        };
        public static Dictionary<Type, Type[]> GetInterfaceAndImplementMap(this Assembly assembly, string keyword, MatchType matchType)
        {

            List<Type> types = assembly.GetTypes().ToList();
            var result = new Dictionary<Type, Type[]>();
            foreach (var item in types.Where(t => !t.IsInterface && map[matchType](t, keyword)))
            {
                var interfaces = item.GetInterfaces();
                result.Add(item, interfaces);
            }
            return result;


        }
    }

    public enum MatchType
    {
        StartsWith,
        EndsWith,

    }
}
