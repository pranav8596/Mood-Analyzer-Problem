using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Mood_Analyzer_Main;

namespace Mood_Analyzer_Main
{
    public class MoodAnalyzerFactory
    {
        public static MoodAnalyzer createMoodAnalyzer()
        {
            Type type = typeof(MoodAnalyzer);
            //Type type = Type.GetType("MoodAnalyzer");
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object myObj = Activator.CreateInstance(type);
            return (MoodAnalyzer) myObj;
        }
    }
}