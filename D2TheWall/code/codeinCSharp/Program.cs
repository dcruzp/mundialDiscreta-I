using System; 
using System.Numerics; 

using static System.Math;

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] fact ; 
            int MOD = 1000003;
            calcfact(out fact , MOD);

            // int n = 100 ; 
            // int k = 50 ; 

            //BigInteger result = Binom(n,k,ref MOD , ref fact);

            //System.Console.WriteLine(result);

            System.Console.WriteLine(BigInteger.ModPow(20,4,11));
            
            // for (int i = 0 ; i < 10 ; i ++)
            // {
            //     System.Console.Write(fact[i] + " ");
            // }
            
        }

        public static BigInteger Binom (int n , int k ,ref int MOD, ref int [] fact)
        {
            return (fact[n] * (BigInteger.ModPow(BigInteger.ModPow (fact[k] , MOD -2 , MOD ),2,MOD)))% MOD ; 
            
        }
        public static void calcfact (out int [] fact  , int MOD) 
        {
            fact = new int [5*10^5 +10] ;
            fact[0] = 1 ;
            for (int i = 1 ; i < fact.Length; i++)
            {
                fact [i] = (fact[i-1] * i) % MOD ;
            }
        }
    }
}
