using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFNet.Stock.TDX.Properties;
namespace LFNet.Stock.TDX
{
    public class StockInfoProvider : IStockInfoProvider
    {
        /// <summary>
        /// 根据股票名称获取股票信息
        /// </summary>
        /// <param name="stockName"></param>
        /// <returns></returns>
        public StockInfo GetStockInfoByName(string stockName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public StockInfo GetStockInfoByCode(string stockCode)
        {
            throw new NotImplementedException();
        }


        public string func()
        {
             byte[] byData = new byte[250];//建立一个FileStream要用的字节组
            char[] charData = new char[32];
           
            FileStream aFile = new FileStream(Settings.Default.TDXInstallPath+@"\T0002\hq_cache\shex.tnf", FileMode.Open);
            aFile.Seek(50, SeekOrigin.Begin);//把文件指针指向，从文件开始位置向前55位字节所指的字节
            for (int i = 0; i < aFile.Length/250; i++)
            {
                aFile.Read(byData, 0, 250);//读取FileStream对象所指的文件到字节数组里

                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, 32, charData, 0);
                Console.WriteLine(charData);
                Console.ReadLine();
            }
            aFile.Close();
        }


        private static List<StockDayInfo> CollectCellFromTDX(StockInfo stockInfo)
        {

            string path = "";// string.Format("{2}\\Vipdoc\\{0}\\lday\\{0}{1}.day", stockInfo.Location.ToString(), CommonFunction.CodeToFull(stockInfo.Code), ConstData.TDXPath);
            if (!File.Exists(path))
            {
                return null;
            }
            FileStream fs = File.OpenRead(path);
            BinaryReader br = new BinaryReader(fs);
            int days = (int)fs.Length / 32;
            List<StockDayInfo> list = new List<StockDayInfo>();
            for (int i = 0; i < days; i++)
            {
                StockDayInfo item = new StockDayInfo();
                //item.DataDate =DateTime.Parse(new string(br.ReadChars(8)));
                int date = br.ReadInt32();
                int year = date / 10000;
                int month = int.Parse(date.ToString().Substring(4, 2));
                int day = int.Parse(date.ToString().Substring(6, 2));
                int open = br.ReadInt32();
                int high = br.ReadInt32();
                int low = br.ReadInt32();
                int close = br.ReadInt32();
                Single amount = br.ReadSingle();
                //Int32 amount = br.ReadInt32();
                decimal am = Convert.ToDecimal(amount);
                long amstr = Convert.ToInt64(amount);
                int vol = br.ReadInt32();
                int preclose = br.ReadInt32();

                //Decimal open = Convert.ToDecimal(br.ReadSingle());
                item.Date = new DateTime(year, month, day);
                item.Open = Convert.ToDecimal(open / 100m);
                item.High = Convert.ToDecimal(high / 100m);
                item.Low = Convert.ToDecimal(low / 100m);
                item.Close = Convert.ToDecimal(close / 100m);
                item.Amount = amstr;
                item.Vol = vol;
                item.Code = stockInfo.Code;
                item.Name = stockInfo.Name;
                list.Add(item);
            }
            br.Close();
            fs.Close();
            return list;
        }



        public List<StockInfo> GetStockInfos()
        {
            throw new NotImplementedException();
        }
    }

    public class StockDayInfoProvider : IStockDayInfoProvider
    {
        public List<StockDayInfo> GetStockDayInfos(StockInfo stockInfo, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public StockDayInfo GetStockDayInfo(StockInfo stockInfo, DateTime date)
        {
            throw new NotImplementedException();
        }

        public string GetStockDayFile(StockInfo stockInfo)
        {
            //C:\new_gjzq_v6\vipdoc\sz\lday\sz000001.day
            string file=string.Format(Settings.Default.TDXInstallPath+@"\vipdoc\{0}\1day\{1}.day",stockInfo.)
        }
    }


    //public static class TdxGlobals
    //{
    //    public static string StockInfoFile
    //    {
    //        get
    //        {
    //            return  Properties.Settings.Default.TDXInstallPath+@"\T0002\hq_cache\";
    //        }
    //    }


    //}
}
