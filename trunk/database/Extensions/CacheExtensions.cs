using System;
using System.Web;
using System.Web.Caching;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace Database.Extensions
{
    public static class CacheExtensions
    {
        static CacheExtensions()
        {
            try
            {
                MemcachedClient client = new MemcachedClient();
                var res = client.Cas(StoreMode.Set, "CacheExtensions", true);
                m_UseMemcached = client.Get<bool>("CacheExtensions");
                m_Client = client;
            }
            catch(System.Exception)
            {
                m_UseMemcached = false;
            }
            
        }

        private static T _Get<T>(string _key, params string[] _depKey) where T : class 
        {
            var cache = HttpRuntime.Cache;
            if (m_UseMemcached)
            {
                if (_depKey != null)
                {
                    for (int i = 0; i < _depKey.Length; ++i)
                    {
                        var dv = m_Client.GetWithCas(_depKey[i]);
                        var v = m_Client.GetWithCas<ulong>(String.Format("{0}/{1}", _key, i));
                        if (dv.Result == null || (dv.Cas != v.Result))
                        {
                            return null;
                        }
                    }
                }
            }
            else
            {
                // if memcached is off, don't use cache
                return null;
            }
            return cache[_key] as T;

        }

        private static void _Set<T>(string _key, T _value, params string[] _depKey)
        {
            var cache = HttpRuntime.Cache;
            if(m_UseMemcached)
            {
                if(_depKey != null)
                {
                    for(int i = 0; i < _depKey.Length; ++i)
                    {
                        m_Client.Store(StoreMode.Add, _depKey[i], DateTime.Now);
                        var v = m_Client.GetWithCas(_depKey[i]).Cas;
                        var dk = String.Format("{0}/{1}", _key, i);
                        var r = m_Client.Cas(StoreMode.Set, dk, v );
                        //var t = m_Client.GetWithCas(dk);
                    }
                }
                cache.Insert(_key, _value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                cache.Insert(_key, _value, new CacheDependency(new string[] { }, _depKey ), System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
        }


        public static bool m_UseMemcached = false;
        private static MemcachedClient m_Client = null;

        public static void ResetDep<O>(this O _operator, Type _type)
        {
            var depKey = _type.Name + "%" + "dep";
            if( m_UseMemcached )
            {
                m_Client.Store(StoreMode.Set, depKey, DateTime.Now);
            }
            else
            {
                var cache = HttpRuntime.Cache;
                cache[depKey] = DateTime.Now;
            }
        }

        public static void ResetDepDb<O>(this O _operator, Type _type)
        {
            var depKey = _type.Name + "Object%" + "dep";
            if (m_UseMemcached)
            {
                m_Client.Store(StoreMode.Set, depKey, DateTime.Now);
            }
            else
            {
                var cache = HttpRuntime.Cache;
                cache[depKey] = DateTime.Now;
            }
        }

        public static void EnsureDep<O>(this O _operator, Type _type)
        {
            var depKey = _type.Name + "%" + "dep";
            if (m_UseMemcached)
            {
                m_Client.Store(StoreMode.Add, depKey, DateTime.Now);
            }
            else
            {
                var cache = HttpRuntime.Cache;
                if(cache[depKey] == null)
                cache[depKey] = DateTime.Now;
            }
        }


        public static T GetOrStore<T, O>(this O _operator, string _key, Type _dependency, Func<T> generator, params object[] _params) where T : class 
        {
            var keyName = _operator.GetType().Name + "%" + _key + "%" + String.Join("|", _params);
            var depKey = _dependency.Name + "%" + "dep";
            var result = _Get<T>(keyName, depKey);
            if (result == null)
            {
                result = generator();
                EnsureDep(_operator, _dependency);
                _Set(keyName, result, depKey);
            }
            return (T)result;
        }

    }
}