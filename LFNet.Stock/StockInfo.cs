using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LFNet.Stock
{
    /// <summary>
    /// 股票信息
    /// </summary>
    public class StockInfo
    {
        /// <summary>
        /// 股票名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
    }


    public enum StockType
    {
        sz,
        sh,
        ds,
    }
}
