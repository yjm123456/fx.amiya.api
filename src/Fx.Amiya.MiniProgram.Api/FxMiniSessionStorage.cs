using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Fx.Amiya.MiniProgram.Api
{
    /// <summary>
    /// 小程序会话存储器
    /// </summary>
    public class FxMiniSessionStorage: IMiniSessionStorage
    {
        private readonly ConcurrentDictionary<string, FxWxMiniUserSession> storage = new ConcurrentDictionary<string, FxWxMiniUserSession>();
        private System.Timers.Timer timer;
        public FxMiniSessionStorage()
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
                    storage.TryRemove(item.Key, out FxWxMiniUserSession session);
                }
            }
        }


        public FxWxMiniUserSession GetSession(string key)
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

        public void SetSession(string key, FxWxMiniUserSession session)
        {
            storage.TryAdd(key, session);
        }
    }
}
