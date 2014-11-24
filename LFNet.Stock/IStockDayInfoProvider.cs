using System;
using System.Collections.Generic;

namespace LFNet.Stock
{
    public interface IStockDayInfoProvider
    {
        /// <summary>
        /// 获取股票日线数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<StockDayInfo> GetStockDayInfos(StockInfo stockInfo, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取某天的股票数据
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        StockDayInfo GetStockDayInfo(StockInfo stockInfo, DateTime date);


    }
}