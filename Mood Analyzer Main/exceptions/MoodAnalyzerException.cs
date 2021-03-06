﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer_Main.exceptions
{
    public class MoodAnalyzerException : Exception
    {
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, CLASS_NOT_FOUND_EXCEPTION, METHOD_NOT_FOUND_EXCEPTION, FIELD_NOT_FOUND_EXCEPTION
        }
        public ExceptionType type;
        public MoodAnalyzerException(String message, ExceptionType type) : base(message)
        {            
            this.type = type;
        }
    }
}
