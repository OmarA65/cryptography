using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_project
{
    class playfair
    {
        public string[,] matrix = new string[5, 5];
        public string alphabets = "abcdefghiklmnopqrstuvwxyz";

        public string encryption(string plaintxt, string key)
        {
            bool next = false;
            int x = 0, y = 0, x2 = 0, y2 = 0;
            string cpihertxt = default;
            key = key.ToLower();
            plaintxt = plaintxt.ToLower();
            plaintxt = removespace(plaintxt);
            key = removespace(key);
            setmatrix(key);
            if (plaintxt.Length % 2 != 0)
            {
                plaintxt += "x";
            }
            for (int i = 0; i < plaintxt.Length; i += 2)
            {
                next = true;
                findTarget(matrix, plaintxt[i], ref x, ref y);
                findTarget(matrix, plaintxt[i + 1], ref x2, ref y2);
                //if (x == 4)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        y = 0;
                //    }
                //}
                //if (y == 4)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        y = 0;
                //    }
                //}

                //if (x2 == 4)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        x2 = 0;
                //    }
                //}
                //if (y2 == 4)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        y2 = -1;
                //    }
                //}

                if (x != x2 && y != y2)
                {
                    cpihertxt += matrix[x, y2];
                    cpihertxt += matrix[x2, y];
                }
                if (x == x2)
                {
                    if (y == 4)
                    {
                        y = -1;
                    }
                    if (y2 == 4)
                    {
                        y2 = -1;
                    }
                    cpihertxt += matrix[x, y + 1];
                    cpihertxt += matrix[x, y2 + 1];
                    next = false;
                }
                if (y == y2 && next)
                {
                    if (x == 4)
                    {
                        x = -1;
                    }
                    if (x2 == 4)
                    {
                        x2 = -1;
                    }
                    cpihertxt += matrix[x + 1, y];
                    cpihertxt += matrix[x2 + 1, y];
                }
            }


            return cpihertxt;
        }

        public string Decryption(string ciphertxt, string key)
        {
            string plaintxt = default;
            int x = 0, y = 0, x2 = 0, y2 = 0;
            key = key.ToLower();
            key = removespace(key);
            ciphertxt = ciphertxt.ToLower();
            ciphertxt = removespace(ciphertxt);
            setmatrix(key);
            for (int i = 0; i < ciphertxt.Length; i += 2)
            {
                findTarget(matrix, ciphertxt[i], ref x, ref y);
                findTarget(matrix, ciphertxt[i + 1], ref x2, ref y2);
                //if (x == 0)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        x = 4;
                //    }
                //}
                //if (y == 0)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        y = 4;
                //    }

                //}

                //if (x2 == 0)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        x2 = 4;
                //    }
                //}
                //if (y2 == 0)
                //{
                //    if (x == x2 || y == y2)
                //    {
                //        y2 = 4;
                //    }

                //}

                if (x != x2 && y != y2)
                {
                    if (matrix[x, y2] == "ij")
                    {
                        plaintxt += 'i';
                        plaintxt += matrix[x2, y];
                    }
                    else
                    {
                        if (matrix[x2, y] == "ij")
                        {
                            plaintxt += matrix[x, y2];
                            plaintxt += 'i';
                        }
                        else
                        {
                            plaintxt += matrix[x, y2];
                            plaintxt += matrix[x2, y];
                        }
                    }

                }
                if (x == x2)
                {
                    if (y == 0)
                    {
                        y = 5;
                    }
                    if (y2 == 0)
                    {
                        y2 = 5;
                    }
                    if (matrix[x, y - 1] == "ij")
                    {

                        plaintxt += 'i';
                        plaintxt += matrix[x, y2 - 1];
                    }
                    else
                    {
                        if (y2 == 0)
                        {
                            y2 = 5;
                        }
                        if (y == 0)
                        {
                            y = 5;
                        }
                        if (matrix[x2, y2 - 1] == "ij")
                        {

                            plaintxt += matrix[x, y - 1];
                            plaintxt += 'i';
                        }
                        else
                        {
                            if (y == 0)
                            {
                                y = 5;
                            }
                            if (y2 == 0)
                            {
                                y2 = 5;
                            }
                            plaintxt += matrix[x, y - 1];
                            plaintxt += matrix[x, y2 - 1];
                        }
                    }

                }
                if (y == y2)
                {
                    if (x == 0)
                    {
                        x = 5;
                    }
                    if (x2 == 0)
                    {
                        x2 = 5;
                    }
                    if (matrix[x - 1, y] == "ij")
                    {

                        plaintxt += 'i';
                        plaintxt += matrix[x2 - 1, y];
                    }
                    else
                    {
                        if (x == 0)
                        {
                            x = 5;
                        }
                        if (x2 == 0)
                        {
                            x2 = 5;
                        }
                        if (matrix[x2 - 1, y] == "ij")
                        {

                            plaintxt += matrix[x - 1, y];
                            plaintxt += 'i';
                        }
                        else
                        {
                            if (x == 0)
                            {
                                x = 4;
                            }
                            if (x2 == 0)
                            {
                                x2 = 0;
                            }
                            plaintxt += matrix[x - 1, y];
                            plaintxt += matrix[x2 - 1, y];
                        }
                    }

                }
            }

            return plaintxt;
        }

        void setmatrix(string key)
        {

            int s = 0;
            int k = 0;
            int a = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (k < key.Length)
                    {
                        for (; ; )
                        {
                            if (check(matrix, key[k].ToString()) && key[k] != ' ')
                            {
                                if (key[k] == 'i')
                                {
                                    matrix[i, j] = key[k].ToString();
                                    matrix[i, j] += 'j';
                                }
                                else
                                {
                                    matrix[i, j] = key[k].ToString();
                                }
                                k++;
                                break;
                            }
                            k++;
                        }
                    }
                    else
                    {
                        for (; ; )
                        {
                            if (check(matrix, alphabets[a].ToString()))
                            {
                                if (alphabets[a] == 'i')
                                {
                                    matrix[i, j] = alphabets[a].ToString();
                                    matrix[i, j] += 'j';
                                }
                                else
                                {
                                    matrix[i, j] = alphabets[a].ToString();
                                }
                                a++;
                                break;
                            }
                            a++;
                        }
                    }
                }
            }
        }

        string removespace(string temp)
        {
            //string temp2 = default;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ' ' || temp[i] == ',' || temp[i] == '.')
                {
                    temp = temp.Remove(i, 1);
                }
            }
            return temp;
        }

        void findTarget(string[,] matrix, char v, ref int x, ref int y)
        {
            bool check = false;
            string vv = default;
            if (v == 'i' || v == 'j')
            {
                vv = "ij";
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (v == 'i' || v == 'j')
                    {
                        if (matrix[i, j] == vv)
                        {
                            x = i; y = j;
                            check = true;
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] == v.ToString())
                        {
                            x = i; y = j;
                            check = true;
                            break;
                        }
                    }

                }
                if (check)
                {
                    break;
                }
            }
        }

        bool check(string[,] matrix, string v)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == v)
                    {
                        return false;
                        break;
                    }
                }
            }
            return true;
        }
    }
}
