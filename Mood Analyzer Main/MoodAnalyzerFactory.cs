using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Mood_Analyzer_Main;
using Mood_Analyzer_Main.exceptions;
using System.Security;
using System.Dynamic;

namespace Mood_Analyzer_Main
{
    public class MoodAnalyzerFactory
    {
        //To create Object of MoodAnalyzer default constructor
        public static MoodAnalyzer CreateMoodAnalyzer()
        {
            Type type = typeof(MoodAnalyzer);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object myObj = Activator.CreateInstance(type);
            return (MoodAnalyzer)myObj;
        }

        //To throw the exception if class name or method name is invalid
        public static void CreateMoodAnalyzer(String classname, int parameter)
        {
            bool checkValidClass = IsValidClassname(classname);
            bool checkValidConstr = IsValidConstructor(parameter);
            if (!checkValidClass)
            {
                throw new MoodAnalyzerException("Class name not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
            }
            else if (checkValidConstr)
            {
                throw new MoodAnalyzerException("Method name not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);

            }
        }

        public static object CreateMoodAnalyzer(ConstructorInfo constructor, String classname, String message)
        {
            Type type = typeof(MoodAnalyzer);
            object constrObject = Activator.CreateInstance(type, message);
            return constrObject;
        }

        //To check the validity of class name 
        public static bool IsValidClassname(String classname)
        {
            if (classname.Equals("MoodAnalyzer"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To check the validity of constuctor name 
        public static bool IsValidConstructor(int constructor)
        {
            if (constructor.Equals((int)constructor))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static ConstructorInfo CreateParamConstructor(int parameters)
        {
            Type type = typeof(MoodAnalyzer);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo info in constructorInfo)
            {
                if (info.GetParameters().Length == parameters)
                {
                    return info;
                }
            }
            return constructorInfo[0];
        }

        public static void CreateMoodAnalyzerClass(ConstructorInfo constructorInfo, string className, int message)
        {
            bool checkValidClass = IsValidClassname(className);
            bool checkValidConstr = IsValidConstructor(message);

            if (!checkValidClass)
            {
                throw new MoodAnalyzerException("Class name not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
            }
            else if (checkValidConstr)
            {
                throw new MoodAnalyzerException("Method name not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);
            }
        }

        public static object CreateMoodAnalyzerInvoke(ConstructorInfo constructorInfo, String methodName)
        {
            Type type = typeof(MoodAnalyzer);
            object stringConstr = constructorInfo.Invoke(new object[] { "I am in a happy mood" });
            if (methodName.Equals("AnalyzeMoodInvoke"))
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mainObj = methodInfo.Invoke(stringConstr, new object[] { "I am in happy mood" });
                return mainObj;
            }
            else
            {
                throw new MoodAnalyzerException("Method name not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);

            }
        }

        

        public static object SetField(ConstructorInfo constructorInfo, string fieldName, string methodName, string fieldValue)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);
                object stringConstr = constructorInfo.Invoke(new object[] { fieldValue });
                if (fieldName.Equals("message"))
                {
                    MethodInfo methodInfo = type.GetMethod(methodName);
                    object mainObj = methodInfo.Invoke(stringConstr, new object[] { fieldValue });
                    return mainObj;
                }
                else
                {
                    throw new MoodAnalyzerException("Field Name not found", MoodAnalyzerException.ExceptionType.FIELD_NOT_FOUND_EXCEPTION);

                }
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyzerException("Please enter valid messege", MoodAnalyzerException.ExceptionType.NULL_EXCEPTION);
            }



        }
    }
}