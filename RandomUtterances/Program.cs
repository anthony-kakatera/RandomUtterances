using System.Security.Cryptography;

namespace RandomUtterences {
    public class RandomUtterences {

        public static void Main(String[] args) {
            //preload the adjectives textfile before aquiring the user input
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "Adjectives.txt");
            //get text
            string text = System.IO.File.ReadAllText(path);
            //get all adjectives
            string[] adjectives = text.Split(" ");

            //get user number of adjectives
            Console.WriteLine("Provide the noun");
            string noun = Console.ReadLine();

            //get user number of adjectives
            Console.WriteLine("Provide the number of adjectives");
            string tempValue = Console.ReadLine();

            //check if provided value is an actual number
            if (!int.TryParse(tempValue, out _))
            {
               //Notify user of the wrong input
               Console.WriteLine("The provided input isn't a number");
            }
            else {
                //parse to int for cycling through 
                int limiter = Int32.Parse(tempValue);
                //check if this entry has ran before
                string temp = verifyHistory(noun, limiter, adjectives);
                //return string
                Console.WriteLine(temp);
                Console.ReadLine();
            }                
        }

        public static string verifyHistory(string? noun, int limiter, string[] adjectives)
        {
            //return variable
            string statement = "";
            //history link
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "History.txt");
            //get all lines
            string[] lines = System.IO.File.ReadAllLines(path);
            //loop through lines
            for (int i = 0; i < lines.Length; i++) { 
                //split each line into words to verify name
                string[] words = lines[i].Split(' ');
                //verify by noun
                if (words[0].Equals(noun))
                {
                    //verify by adjective count
                    if (words[1].Equals(limiter.ToString()))
                    {
                        Console.WriteLine("we are in");
                        //loop through words from 2 to avoid name and adjective count (limiter)
                        string historyAdjectives = "";
                        for (int r = 2; r < words.Length; r++)
                        {
                            historyAdjectives = historyAdjectives + words[r];
                        }
                        statement = "A " + historyAdjectives + " " + noun;
                    }
                }
                else {
                    //print out and save to history
                    string combinedAdjectives = randomUtterance(limiter, adjectives);
                    //calling random utterance
                    statement = "A " + combinedAdjectives + " " + noun;
                    //write to history
                    writeToHistory(noun, limiter, combinedAdjectives);
                }
            }
            //incase history has no entry
            if (lines.Length == 0) {
                //print out and save to history
                string combinedAdjectives = randomUtterance(limiter, adjectives);
                //calling random utterance
                statement = "A " + combinedAdjectives + " " + noun;
                //write to history
                writeToHistory(noun, limiter, combinedAdjectives);
            }

            return statement;
        }

        public static string randomUtterance(int limiter, string [] adjectives) {
            //new array to hold new randomized adjectives
            string[] randomAdjective = new string[limiter];
            //array says to act as upperband for random generator
            int adjectiveCount = adjectives.Length - 1;
            //loop through with limiter as max number of loops
            for (int i = 0; i < limiter; i++) {
                //random adjective
                randomAdjective[i] = adjectives[RandomNumberGenerator.GetInt32(0, adjectiveCount)];
            }
            //merged the string
            return String.Join(" ,", randomAdjective);
        }

        public static void writeToHistory(string noun, int limiter, string adjectives) {
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "History.txt");
            string writter = noun + " " + limiter + " " + adjectives;
            //write to history by appending file
            File.AppendAllText(path, writter + Environment.NewLine);
        }

    }
}
