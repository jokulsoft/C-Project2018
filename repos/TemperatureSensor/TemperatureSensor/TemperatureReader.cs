using System;

namespace TemperatureSensor
{
    public static class TemperatureReader
    {
        //温度数据
        public static byte[] TemperReciveByte = new byte[2];
        public static int TemperSetting = -1;
        /// <summary>
        /// 构造函数
        /// </summary>
        static TemperatureReader() { }


        /// <summary>
        /// 读取温度数据
        /// 参数(byte[])
        /// </summary>
        /// <param name="tem"></param>
        public static void ReadTemperData(byte[] tem)
        {
            TemperReciveByte = tem;
        }


        /// <summary>
        /// 处理温度数据
        /// </summary>
        /// <returns></returns>
        public static double DealTemperData()
        {
            double DecimalTemper = ((TemperReciveByte[1] << 8) | TemperReciveByte[0]) / 10.0;
            return DecimalTemper;
        }

        /// <summary>
        /// 设定温度数据
        /// </summary>
        /// <param name="temlit"></param>
        public static void SetTemperLimit(ref int temlit)
        {
            temlit = TemperSetting;
        }
    }
}
