using System;

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            System.Console.WriteLine(solBacktraking(n));
        }

        public static void backtraking (int r , int b , ref long count)
        {
            if (r ==0 && b==0 )  //si llego aqui es que esta ahora en un estado final , o sea que cada bot a hecho exactamante n movimientos 
            {
                count += 1 ;   // aumento el contador pues los estados finales tambien son validos
            }
            else 
            {
                count += 1;  // aumento el contador en 1 pues si llego aqui es porque es un estado valido, pues si llego aqui es porque r>0 (todavia se puede mover con el bot rojo )o b>0 (todavia se puede mover con el bot azul )
                if (r > 0)   // si todavia se pueden dar mas pasos con el bot rojo 
                {
                    backtraking (r-1, b, ref count) ; //llamo al backtraking movindome con el bot rojo a un estado  (llamando a la funcion recursiva disminuyendo la cuota de movimientos del bot rojo )
                }
                if (b > 0)  // si tidavia se pueden dar mas  pasos con el bot azul 
                {
                    backtraking (r,b-1,ref count) ;  //llamo al backtraking movindome con el bot azul a un estado  (llamando a la funcion recursiva disminuyendo la cuota de movimientos del bot azul )
                }
                
            }
        }
        public static long solBacktraking (int n) 
        {
            long count = 0 ;  // pongo un contador en cero 
            backtraking (n,n,ref count ) ; //lamo a la solucion partiendo con todos los movimientos validos o sea para cada bot con una cantidad e movimientos validos igual a n 
            return count ;  // retorno el contador despues de hacer el llamado a la funcion  backtraking 
        } 
    }
}