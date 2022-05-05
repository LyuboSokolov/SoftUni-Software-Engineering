using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public |
                                                          BindingFlags.Static | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var field in fields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in nonPublicMethods.Where(p => p.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(p => p.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: { type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance |
                                                   BindingFlags.Static | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var method in methods.Where(p => p.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(p => p.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
