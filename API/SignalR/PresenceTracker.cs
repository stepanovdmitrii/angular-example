using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private static readonly Dictionary<string, HashSet<string>> OnlineUsers
            = new Dictionary<string, HashSet<string>>();

        public Task<bool> UserConnected(string username, string connectionId){
            bool isOnline = false;
            lock(OnlineUsers){
                if(OnlineUsers.TryGetValue(username, out var connections)){
                    connections.Add(connectionId);
                }
                else{
                    OnlineUsers[username] = new HashSet<string>{connectionId};
                    isOnline = true;
                }
            }
            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(string username, string connectionId){
            bool isOffline = false;
            lock(OnlineUsers){
                if(OnlineUsers.TryGetValue(username, out var connections)){
                    connections.Remove(connectionId);
                    if(connections.Count == 0){
                        OnlineUsers.Remove(username);
                        isOffline = true;
                    }
                }
            }
            return Task.FromResult(isOffline);
        }

        public Task<string[]> GetOnlineUsers(){
            string[] onlineUsers;
            lock(OnlineUsers){
                onlineUsers = OnlineUsers.Keys.OrderBy(p => p).ToArray();
            }
            return Task.FromResult(onlineUsers);
        }

        public Task<List<string>> GetConnectionsForUser(string username){
            HashSet<string> connectionIds;
            lock(OnlineUsers){
                connectionIds = OnlineUsers.GetValueOrDefault(username);
            }

            return Task.FromResult(connectionIds.ToList());
        }
    }
}