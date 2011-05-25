using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Doorbell_Server
{
    class IOControl
    {

        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int address, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(int address);

        public static int PinOutput(int Port, int Pin, int Value)
        {
            string oldvalue = ToBinary(Input(Settings.GetLPTPortNumber(Port, false)));
            string newvalue = null;

            for (int i = oldvalue.Length; i <= 7; i++)
            {
                oldvalue = "0" + oldvalue;
            }

            for (int count = 0; count < 8; count++)
            {
                if (count == Pin - 1)
                {
                    newvalue = newvalue + Value;
                }
                else
                {
                    newvalue = newvalue + oldvalue[count];
                }
            }
            Output(Settings.GetLPTPortNumber(Port, false), ToDecimal(newvalue));
            return (0);
        }

        public static int SetAll(int Value)
        {
            Output(Settings.GetLPTPortNumber(1, false), Value);
            return (0);
        }

        public static string ToBinary(Int64 Decimal)
        {
            // Declare a few variables we're going to need
            Int64 BinaryHolder;
            char[] BinaryArray;
            string BinaryResult = "";

            while (Decimal > 0)
            {
                BinaryHolder = Decimal % 2;
                BinaryResult += BinaryHolder;
                Decimal = Decimal / 2;
            }
            // The algoritm gives us the binary number in reverse order (mirrored)
            // We store it in an array so that we can reverse it back to normal
            BinaryArray = BinaryResult.ToCharArray();
            Array.Reverse(BinaryArray);
            BinaryResult = new string(BinaryArray);

            return BinaryResult;
        }

        public static int ToDecimal(string bin)
        {
            long l = Convert.ToInt64(bin, 2);
            int i = (int)l;
            return i;
        }

        public static bool ToBool(int num)
        {
            if (num == 0)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        public static bool GetInputPinValue(int Port, int Pin)
        {
            string value = ToBinary(Input(Settings.GetLPTPortNumber(Port, true))).ToString();

            for (int i = value.Length; i <= 7; i++)
            {
                value = "0" + value;
            }

            if (value[Pin-1].ToString() == "1")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}