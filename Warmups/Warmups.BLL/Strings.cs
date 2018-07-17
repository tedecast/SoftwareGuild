using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
           return  "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word) {

            return container.Insert(2, word);
        }

        public string MultipleEndings(string str)
        {
            return str.Substring(str.Length - 2) + str.Substring(str.Length - 2) + str.Substring(str.Length - 2);
        }

        public string FirstHalf(string str)
        {
            return str.Substring(0, (str.Length / 2));
        }

        public string TrimOne(string str)
        {
            str = str.Remove(str.Length - 1);
            str = str.Remove(0, 1);
            return str;
        }

        public string LongInMiddle(string a, string b)
        {
            string longer, shorter;
            if (a.Length > b.Length)
            {
                longer = a;
                shorter = b;

            }
            else
            {
                longer = b;
                shorter = a;
            }

            return shorter + longer + shorter;
        }

        public string RotateLeft2(string str)
        {
            string attach = str.Substring(0,2);
            str = str.Remove(0,2);

            return str + attach;
        }

        public string RotateRight2(string str)
        {
            int length = str.Length;
            string newstr = str.Substring(length - 2);
            str = str.Remove(length - 2);

            return newstr + str;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);

            }
            else
            {
                return str.Substring(str.Length - 1);
            }
        }

        public string MiddleTwo(string str)
        {
            int length = (str.Length - 2) / 2;
            str = str.Remove(0, length);
            str = str.Remove(str.Length - length);

            return str;
        }

        public bool EndsWithLy(string str)
        {
            bool ending = false;
            string check = str;

            if (str.Length > 2)
            {
               check = str.Substring(str.Length - 2);
            }
            if (check == "ly")
            {
                ending = true;
            }
            return ending;
        }

        public string FrontAndBack(string str, int n)
        {
            string newstr = str.Substring(0, n) + str.Substring(str.Length - n);

            return newstr;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > str.Length - 2)
            {
                n = 0;
            }
            string newstr = str.Substring(n, 2);

            return newstr; 
        }

        public bool HasBad(string str)
        {
            
            bool isBad = false;
               if (str.Contains("bad") && str.Substring(0,2) != "xx" && str != "")
               {
                   isBad = true;
               }

            return isBad;
        }

        public string AtFirst(string str)
        {
            if (str.Length > 2)
            {
                str = str.Substring(0, 2);
            }
            else
            {
                for (int i = str.Length; i < 2; i++)
                {
                    str += "@";
                }
            }

            return str;
        }

        public string LastChars(string a, string b)
        {
            string new_a;
            string new_b;

            if (a.Length > 1)
            {
                new_a = new_a = a.Substring(0, 1);
            }
            else
            {
                new_a = "@";
            }

            if (b.Length >= 1)
            {
                new_b = b.Substring(b.Length - 1);
            }
            else
            {
                new_b = "@";
            }

            return new_a + new_b;
        }

        public string ConCat(string a, string b)
        {
            string Cat = a + b;

            for (int i = 0; i < Cat.Length-1; i++)
            {
                if (Cat[i] == Cat[i+1])
                {
                    Cat = Cat.Remove(i, 1);
                }
            }

            return Cat; 
        }

        public string SwapLast(string str)
        {
            if (str.Length == 1)
            {
            }
            else if (str.Length == 2)
            {
                string front = str.Substring(0,1);
                str = str.Remove(0, 1);
                str += front;
            }
            else
            {
                string secondlast = str.Substring(str.Length - 2, 1);
                str = str.Remove(str.Length-2, 1);
                str += secondlast;
            }
           
            return str;
        }

        public bool FrontAgain(string str)
        {
            bool front_again = false;

            if (str.Substring(0, 2) == str.Substring(str.Length - 2))
            {
                front_again = true;
            }

            return front_again;
        }

        public string MinCat(string a, string b)
        {
            int del_length;
            del_length = Math.Abs(a.Length - b.Length);

            if (a.Length > b.Length)
            {
                a = a.Remove(0, del_length);
            }
            else
            {
               b = b.Remove(0, del_length);
            }

            return a+b;

        }

        public string TweakFront(string str)
        {
            bool del_first = false;
            if (str != "")
            {

                for (int i = 0; i < 2; i++)
                {
                    if (del_first)
                    {
                        if (str[i - 1] != 'a' && str[i - 1] != 'b')
                        {

                            str = str.Remove(i - 1, 1);
                        }
                    }
                    else
                    {
                        if (str[i] != 'a' && str[i] != 'b')
                        {

                            str = str.Remove(i, 1);
                            del_first = true;

                        }
                    }
                }
            }
                        return str; 

            }

        

        public string StripX(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {

                    if (str[i] == 'x' && (i == str.Length - 1 || i == 0))
                    {
                        str = str.Remove(i, 1);
                    }              
            }           
            return str; 
        }
    }
}
