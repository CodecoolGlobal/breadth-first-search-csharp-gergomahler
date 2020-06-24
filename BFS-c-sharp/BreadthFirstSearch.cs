using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    class BreadthFirstSearch
    {
        private readonly List<UserNode> _userGraph;

        public BreadthFirstSearch(List<UserNode> userGraph)
        {
            _userGraph = userGraph;
        }

        public int GetDistance(UserNode userFrom, UserNode userTo)
        {
            Queue<KeyValuePair<UserNode, int>> usersToVisit = new Queue<KeyValuePair<UserNode, int>>();
            List<UserNode> visited = new List<UserNode>();

            usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(userFrom, 0));

            while (usersToVisit.Count != 0)
            {
                KeyValuePair<UserNode, int> user = usersToVisit.Dequeue();
                visited.Add(user.Key);
                foreach (UserNode friend in user.Key.Friends)
                {
                    if (friend.Id.Equals(userTo.Id))
                    {
                        return user.Value + 1;
                    }
                    usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(friend, user.Value + 1));
                }
            }
            return 0;
        }

        public List<UserNode> GetFriendsOfFriends(UserNode user, int distance)
        {
            List<UserNode> visited = new List<UserNode>();
            Queue<KeyValuePair<UserNode, int>> usersToVisit = new Queue<KeyValuePair<UserNode, int>>();

            usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(user, 0));

            while (usersToVisit.Count != 0)
            {
                KeyValuePair<UserNode, int> currentUser = usersToVisit.Dequeue();

                if (currentUser.Value > distance)
                {
                    break;
                }

                visited.Add(currentUser.Key);

                foreach (UserNode friend in currentUser.Key.Friends)
                {
                    if (visited.Contains(friend) || usersToVisit.Select(u => u.Key).Contains(friend)) continue;
                    usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(friend, currentUser.Value + 1));
                }
            }
            return visited.Where(u => !u.Equals(user)).ToList();
        }
    }
}
