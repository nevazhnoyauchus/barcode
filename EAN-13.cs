using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarCodeGenerator
{
    class EAN_13
    {
        /// <summary>
        /// Получает цифру контрольной суммы для расчета G строки кодировки
        /// </summary>
        /// <param name="contorlSummNumber"></param>
        /// <returns>G строку кодировки</returns>
        public static string GetG(int contorlSummNumber)
        {
            switch (contorlSummNumber)
            {
                case '0': return "LLLLLL";
                case '1': return "LLGLGG";
                case '2': return "LLGGLG";
                case '3': return "LLGGGL";
                case '4': return "LGLLGG";
                case '5': return "LGGLLG";
                case '6': return "LGGGLL";
                case '7': return "LGLGLG";
                case '8': return "LGLGGL";
                case '9': return "LGGLGL";
                default: return "LLLLLL";
            }
        }

        /// <summary>
        /// Расчитывает код цифры исходя из G или L позиции в коде
        /// </summary>
        /// <param name="LorGCode"></param>
        /// <param name="number"></param>
        /// <returns>Строку кодировки цифры</returns>
        public static string GetLeftCode(char LorGCode, char number)
        {
            switch (number)
            {
                case 'L': return GetLeftL(number);
                case 'G': return GetLeftG(number);
                default: return "0100111";
            }
        }

        /// <summary>
        /// Расчитывает код полученной цифры по G кодировке
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Строка кода цифры в G кодировке</returns>
        public static string GetLeftG(char number)
        {
            switch (number)
            {
                case '0': return "0100111";
                case '1': return "0110011";
                case '2': return "0011011";
                case '3': return "0100001";
                case '4': return "0011101";
                case '5': return "0111001";
                case '6': return "0000101";
                case '7': return "0010001";
                case '8': return "0001001";
                case '9': return "0010111";
                default: return "0100111";
            }
        }

        /// <summary>
        /// Расчитывает код полученной цифры по L кодировке
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Строка кода цифры в L кодировке</returns>
        public static string GetLeftL(char number)
        {
            switch (number)
            {
                case '0': return "0001101";
                case '1': return "0011001";
                case '2': return "0010011";
                case '3': return "0111101";
                case '4': return "0100011";
                case '5': return "0110001";
                case '6': return "0101111";
                case '7': return "0111011";
                case '8': return "0110111";
                case '9': return "0001011";
                default: return "0001101";
            }
        }

        /// <summary>
        /// Расчитывает код полученной цифры по R кодировке
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Строка кода цифры в L кодировке</returns>
        public static string GetRight(char s)
        {
            switch (s)
            {
                case '0': return "1110010";
                case '1': return "1100110";
                case '2': return "1101100";
                case '3': return "1000010";
                case '4': return "1011100";
                case '5': return "1001110";
                case '6': return "1010000";
                case '7': return "1000100";
                case '8': return "1001000";
                case '9': return "1110100";
                default: return "0001101";
            }
        }


    }
}
