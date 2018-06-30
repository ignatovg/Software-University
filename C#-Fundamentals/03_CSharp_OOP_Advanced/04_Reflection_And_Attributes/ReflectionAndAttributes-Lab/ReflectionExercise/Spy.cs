using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classPublicMethods =
            classType.GetMethods(BindingFlags.Instance |  BindingFlags.Public);

        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo methodInfo in classPrivateMethods.Where(m=> m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }
        foreach (MethodInfo methodInfo in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo info in methodInfos)
        {
                sb.AppendLine(info.Name);
        }
        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type =Type.GetType(className);

        MethodInfo[] classMethodInfos =
            type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo methodInfo in classMethodInfos.Where(n=>n.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
        }

        foreach (MethodInfo methodInfo in classMethodInfos.Where(n => n.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}