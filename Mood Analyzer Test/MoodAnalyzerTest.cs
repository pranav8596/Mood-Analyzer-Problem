using Mood_Analyzer_Main;
using Mood_Analyzer_Main.exceptions;
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
            string mood = moodAnalyzer.AnalyzeMood("I am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.AnalyzeMood("I am in any mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsSad_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in sad mood");
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in happy mood");
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsNull_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.NULL_EXCEPTION, e.type);
            }
        }

        [Test]
        public void givenMessageInConstructor_WhenEmpty_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer("");
                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, e.type);
            }
        }

        [Test]
        public void givenMoodAnalyserClass_WhenProper_ShouldReturnObject()
        {
            MoodAnalyzer moodAnalyzer = MoodAnalyzerFactory.CreateMoodAnalyzer();
            Assert.AreEqual(new MoodAnalyzer(), moodAnalyzer);
        }

        [Test]
        public void givenMoodAnalyserClass_WhenImProper_ShouldReturnClassNotFoundException()
        {
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION, e.type);

            }
        }
    }
}