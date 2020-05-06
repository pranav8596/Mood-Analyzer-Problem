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
        public static MoodAnalyzer CreateMoodAnalyzer()
        {
            Type type = typeof(MoodAnalyzer);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object myObj = Activator.CreateInstance(type);
            return (MoodAnalyzer) myObj;
        }

        public static void CreateMoodAnalyzer(string classname)
        {
            bool checkValid = IsValidClassname(classname);
            if (!checkValid)
            {
                throw new MoodAnalyzerException("Class name not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
            }

        }

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
    }
}