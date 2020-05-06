using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Mood_Analyzer_Main;
using Mood_Analyzer_Main.exceptions;

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
        
        //To throw the exception if class name is invalid
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

        /*public static void CreateMoodAnalyzer(string classname, String constructor)
        {
            bool checkValidConstr = IsValidConstructor(constructor);
            if (!checkValidConstr)
            {
                throw new MoodAnalyzerException("Method name not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);
            }

        }*/

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

       
    }
}