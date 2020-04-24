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

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("I am in any mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsSad_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in sad mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in happy mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsNull_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }
    }
}