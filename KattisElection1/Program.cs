using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var namelist = new List<string>();

            //Creates 2 lists for storing the candidate name and party list
            var partylist = new List<string>();

            //Creates a dictionary to store each candidate with the vote counnt
            var votes = new Dictionary<string, int>();

            //Asks for the number of candidates
            int n = int.Parse(Console.ReadLine());

            int max = 0;

            for (int i = 0; i < n; i++)
            {
                namelist.Add(Console.ReadLine());

                //Adds name and party to their respective lists
                partylist.Add(Console.ReadLine());
            }

            //Asks for the number of votes
            int m = int.Parse(Console.ReadLine());
            for (int j = 0; j < m; j++)
            {
                //Vote input
                String name = Console.ReadLine();
                if (namelist.Contains(name))
                {
                    if (!votes.ContainsKey(name))
                    {
                        //Adds the voted name to the dictionnary with a value of 1
                        votes[name] = 1;
                        //Console.WriteLine(votes[name]);
                    }
                    else
                    {

                        //Increases vote count for name by 1
                        votes[name] += 1;
                        //Console.WriteLine(votes[name]);
                    }
                }
            }
            //This loop goes through the dictionnary and check if 2 candidates have the highest vote count
            foreach (KeyValuePair<string, int> vote in votes)
            {
                if (vote.Value.Equals(votes.Values.Max()))
                {
                    max += 1;
                    if (max == 2)
                    {
                        //If 2 or more candidates have the maximum vote count, It's a tie and the program exits 
                        Console.WriteLine("tie");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
            }

            if (votes.Count == 0)
            { //no candidates got any votes, so it's automatically a tie.
                Console.WriteLine("tie");
            }
            else
            {
                //Looks up the name of the candidate with the highest vote count
                string winner = votes.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; // <-- only works properly if votes.Count is not 0.

                //Since the index of the candidate in the list is the same as the index of the party of the candidate, we can use the index to get the party name from the list
                Console.WriteLine(partylist[namelist.IndexOf(winner)]);
                Console.ReadLine();
            }
        }
    }
}