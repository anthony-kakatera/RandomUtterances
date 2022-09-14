namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //preload the adjectives textfile before aquiring the user input
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "Adjectives.txt");
            //get text
            string text = System.IO.File.ReadAllText(path);
            //get all adjectives
            string[] adjectives = text.Split(" ");

            var result = RandomUtterences.RandomUtterences.verifyHistory("Jake", 4, adjectives);
            //Testing to see if the randoml generated statement is saved by proving the exact name and number of adjectives
            Assert.That(result, Is.EqualTo("A clean,friendly,lively,cloudy Jake"));
        }

        //Testing random values
        [Test]
        public void Test2()
        {
            string[] adjectives = { "sad", "happy", "green" };
            //running test
            var result = RandomUtterences.RandomUtterences.randomUtterance( 2, adjectives);
            //performing test
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test3()
        {
            string[] adjectives = { "sad", "blue", "green", "joyous" };
            //running test
            var result = RandomUtterences.RandomUtterences.randomUtterance(3, adjectives);
            //performing test by looping through adjectives to see if they are in the string
            for (int i = 0; i < adjectives.Length; i++) {
                if (result.Contains(adjectives[i])) { Assert.Pass(); }
            }
            
        }
    }
}