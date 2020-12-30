using System;

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] input = Console.ReadLine().Split();
            int l = int.Parse (input[0]);
            int n = int.Parse(input[1]);
            input= Console.ReadLine().Split(); 

            bool [] light = new bool [l];
            for(int i =0 ; i < n ; i++)
                light[int.Parse(input[i])-1 ]= true ; 

            int count = 0; 

            backtraking(ref light , n , ref count) ; 

            System.Console.WriteLine(count); 
        }

        // i -> indice de la posicion de la luz que se quiere saber si tiene luces adyacentes encendidas
        // light -> array de bool donde estan representado los estados de las luces (true -> encendido , false -> apagado)
        // returna si la luz que esta en la posicion i tiene luces  adyacentes que estan encendidas 
        public static bool cantSwichOn(int i , ref bool  [] light)
        {
            //verifica que los indices adyacentes no estan fuera del rango en el array light,
            // y en caso de que alguna luz adyacente este encendida entonces retorna true 
            return (((i-1 >= 0) && light[i-1]) || ((i+1 < light.Length && light[i+1]))); 
        }

        // light -> array de bool , que me representa el estado de las luces (true -> encendido , false -> apagado)
        // n -> es la cantida de luces que estan encendidas en el momento del llamado a la funcion 
        // count -> una referencia a una variable externa que es el contador de estados finales (en que todas las luces estan encendidas)
        public static void backtraking (ref bool [] light , int n , ref int count  )
        {
            //si se llega a un estado en el que todas las luces fueron 
            //encendidas entonces se aumenta el contador en 1
            if (n == light.Length)   
                count = count + 1 ; 
            else 
            { 
                //se recorre todo el array y se pregunta por cada una de las luces 
                for(int i = 0; i < light.Length; i++)
                {
                    //si la luz en el array con indice i esta apagada y tiene una luz adyacente encendida
                    // entonces la enciendo y vuelvo a llamar el metodo para probar todos los posibles estados 
                    // en los que a partir de este punto se encendio la luz con indice i 
                    if (light[i] == false && cantSwichOn(i,ref light))
                    {
                        light[i] = true;  // enciende la luz 

                        //se llama al metodo con las referencias al mismo array  y el contador 
                        // aumentandole en 1 la cantidad de luces encendidas 
                        backtraking(ref light , n+1 , ref count ); 

                        // una vez analizada todos los posibles casos en los que la i-esima luz se 
                        // encendio la apago para continuar con el analisis de los casos de la i+1  en adelante
                        light[i] = false; 
                    }
                }
            }
        }
    }
}
