using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            BreadthFirstSearch bfs = new BreadthFirstSearch(users);

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Random random = new Random();

            UserNode user1 = users[random.Next(0, users.Count)];
            UserNode user2 = users[random.Next(0, users.Count)];

            Console.WriteLine($"Distance between {user1} and {user2} is: {bfs.GetDistance(user1, user2)}");

            Console.WriteLine($"Friends of {user1} with distance 2 are:");
            foreach (var friend in bfs.GetFriendsOfFriends(user1, 2)) {
                Console.WriteLine(friend);
            }


            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
