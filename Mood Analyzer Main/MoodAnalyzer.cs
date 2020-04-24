using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer_Main
{
    public class MoodAnalyzer
    {
        public String analyzeMood(string message)
        {
            if (message.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }
    }
}
