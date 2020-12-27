using System;
using System.Numerics; 
using static System.Math; 

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            System.Console.WriteLine(solveBacktraking(n));
            System.Console.WriteLine(solveComb(n));
        }

        /// PROPUESTA DE SOLUCION # 1 (USANDO BACKTRAKING )


        // r-> cantidad maxima de movimentos que puede dar el bot azul 
        // b-> cantidad maxima de movimentos que puede dar el bot rojo 
        // count -> una referenia a una variable externa donde se va a ir cantoando la cantidad de estados en cada llamado recursivo 
        public static void backtraking (int r , int b , ref long count)
        {
            //si llego aqui es que esta ahora en un estado final , o sea que cada bot a hecho exactamante n movimientos 
            // aumento el contador pues los estados finales tambien son validos (es decir en los estados en que cada bot 
            // camino exactamente n posiciones ) inicialmente r y b son exactamente n
            if (r ==0 && b==0 )  
                count += 1 ; 
            else 
            {
                // aumento el contador en 1 pues si llego aqui es porque es un estado valido, pues si llego aqui es porque r>0 (todavia se puede mover con el bot rojo )o b>0 (todavia se puede mover con el bot azul )
                count += 1;  

                // si todavia se pueden dar mas pasos con el bot rojo entonces llamo al backtraking moviendome con el bot rojo a un nuevo estado 
                // (llamando a la funcion recursiva disminuyendo la cuota de movimientos del bot rojo )
                if (r > 0)   
                    backtraking (r-1, b, ref count) ;
                // si tidavia se pueden dar mas  pasos con el bot azul  llamo al backtraking movindome con el bot azul a un estado  
                // (llamando a la funcion recursiva disminuyendo la cuota de movimientos del bot azul )
                if (b > 0)   
                    backtraking (r,b-1,ref count) ;                 
            }
        }

        // n-> cantidad maxima de pasos que puede dara cada bot 
        // retorna -> cantidad total de estados en las que se puede encontrar el juego 
        public static long solveBacktraking (int n) 
        {
            long count = 0 ;  // pongo un contador en cero 
            backtraking (n,n,ref count ) ; //lamo a la solucion partiendo con todos los movimientos validos o sea para cada bot con una cantidad e movimientos validos igual a n 
            return count ;  // retorno el contador despues de hacer el llamado a la funcion  backtraking 
        } 


        /// PROPUESTA DE SOLUCION # 2 (USANDO COMBINATORIA  )

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

        // n > cantidad maxima de pasos que puede dar a lo sumo un bot 
        // retorna -> al respuesta de calcular la cantidad de estados en las que cada bot puede encontrarse cuando cada bot puede dar a lo sumo n pasos 
        public static BigInteger solveComb (int n)
        {
            BigInteger [] fact  = new BigInteger [2000007];  // array de BigInteger donde en cada indice del array voy a almacenar el factorial modulo MOD
            BigInteger MOD = 1000000007;  // el modulo por el que voy a ir calculando los restos con los que me voy a ir quedando (es un numero primo )
            compfactorial (ref fact , MOD); // llamo a la funcion para calcular el factorial y almacenarlo en el array fact (todos los valores son calculados modulo MOD)

            BigInteger answer = Binom(2*n+2 , n+1 , ref fact , MOD) -1 ; // la respuesta (para nuestro problema es la combinacion de 2(n+1) en n+1 todo es menos 1 )
            return answer; // retornar la respuesta 
        }
    }
}