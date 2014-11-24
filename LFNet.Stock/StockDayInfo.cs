using System;

namespace LFNet.Stock
{
    /// <summary>
    /// 股票日线数据
    /// </summary>
    public class StockDayInfo
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Amount { get; set; }
        public int Vol { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}