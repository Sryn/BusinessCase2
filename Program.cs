using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
namespace BusinessCase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Business Case 2 - Data Migration C# Program\n");

            bool booOldCodeNotOK = true, booOldCodeAllNumbers = true;
            int i = 0 ;
            string strOldCode = "";

            // get old postcode
            do
            {
                try
                {
                    strOldCode = "";

                    Console.Write("Please type in the old 4-digit postcode: ");
                    strOldCode = strOldCode + Convert.ToString(Console.ReadLine());

                    booOldCodeAllNumbers = true; i = 0;

                    while((i < strOldCode.Length) && booOldCodeAllNumbers)
                    {
                        switch (strOldCode[i])
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9': booOldCodeAllNumbers = true; break;
                            default: booOldCodeAllNumbers = false; break;
                        }

                        i++;
                    }

                    if ((strOldCode.Length == 4) && booOldCodeAllNumbers)
                        booOldCodeNotOK = false;
                    else
                        booOldCodeNotOK = true;
                }
                catch
                {
                    booOldCodeNotOK = true;
                }
            } while (booOldCodeNotOK);
            // end get old postcode

            bool booBlockNotOK = true, booBlockFormatOK = true;
            string strBlock = "";

            string strTemp = "";

            // get block number
            do
            {
                try
                {
                    strBlock = "";

//                    Console.Write("Please type in the old 4-digit postcode: ");
//                    strOldCode = strOldCode + Convert.ToString(Console.ReadLine());

                    Console.Write("Please type in the block number (including the alphabet following it): ");
                    strBlock = Convert.ToString(Console.ReadLine());

                    strBlock.ToUpper();

                    i = 0;

                    if ((strBlock.Length > 4) || (strBlock.Length == 0))
                        booBlockFormatOK = false;
                    else
                        booBlockFormatOK = true; 

                    while ((i < strBlock.Length) && booBlockFormatOK)
                    {
                        if (i < strBlock.Length - 1)
                        { // case for i not the last strBlock character
                            switch (strBlock[i])
                            {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9': booBlockFormatOK = true; break;
                                default: booBlockFormatOK = false; break;
                            }
                        }
                        else if(i == 3)
                        { // case if strBlock is of length 4 then surely the 4th character must be of A-H

                            strTemp = "";
                            strTemp = strTemp + Convert.ToChar(strBlock[i]);
                            strTemp = String.Format(strTemp).ToUpper();

                            switch (strTemp)
                            {
                                case "A":
                                case "B":
                                case "C":
                                case "D":
                                case "E":
                                case "F":
                                case "G":
                                case "H": booBlockFormatOK = true; break;
                                default: booBlockFormatOK = false; break;
                            }
                        }
                        else
                        { // case for not the last letter nor if strBlock is of length 4

                            strTemp = "";
                            strTemp = strTemp + Convert.ToChar(strBlock[i]);
                            strTemp = String.Format(strTemp).ToUpper();

                            switch (strTemp)
                            {
                                case "0":
                                case "1":
                                case "2":
                                case "3":
                                case "4":
                                case "5":
                                case "6":
                                case "7":
                                case "8":
                                case "9":
                                case "A":
                                case "B":
                                case "C":
                                case "D":
                                case "E":
                                case "F":
                                case "G":
                                case "H": booBlockFormatOK = true; break;
                                default: booBlockFormatOK = false; break;
                            }
                        }

                        i++;
                    }

                    if ((strBlock.Length <= 4) && booBlockFormatOK)
                        booBlockNotOK = false;
                    else
                        booBlockNotOK = true;
                }
                catch
                {
                    booBlockNotOK = true;
                }
            } while (booBlockNotOK);
            // end get block number

            string strNewCode = Convert.ToString(strOldCode[2]) + Convert.ToString(strOldCode[3]);

//            Console.WriteLine("First two digits of the new code are {0}", strNewCode);

            string strLastBlockChar;

            if (strBlock.Length > 0)
                strLastBlockChar = strBlock[strBlock.Length - 1].ToString();
            else
                strLastBlockChar = "";

//            Console.WriteLine("Last digit of the block number is {0}", strLastBlockChar);

            bool booAllNumbersBlock = false;
            char chrThirdNewDigit = '0';

            strLastBlockChar = String.Format(strLastBlockChar).ToUpper();

            switch (strLastBlockChar)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9": booAllNumbersBlock = true; break;
                case "A": chrThirdNewDigit = '1'; break;
                case "B": chrThirdNewDigit = '2'; break;
                case "C": chrThirdNewDigit = '3'; break;
                case "D": chrThirdNewDigit = '4'; break;
                case "E": chrThirdNewDigit = '5'; break;
                case "F": chrThirdNewDigit = '6'; break;
                case "G": chrThirdNewDigit = '7'; break;
                case "H": chrThirdNewDigit = '8'; break;
                default: break;
            }

            strNewCode = strNewCode + Convert.ToString(chrThirdNewDigit);

//            Console.WriteLine("First three digits of the new code are {0}", strNewCode);

            string strLastNewThreeDigits = "";

            if (booAllNumbersBlock)
            {
                /**/
                switch (strBlock.Length)
                {
                    case 1: strLastNewThreeDigits = "0" + "0" + strBlock[0].ToString(); break;
                    case 2: strLastNewThreeDigits = "0" + strBlock[0].ToString() + strBlock[1].ToString(); break;
                    case 3: strLastNewThreeDigits = strBlock[0].ToString() + strBlock[1].ToString() + strBlock[2].ToString(); break;
                    default: strLastNewThreeDigits = "000"; break;
                } // max three numbers
                 /**/


            }
            else
            {
                /**/
                switch (strBlock.Length)
                {
                    case 1: strLastNewThreeDigits = "000"; break;
                    case 2: strLastNewThreeDigits = "0" + "0" + strBlock[0].ToString(); break;
                    case 3: strLastNewThreeDigits = "0" + strBlock[0].ToString() + strBlock[1].ToString(); break;
                    case 4: strLastNewThreeDigits = strBlock[0].ToString() + strBlock[1].ToString() + strBlock[2].ToString(); break;
                    default: strLastNewThreeDigits = "000"; break;
                } // max three numbers + 1 letter
                 /**/
            }

            strNewCode = strNewCode + strLastNewThreeDigits;

            Console.WriteLine("\nThe whole 6-digits new code are {0}\n", strNewCode);

        }
    }
}
