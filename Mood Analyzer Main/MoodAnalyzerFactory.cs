using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Mood_Analyzer_Main;
using Mood_Analyzer_Main.exceptions;
using System.Security;

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

        public static ConstructorInfo CreateMoodAnalyzerPar(int parameters)
        {
            Type type = typeof(MoodAnalyzer);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach(ConstructorInfo info in constructorInfo)
            {
                if(info.GetParameters().Length == parameters)
                {
                    return info;
                }
            }
            return constructorInfo[0];
        }

        public static void CreateMoodAnalyzerClass(ConstructorInfo constructorInfo, string className, string message)
        {
            bool checkValidClass = IsValidClassname(className);
            if (!checkValidClass)
            {
                throw new MoodAnalyzerException("Class name not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
            }
           
        }
    }
}