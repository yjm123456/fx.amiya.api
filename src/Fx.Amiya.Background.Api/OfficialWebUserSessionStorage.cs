using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Fx.Amiya.Background.Api
{
    public class OfficialWebUserSessionStorage:IOffcialWebUserSessionStorage
    {
        private readonly ConcurrentDictionary<string, OffcialWebUserSession> storage = new ConcurrentDictionary<string, OffcialWebUserSession>();
        private System.Timers.Timer timer;
        public OfficialWebUserSessionStorage()
        {
            timer = new System.Timers.Timer(60 * 1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public int Count
        {
            get
            {
                return storage.Count;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            foreach (var item in storage.AsEnumerable())
            {
                if (item.Value.ExpireTime <= DateTime.Now)
                {
                    storage.TryRemove(item.Key, out OffcialWebUserSession session);
                }
            }
        }


        public OffcialWebUserSession GetSession(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;
            var session = storage.GetValueOrDefault(key, null);
            if (session != null)
            {
                if (session.ExpireTime.Subtract(new TimeSpan(1, 0, 0)) <= DateTime.Now)
                {
                    session.ExpireTime.AddDays(1);
                }
            }
            return session;
        }

        public void SetSession(string key, OffcialWebUserSession session)
        {
            storage.TryAdd(key, session);
        }
    }
}
