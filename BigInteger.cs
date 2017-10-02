using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Euler.Solutions
{
    struct BigInteger
    {
		uint[] bits;
        public BigInteger(int exp2)
        {
			bits = new uint[32];
            bits[exp2 / 32] = 1u << (exp2 % 32);
        }
        public BigInteger(uint value)
        {
			bits = new uint[32];
            bits[0] = value;
        }
        public override string ToString()
        {
            string result = "";
            uint[] bits = (uint[])this.bits.Clone();
            do result = divide(bits, 10, bits) + result; while (bits.Any(c => c > 0));
            return result;
        }
		private static void add(uint[] num1, uint[] num2, uint[] result)
		{
			ulong sum = 0;
			for (int i = 0; i < num1.Length; i++)
			{
				sum += num1[i] + num2[i];
				result[i] = (uint)sum;
				sum >>= 32;//add overflowbit next time
			}
			return;
		}
		private static void sub(uint[] num1, uint[] num2, uint[] result)
		{
			ulong sum = 0;
			bool borrow=false;
			for (int i = 0; i < num1.Length; i++)
			{
				sum = num1[i] - num2[i] - ((borrow)?1ul:0);
				result[i] = (uint)sum;
				borrow = num1[i] < num2[i];
			}
			return;
		}
		private static uint divide(uint[] bi1, uint divider, uint[] quotient) 
        {
            int pos = bi1.Length;
            while (bi1[--pos] == 0) ; pos++;
            ulong remainder = 0;
            while (--pos>= 0)
            {
                ulong divident = (remainder << 32) + bi1[pos];
                quotient[pos] = (uint)(divident / divider);
                remainder = divident % divider;
            }
            return (uint)remainder;
        }
        private static void multiply(uint[] bi1, long n, uint[] result)
        {
            uint carry = 0;
            int len = bi1.Length;
            while (bi1[--len] == 0) ; len ++; 
            for (int pos = 0; pos < len || carry>0; pos++)
            {
                long temp = bi1[pos] * n + carry;
                result[pos] = (uint)temp;
                carry = (uint)(temp >> 32);
            }
        }
		public static BigInteger operator +(BigInteger left, BigInteger right)
		{
			BigInteger result = 0;
			add(left.bits, right.bits, result.bits);
			return result;
		}
		public static BigInteger operator -(BigInteger left, BigInteger right)
		{
			BigInteger result = 0;
			sub(left.bits, right.bits, result.bits);
			return result;
		}
		public static BigInteger operator /(BigInteger left, BigInteger right)
        {
            BigInteger result = 0;
            divide(left.bits, right.bits[0], result.bits);
            return result;
        }
        public static BigInteger operator *(int left, BigInteger right)
        {
            BigInteger result = 0;
            multiply(right.bits, left, result.bits);
            return result;
        }
		public static BigInteger operator ^(BigInteger left, int right)
		{
			BigInteger result = 1;
			for (int i = 0; i < right; i++)
			{
				multiply(result.bits, left.bits[0], result.bits);
			}
			return result;
		}
		public static int operator %(BigInteger left, int right) //added for euler
		{
			BigInteger result = left - (right * (left / right));
			return (int)result.bits[0];
		}
		public static bool operator ==(BigInteger left, BigInteger right)
        {
            for (int i = 0; i < left.bits.Length; i++) if (left.bits[i] != right.bits[i]) return false;
            return true;
        }
        public static bool operator !=(BigInteger left, BigInteger right)
        {
            return !(left == right);
        }
        public static bool operator <(BigInteger left, int right)
        {
            return left.bits[0] < right;
        }
        public static bool operator >(BigInteger left, int right)
        {
            return left.bits[0] > right;
        }
        public static BigInteger operator ++(BigInteger left)
        {
            return left+1;
        }
        public static implicit operator BigInteger(int value)
        {
            return new BigInteger((uint)value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public static void UnitTest()
        {
            BigInteger a, b, c;
            a = new BigInteger(32); // 2^32
            b = 4;
            c = a / b;
            Debug.Assert(c == 1073741824, "UnitTest failed: Division error.");
            Debug.Assert(2 * b == 8, "UnitTest failed: Multiply 1.");
            b = new BigInteger(33);
            Debug.Assert(b.ToString() == "8589934592", "UnitTest failed: ToString().");
            Debug.Assert(2 * a == b, "UnitTest failed: Multiply 2.");
            b = new BigInteger(31);
            Debug.Assert(2 * b == a, "UnitTest failed: Multiply 3.");
            b = 1000;
            c = b^3;
            Debug.Assert(c == 1000000000, "UnitTest failed: Power 1.");
            b = 99;
            c = b ^ 95;
            Debug.Assert(c.ToString().EndsWith("90801973870359499"), "UnitTest failed: ToString2().");
            for (BigInteger i = 0; i < 10; i++) ;
        }
    }
}
