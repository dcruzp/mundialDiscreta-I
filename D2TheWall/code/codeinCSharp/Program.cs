using System; 
using System.Numerics; 

using static System.Math;

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] input  = Console.ReadLine().Split(); 
            int n = int.Parse (input[0]); 
            int C = int.Parse (input[1]); 
            
            BigInteger answer = solveComb(n,C); 
            System.Console.WriteLine(answer); 
            
        }

        // fact -> una referencia a un array de BigIntegers donde vamos a calcular el factorial para cada posicion (para cada n en el indice i)
        // MOD  -> el valor del MOD por el que queremos calcular los restos de la multiplicacion( en nuesto caso es un numero primo 1000000007)
        // retorna -> en el array fact queda el factorial modulo MOD calculado hasta el tamano de fact  
        public static void compfactorial (ref BigInteger [] fact , BigInteger MOD)
        {
            fact[0] = 1;  // en la primera posicion queda que el fact [0] 1 para poder calcular los demas
            // se hace en for desde el indice i=1 hasta la longitud de fact para ir calculando el factorial
            // basandose en el anterior previamente calculado. 
            for(int i=1 ; i < fact.Length ; i++ ) 
            {
                // calculamos el factorial de la posicion i basandonos en el de la posicion i-1 y nos quedamos con el resto  (modulo MOD)
                fact[i] = (fact[i-1]*(BigInteger)i) % MOD;   
            }
        }

        // n -> cantidad de obetos totales de los que disponemos
        // k -> cantidad de objetos a escoger de los n que que me dieron 
        // fact -> una referencia a un array de factoriales previamente calculados 
        // MOD -> el valor por le que queremos calcular el resto de la division entre ese MOD 
        // retorna -> el valor de el numeros de combinaciones de n en k  
        public static BigInteger Binom (int n , int k , ref BigInteger [] fact , BigInteger MOD)
        {
            // calculamos el binomio usando el inverso modulo MOD (que se ustifica por el Pequeno Teorema de Fermat)
            // y no quedamos con el modulo de todas las multiplicaciones 
            return (fact [n] * ((BigInteger.ModPow(fact [n-k] , MOD -2 , MOD) *BigInteger.ModPow(fact [k] , MOD -2 , MOD))%MOD))%MOD; 
        }

        // n -> cantidad maxima de bloques que hay para crear el muro 
        // C -> cantidad de columnas que tiene que tener el muro a construir 
        // retorna -> al respuesta de calcular la cantidad de muros que se pueden construir de C columnas con a lo sumo n bloques  
        public static BigInteger solveComb (int n , int C)
        {
            BigInteger [] fact  = new BigInteger [700005];  // array de BigInteger donde en cada indice del array voy a almacenar el factorial modulo MOD
            BigInteger MOD = 1000003;  // el modulo por el que voy a ir calculando los restos con los que me voy a ir quedando (es un numero primo )
            compfactorial (ref fact , MOD); // llamo a la funcion para calcular el factorial y almacenarlo en el array fact (todos los valores son calculados modulo MOD)

            BigInteger answer = Binom(n+C , C , ref fact , MOD) -1 ; // la respuesta (para nuestro problema es la combinacion de (n+C) en C ,  menos 1 )
            return answer; // retornar la respuesta 
        }
    }
}
