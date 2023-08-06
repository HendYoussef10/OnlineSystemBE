using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Products
{
    public interface ICacheProductService
    {
        string GetData(string key);
        bool SetData(string key, string value);
        void RemoveData(string key);
    }
}
