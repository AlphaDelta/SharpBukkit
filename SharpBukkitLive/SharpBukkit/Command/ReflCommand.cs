using SharpBukkitLive.SharpBukkit.TypeConverters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SharpBukkitLive.SharpBukkit.Command
{
    public class ReflSharpBukkitCommand
    {
        static ConcurrentDictionary<Type, TypeConverter> ConverterCache = new ConcurrentDictionary<Type, TypeConverter>();
        static ReflSharpBukkitCommand()
        {
            ConverterCache.TryAdd(typeof(DateTime), new RelativeDateTimeConverter());
        }

        public string Name = null;

        public SharpBukkitCommandAttribute Attr = null;
        public MethodInfo Method = null;
        private ParameterInfo[] @params;

        /* Not thread safe AFAIK */
        string _Signature = null;
        public string Signature
        {
            get
            {
                if (_Signature == null)
                {
                    List<string> ps = new List<string>();

                    foreach (ParameterInfo p in Params)
                        if (!p.HasDefaultValue)
                            ps.Add($"<{p.Name.ToLower()}>");
                        else
                            ps.Add($"[{p.Name.ToLower()}={(p.DefaultValue == null ? "null" : p.DefaultValue.ToString())}]");

                    _Signature = string.Join(" ", ps);
                }

                return _Signature;
            }
        }

        public ParameterInfo[] Params { get => @params; set => @params = value; }

        public ReflSharpBukkitCommand(MethodInfo mi, SharpBukkitCommandAttribute attr)
        {
            Name = mi.Name;
            Attr = attr;
            Method = mi;
            Params = mi.GetParameters();

            if (!string.IsNullOrWhiteSpace(attr.Name))
                Name = attr.Name;

            Name = Name.ToLower();
        }

        private TypeConverter GetTypeConverter(Type t)
        {
            if (ConverterCache.ContainsKey(t)) return ConverterCache[t];

            TypeConverter c = TypeDescriptor.GetConverter(t);
            if (c == null || !c.CanConvertFrom(typeof(string)))
                throw new Exception($"Cannot convert {t.FullName} from string");

            ConverterCache.TryAdd(t, c);

            Entrypoint.logger.Fine($"Found {t.Name} TypeConverter {c.GetType().Name}");

            return c;
        }

        public string HasInvocationProblem(string[] args, bool isOP, bool isPlayer)
        {
            if (Attr.OPOnly && !isOP)
                return "You must be an operator to use this command";
            if (Attr.PlayerOnly && !isPlayer)
                return "This command can only be performed in-game by a player";

            int required = Params.Count(p => !p.IsOptional);
            if (args.Length < required) return $"Expected at least {required} parameters";

            for (int i = 0; i < Params.Length && i < args.Length; i++)
            {
                TypeConverter c = GetTypeConverter(Params[i].ParameterType);

                if ((!Params[i].ParameterType.IsEnum || !Enum.GetNames(Params[i].ParameterType).Any(p => string.Equals(p, args[i], StringComparison.OrdinalIgnoreCase))) && !c.IsValid(args[i]))
                    return $"Expected parameter {i + 1}, {Params[i].Name}, to be a {Params[i].ParameterType.Name}";
            }

            return null;
        }

        public object[] PrepareArgs(string[] args)
        {
            int required = Params.Count(p => !p.IsOptional);
            if (args.Length < required) return null;

            List<object> rargs = new List<object>();

            for (int i = 0; i < Params.Length; i++)
            {
                if (i >= args.Length)
                {
                    if (Params[i].HasDefaultValue)
                        rargs.Add(Params[i].DefaultValue);
                    else
                        break;
                }
                else
                {
                    TypeConverter c = GetTypeConverter(Params[i].ParameterType);

                    rargs.Add(c.ConvertFromString(args[i]));
                }
            }

            return rargs.ToArray();
        }
    }
}
