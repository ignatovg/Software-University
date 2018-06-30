using System;
using System.Reflection;
using System.Text;

public class HarvestReflection
{
    public string SortFields(string className, string command)
    {
        Type type = Type.GetType(className);

        StringBuilder sb = new StringBuilder();

        switch (command)
        {
            case "private":

                FieldInfo[] privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                foreach (FieldInfo fieldInfo in privateFields)
                {
                    if (fieldInfo.IsPrivate)
                        sb.AppendLine($"private {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;

            case "public":
                FieldInfo[] publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

                foreach (FieldInfo fieldInfo in publicFields)
                {
                    if (fieldInfo.IsPublic)
                        sb.AppendLine($"public {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
                break;

            case "protected":
                FieldInfo[] protectedFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                foreach (FieldInfo fieldInfo in protectedFields)
                {
                    if (fieldInfo.IsFamily)
                        sb.AppendLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
                break;

            case "all":
                FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                string mofifier = "";

                foreach (FieldInfo fieldInfo in allFields)
                {
                    if (fieldInfo.IsPrivate)
                        mofifier = "private";

                    if (fieldInfo.IsPublic)
                        mofifier = "public";

                    if (fieldInfo.IsFamily)
                        mofifier = "protected";

                    sb.AppendLine($"{mofifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }

                break;
        }
        return sb.ToString().Trim();
    }

}

