﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace PnrAnalysis
{
    /// <summary>   
    /// 拼音转化   
    /// </summary>   
    public class PinYingMange
    {
        /// <summary>
        /// 替换错的拼音
        /// </summary>
        /// <param name="strChar"></param>
        /// <returns></returns>
        public static string RepacePinyinChar(string strChar)
        {
            strChar = strChar.Replace("潇", "萧");
            return strChar;
        }
        #region 汉字转拼方法1
        /// <summary>汉字转拼音缩写</summary>   
        /// <param name="str">要转换的汉字字符串</param>   
        /// <returns>拼音缩写</returns>   
        public static string GetSpellString(string str)
        {
            if (IsEnglishCharacter(str))
                return str;
            string tempStr = "";

            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留              
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母        
                    tempStr += GetSpellChar(c.ToString());
                }
            }
            return tempStr;
        }


        /// <summary>   
        /// 判断是否字母   
        /// </summary>   
        /// <param name="str"></param>   
        /// <returns></returns>   
        private static bool IsEnglishCharacter(String str)
        {
            CharEnumerator ce = str.GetEnumerator();
            while (ce.MoveNext())
            {
                char c = ce.Current;
                if ((c <= 0x007A && c >= 0x0061) == false &&
                   (c <= 0x005A && c >= 0x0041) == false)
                    return false;
            }
            return true;
        }

        /// <summary>   
        /// 判断是否有汉字   
        /// </summary>   
        /// <param name="testString"></param>   
        /// <returns></returns>   
        public static bool HaveChineseCode(string testString)
        {
            if (Regex.IsMatch(testString, @"[\u4e00-\u9fa5]+"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //是否有汉字
        public static bool IsChina(string CString)
        {
            bool BoolValue = false;
            for (int i = 0; i < CString.Length; i++)
            {
                if (!(Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128))))
                {
                    BoolValue = true;
                    break;
                }
            }
            return BoolValue;
        }

        /// <summary>   
        /// 取单个字符的拼音声母   
        /// </summary>   
        /// <param name="c">要转换的单个汉字</param>   
        /// <returns>拼音声母</returns>   
        public static string GetSpellChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '0') * 256 + ((short)(array[1] - '0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }
        #endregion

        #region 汉字转拼方法2
        private static Hashtable _Phrase;
        /// <summary>   
        /// 设置或获取包含列外词组读音的键/值对的组合。   
        /// </summary>   
        public static Hashtable Phrase
        {
            get
            {
                if (_Phrase == null)
                {
                    _Phrase = new Hashtable();
                    _Phrase.Add("圳", "Zhen");
                    _Phrase.Add("什么", "ShenMe");
                    _Phrase.Add("晖", "Hui");
                    _Phrase.Add("孑", "Jie");
                    _Phrase.Add("韬", "TAO");
                }
                return _Phrase;
            }
            set { _Phrase = value; }
        }

        #region 定义编码
        private static int[] pyvalue = new int[]  
            {  
                -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032,  
                -20026, -20002, -19990, -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751,   
                -19746, -19741, -19739, -19728, -19725, -19715, -19540, -19531, -19525, -19515, -19500, -19484, -19479,  
                -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249, -19243, -19242, -19238, -19235,   
                -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996,  
                -18977, -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710,  
                -18697, -18696, -18526,  
                -18518, -18501, -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211,  
                -18201, -18184, -18183,  
                -18181, -18012, -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759,  
                -17752, -17733, -17730,  
                -17721, -17703, -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433,  
                -17427, -17417, -17202,  
                -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474,  
                -16470, -16465, -16459,  
                -16452, -16448, -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220,  
                -16216, -16212, -16205,  
                -16202, -16187, -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915,  
                -15903, -15889, -15878,  
                -15707, -15701, -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436,  
                -15435, -15419, -15416,  
                -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153,  
                -15150, -15149, -15144,  
                -15143, -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933,  
                -14930, -14929, -14928,  
                -14926, -14922, -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678,  
                -14674, -14670, -14668,  
                -14663, -14654, -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353,  
                -14345, -14170, -14159,  
                -14151, -14149, -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097,  
                -14094, -14092, -14090,  
                -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859,  
                -13847, -13831, -13658,  
                -13611, -13601, -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356,  
                -13343, -13340, -13329,  
                -13326, -13318, -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060,  
                -12888, -12875, -12871,  
                -12860, -12858, -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585,  
                -12556, -12359, -12346,  
                -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831,  
                -11798, -11781, -11604,  
                -11589, -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045,  
                -11041, -11038, -11024,  
                -11020, -11019, -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544,  
                -10533, -10519, -10331,  
                -10329, -10328, -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256,  
                -10254  
            };

        private static string[] pystr = new string[]  
            {  
                "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian",  
                "biao",  
                "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan"  
                , "chang", "chao", "che", "chen",  
                "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong"  
                , "cou", "cu", "cuan", "cui",  
                "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", "die", "ding",  
                "diu", "dong", "dou", "du", "duan",  
                "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", "fei", "fen", "feng", "fo", "fou", "fu", "ga"  
                , "gai", "gan", "gang", "gao",  
                "ge", "gei", "gen", "geng", "gong", "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo",  
                "ha", "hai", "han", "hang",  
                "hao", "he", "hei", "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun",  
                "huo", "ji", "jia", "jian",  
                "jiang", "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan",  
                "kang", "kao", "ke", "ken",  
                "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan",  
                "lang", "lao", "le", "lei",  
                "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", "lv",  
                "luan", "lue", "lun", "luo",  
                "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", "miao", "mie", "min",  
                "ming", "miu", "mo", "mou", "mu",  
                "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", "neng", "ni", "nian", "niang", "niao", "nie",  
                "nin", "ning", "niu", "nong",  
                "nu", "nv", "nuan", "nue", "nuo", "o", "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng",  
                "pi", "pian", "piao", "pie",  
                "pin", "ping", "po", "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu",  
                "qu", "quan", "que", "qun",  
                "ran", "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa",  
                "sai", "san", "sang",  
                "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi",  
                "shou", "shu", "shua",  
                "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun",  
                "suo", "ta", "tai",  
                "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan",  
                "tui", "tun", "tuo",  
                "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao",  
                "xie", "xin", "xing",  
                "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", "ying", "yo",  
                "yong", "you",  
                "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", "zeng", "zha", "zhai"  
                , "zhan", "zhang",  
                "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", "zhuang",  
                "zhui", "zhun", "zhuo",  
                "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo"  
            };
        #endregion

        #region 获取汉字拼音
        /// <summary>   
        /// 获取汉字拼音   
        /// </summary>   
        /// <param name="chsstr">汉字字符串</param>   
        /// <returns>拼音</returns>   
        public static string GetSpellByChinese(string _chineseString)
        {
            string strRet = string.Empty;
            // 例外词组   
            foreach (DictionaryEntry de in Phrase)
            {
                _chineseString = _chineseString.Replace(de.Key.ToString(), de.Value.ToString());
            }
            char[] ArrChar = _chineseString.ToCharArray();
            foreach (char c in ArrChar)
            {
                strRet += GetSingleSpellByChinese(c.ToString());
            }
            return strRet;
        }
        #endregion

        #region 获取汉字拼音首字母
        /// <summary>   
        /// 获取汉字拼音首字母   
        /// </summary>   
        /// <param name="chsstr">指定汉字</param>   
        /// <returns>拼音首字母</returns>   
        public static string GetHeadSpellByChinese(string _chineseString)
        {
            string strRet = string.Empty;
            char[] ArrChar = _chineseString.ToCharArray();
            foreach (char c in ArrChar)
            {
                strRet += GetHeadSingleSpellByChinese(c.ToString());
            }
            return strRet;
        }
        #endregion

        #region 获取单个汉字拼音
        /// <summary>   
        /// 获取单个汉字拼音   
        /// </summary>   
        /// <param name="SingleChs">单个汉字</param>   
        /// <returns>拼音</returns>   
        private static string GetSingleSpellByChinese(string _singleChineseString)
        {
            byte[] array = Encoding.Default.GetBytes(_singleChineseString);
            int iAsc;
            string strRtn = string.Empty;
            try
            {
                iAsc = (short)(array[0]) * 256 + (short)(array[1]) - 65536;
            }
            catch
            {
                iAsc = 1;
            }

            if (iAsc > 0 && iAsc < 160)
                return _singleChineseString;

            for (int i = (pyvalue.Length - 1); i >= 0; i--)
            {
                if (pyvalue[i] <= iAsc)
                {
                    strRtn = pystr[i];
                    break;
                }
            }

            //将首字母转为大写   
            if (strRtn.Length > 1)
            {
                strRtn = strRtn.Substring(0, 1).ToUpper() + strRtn.Substring(1);
            }

            return strRtn;
        }
        #endregion

        #region 获取单个汉字的首字母
        /// <summary>   
        /// 获取单个汉字的首字母   
        /// </summary>   
        /// <returns></returns>   
        private static string GetHeadSingleSpellByChinese(string _singleChineseString)
        {
            // 例外词组   
            foreach (DictionaryEntry de in Phrase)
            {
                _singleChineseString = _singleChineseString.Replace(de.Key.ToString(), de.Value.ToString());
            }
            return GetSingleSpellByChinese(_singleChineseString).Substring(0, 1);
        }
        #endregion

        #region 获取汉字拼音(第一个汉字只有首字母)
        /// <summary>   
        /// 获取汉字拼音(第一个汉字只有首字母)   
        /// </summary>   
        /// <param name="_chineseString"></param>   
        /// <returns></returns>   
        public static string GetAbSpellByChinese(string _chineseString)
        {
            string strRet = string.Empty;
            // 例外词组   
            foreach (DictionaryEntry de in Phrase)
            {
                _chineseString = _chineseString.Replace(de.Key.ToString(), de.Value.ToString());
            }
            char[] ArrChar = _chineseString.ToCharArray();
            for (int i = 0; i < ArrChar.Length; i++)
            {
                if (i == 0)
                {
                    strRet += GetHeadSingleSpellByChinese(ArrChar[i].ToString());
                }
                else
                {
                    strRet += GetSingleSpellByChinese(ArrChar[i].ToString());
                }
            }
            return strRet;
        }
        #endregion
        #endregion
    }
}
