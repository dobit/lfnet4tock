using System.Collections.Generic;

namespace LFNet.Stock
{
    /// <summary>
    /// 股票信息获取
    /// </summary>
    public interface IStockInfoProvider
    {
        StockInfo GetStockInfoByName(string stockName);

        StockInfo GetStockInfoByCode(string stockCode);
        /// <summary>
        /// 获取全部股票信息
        /// </summary>
        /// <returns></returns>
        List<StockInfo> GetStockInfos();
    }
}