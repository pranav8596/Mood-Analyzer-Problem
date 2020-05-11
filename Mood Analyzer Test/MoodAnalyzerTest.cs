using Microsoft.VisualBasic.CompilerServices;
using Mood_Analyzer_Main;
using Mood_Analyzer_Main.exceptions;
using NUnit.Framework;
using System.Reflection;

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

        //Default constructor
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
                MoodAnalyzerFactory.CreateMoodAnalyzer("Mood", 0);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION, e.type);

            }
        }

        [Test]
        public void givenMoodAnalyserConstructor_WhenImProper_ShouldReturnMethodNotFoundException()
        {
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer", 805);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION, e.type);
            }
        }

        //Parameterized constructor
        [Test]
        public void givenMoodAnalyserClass_WhenProperParamConstr_ShouldReturnObject()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            object mainObj = MoodAnalyzerFactory.CreateMoodAnalyzer(constructorInfo, "MoodAnalyzer", "I am in happy mood");
            Assert.AreEqual(new MoodAnalyzer("I am in happy mood"), mainObj);
        }

        [Test]
        public void givenMoodAnalyserClass_WhenImProperParamConstr_ShouldReturnClassNotFoundException()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzerClass(constructorInfo, "Mood", 0);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION, e.type);

            }
        }

        [Test]
        public void givenMoodAnalyserParamConstructor_WhenImProper_ShouldReturnMethodNotFoundException()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzerClass(constructorInfo, "MoodAnalyzer", 555);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION, e.type);
            }
        }

        [Test]
        public void givenHappyMessageUsingReflection_WhenProper_ShouldReturnHappyMood()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            object moodAnal = MoodAnalyzerFactory.CreateMoodAnalyzerInvoke(constructorInfo, "AnalyzeMoodInvoke");
            Assert.AreEqual("happy", moodAnal);
        }


        [Test]
        public void givenHappyMessageUsingReflection_WhenImProper_ShouldReturnMethodNotFoundException()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzerInvoke(constructorInfo, "AnalyzeMood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION, e.type);
            }
        }


        [Test]
        public void givenHappyMessageInFieldName_WhenProper_ShouldReturnHappyMood()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            object mood = MoodAnalyzerFactory.SetField(constructorInfo, "message", "AnalyzeMoodInvoke", "I am in a happy mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenHappyMessageInFieldName_WhenImProper_ShouldReturnFieldNotFoundException()
        {
            ConstructorInfo constructorInfo = MoodAnalyzerFactory.CreateParamConstructor(1);
            try
            {
                MoodAnalyzerFactory.SetField(constructorInfo, "mesage", "AnalyzeMoodInvoke", "I am in a happy mood");

            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.FIELD_NOT_FOUND_EXCEPTION, e.type);
            }
        }
    }
}