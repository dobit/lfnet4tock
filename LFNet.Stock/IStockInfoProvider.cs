namespace LFNet.Stock
{
    /// <summary>
    /// 股票信息获取
    /// </summary>
    public interface IStockInfoProvider
    {
        StockInfo GetStockInfoByName(string stockName);

        StockInfo GetStockInfoByCode(string stockCode);
    }
}