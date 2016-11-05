﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PnrAnalysis.Model
{
    /// <summary>
    /// 航段信息
    /// </summary>
    /// 
    [Serializable]
    public class LegInfo
    {
        private string _SerialNum = string.Empty;
        /// <summary>
        /// 序号
        /// </summary>
        public string SerialNum
        {
            get { return _SerialNum; }
            set { _SerialNum = value; }
        }
        private bool _IsShareFlight = false;

        /// <summary>
        /// 是否共享航班 true是 false 不是
        /// </summary>
        public bool IsShareFlight
        {
            get { return _IsShareFlight; }
            set { _IsShareFlight = value; }
        }


        private string _AirCodeFlightNum = string.Empty;

        /// <summary>
        /// 承运人与航班号 如:*CZ2584 CA9856
        /// </summary>
        public string AirCodeFlightNum
        {
            get { return _AirCodeFlightNum; }
            set { _AirCodeFlightNum = value; }
        }

        private string _AirCode = string.Empty;
        /// <summary>
        /// 航空公司二字码 二位 如:ZH
        /// </summary>
        public string AirCode
        {
            get { return _AirCode; }
            set { _AirCode = value; }
        }
        private string _FlightNum = string.Empty;
        /// <summary>
        /// 航班号 四位 如:5854
        /// </summary>
        public string FlightNum
        {
            get { return _FlightNum; }
            set { _FlightNum = value; }
        }

        private string _Seat = string.Empty;

        /// <summary>
        /// 舱位 Y
        /// </summary>
        public string Seat
        {
            get { return _Seat; }
            set { _Seat = value; }
        }

        private string _FlyDate = string.Empty;

        /// <summary>
        /// 起飞日期 TU19JUN
        /// </summary>
        public string FlyDate
        {
            get { return _FlyDate; }
            set { _FlyDate = value; }
        }


        private string _FlyDateE = string.Empty;

        /// <summary>
        /// 到达日期  如：2012-06-20
        /// </summary>
        public string FlyDateE
        {
            get { return _FlyDateE; }
            set { _FlyDateE = value; }
        }


        private string _FlyDate1 = string.Empty;
        /// <summary>
        /// 起飞日期 如：2012-06-19
        /// </summary>
        public string FlyDate1
        {
            get { return _FlyDate1; }
            set { _FlyDate1 = value; }
        }

        private string _CityDouble = string.Empty;

        /// <summary>
        /// 城市对 如:CTUHGH
        /// </summary>
        public string CityDouble
        {
            get { return _CityDouble; }
            set { _CityDouble = value; }
        }


        private string _FromCode = string.Empty;
        /// <summary>
        /// 出发城市三字码 CTU
        /// </summary>
        public string FromCode
        {
            get { return _FromCode; }
            set { _FromCode = value; }
        }

        private string _ToCode = string.Empty;
        /// <summary>
        /// 到达城市三字码 PEK
        /// </summary>
        public string ToCode
        {
            get { return _ToCode; }
            set { _ToCode = value; }
        }

        private string _PnrStatus = string.Empty;

        /// <summary>
        /// 编码状态 如:HK
        /// </summary>
        public string PnrStatus
        {
            get { return _PnrStatus; }
            set { _PnrStatus = value; }
        }
        private string _FlyStartTime = string.Empty;

        /// <summary>
        /// 起飞时间 0800
        /// </summary>
        public string FlyStartTime
        {
            get { return _FlyStartTime; }
            set { _FlyStartTime = value; }
        }
        private string _FlyEndTime = string.Empty;
        /// <summary>
        /// 到达时间 1100
        /// </summary>
        public string FlyEndTime
        {
            get { return _FlyEndTime; }
            set { _FlyEndTime = value; }
        }

        private string _IsAddOneDayEndTime = string.Empty;
        /// <summary>
        /// 到达时间是否添加一天 像这样的时间1100+1  值为1 否则为空
        /// </summary>
        public string IsAddOneDayEndTime
        {
            get { return _IsAddOneDayEndTime; }
            set { _IsAddOneDayEndTime = value; }
        }

        private string _ChildSeat = string.Empty;
        /// <summary>
        /// 子舱位 V1
        /// </summary>
        public string ChildSeat
        {
            get { return _ChildSeat; }
            set { _ChildSeat = value; }
        }

        private string _BigCode = string.Empty;

        /// <summary>
        /// 大编码
        /// </summary>
        public string BigCode
        {
            get { return _BigCode; }
            set { _BigCode = value; }
        }

        private string _E = string.Empty;

        /// <summary>
        /// 电子客票标识 E
        /// </summary>
        public string E
        {
            get { return _E; }
            set { _E = value; }
        }

        private string _FromCityT1 = string.Empty;

        /// <summary>
        /// 出发城市T1航站楼
        /// </summary>
        public string FromCityT1
        {
            get { return _FromCityT1; }
            set { _FromCityT1 = value; }
        }

        private string _ToCityT2 = string.Empty;
        /// <summary>
        /// 到达城市T2航站楼
        /// </summary>
        public string ToCityT2
        {
            get { return _ToCityT2; }
            set { _ToCityT2 = value; }
        }

    }
}
