﻿using Mood_Analyzer_Main.exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer_Main
{
    public class MoodAnalyzer
    {
        private String message;
        public MoodAnalyzer()
        {

        }

        public MoodAnalyzer(String message)
        {
            this.message = message;
        }

        public string analyzeMood()
        {
            return analyzeMood(message);
        }

        public String analyzeMood(string message)
        {
            try
            {
                if(message.Length == 0)
                {
                    throw new MoodAnalyzerException("Please enter valid message", MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION);
                }
                else if (message.Contains("sad"))
                {
                    return "sad";
                }
                else if (message.Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyzerException("Please enter valid messege", MoodAnalyzerException.ExceptionType.NULL_EXCEPTION);
            }
        }
    }
}
