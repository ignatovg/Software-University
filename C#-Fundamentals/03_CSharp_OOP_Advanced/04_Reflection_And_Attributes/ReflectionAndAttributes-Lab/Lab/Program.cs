using System;
using System.Reflection;
using System.Text;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Type compileType = typeof(TestReflection);

            Type runtimeType = Type.GetType("Lab.TestReflection");

            Type testType = typeof(TestReflection);
            TestReflection testInstance = (TestReflection)Activator.CreateInstance(testType);
            FieldInfo field = testType.GetField("publicField");
            field.SetValue(testInstance,5);
            int fieldValue = (int)field.GetValue(testInstance);


        }
    }
}
