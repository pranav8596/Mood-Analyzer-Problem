using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer_Main.exceptions
{
    public class MoodAnalyzerException : Exception
    {
        public enum ExceptionType
        {
            NULL_EXCEPTION
        }
        public ExceptionType type;
        public MoodAnalyzerException(String message, ExceptionType type) : base(message)
        {            
            this.type = type;
        }
    }
}
