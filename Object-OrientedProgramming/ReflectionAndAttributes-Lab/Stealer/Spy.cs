﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        private StringBuilder sb;
        private Type classType;

        public Spy()
        {
            sb = new StringBuilder();
            classType = Type.GetType("Hacker");
        }

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Public | BindingFlags.Instance |
                 BindingFlags.NonPublic | BindingFlags.Static);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classType}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods
                (BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MemberInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set firld of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
