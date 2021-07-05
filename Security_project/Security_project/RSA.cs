using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_project
{
    public class RSA
    {
        public string Encrypt(int p, int q, int e, int m)
        {

            int n = p * q;

            int phiN = (p - 1) * (q - 1);

            int d = 0;
            int repetition = 0;

            int r = phiN;

            int a = phiN;
            int b = e;

            /* while(r!=1)
             {
                 r = modlues(a, b, out repetition) ;
                 a = b;
                 b = r;
                 d += repetition;
             }*/

            d = modInverse(e, phiN);

            Console.WriteLine("D: " + d);

            List<int> binaryValues = BinaryValue(e);

            int squareValue = 1;
            int x = 0;
            int v = 0;

            for(int i=0;i<binaryValues.Count;i++)
            {
                if(i==0&& binaryValues[i] == 0)
                {
                    squareValue = 0;
                }

                if(binaryValues[i]==1)
                {
                    v = (squareValue * squareValue);

                    v = modlues(v, n, out x);

                    v *= m;

                    v = modlues(v, n, out x); ;

                    squareValue = v;

                    Console.WriteLine("BT: " + i + " = " + squareValue);
                }
                else
                {
                    v = (squareValue * squareValue);

                    v = modlues(v, n, out x);

                    squareValue = v;

                    Console.WriteLine("BT: " + i + " = " + squareValue);
                }
            }

            Console.WriteLine("Cipher= " + squareValue);

            return "RSA Cipher = " + squareValue.ToString();
        }

        public string Decryption(int p, int q, int e, int c)
        {
            int n = p * q;

            int phiN = (p - 1) * (q - 1);

            int d = 0;
            int repetition = 0;

            int r = phiN;

            int a = phiN;
            int b = e;

            /*while (r != 1)
            {
                r = modlues(a, b, out repetition);
                a = b;
                b = r;
                d += repetition;
            }*/

            d = modInverse(e, phiN);

            Console.WriteLine("D: " + d);

            List<int> binaryValues = BinaryValue(d);

            int squareValue = 1;
            int x = 0;
            int v = 0;

            for (int i = 0; i < binaryValues.Count; i++)
            {
                if (i == 0 && binaryValues[i] == 0)
                {
                    squareValue = 0;
                }

                if (binaryValues[i] == 1)
                {
                    v = (squareValue * squareValue);

                    v = modlues(v, n, out x);

                    v *= c;

                    v = modlues(v, n, out x); ;

                    squareValue = v;

                    Console.WriteLine("BT: " + i + " = " + squareValue);
                }
                else
                {
                    v = (squareValue * squareValue);

                    v = modlues(v, n, out x);

                    squareValue = v;

                    Console.WriteLine("BT: " + i + " = " + squareValue);
                }
            }

            Console.WriteLine("Original = " + squareValue);

            return "RSA Original Text = " + squareValue.ToString();
        }

        public int modInverse(int a, int m)
        {

            for (int x = 1; x < m; x++)
                if (((a % m) * (x % m)) % m == 1)
                    return x;
            return 1;
        }


        public int modlues(int a, int b, out int repeat)
        {
            int v = (a / b);
            repeat = v;
            v = (v * b);
            v = (a - v);

            Console.WriteLine("Modules result: " + a.ToString() + " mod " + b.ToString() + " = " + v);
            return v;
        }

        public List<int> BinaryValue(int v)
        {
            string binary = Convert.ToString(v, 2);

            string debug = "";

            List<int> binaryValues = new List<int>();

            for(int i=0;i<binary.Length;i++)
            {
                if(i==0&&binary[i]=='1')
                {
                    binaryValues.Add(int.Parse(binary[i].ToString()));
                    debug += binary[i];
                }

                if(i!=0)
                {
                    binaryValues.Add(int.Parse(binary[i].ToString()));
                    debug += binary[i];
                }
            }

            Console.WriteLine("Input: "+v+" Binary value= " + binary+" ,fianl: "+debug);
            return binaryValues;
        }
    }
}
