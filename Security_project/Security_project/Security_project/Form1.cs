using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_project
{
    public partial class Form1 : Form
    {

        public void S_DES_Encryption()
        {
            char[] Key = new char[10];
            char[] plaintext = new char[10];
            Key = textBox1.Text.ToCharArray();
            plaintext = textBox2.Text.ToCharArray();
            int[] p10 = { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
            int[] temp2 = new int[10];
            int[] p8 = { 6, 3, 7, 4, 8, 5, 10, 9};
            int[] Ip = { 2, 6, 3, 1, 4, 8, 5, 7 };
            int[] Ip_Sol = new int[8];
            int[] Ep = { 4, 1, 2, 3, 2, 3, 4, 1 };
            int[] p4 = { 2, 4, 3, 1 };
            int[] inv_Ip = { 4, 1, 3, 5, 7, 2, 8, 6 };
            int[,] S0 = new int[,] { { 1, 0 ,3 ,2 }, { 3, 2, 1, 0 }, { 0, 2, 1, 3 },{ 3, 1, 3, 2 } };
            int[,] S1 = new int[,] { { 0, 1, 2, 3 }, { 2, 0, 1, 3 }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
            int[] k1=new int[8] ;
            int[] k2 = new int[8];
            int[] final_result = new int[8];
            int[] temp1 = { int.Parse(Key[0].ToString()), int.Parse(Key[1].ToString()), int.Parse(Key[2].ToString()), int.Parse(Key[3].ToString()), int.Parse(Key[4].ToString()), int.Parse(Key[5].ToString()), int.Parse(Key[6].ToString()), int.Parse(Key[7].ToString()), int.Parse(Key[8].ToString()), int.Parse(Key[9].ToString()) };
            int[] temp_enc = new int[4];
            string result=null;
            key1_gen();
            key2_gen();
            IP();
            
            
            encryption_round1();
            encryption_round2();
            Final_Permutation();


            void bin_to_dec(int m,int num)
            {
                if (m == 0 )
                {
                    temp_enc[num] = 0;
                    temp_enc[num+1] = 0;
                }
                if (m == 1 )
                {
                    temp_enc[num] = 0;
                    temp_enc[num + 1] = 1;
                }
                if (m == 2 )
                {
                    temp_enc[num] = 1;
                    temp_enc[num + 1] = 0;
                }
                if (m == 3 )
                {
                    temp_enc[num] = 1;
                    temp_enc[num + 1] = 1;
                }

            }
            void key1_gen()
            {
                for (int i = 0; i < 10; i++)
                {
                    temp2[i] = temp1[p10[i]-1];
                
                }
                
                int Shiftvalue = temp2[0];
                int Shiftvalue2 = temp2[5];
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (i != 4)
                        {
                            temp2[i] = temp2[i + 1];
                        }
                        else
                        {
                            temp2[i] = Shiftvalue;
                        }
                    }
                    else
                    {
                        if (i != 9)
                        {
                            temp2[i] = temp2[i + 1];
                        }
                        else
                        {
                            temp2[i] = Shiftvalue2;
                        }
                    }

                }
                for (int i = 0; i < 8; i++)
                {
                    k1[i] = temp2[p8[i] - 1];

                }
                int hamda = 0;
            }
            void key2_gen()
            {
                for (int i = 0; i < 10; i++)
                {
                    temp2[i] = temp1[p10[i] - 1];

                }

                int[] Shiftvalue = { temp2[0], temp2[1], temp2[2] };
                int []Shiftvalue2 = { temp2[5], temp2[6], temp2[7] }; ;
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (i == 0)
                        {
                            temp2[i] = temp2[3];

                        }
                        if (i == 1)
                        {
                            temp2[i] = temp2[4];
                        }
                        if (i != 0 && i != 1)
                        {
                            temp2[i] = Shiftvalue[i - 2];
                        }
                    }
                    else
                    {
                        if (i == 5)
                        {
                            temp2[i] = temp2[8];

                        }
                        if (i == 6)
                        {
                            temp2[i] = temp2[9];
                        }
                        if (i != 5 && i != 6)
                        {
                            temp2[i] = Shiftvalue2[i - 7];
                        }
                    }

                }
                for (int i = 0; i < 8; i++)
                {
                    k2[i] = temp2[p8[i] - 1];

                }
               
            }
            void IP()
            {
                for (int i = 0; i < 8; i++)
                {
                    Ip_Sol[i] = int.Parse(plaintext[Ip[i] - 1].ToString());

                }
            }
            void encryption_round1()
            {
                int[] right_IP = { Ip_Sol[4], Ip_Sol[5], Ip_Sol[6], Ip_Sol[7] };
                int[] Ep_sol = new int[8];
                
                double row1, row2, col1, col2;
                for (int i = 0; i < 8; i++)
                {
                    Ep_sol[i] = right_IP[Ep[i] - 1];

                }
                for (int i = 0; i < 8; i++)
                {
                    if (Ep_sol[i] == k1[i])
                    {
                        Ep_sol[i] = 0;
                    }
                    else
                    {
                        Ep_sol[i] = 1;
                    }

                }

                row1 = Ep_sol[3] * Math.Pow(2, 0) + Ep_sol[0] * Math.Pow(2, 1);
                col1 = Ep_sol[2] * Math.Pow(2, 0) + Ep_sol[1] * Math.Pow(2, 1);//56
                row2 = Ep_sol[7] * Math.Pow(2, 0) + Ep_sol[4] * Math.Pow(2, 1);
                col2 = Ep_sol[6] * Math.Pow(2, 0) + Ep_sol[5] * Math.Pow(2, 1);
                int t = S0[int.Parse(row1.ToString()), int.Parse(col1.ToString())];
                int t2 = S1[int.Parse(row2.ToString()), int.Parse(col2.ToString())];
                int[] temp_p4 = new int[4];
                bin_to_dec(t, 0);
                bin_to_dec(t2, 2);

                for (int i = 0; i < 4; i++)
                {
                    temp_p4[i] = temp_enc[p4[i] - 1];

                }
                for (int i = 0; i < 4; i++)
                {
                    if (temp_p4[i] == Ip_Sol[i])
                    {
                        temp_p4[i] = 0;
                    }
                    else
                    {
                        temp_p4[i] = 1;
                    }

                }
                for (int i = 0; i < 4; i++)
                {
                    Ip_Sol[i] = temp_p4[i];
                }
                for (int i = 0; i < 4; i++)
                {
                    int te = Ip_Sol[i];
                    Ip_Sol[i] = Ip_Sol[i + 4];
                    Ip_Sol[i + 4] = te;
                }
                int m = 0;
            }
            void encryption_round2()
            {
                int[] right_IP = { Ip_Sol[4], Ip_Sol[5], Ip_Sol[6], Ip_Sol[7] };
                int[] Ep_sol = new int[8];

                double row1, row2, col1, col2;
                for (int i = 0; i < 8; i++)
                {
                    Ep_sol[i] = right_IP[Ep[i] - 1];

                }
                for (int i = 0; i < 8; i++)
                {
                    if (Ep_sol[i] == k2[i])
                    {
                        Ep_sol[i] = 0;
                    }
                    else
                    {
                        Ep_sol[i] = 1;
                    }

                }

                row1 = Ep_sol[3] * Math.Pow(2, 0) + Ep_sol[0] * Math.Pow(2, 1);
                col1 = Ep_sol[2] * Math.Pow(2, 0) + Ep_sol[1] * Math.Pow(2, 1);//56
                row2 = Ep_sol[7] * Math.Pow(2, 0) + Ep_sol[4] * Math.Pow(2, 1);
                col2 = Ep_sol[6] * Math.Pow(2, 0) + Ep_sol[5] * Math.Pow(2, 1);
                int t = S0[int.Parse(row1.ToString()), int.Parse(col1.ToString())];
                int t2 = S1[int.Parse(row2.ToString()), int.Parse(col2.ToString())];
                int[] temp_p4 = new int[4];
                bin_to_dec(t, 0);
                bin_to_dec(t2, 2);

                for (int i = 0; i < 4; i++)
                {
                    temp_p4[i] = temp_enc[p4[i] - 1];

                }
                for (int i = 0; i < 4; i++)
                {
                    if (temp_p4[i] == Ip_Sol[i])
                    {
                        temp_p4[i] = 0;
                    }
                    else
                    {
                        temp_p4[i] = 1;
                    }

                }
                for (int i = 0; i < 4; i++)
                {
                    Ip_Sol[i] = temp_p4[i];
                }
                
                int m = 0;
            }
            void Final_Permutation()
            {
                
                for (int i = 0; i < 8; i++)
                {
                    final_result[i] = Ip_Sol[inv_Ip[i] - 1];
                    result += final_result[i];
                }

                textBox3.Text = result;
            }
        }
        public void S_DES_Decryption()
        {
            char[] Key = new char[10];
            char[] plaintext = new char[10];
            Key = textBox1.Text.ToCharArray();
            plaintext = textBox2.Text.ToCharArray();
            int[] p10 = { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
            int[] temp2 = new int[10];
            int[] p8 = { 6, 3, 7, 4, 8, 5, 10, 9 };
            int[] Ip = { 2, 6, 3, 1, 4, 8, 5, 7 };
            int[] Ip_Sol = new int[8];
            int[] Ep = { 4, 1, 2, 3, 2, 3, 4, 1 };
            int[] p4 = { 2, 4, 3, 1 };
            int[] inv_Ip = { 4, 1, 3, 5, 7, 2, 8, 6 };
            int[,] S0 = new int[,] { { 1, 0, 3, 2 }, { 3, 2, 1, 0 }, { 0, 2, 1, 3 }, { 3, 1, 3, 2 } };
            int[,] S1 = new int[,] { { 0, 1, 2, 3 }, { 2, 0, 1, 3 }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
            int[] k1 = new int[8];
            int[] k2 = new int[8];
            int[] final_result = new int[8];
            int[] temp1 = { int.Parse(Key[0].ToString()), int.Parse(Key[1].ToString()), int.Parse(Key[2].ToString()), int.Parse(Key[3].ToString()), int.Parse(Key[4].ToString()), int.Parse(Key[5].ToString()), int.Parse(Key[6].ToString()), int.Parse(Key[7].ToString()), int.Parse(Key[8].ToString()), int.Parse(Key[9].ToString()) };
            int[] temp_enc = new int[4];
            string result = null;
            key1_gen();
            key2_gen();
            IP();


            Decryption_round1();
            Decryption_round2();
            Final_Permutation();


            void bin_to_dec(int m, int num)
            {
                if (m == 0)
                {
                    temp_enc[num] = 0;
                    temp_enc[num + 1] = 0;
                }
                if (m == 1)
                {
                    temp_enc[num] = 0;
                    temp_enc[num + 1] = 1;
                }
                if (m == 2)
                {
                    temp_enc[num] = 1;
                    temp_enc[num + 1] = 0;
                }
                if (m == 3)
                {
                    temp_enc[num] = 1;
                    temp_enc[num + 1] = 1;
                }

            }
            void key1_gen()
            {
                for (int i = 0; i < 10; i++)
                {
                    temp2[i] = temp1[p10[i] - 1];

                }

                int Shiftvalue = temp2[0];
                int Shiftvalue2 = temp2[5];
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (i != 4)
                        {
                            temp2[i] = temp2[i + 1];
                        }
                        else
                        {
                            temp2[i] = Shiftvalue;
                        }
                    }
                    else
                    {
                        if (i != 9)
                        {
                            temp2[i] = temp2[i + 1];
                        }
                        else
                        {
                            temp2[i] = Shiftvalue2;
                        }
                    }

                }
                for (int i = 0; i < 8; i++)
                {
                    k1[i] = temp2[p8[i] - 1];

                }
                int hamda = 0;
            }
            void key2_gen()
            {
                for (int i = 0; i < 10; i++)
                {
                    temp2[i] = temp1[p10[i] - 1];

                }

                int[] Shiftvalue = { temp2[0], temp2[1], temp2[2] };
                int[] Shiftvalue2 = { temp2[5], temp2[6], temp2[7] }; ;
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (i == 0 )
                        {
                            temp2[i] = temp2[3];
                            
                        }
                        if (i == 1)
                        {
                            temp2[i] = temp2[4];
                        }
                        if(i!=0&&i!=1)
                        {
                            temp2[i] = Shiftvalue[i - 2];
                        }
                    }
                    else
                    {
                        if (i == 5 )
                        {
                            temp2[i] = temp2[8];
                            
                        }
                        if (i == 6)
                        {
                            temp2[i] = temp2[9];
                        }
                        if(i!=5&&i!=6)
                        {
                            temp2[i] = Shiftvalue2[i - 7];
                        }
                    }

                }
                for (int i = 0; i < 8; i++)
                {
                    k2[i] = temp2[p8[i] - 1];

                }

            }
            void IP()
            {
                for (int i = 0; i < 8; i++)
                {
                    Ip_Sol[i] = int.Parse(plaintext[Ip[i] - 1].ToString());

                }
            }
            void Decryption_round1()
            {
                int[] right_IP = { Ip_Sol[4], Ip_Sol[5], Ip_Sol[6], Ip_Sol[7] };
                int[] Ep_sol = new int[8];

                double row1, row2, col1, col2;
                for (int i = 0; i < 8; i++)
                {
                    Ep_sol[i] = right_IP[Ep[i] - 1];

                }
                for (int i = 0; i < 8; i++)
                {
                    if (Ep_sol[i] == k2[i])
                    {
                        Ep_sol[i] = 0;
                    }
                    else
                    {
                        Ep_sol[i] = 1;
                    }

                }

                row1 = Ep_sol[3] * Math.Pow(2, 0) + Ep_sol[0] * Math.Pow(2, 1);
                col1 = Ep_sol[2] * Math.Pow(2, 0) + Ep_sol[1] * Math.Pow(2, 1);//56
                row2 = Ep_sol[7] * Math.Pow(2, 0) + Ep_sol[4] * Math.Pow(2, 1);
                col2 = Ep_sol[6] * Math.Pow(2, 0) + Ep_sol[5] * Math.Pow(2, 1);
                int t = S0[int.Parse(row1.ToString()), int.Parse(col1.ToString())];
                int t2 = S1[int.Parse(row2.ToString()), int.Parse(col2.ToString())];
                int[] temp_p4 = new int[4];
                bin_to_dec(t, 0);
                bin_to_dec(t2, 2);

                for (int i = 0; i < 4; i++)
                {
                    temp_p4[i] = temp_enc[p4[i] - 1];

                }
                for (int i = 0; i < 4; i++)
                {
                    if (temp_p4[i] == Ip_Sol[i])
                    {
                        temp_p4[i] = 0;
                    }
                    else
                    {
                        temp_p4[i] = 1;
                    }

                }
                for (int i = 0; i < 4; i++)
                {
                    Ip_Sol[i] = temp_p4[i];
                }
                for (int i = 0; i < 4; i++)
                {
                    int te = Ip_Sol[i];
                    Ip_Sol[i] = Ip_Sol[i + 4];
                    Ip_Sol[i + 4] = te;
                }
                int m = 0;
            }
            void Decryption_round2()
            {
                int[] right_IP = { Ip_Sol[4], Ip_Sol[5], Ip_Sol[6], Ip_Sol[7] };
                int[] Ep_sol = new int[8];

                double row1, row2, col1, col2;
                for (int i = 0; i < 8; i++)
                {
                    Ep_sol[i] = right_IP[Ep[i] - 1];

                }
                for (int i = 0; i < 8; i++)
                {
                    if (Ep_sol[i] == k1[i])
                    {
                        Ep_sol[i] = 0;
                    }
                    else
                    {
                        Ep_sol[i] = 1;
                    }

                }

                row1 = Ep_sol[3] * Math.Pow(2, 0) + Ep_sol[0] * Math.Pow(2, 1);
                col1 = Ep_sol[2] * Math.Pow(2, 0) + Ep_sol[1] * Math.Pow(2, 1);//56
                row2 = Ep_sol[7] * Math.Pow(2, 0) + Ep_sol[4] * Math.Pow(2, 1);
                col2 = Ep_sol[6] * Math.Pow(2, 0) + Ep_sol[5] * Math.Pow(2, 1);
                int t = S0[int.Parse(row1.ToString()), int.Parse(col1.ToString())];
                int t2 = S1[int.Parse(row2.ToString()), int.Parse(col2.ToString())];
                int[] temp_p4 = new int[4];
                bin_to_dec(t, 0);
                bin_to_dec(t2, 2);

                for (int i = 0; i < 4; i++)
                {
                    temp_p4[i] = temp_enc[p4[i] - 1];

                }
                for (int i = 0; i < 4; i++)
                {
                    if (temp_p4[i] == Ip_Sol[i])
                    {
                        temp_p4[i] = 0;
                    }
                    else
                    {
                        temp_p4[i] = 1;
                    }

                }
                for (int i = 0; i < 4; i++)
                {
                    Ip_Sol[i] = temp_p4[i];
                }

                int m = 0;
            }
            void Final_Permutation()
            {

                for (int i = 0; i < 8; i++)
                {
                    final_result[i] = Ip_Sol[inv_Ip[i] - 1];
                    result += final_result[i];
                }

                textBox3.Text = result;
            }
        }
        public void S_AES_Encryption()
        {

            void XOR(char[] word1, char[] word2, char[] Temp)
            {
                string W2string = "";

                for (int i = 0; i < word1.Length; i++)
                {

                    if ((int.Parse(word1[i].ToString()) + int.Parse(word2[i].ToString())) % 2 == 0)
                    {
                        Temp[i] = '0';
                        W2string += Temp[i].ToString();
                    }
                    else
                    {
                        Temp[i] = '1';
                        W2string += Temp[i].ToString();
                    }
                }
            }
            string arrayToString(char[] A)
            {
                string Output = "";
                for (int i = 0; i < A.Length; i++)
                {
                    Output += A[i].ToString();
                }
                return Output;
            }

            void RotNib(char[] word)
            {
                //Swaps the first the last 4 bits
                for (int i = 0; i < 4; i++)
                {
                    char temp = word[i];
                    word[i] = word[i + 4];
                    word[i + 4] = temp;

                }
            }
            void SubNib(char[] word)
            {
                string left = "", right = "";

                for (int i = 0; i < 4; i++)
                {
                    left += word[i].ToString();
                }

                for (int i = 4; i < 8; i++)
                {
                    right += word[i].ToString();
                }

                for (int i = 0; i < 2; i++)
                {
                    string subnib = "";

                    if (i == 0)
                    {
                        subnib = left;
                    }
                    else
                    {
                        subnib = right;
                    }
                    ///////////////////////
                    if (subnib == "0000")
                    {
                        subnib = "1001";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0001")
                    {
                        subnib = "0100";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0010")
                    {
                        subnib = "1010";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0011")
                    {
                        subnib = "1011";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0100")
                    {
                        subnib = "1101";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0101")
                    {
                        subnib = "0001";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0110")
                    {
                        subnib = "1000";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "0111")
                    {
                        subnib = "0101";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    ///////////////////////
                    if (subnib == "1000")
                    {
                        subnib = "0110";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1001")
                    {
                        subnib = "0010";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1010")
                    {
                        subnib = "0000";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1011")
                    {
                        subnib = "0011";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1100")
                    {
                        subnib = "1100";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1101")
                    {
                        subnib = "1110";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1110")
                    {
                        subnib = "1111";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    if (subnib == "1111")
                    {
                        subnib = "0111";
                        if (i == 0)
                        {
                            left = subnib;
                        }
                        else
                        {
                            right = subnib;
                        }

                        continue;
                    }
                    //////////////////////

                }
                for (int i = 0; i < 4; i++)
                {
                    word[i] = left[i];
                    word[i + 4] = right[i];
                }
            }

            char[] GenerateWord2(char[] W0, char[] W1)
            {
                string Output;
                char[] W2 = new char[8];
                char[] Bits128 = new char[8] { '1', '0', '0', '0', '0', '0', '0', '0' };
                char[] Temp = new char[8];
                char[] Temp2 = new char[8];

                for (int i = 0; i < Temp2.Length; i++)
                {
                    Temp2[i] = W1[i];
                }


                RotNib(Temp2);
                Output = arrayToString(W1);

                SubNib(Temp2);
                Output = arrayToString(W1);

                XOR(Temp2, Bits128, Temp);
                XOR(Temp, W0, W2);

                return W2;
            }

            string subNibConditions(string subnib)
            {

                if (subnib == "0000")
                {
                    subnib = "1001";
                    return subnib;
                }
                if (subnib == "0001")
                {
                    subnib = "0100";
                    return subnib;
                }
                if (subnib == "0010")
                {
                    subnib = "1010";
                    return subnib;
                }
                if (subnib == "0011")
                {
                    subnib = "1011";
                    return subnib;
                }
                if (subnib == "0100")
                {
                    subnib = "1101";
                    return subnib;
                }
                if (subnib == "0101")
                {
                    subnib = "0001";
                    return subnib;
                }
                if (subnib == "0110")
                {
                    subnib = "1000";
                    return subnib;
                }
                if (subnib == "0111")
                {
                    subnib = "0101";
                    return subnib;
                }
                ///////////////////////
                if (subnib == "1000")
                {
                    subnib = "0110";
                    return subnib;
                }
                if (subnib == "1001")
                {
                    subnib = "0010";
                    return subnib;
                }
                if (subnib == "1010")
                {
                    subnib = "0000";
                    return subnib;
                }
                if (subnib == "1011")
                {
                    subnib = "0011";
                    return subnib;
                }
                if (subnib == "1100")
                {
                    subnib = "1100";
                    return subnib;
                }
                if (subnib == "1101")
                {
                    subnib = "1110";
                    return subnib;
                }
                if (subnib == "1110")
                {
                    subnib = "1111";
                    return subnib;
                }
                if (subnib == "1111")
                {
                    subnib = "0111";
                    return subnib;
                }
                return subnib;
            }
            string subNibLong(char [] Res)
            {
                string firstQuart = "";
                string secondQuart = "";
                string thirdQuart = "";
                string fourthQuart = "";
                string resSubNib = "";

                for(int i=0;i<4; i++)
                {
                    firstQuart += Res[i].ToString();
                }
                for (int i = 4; i < 8; i++)
                {
                    secondQuart += Res[i].ToString();
                }
                for (int i = 8; i < 12; i++)
                {
                    thirdQuart += Res[i].ToString();
                }
                for (int i = 12; i < 16; i++)
                {
                    fourthQuart += Res[i].ToString();
                }

                firstQuart  = subNibConditions(firstQuart);
                secondQuart = subNibConditions(secondQuart);
                thirdQuart  = subNibConditions(thirdQuart);
                fourthQuart = subNibConditions(fourthQuart);

                resSubNib = firstQuart + secondQuart + thirdQuart + fourthQuart;

                return resSubNib;

            }

            char[] GenerateWords4(char[] W2, char[] W3)
            {
                string Output;
                char[] W4 = new char[8];
                char[] Bits48 = new char[8] {'0', '0', '1', '1', '0', '0', '0', '0' };
                char[] Temp = new char[8];
                char[] Temp2 = new char[8];

                for (int i = 0; i < Temp2.Length; i++)
                {
                    Temp2[i] = W3[i];
                }

                RotNib(Temp2);
                Output = arrayToString(Temp2);

                SubNib(Temp2);
                Output = arrayToString(Temp2);

                XOR(Temp2, Bits48, Temp);
                XOR(Temp, W2, W4);

                return W4;
            }

            void Shift2_4(char[] key)
            {
                char temp;

                for (int i = 0; i < 4; i++)
                {
                    temp = key[i + 4];
                    key[i + 4] = key[i + 12];
                    key[i + 12] = temp;

                }
            }
            char BinToHex(string Bin)
            {
                char Hex = ' ';
                int hex = 0;
                int[] bitvalues = {8,4,2,1};

                for(int i=3;i>=0;i--)
                {
                    if(Bin[i].ToString() == "1")
                    {
                        hex += bitvalues[i];
                    }
                }

                if (hex > 9)
                {
                    if(hex == 10)
                    {
                        Hex = 'a';
                    }
                    if (hex == 11)
                    {
                        Hex = 'b';
                    }
                    if (hex == 12)
                    {
                        Hex = 'c';
                    }
                    if (hex == 13)
                    {
                        Hex = 'd';
                    }
                    if (hex == 14)
                    {
                        Hex = 'e';
                    }
                    if (hex == 15)
                    {
                        Hex = 'f';
                    }
                }
                else
                {
                    Hex = Convert.ToChar(Convert.ToString(hex));
                }
                return Hex;
            }
            void conca(char[] W0, char[] W1, char[] Key)
            {
                for (int i = 0; i < W0.Length; i++)
                {
                    Key[i] = W0[i];
                    Key[i + 8] = W1[i];
                }
            }
            int R = 0, C = 0;
            char[] Key0 = new char[16];
            char[] Key1 = new char[16];
            char[] Key2 = new char[16];

            char[] plainText = new char[16];

            char[,] MultiTable = new char[15, 15] {{'1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'},
                                                   {'2','4','6','8','a','c','e','3','1','7','5','b','9','f','d'},
                                                   {'3','6','5','c','f','a','9','b','8','d','e','7','4','1','2'},
                                                   {'4','8','c','3','7','b','f','6','2','e','a','5','1','d','9'},
                                                   {'5','a','f','7','2','d','8','e','b','4','1','9','c','3','6'},
                                                   {'6','c','a','b','d','7','1','5','3','9','f','e','8','2','4'},
                                                   {'7','e','9','f','8','1','6','d','a','3','4','2','5','c','b'},
                                                   {'8','3','b','6','e','5','d','c','4','f','7','a','2','9','1'},
                                                   {'9','1','8','2','b','3','a','4','d','5','c','6','f','7','e'},
                                                   {'a','7','d','e','4','9','3','f','5','8','2','1','b','6','c'},
                                                   {'b','5','e','a','1','f','4','7','c','2','9','d','6','8','3'},
                                                   {'c','b','7','5','9','e','2','a','6','1','d','f','3','4','8'},
                                                   {'d','9','4','1','c','8','5','2','f','b','6','3','e','a','7'},
                                                   {'e','f','1','d','3','2','c','9','7','6','8','4','a','b','5'},
                                                   {'f','d','2','9','6','4','b','1','e','c','3','8','7','5','a'}};

            Key0 = textBox1.Text.ToCharArray();
            plainText = textBox2.Text.ToCharArray();

            char[] Word0 = new char[8];
            char[] Word1 = new char[8];
            char[] Word2 = new char[8];
            char[] Word3 = new char[8];
            char[] Word4 = new char[8];
            char[] Word5 = new char[8];

            string output = "";

            //Word0 is the first 8-bits of Key0
            for (int i = 0; i < Key0.Length/2; i++)
            {
                Word0[i] = Key0[i];
            }

            output = arrayToString(Word0);
            MessageBox.Show("Word 0: " + output);
            //Word1 is the last 8-bits of Key0
            for (int i = 0; i < Key0.Length/2; i++)
            {
                Word1[i] = Key0[i+8];
            }

            output = arrayToString(Word1);
            MessageBox.Show("Word 1: " + output);

            Word2 = GenerateWord2(Word0, Word1);
            output = arrayToString(Word2);
            MessageBox.Show("Word 2: " + output);

            XOR(Word1, Word2, Word3);
            output = arrayToString(Word3);
            MessageBox.Show("Word 3: " + output);

            Word4 = GenerateWords4(Word2, Word3);
            output = arrayToString(Word4);
            MessageBox.Show("Word 4: " + output);

            XOR(Word3, Word4, Word5);
            output = arrayToString(Word5);
            MessageBox.Show("Word 5: " + output);

            ////////////////Generate_Keys
            conca(Word0, Word1, Key0);
            output = arrayToString(Key0);
            MessageBox.Show("Key0: " + output);

            conca(Word2, Word3, Key1);
            output = arrayToString(Key1);
            MessageBox.Show("Key1: " + output);

            conca(Word4, Word5, Key2);
            output = arrayToString(Key2);
            MessageBox.Show("Key2: " + output);
            //////////////////////////////


            char[] res = new char[16];
            XOR(Key0, plainText, res);
            output = arrayToString(res);

            MessageBox.Show("PlainText XOR Key0: " + arrayToString(res));
            output = subNibLong(res);
            for(int i=0;i<output.Length;i++)
            {
                res[i] = output[i];
            }

            Shift2_4(res);


            //////////////Mixed Columns///////////////
            //////
            ///

            string TempRes = "", first4="", second4 = "", third4 ="", fourth4="";
            string binTemp1, binTemp2;
            char[] a = new char[4];
            char[] bits16 = new char[16];


            for (int i=0;i<4;i++)
            {
                first4  += res[i].ToString();
                second4 += res[i+4].ToString();
                third4  += res[i+8].ToString();
                fourth4 += res[i+12].ToString();
            }


            char hexLeft, hexRight;

            string HexToBin(char chtemp)
            {
                string h = Convert.ToString(chtemp);
                UInt16 g = Convert.ToUInt16(h, 16);
                h = Convert.ToString(g, 2);
                h = h.PadLeft(4, '0');
                return h;
            }

            void findResult(ref int r, ref int c, char targetR, char targetC)
            {
                for (r = 0; r < 15; r++)
                {
                    if(targetR == MultiTable[r,0])
                    {
                        break;
                    }
                }
                for (c = 0; c < 15; c++)
                {
                    if (targetC == MultiTable[0, c])
                    {
                        break;
                    }
                }

            }
            ///////////////////////////
            hexLeft = BinToHex(first4);
            hexRight = BinToHex(second4);

            findResult(ref R, ref C, '4', hexRight);

            hexRight = MultiTable[R, C];

            binTemp1 = HexToBin(hexLeft);
            binTemp2 = HexToBin(hexRight);

            XOR(binTemp1.ToCharArray(), binTemp2.ToCharArray(), a);
            TempRes += arrayToString(a);

            ///////////////////////////
            hexLeft = BinToHex(first4);
            hexRight = BinToHex(second4);

            findResult(ref R,ref C, '4', hexLeft);

            hexLeft = MultiTable[R, C];

            binTemp1 = HexToBin(hexLeft);
            binTemp2 = HexToBin(hexRight);

            XOR(binTemp1.ToCharArray(), binTemp2.ToCharArray(), a);
            TempRes += arrayToString(a);

            ///////////////////////////
            hexLeft = BinToHex(third4);
            hexRight = BinToHex(fourth4);

            findResult(ref R, ref C, '4', hexRight);
            hexRight = MultiTable[R, C];

            binTemp1 = HexToBin(hexLeft);
            binTemp2 = HexToBin(hexRight);

            XOR(binTemp1.ToCharArray(), binTemp2.ToCharArray(), a);
            TempRes += arrayToString(a);

            ///////////////////////////
            hexLeft = BinToHex(third4);
            hexRight = BinToHex(fourth4);

            findResult(ref R, ref C, '4', hexLeft);

            hexLeft = MultiTable[R, C];

            binTemp1 = HexToBin(hexLeft);
            binTemp2 = HexToBin(hexRight);

            XOR(binTemp1.ToCharArray(), binTemp2.ToCharArray(), a);
            TempRes += arrayToString(a);
            ///////////////////////////
            MessageBox.Show("Mixed Columns output: " + TempRes);

            XOR(TempRes.ToCharArray(), Key1, bits16);
            TempRes = arrayToString(bits16);
            MessageBox.Show("Output of Round 1 XOR Key 1: " + TempRes);
            a = TempRes.ToCharArray();
            TempRes = subNibLong(a);
            a = TempRes.ToCharArray();
            Shift2_4(a);
            MessageBox.Show("Round 2 input: " + arrayToString(a));

            //////////////////////////
            XOR(a, Key2, bits16);

            first4 = bits16[0].ToString() + bits16[1].ToString() + bits16[2].ToString() + bits16[3].ToString();
            second4 = bits16[4].ToString() + bits16[5].ToString() + bits16[6].ToString() + bits16[7].ToString();
            third4 = bits16[8].ToString() + bits16[9].ToString() + bits16[10].ToString() + bits16[11].ToString();
            fourth4 = bits16[12].ToString() + bits16[13].ToString() + bits16[14].ToString() + bits16[15].ToString();

            textBox3.Text = arrayToString(bits16) + " Hex Representation (" + BinToHex(first4) + BinToHex(second4) + BinToHex(third4) + BinToHex(fourth4) + ")";



        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //MessageBox.Show("Encryption ");
                label5.Text = "Ciphertext:";
                if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text.Length == 10 && textBox2.Text.Length == 8)
                    {
                        S_DES_Encryption();

                    }
                    else
                    {
                        MessageBox.Show("Check the key should be 10 bit or the plaintext should be 8 bit");
                    
                    }
                    ///S_DES

                }
                if (comboBox1.SelectedIndex == 1)
                {
                    if (textBox1.Text.Length == 16 && textBox2.Text.Length == 16)
                    {
                        S_AES_Encryption();
                    }
                    else
                    {
                        MessageBox.Show("Please make sure that both the Key and the plaintext are equal to 16 bits");
                    }
                    ///S_AES


                }
            }
            if (radioButton2.Checked)
            {
                //MessageBox.Show("Decryption ");
                label5.Text = "Plaintext:";
                if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text.Length == 10 && textBox2.Text.Length == 8)
                    {
                        S_DES_Decryption();

                    }
                    else
                    {
                        MessageBox.Show("Check the key should be 10 bit or the plaintext should be 8 bit");

                    }


                }
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Choose a way to apply the algorithm ");
            }
        }
    }
}
