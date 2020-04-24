using Mood_Analyzer_Main;
using NUnit.Framework;

namespace Mood_Analyzer_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenMessage_WhenContainsSad_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("I am in sad mood");
            Assert.AreEqual("sad", mood);
        }
    }
}