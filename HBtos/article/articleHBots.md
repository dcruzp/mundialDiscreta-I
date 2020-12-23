# [HBots](https://codeforces.com/problemset/problem/575/H)
-----------------------------------------------------------
## Orden del Probema

> ## In Inglish 
>>Sasha and Ira are two best friends. But they aren’t just friends, they are software engineers and experts in artificial  intelligence. They are developing an algorithm for two bots playing a two-player game. The game is cooperative and turn based. In each turn, one of the players makes a move (it doesn’t matter which player, it's possible that players turns do not alternate).
>>
>>Algorithm for bots that Sasha and Ira are developing works by keeping track of the state the game is in. Each time either bot makes a move, the state changes. And, since the game is very dynamic, it will never go back to the state it was already in at any point in the past.
>>
>>Sasha and Ira are perfectionists and want their algorithm to have an optimal winning strategy. They have noticed that in the optimal winning strategy, both bots make exactly N moves each. But, in order to find the optimal strategy, their algorithm needs to analyze all possible states of the game (they haven’t learned about alpha-beta pruning yet) and pick the best sequence of moves.
>>
>>They are worried about the efficiency of their algorithm and are wondering what is the total number of states of the game that need to be analyzed? 
>>## Input
>>
>>> The first and only line contains integer N.
>>> - 1 ≤ N ≤ 106
>>### Output 
>>>utput should contain a single integer – number of possible states modulo $10^9 + 7$.
>>
>## En Espanol
>>Sasha e Ira son dos mejores amigos. Pero no son solo amigos, son ingenieros de software y expertos en inteligencia artificial. Están desarrollando un algoritmo para dos bots que juegan un juego de dos jugadores. El juego es cooperativo y por turnos. En cada turno, uno de los jugadores hace un movimiento (no importa qué jugador, los turnos del jugador no pueden alternar).
>>
>>El algoritmo para los bots que Sasha e Ira están desarrollando funciona al realizar un seguimiento del estado en el que se encuentra el juego. Cada vez que cualquiera de los bots hace un movimiento, el estado cambia. Y, dado que el juego es muy dinámico, nunca volverá al estado en el que ya estaba en ningún momento del pasado.
>>
>>Sasha e Ira son perfeccionistas y quieren que su algoritmo tenga una estrategia ganadora óptima. Han notado que en la estrategia ganadora óptima, ambos bots realizan exactamente N movimientos cada uno. Pero, para encontrar la estrategia óptima, su algoritmo necesita analizar todos los estados posibles del juego (todavía no han aprendido sobre la poda alfa-beta) y elegir la mejor secuencia de movimientos.
>>
>>Están preocupados por la eficiencia de su algoritmo y se preguntan cuál es el número total de estados del juego que deben analizarse.
>>## Entrada
>>>La primera y única línea contiene el entero N.
>>>
>>> - 1 ≤ N ≤ 106
>>## Salida
>>>La salida debe contener un solo entero: número de estados posibles módulo $10^9 + 7$.

#### Example

```console
Input
2
Output
19
```

<!-- 
$$\binom{0}{0}$$
$$\binom{1}{0} \hspace{0.5cm} \binom{1}{1}$$
$$\binom{2}{0} \hspace{0.5cm} \binom{2}{1}\hspace{0.5cm} \binom{2}{2}$$
$$\binom{3}{0} \hspace{0.5cm} \binom{3}{1} \hspace{0.5cm} \binom{3}{2} \hspace{0.5cm} \binom{3}{3}$$
$$\binom{4}{0} \hspace{0.5cm} \binom{4}{1} \hspace{0.5cm} \binom{4}{2} \hspace{0.5cm} \binom{4}{3} \hspace{0.5cm} \binom{4}{4}  $$ -->


### Solucion 
>El problema nos pide calcualr la cantidad de estados posibles en que se puede encontrar en un momento determinado los dos bots 
> - En cada estado solo un bot puede caminar (o sea, en un momento determinado solo un bot puede hacer un movimiento ), es decir los dos no se pueden mover en un estado determinado, al mismo tiempo. 
>
> - cada bot puede hacer exactamente n movimientos.
>
>El problema es  encontrar la cantidad de  estados posibles (es decir sin importar la cantidad de pasos que hallan dados cada bots,siempre y cuando cada bot no de mas de $n$ pasos) , determinar de cuantas formas se pueden hacer esos movimientos. 
>
> Vamos a denotar un estado $E$. Luego si tenemos dos bots (un bot rojo (r) y otro azul (b)). Entonces en cada estado $E$ tenemos dos posibilidades
> - (o movernos con el bot rojo (r))
> -  o movernos con el azul (b)).
>
>Entonces para cada estado tenemos dos posibilidades.
>Podemos interpretar los movimientos apoyandonos en los coeficientes binomicos . Para esto vamos a interpretar de forma grafica los posibles movimientos de cada bot en un estado determinado, para esto vamos a ver la analogia con el Triangulo de Pascal para poder llevar nuestro problema a terminos y definiciones combinatorias y solucionarlo desde el punto de vista matematico usando los resultados vistos en el curso de Matematica Discreta. 

