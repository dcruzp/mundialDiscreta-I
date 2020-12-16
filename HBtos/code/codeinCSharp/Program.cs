using System;
using System.Collections.Generic; 

namespace codeinCSharp
{
    enum type 
    {
        red = 0 , 
        blue = 1
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 

            System.Console.WriteLine(solution(n));
        }

        public static void printrack (ref Stack<type> track)
        {
            type [] aux = track.ToArray(); 
            for (int i = aux.Length-1 ;  i >= 0 ; i-- )
            {
                System.Console.Write(aux[i].ToString() + " ");
            }
            System.Console.WriteLine();
        }
        public static void recursivesolution (int r , int b , ref long count ,ref Stack<type> track)
        {
            if (r ==0 && b==0 )
            {
                count += 1 ; 
                //printrack(ref track); 
            }
            else 
            {
                count += 1; 
                if (r > 0)
                {
                    //track.Push(type.red); 
                    recursivesolution(r-1, b, ref count , ref track) ;
                    //track.Pop(); 
                }
                if (b > 0)
                {
                    //track.Push(type.blue); 
                    recursivesolution(r,b-1,ref count , ref track) ;
                    //track.Pop(); 
                }
                
            }
        }
        public static long solution (int n) 
        {
            long count = 0 ; 
            Stack<type> track = new Stack<type>(); 
            recursivesolution(n,n,ref count , ref track) ;
            return count ; 
        } 
    }
}
