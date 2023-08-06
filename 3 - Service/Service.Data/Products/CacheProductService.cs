using Microsoft.Extensions.Caching.Memory;
using Service.Interface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data.Products
{
    public class CacheProductService: ICacheProductService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheProductService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string GetData(string key)
        {
            try
            {
                string item = _memoryCache.Get(key)?.ToString();
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SetData(string key, string value)
        {
            bool res = true;
            TimeSpan expirationTime = TimeSpan.FromDays(1);

            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value, expirationTime);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }
        public void RemoveData(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Remove(key);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}

