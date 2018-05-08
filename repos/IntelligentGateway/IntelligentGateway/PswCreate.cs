using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntelligentGateway
{
    static class PswCreate
    {
        
        /// <summary>
        /// 处理参数
        /// </summary>
        /// <param name="PswParameters"></param>
        /// <returns></returns>
        private static int[] DealPswParameters(string PswParameters)
        {
            //存储参数
            int[] ParamArray = new int[7];
            for (int i = 0; i < PswParameters.Length; i++)
            {
                ParamArray[i] = int.Parse(PswParameters.Substring(i, 1));
            }

            return ParamArray;
        }

        /// <summary>
        /// 按位取反
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static char ContraryPsw(char psw)
        {
            int Temporary = (char)~(psw);
            Temporary %= 94;
            Temporary += 33;
            return (char)Temporary;
        }

        /// <summary>
        /// 倒序密码
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static char ReversePsw(char psw)
        {
            int Temporary = 0;
            int PswTem = psw;
            PswTem -= 23;
            for (int i = 0; i < 7; i++)
            {
                Temporary *= 2;
                Temporary += PswTem % 2;
                PswTem /= 2;
            }
            Temporary %= 94;
            Temporary += 32;
            return (char)Temporary;
        }

        /// <summary>
        /// 奇数位异或
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static char OddNumberPsw(char psw)
        {
            int Temporary_a = psw;
            for(int i = 0; i<6; i+=2)
            {
                int Temporary = 1;
                Temporary <<= i;
                Temporary &= Temporary_a;
                Temporary <<= 2;
                Temporary_a ^= Temporary;
            }
            Temporary_a %= 94;
            Temporary_a += 32;


            return (char)Temporary_a;
        }

        /// <summary>
        /// 偶数位异或 
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static char EvenNumberpsw(char psw)
        {
            int Temporary_a = psw;
            for (int i = 1; i < 6; i += 2)
            {
                int Temporary = 1;
                Temporary <<= i;
                Temporary &= Temporary_a;
                Temporary <<= 2;
                Temporary_a ^= Temporary;
            }
            Temporary_a %= 94;
            Temporary_a += 33;


            return (char)Temporary_a;
        }

        public static char RotationPws(int Rot_as,int Rot_bs,int Rot_cs,char psw)
        {
            int Rot_a = Rot_as % 7;
            int Rot_b = Rot_bs % 7;
            int Rot_c = Rot_cs % 7;
            bool[] TemporaryBoolArray = new bool[7];
            int Temporary = psw;
            for(int i = 0 ; i<7; i++)
            {
                if(Temporary % 2 == 1)
                {
                    TemporaryBoolArray[i] = true;
                }
                else
                {
                    TemporaryBoolArray[i] = false;
                }
                Temporary /= 2;
            }
            bool ChangeTem = TemporaryBoolArray[Rot_a];
            TemporaryBoolArray[Rot_a] = TemporaryBoolArray[Rot_c];
            TemporaryBoolArray[Rot_c] = TemporaryBoolArray[Rot_b];
            TemporaryBoolArray[Rot_b] = ChangeTem;

            Temporary = 0;
            for(int i = 0; i<7; i++)
            {
                double Tem = 0;
                if (TemporaryBoolArray[i])
                {
                    Tem += Math.Pow(2, i);
                    Temporary += (int)Tem;
                }
            }
            Temporary %= 94;
            Temporary += 32;
            return (char)Temporary;



        }

        public static char[] SubStringPsw(char[] psw , int HKey , int OddOREvent)
        {
            int SubStartNum = 255 % HKey;
            if(OddOREvent%2 == 1)
            {
                while(SubStartNum+OddOREvent+1<255)
                {
                    OddOREvent += 1;
                    SubStartNum += OddOREvent;
                    for(int i = SubStartNum; i<254;i++)
                    {    
                        psw[i] = psw[i + 1];
                    }
                    psw[254] = (char)32;
                }
            }
            else
            {
                while (SubStartNum + OddOREvent + 1 < 255)
                {
                    OddOREvent += 2;
                    SubStartNum += OddOREvent;
                    for (int i = SubStartNum; i < 254; i++)
                    {
                        psw[i] = psw[i + 1];
                    }
                    psw[254] = (char)32;
                }
            }
            return psw;
        }


        public static string PswStringCreate(string OriginallyPsw, string PswParameters)
        {
            //生成密码
            string Psw = null;
            //生成参数数组
            int[] Param = DealPswParameters(PswParameters);
            //原密码数组
            char[] CharArray = new char[255];
      
            for(int i = 0; i<255;i++ )
            {
                CharArray[i] = char.Parse(OriginallyPsw.Substring(i, 1));
            }

            for (int item = 0; item < CharArray.Length; item++)
            {
                //按位取反
                if (Param[0] % 2 == 1)
                {
                    CharArray[item] = ContraryPsw(CharArray[item]);
                }
                //倒序
                else
                {
                    CharArray[item] = ReversePsw(CharArray[item]);

                }
                //奇偶位异或
                if(Param[1]%2 == 1)
                {
                    CharArray[item] = OddNumberPsw(CharArray[item]);
                }
                else
                {
                    CharArray[item] = EvenNumberpsw(CharArray[item]);
                }
                CharArray[item] = RotationPws(Param[2], Param[3], Param[4], CharArray[item]);
            }
            char[] Temper = SubStringPsw(CharArray, Param[5], Param[6]);
            for(int i = 0; Temper[i]!=32; i++)
            {
                Psw += Temper[i];
            }

            return Psw;
        }
    }
}