En el sigiente grafico vamos a ver como podemos estudiar los posibles estados para ver como podemos estudiarlo usando los coeficientes binomicos.

 Vamos a ver el caso en el que los bots solo pueden dar 2 pasos cada uno. y despues vemos el caso general

Para el caso en que los dos pueden dar 2 pasos cada una , vamos a ver un grafico en el que se muestra el comportamiento para determinados estados (haciendo por un arbol).

#### Comienzo 
> Un estado inicial, donde tenemos un solo estado (A), desde donde partimos (todavia no se han hecho moviminetos ).

@import "tikzpictures/figure0.tex" {cmd = true hide  }


#### Turno 1 
> Desde el estado inicial tenemos dos posibilidades, movernos con el bot rojo, o movernos con el bot azul, por lo que se nos adicionan dos estados mas , uno en el que nos movimos con el bot rojo  desde el estado A hasta el estado B, y otro en el que nos movemos con el bot azul desde el estado A hasta el estado B.


@import "tikzpictures/figure1.tex" {cmd = true}

#### Turno 2
> Despues puedemos hacer un movimiento mas con cada bot. Por lo que desde el estado B podriamos movernos con el bot rojo o con el azul, y lo mismo desde el estado C. Lo que nos crea cuatro nuevos estado (D,E,F,G).

```latex {cmd=true hide=true}
\documentclass{standalone}
\usepackage{tikz}
\usepackage{amsmath}
\usetikzlibrary{matrix}
\usetikzlibrary {shapes.geometric}
\begin{document}
         \begin{tikzpicture}

            %\draw [help lines] (0,0) grid (10,10); 

            \path   (5,10)  node (a) [circle,draw] {A}
                    (3,9) node (b) [circle,draw] {B}
                    (7,9) node (c) [circle,draw] {C}
                    (2,8) node (d) [circle,draw] {D}
                    (4,8) node (e) [circle,draw] {E}
                    (6,8) node (f) [circle,draw] {F}
                    (8,8) node (g) [circle,draw] {G};
                    
                
            \draw[thick,red]  (node cs: name =a ) -- (node cs:name =b);
            \draw[thick,blue] (node cs: name =a ) -- (node cs:name =c);
            \draw[thick,red] (node cs: name =b ) -- (node cs:name =d);
            \draw[thick,blue] (node cs: name =b ) -- (node cs:name =e);
            \draw[thick,red] (node cs: name =c ) -- (node cs:name =f);
            \draw[thick,blue] (node cs: name =c ) -- (node cs:name =g);
            
        \end{tikzpicture}
\end{document}
```

#### Turno 3
> Ahora tenemos cuatro estados desde los que podemos tomar deciciones (D,E,F,G) y se nos forman 8 nuevos estados (H,I,J,K,L,M,N,O). pues por cada estado tenemos dos posibilidades , y si partimos desde cuatro estados distintos entonces se nos forman ocho nuevos estados


