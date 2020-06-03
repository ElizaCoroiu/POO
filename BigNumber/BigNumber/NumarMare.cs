using System;
using System.Text;

namespace BigNumber
{
    public class NumarMare
    {
        private int[] bigNum;
        private int length;

        public NumarMare()
        {

        }

        public NumarMare(string Num)
        {
            this.length = Num.Length;
            this.bigNum = new int[Num.Length];
            for (int i = Num.Length - 1; i >= 0; i--)
            {
                bigNum[Num.Length - 1 - i] = int.Parse((Num[i]).ToString());
            }
        }

        public NumarMare(int length)  
        {
            this.length = length;
            this.bigNum = new int[length];
        }

        public static NumarMare operator +(NumarMare a, NumarMare b)
        {
            int min = Math.Min(a.bigNum.Length, b.bigNum.Length);
            int max = Math.Max(a.bigNum.Length, b.bigNum.Length);
            NumarMare c = new NumarMare(max + 1);

            int k = 0;
            for (int i = 0; i < min; i++)
            {
                c.bigNum[i] = a.bigNum[i] + b.bigNum[i]+ k;

                if (c.bigNum[i] >= 10)
                {
                    k = 1;
                    c.bigNum[i] -= 10;
                }
                else
                {
                    k = 0;
                }
            }
            NumarMare d = new NumarMare();
            if (a.bigNum.Length > b.bigNum.Length)
            {
                d = a;
            }
            else
            {
                d = b;
            }

            for (int i = min; i < max; i++)
            {
                c.bigNum[i] = d.bigNum[i] + k;

                if (c.bigNum[i] >= 10)
                {
                    k = 1;
                    c.bigNum[i] -= 10;
                }
                else
                {
                    k = 0;
                }
            }

            if (k == 1)
            {
                c.bigNum[max] = 1;
            }

            return c.RemoveZeros();
        }

        public NumarMare GetFactorial(int n)
        {
            NumarMare currentNumber = new NumarMare("1");
            NumarMare factorial = new NumarMare("1");

            for (int i = 0; i < n; i++)
            {
                factorial *= currentNumber;
                currentNumber++;
            }

            return factorial;
        }

        public static NumarMare operator ++(NumarMare a)
        {
            return a + new NumarMare("1");
        }

        public static NumarMare operator *(NumarMare a, NumarMare b)
        {
            NumarMare c = new NumarMare(a.bigNum.Length + b.bigNum.Length);

            NumarMare[] intermediar = new NumarMare[b.bigNum.Length];

            for (int i = 0; i < b.length; i++)
            {
                NumarMare d = new NumarMare(a.bigNum.Length + b.bigNum.Length); ;
                int produs, rest, cat = 0;

                for (int j = 0; j < a.length; j++)
                {

                    produs = b.bigNum[i] * a.bigNum[j] + cat;
                    rest = produs % 10;
                    cat = produs / 10;

                    d.bigNum[j + i] = rest;
                }

                if (cat > 0)
                {
                    d.bigNum[a.length + i] = cat;
                }
                intermediar[i] = d;
            }

            for (int i = 0; i < intermediar.Length; i++)
            {
                c = c+intermediar[i];
            }

            return c.RemoveZeros();
        }
               
        public NumarMare RemoveZeros()
        {
            int last_pos = -1;
            for (int i = 0; i < this.bigNum.Length; i++)
            {
                if (this.bigNum[i] == 0)
                {
                    if (last_pos < 0)
                    {
                        last_pos = i;
                    }
                }
                else
                {
                    last_pos = -1;
                }
            }
            if (last_pos > 0)
            {
                NumarMare a = new NumarMare(last_pos);
                for (int i = 0; i < a.bigNum.Length; i++)
                {
                    a.bigNum[i] = this.bigNum[i];
                }
                return a;
            }
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.bigNum.Length; i++)
            {
                sb.Append(this.bigNum[this.bigNum.Length-1-i]);
            }

            return sb.ToString();
        }
    }
}



   
        

        

           