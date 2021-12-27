using System;
using System.Collections.Generic;
using System.Linq;
using ClevInvest.Models;
using ClevInvest.Services.Database;

namespace ClevInvest.Services
{
    public class SessionKeyStorage
    {

        private ApplicationContext _db;
        public SessionKeyStorage(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }
        
        private HashSet<string> keys = new HashSet<string>();
        private Dictionary<string, DateTime> keysExpireDates = new Dictionary<string, DateTime>();
        private Dictionary<string, int> keysOwnersIds = new Dictionary<string, int>();

        public void AddNewSession(string key, int userId)
        {
            keys.Add(key);
            keysExpireDates.Add(key, DateTime.Now.AddDays(1));
            keysOwnersIds.Add(key, userId);
        }

        public User GetUserByKey(string key)
        {
            if (keys.Contains(key) && keysExpireDates[key] > DateTime.Now)
            {
                var userId = keysOwnersIds[key];
                return _db.Users.FirstOrDefault(user => user.Id == userId);
            }

            return null;
        }
    }
}