```latex {cmd=true hide=true}
\documentclass{standalone}
\usepackage{tikz}
\usepackage{amsmath}
\usetikzlibrary{matrix}
\usetikzlibrary {shapes.geometric}
\begin{document}
         \begin{tikzpicture}

            %\draw [help lines] (0,0) grid (16,16); 

            \path   (8,10)  node (a) [circle,draw] {A}
                    (4,9) node (b) [circle,draw] {B}
                    (12,9) node (c) [circle,draw] {C}
                    (2,8) node (d) [circle,draw] {D}
                    (6,8) node (e) [circle,draw] {E}
                    (10,8) node (f) [circle,draw] {F}
                    (14,8) node (g) [circle,draw] {G}
                    (1,7) node (h) [circle,draw,fill=gray] {H}
                    (3,7) node (i) [circle,draw] {I}
                    (5,7) node (j) [circle,draw] {J}
                    (7,7) node (k) [circle,draw] {K}
                    (9,7) node (l) [circle,draw] {L}
                    (11,7) node (m) [circle,draw] {M}
                    (13,7) node (n) [circle,draw] {N}
                    (15,7) node (o) [circle,draw,fill = gray] {O};

                    
                
            \draw[thick,red]  (node cs: name =a ) -- (node cs:name =b);
            \draw[thick,blue] (node cs: name =a ) -- (node cs:name =c);
            \draw[thick,red] (node cs: name =b ) -- (node cs:name =d);
            \draw[thick,blue] (node cs: name =b ) -- (node cs:name =e);
            \draw[thick,red] (node cs: name =c ) -- (node cs:name =f);
            \draw[thick,blue] (node cs: name =c ) -- (node cs:name =g);
            \draw[thick,black] (node cs: name =d ) -- (node cs:name =h);
            \draw[thick,red] (node cs: name =e ) -- (node cs:name =j);
            \draw[thick,red] (node cs: name =f ) -- (node cs:name =l);
            \draw[thick,red] (node cs: name =g) -- (node cs:name =n);
            \draw[thick,blue] (node cs: name =d ) -- (node cs:name =i);
            \draw[thick,blue] (node cs: name =e ) -- (node cs:name =k);
            \draw[thick,blue] (node cs: name =f) -- (node cs:name =m);
            \draw[thick,black] (node cs: name =g ) -- (node cs:name =o);
            
        \end{tikzpicture}
\end{document}
```

>Pero si nos damos cuenta, en el tercer turno, cuando se determino moverse a un estado H nos movimo usando el bot rojo , pero cada robot puede dar a lo sumo 2 pasos, y en el estado H hemos dado tres pasos con el bot rojo, por lo tanto ese movimiento no es valido, luego en un juego donde cada bot puede dar a lo sumo 2 paso no puede haber un estado H. Igua pasa en el paso de estado del G al O.
>
>Por lo tanto 

<!-- ```python
import abc
``` -->

<!-- ```python {cmd = usr/bin/python3 hide = true}
print('you can see this output message, but not this code')
``` -->

<!-- ```mermaid
stateDiagram
    A -> B
    A -> C

    B -> D
    B -> E
    C -> E
    C -> F 

    D -> H
    D -> I
    E -> I
    E -> J
    F -> J
    F -> K 
``` -->

<!-- 
```mermaid
graph TD
    A((B)) -.-> B((B))
    A((A)) -.-> C((C)) 

    B((B)) -.-> D((D))
    B((B)) -.-> E((E))
    C((C)) -.-> E((E))
    C((C)) -.-> F((F)) 

    D((D)) -.-> H((H))
    E((E)) -.-> J((J))
    E((E)) -.-> I((I))
    D((D)) -.-> J((J))
    F((F)) -.-> K((K))
    F((F)) -.-> I((I))

``` -->


### Codigo en Python

```python {cmd = usr/bin/python3 }
MOD = 10**9+7 
fact = [1]*(2*10**6+5)

for i in range(1,len(fact)):
    fact[i] = (fact[i-1]* i)% (MOD)

def C(n,k):
    return (fact[n] * pow(fact[k], MOD - 2 , MOD)**2) % MOD

if __name__ == "__main__":
    #n = int(input())
    n=2
    print (C(2*n+2 , n+1) -1 )  
```


### Codigo en C#

```CSharp
using System;
using System.Collections.Generic; 

namespace codeinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            System.Console.WriteLine(solution(n));
        }

        public static void recursivesolution (int r , int b , ref long count )
        {
            if (r ==0 && b==0 )
            {
                count += 1 ; 
            }
            else 
            {
                count += 1; 
                if (r > 0)
                {
                    recursivesolution(r-1, b, ref count); 
                }
                if (b > 0)
                {
                    recursivesolution(r,b-1,ref count );
                }
                
            }
        }
        public static long solution (int n) 
        {
            long count = 0 ; 
            recursivesolution(n,n,ref count) ;
            return count ; 
        } 
    }
}
```


```latex {cmd=true hide=true}
\documentclass{standalone}
\usepackage{tikz}
\usepackage{amsmath}
\usetikzlibrary{matrix}
\usetikzlibrary {shapes.geometric}
\begin{document}
    
        \begin{tikzpicture}

            %\draw [help lines] (0,0) grid (10,10); 

            \path   (5,10)  node (a) [circle,draw] {A}
                    (4,9) node (b) [circle,draw] {B}
                    (6,9) node (c) [circle,draw] {C}
                    (3,8) node (d) [circle,draw] {D}
                    (5,8) node (e) [circle,draw] {E}
                    (7,8) node (f) [circle,draw] {F}
                    (2,7) node (g) [circle,draw] {G}
                    (4,7) node (h) [circle,draw] {H}
                    (6,7) node (i) [circle,draw] {I}
                    (8,7) node (j) [circle,draw] {J}
                    (1,6) node (k) [circle,draw] {K}
                    (3,6) node (l) [circle,draw] {L}
                    (5,6) node (m) [circle,draw] {M}
                    (7,6) node (n) [circle,draw] {N}
                    (9,6) node (o) [circle,draw] {O};
                
            \draw[thick,red]  (node cs: name =a ) -- (node cs:name =b);
            \draw[thick,blue] (node cs: name =a ) -- (node cs:name =c);
            \draw[thick,red] (node cs: name =b ) -- (node cs:name =d);
            \draw[thick,blue] (node cs: name =b ) -- (node cs:name =e);
            \draw[thick,red] (node cs: name =d ) -- (node cs:name =g);
            \draw[thick,red] (node cs: name =c ) -- (node cs:name =e);
            \draw[thick,blue] (node cs: name =c ) -- (node cs:name =f);
            \draw[thick,red] (node cs: name =g ) -- (node cs:name =k);
            \draw[thick,blue] (node cs: name =g ) -- (node cs:name =l);
            \draw[thick,blue] (node cs: name =d ) -- (node cs:name =h);
            \draw[thick,red] (node cs: name =h ) -- (node cs:name =l);
            \draw[thick,red] (node cs: name =e ) -- (node cs:name =h);
            \draw[thick,blue] (node cs: name =h ) -- (node cs:name =m);
            \draw[thick,blue] (node cs: name =e ) -- (node cs:name =i);
            \draw[thick,red] (node cs: name =i ) -- (node cs:name =m);
            \draw[thick,blue] (node cs: name =i ) -- (node cs:name =n);
            \draw[thick,red] (node cs: name =f ) -- (node cs:name =i);
            \draw[thick,blue] (node cs: name =f ) -- (node cs:name =j);
            \draw[thick,red] (node cs: name =j ) -- (node cs:name =n);
            \draw[thick,blue] (node cs: name =j ) -- (node cs:name =o);
        \end{tikzpicture}

       
   
\end{document}
```