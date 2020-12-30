---
# [HBots](https://codeforces.com/problemset/problem/575/H)
title: "HBots"
author: "Daniel de la Cruz Prieto"
date: "76767"
output: html_document 
---
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

## Solucion 

>El problema nos pide calcualr la cantidad de estados posibles en que se puede encontrar en un momento determinado los dos bots 
> - En cada estado solo un bot puede caminar (o sea, en un momento determinado solo un bot puede hacer un movimiento ), es decir los dos no se pueden mover en un estado determinado, al mismo tiempo. 
>
> - cada bot puede hacer exactamente n movimientos.
>
>El problema es  encontrar la cantidad de  estados posibles (es decir sin importar la cantidad de pasos que hallan dados cada bots,siempre y cuando cada bot no de mas de $n$ pasos) , determinar de cuantas formas se pueden hacer esos movimientos. 
>
> Vamos a denotar un estado $E$. Luego si tenemos dos bots (un bot rojo (r) y otro azul (b)). Entonces en cada estado $E$ tenemos dos posibilidades
> - o movernos con el bot rojo (r)
> -  o movernos con el azul (b).
>
>Entonces para cada estado tenemos dos posibilidades.
>Podemos interpretar los movimientos apoyandonos en los coeficientes binomicos . Para esto vamos a interpretar de forma grafica los posibles movimientos de cada bot en un estado determinado, para esto vamos a ver la analogia con el Triangulo de Pascal para poder llevar nuestro problema a terminos y definiciones combinatorias y solucionarlo desde el punto de vista matematico usando los resultados vistos en el curso de Matematica Discreta. 

Primero vamos a ver una solucion que no es combinatoria pero que es valida, porque es totalmete correcta, lo que no eficiente, pues lleva un calculo computacional muy elevado , y su complejidad temporal es exponencial 



### Propuesta de Solucion 1

Una solucion valida (y que creo que se le ocurre a todo el mundo) es probar todos los posibles estados , haciendo un backtraking y contando todos los posibles estados. Esta solucion es valida , pore no factible dadod el gran numero de operaciones que hay que hacer, y computacionalmente inviable, pues el numero de llamados recursivos es grade cuando el $n$ es relativamente grande. Y es costo computacional es exponencial, dado que por cada estado hay dos posiblidades de hacer movimientos y generar dos nuevos estados a analizar.Esta claro que la complejidad temporal es exponencial. Si cada bot puede dar a lo sumo $n$ pasos entonces entre los dos pueden dar a lo sumo $2n$ pasos. Entonces el arbol de estados que se forma tiene una profundidad de $2n$ niveles. y como por cada estado se generan $2$ nuevos estados entonces de un nivel a otro se multiplica por dos el numero de estados. Entonces podemos deducir una formula para el numero de estados para un $n$ de la entrada determinado. Entonces la formula es 

$$\sum_{i=0}^{2n} 2^i = 2^{2n}-1$$

Luego esta claro que el numero de operaciones a realizar es exponencial con respecto a $n$. Por lo que un algoritmo que use esta via es exponencial su complejidad temporal

Podemos hacer una poda en el backtraking para no analizar los estados que ya no cumpalan con el requisito de que cada bot de a lo sumo $n$ pasos. Pero el algoritmo va a seguir siendo igual de ineficiente para nuestro caso, pues n es demasiado grande. y el numero de estados a analizar va a seguir siendo grande. Por el resultado que obtuvimos arriba el numero de estados validos  a analizar para un $n$ determinado es $ \binom{2n+2}{n+1} -1$. Lo que hace nuestra proposicion ineficiente es la cantidad de llamados recursivos y el gasto enorme de recursos de la computadora para dar el resultado.

Aqui voy a poner una implementacion de un algoritmo backtraking que usa una poda para no analizar los estados que no cumplan que los bots puedan dar a lo sumo $n$ pasos cada uno .

La figura siguiente muestra los estados analizados por el algoritmo para un $n=2$, en gris los nodos que son validos y en negro los vertices que se podaron (que son los vertices que no cumplen que cada bot camine a lo sumo 2 pasos)

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure12.tex" {cmd = true hide=true  }

</div>

aqui podemos ver que la cantidad de nodos validos es 19 , por lo que. En los estados que estan en negro es porque en el instante es que el algoritmo determina moverse a un estado en negro es porque no cumple que cada bot de a lo sumo mas de dos movimientos , por lo tanto esos estados se podan en el algoritmo, pues no seran validos en nuestra respuesta.
### Implementacion de la Propuesta de Solucion 1  

##### Codigo en Python

@import "../code/HBots.py"{class="line-numbers" line_begin=4 line_end=25  }

##### Codigo en C#

@import "../code/codeinCSharp/Program.cs" {class="line-numbers" line_begin=18 line_end=53 }


### Propuesta de Solucion 2

En el sigiente grafico vamos a ver como podemos estudiar los posibles estados para ver como podemos estudiarlo usando los coeficientes binomicos.

 Vamos a ver el caso en el que los bots solo pueden dar 2 pasos cada uno. y despues vemos el caso general

Para el caso en que los dos pueden dar 2 pasos cada una , vamos a ver un grafico en el que se muestra el comportamiento para determinados estados (haciendo por un arbol)

#### Comienzo 
> Un estado inicial, donde tenemos un solo estado (A), desde donde partimos (todavia no se han hecho movimientos).

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure0.tex" {cmd =true hide =true  }

</div>

#### Turno 1 
> Desde el estado inicial tenemos dos posibilidades, movernos con el bot rojo, o movernos con el bot azul, por lo que se nos adicionan dos estados mas , uno en el que nos movimos con el bot rojo  desde el estado A hasta el estado B, y otro en el que nos movemos con el bot azul desde el estado A hasta el estado B.

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure1.tex" {cmd =true hide =true }

</div>

#### Turno 2
> Despues puedemos hacer un movimiento mas con cada bot. Por lo que desde el estado B podriamos movernos con el bot rojo o con el azul, y lo mismo desde el estado C. Lo que nos crea cuatro nuevos estado (D,E,F,G).

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure4.tex" {cmd =true hide =true  }

</div>

#### Turno 3

> Ahora tenemos cuatro estados desde los que podemos tomar deciciones (D,E,F,G) y se nos forman 8 nuevos estados (H,I,J,K,L,M,N,O) . pues por cada estado tenemos dos posibilidades , y si partimos desde cuatro estados distintos entonces se nos forman ocho nuevos estados

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure5.tex" {cmd =true hide=true  }

</div>

>Pero si nos damos cuenta, en el tercer turno, cuando se determino moverse a un estado H nos movimo usando el bot rojo , pero cada robot puede dar a lo sumo 2 pasos, y en el estado H hemos dado tres pasos con el bot rojo, por lo tanto ese movimiento no es valido, luego en un juego donde cada bot puede dar a lo sumo 2 paso no puede haber un estado H. Igua pasa en el paso de estado del G al O.
>
>Por lo tanto los estados validos para el tercer turno son los que se presentan a continuacion

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure6.tex" {cmd =true hide= true }

</div>

#### Turno 4

> luego en el ultimo turno solo tendremos seis estados mas, donde se cumple que cada uno de los bot camina exactamente dos veces. Por lo tanto tenemos el siguiente formato de estados. Donde en total tenemos 19 estados. En la figura se muestran los posibles estados.

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure7.tex" {cmd =true hide = true }

</div>

### Similitud con el Triangulo de Pascal

Si analizamos el esquema sigiente podemos ver que todos los caminos que llevan a estados que son finales (donde cada bot camina exactamente n pasos )quedan representados en el esquema siguiete desde A hasta M. Donde en cada estado se determina moverse a la derecha (linea azul) , o la izquierda (linea roja).

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure14.tex" {cmd=true hide = true}

</div>

Aqui vemos que todos los posibles caminos del **Turno 4** estan representados en la figura. y van desde el estado **A** hasta el estado **M**

Cada uno de los estados en gris son estados validos para los cuales los bots no han dedo mas de 2 pasos. Ahora nuestro objetivo es determinar en cuantos posibles estados que sean validos pueden estar los bots en un momento determinado

Pero si vemos que la cantidad de caminos posibles partiendo desde **A** hasta cada uno de los estados es la cantidad de estados en que los bots se pueden encontrar en un momento determinado.

En el ejemplo para n=2 en la figura los posibles caminos que tenemos son:

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure8.tex" {cmd =true hide = true }

</div>

Podemos ver que la cantidad de caminos desde **A** hasta un estado determinado coincide con los numeros en la distribucion del Triangulo de Pascal. Como se ve en la figura siguiente:

<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure2.tex" {cmd = true hide=true }

</div>

Luego como lo que nos interesa es determinar la cantidad de caminos que hay hasta un estado determinado partiendo desde el estado inicial (estado A). Pero los valores en el triangulo de Pascal te da la cantidad de caminos hasta una posicion determinada.

Por lo tanto lo que nos interesa es la suma de los estados posibles en cada uno de los camino valido. Para el caso n=2 seria lo siguiente:


<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure13.tex" {{cmd =true  hide=true }}

</div>


Entonces tendriamos un total de 19 estados posibles:

$$ \displaystyle \binom{0}{0} + \binom{1}{0} +\binom{1}{1} + \binom{2}{0} + \binom{2}{1} + \binom{2}{2} + \binom{3}{1} + \binom{3}{2} +\binom{4}{2}= 19 $$

Si generalizamo entonces tenemos que la formula general para el calculo de todos los posibles estados esta dada por la suma de los numeros combinatorios en el triangulo de Pascal hasta el nivel $2n$ donde cada estado este en un camino donde el numero de pasos a la derecha (bot azul ) y numero e pasos a la izquierda (bot rojo) no exceda a $n$.Entonces la formula para el calculo de todos los pasibles estados hasta un $n$ dado es:

$$\displaystyle \sum_{k = 0}^{n} \sum_{j = 0}^{n} \binom{j+k}{k} $$

Pero podemos simplificar el calculo. Dado que hay propiedades de los binomios que nos permiten hacer menos calculos en terminos de sumatoria. Vamos a usar la propiedad de los binomios conocida como [Christmas Stocking Theorem](https://mathworld.wolfram.com/ChristmasStockingTheorem.html). O tambien conocida como [Hockey-Stick Identity](https://artofproblemsolving.com/wiki/index.php/Combinatorial_identity) entre otras que hay en la literatura . La cual dice lo siguiente: que $\forall \hspace{0.2cm}r,n \in \mathbb{N}$ con $n>r$

$$ \sum_{i=r}^{n} \binom{i}{r} =  \binom{n+1}{r+1}$$

#### Demostracion 
Vamos a hacer la demostracion por induccion en $n$
>**Caso Base:**
>El caso base es cuando $n=r$,entonces tenemos lo siguiente:
> $$\sum_{i=r}^{n} \binom{i}{r}= \sum_{i=r}^{r}\binom{i}{r} = \binom{r}{r} = 1 = \binom{r+1}{r+1}$$
>Luego para $n=r$ se cumple la igualdad.
>
>**Paso Inductivo**
>Vamos a demostrar ahora que si se cumple para algun $k \in \mathbb{N}$, con $k>r$. Es decir que se cumpla que:
$$ \sum_{i=r}^{k} \binom{i}{r} = \binom{k+1}{r+1}$$
>Entonces si desarrollamos la sumatoria tenemos que se cumple que: 
>$$\sum_{i=r}^{k+1} \binom{i}{r} = \left(\sum_{i=r}^{k}\binom{i}{r}\right) + \binom{k+1}{r} = \binom{k+1}{r+1} +\binom{k+1}{r}$$
>Pero sabemos que una de las propiedades (que estudiamos en calses)que cumplen los binomios es:
>$$\binom{n}{k} = \binom{n-1}{k-1} + \binom{n-1}{k}$$
>Luego usando esta propiedad nos queda que:
>$$\sum_{i=r}^{k+1} \binom{i}{r} = \left(\sum_{i=r}^{k}\binom{i}{r}\right) + \binom{k+1}{r} = \binom{k+2}{r+1}$$
>Entonces hemos demostrado por induccion que si se cumple para un $k$ entonces se cumple para $k+1$. Por lo tanto hemos demostrado que:
>$$ \sum_{i=r}^{n} \binom{i}{r} =  \binom{n+1}{r+1}$$

<!-- Sabemos que se cumple que:

$$\displaystyle \sum_{k = 0}^{n} \sum_{j = 0}^{n} \binom{j+k}{k} = \sum_{j = 0}^{n} \sum_{k = 0}^{n} \binom{j+k}{k} $$ -->

Entonces usando la propiedad que demostramos arriba , que para estar a corde con nuestra demostracion se puede escribir de la siguiente manera:

$$ \sum_{j=0}^{n}\binom{j+k}{k}= \binom{n+k+1}{k+1}$$



Igual se pude deducir la siguiente  identidad si se toma un $j$ fijo y corremos el valor de $k$. Esta se puede deducir a partir de la propiedad de los binomios vistos en clase $\binom{n}{k} = \binom{n}{n-k}$.Por lo tanto la identidad siguiente tambien es valida.Y se deduce de forma analoga a la que demostramos anteriormente.

$$ \sum_{k = 0}^{n} \binom{j+k}{k} = \binom{n+j+1}{j+1}$$

<!-- $$ \sum_{j = 0}^{n} \binom{j+k}{k} = \binom{n+k+1}{k+1}$$ -->


para un $j$ fijo, en la figura siguiente  se muestra para el caso $n=2$ y con $j=1$. Viendo una representacion visual del traingulo de pascal las identidades que estamos viendo (la sumatoria en azul y el valor del coeficiente binomico de la derecha de la igualdad en rojo )


<div style="text-align: center">
<div>  </div>

@import "tikzpictures/figure11.tex" {cmd =true hide =true }

</div>

Luego podemos deducir una forma general para calcular lo que estamos buscando, usando los resultados vistos hasta el momento:

$$\displaystyle \sum_{k = 0}^{n} \sum_{j = 0}^{n} \binom{j+k}{k} =  \displaystyle \sum_{k = 0}^{n} \binom{n+k+1}{k+1}$$

Pero podemos plantear lo siguiente usando los resultados obtenidos, los cuales no alteran los resultados anteriores y obtenemos las igualdades siguiente:

$$\sum_{k = 0}^{n} \binom{n+k+1}{k+1} = \sum_{k=0}^{n+1}\binom{n+k}{k} - \binom{n}{0} = \binom{2n+2}{n+1} - \binom{n}{0}$$

Luego obtenemos una forma cerrada en forma binomica para la formula que queremos calcular por lo que podemos dar nustra solucion de la siguiete manera:

$$\displaystyle \sum_{k = 0}^{n} \sum_{j = 0}^{n} \binom{j+k}{k} = \binom{2n+2}{n+1} - 1$$


Por lo tanto nuestra solucion se reduce al calcular el coeficiente binomico $\binom{2n+2}{n+1} - 1$ el cual es el numero de estados en que se pueden encontrar los bot en un momento dado sin que ninguno de los dos hayan dado mas de $n$ pasos


### Solucion Computacional

La soluion comptacional tiene cierto grado de dificultad, dado que hay que que computar un numero grade pues si tenemos en cuenta que $1 \leq N \leq 10^6$. entonces el valor de $\binom{2n+2}{n+1}$ puede ser bastante grande para valores de $n>100$ .

Pero tenemos que el resultado podemos expresarlo modulo $10^9+7$. Esto nos puede facilitar los grades volumenes de calculo su usamos  resultados de *Teoria de numeros* , dado que podemos trabajar con los modulos de las operaciones y el valor del calculo nunca va a ser mayor que $10^9+7$. Esto es  correcto, por resultados estudiados en *Teoria de numeros*.


### Como calcular $\binom{n}{k}$ modulo $m$ eficientemente

Necesitamos calcular $\binom{n}{k}$ modulo $m$  eficientemente. Si vemos en nuestro caso $m~=~10^9~+~7$ es un numero primo. Si vemos para valores de $n>100$, el valor de $\binom{n}{k}$ puede ser un numero bastante grande si $k$ se aproxima a $\frac{n}{2}$. Por lo que necesitamo un resultado que nos permita calcular esos valores binomiales modulo $m$ eficientemente. 

> **El Pequeno teorema de Fermat (estudiado en clases)**
> Sea  $p$ primo y $a \in \mathbb{Z}$ 
> - Si mcd $\left(a,p\right) =1$ entonces, $a^{p-1} \equiv 1 \left(\mod p \right)$  
> - Para cualquier $a \in \mathbb{Z}^+$ se tiene $a^p \equiv a \left(\mod p\right)$

Pero tenemos que usando los resultados del Pequeno teorema de Fermat podemos obtener el siguiente resultado:

> Sea $p$ primo y a cualquier entero tal que $p \nmid  a$. Entonces, $a^{p-2}$ es el inverso de $a$ modulo $p$
>
> **Demostracion**
> Por el Pequeno Teorema de Fermat tenemos que $a^{p-1} \equiv 1\left(\mod p \right)$ , entonces tenemos que $a \cdot a^{p-2} \equiv 1 \left(\mod p \right)$, ahora sea $\bar{a}$ el inverso de $a$ modulo $p$ entonces $a^{p-2} \equiv \bar{a} \left(\mod p \right)$

El resultado anterior lo podemos justificar por el resulado estudiado en clases:
> Si mcd $\left( a, p \right)$ = 1 entonces $a \cdot x \equiv 1 \left(\mod p \right)$ tiene solución única $x = \bar{a}$ módulo $p$.
>
>**Demostracion**
>Tenemos que resolver la congruencia $a\cdot x \equiv 1 \left(\mod m\right)$ es equivalente a resolver la ecuacion $a\cdot x + m\cdot y = 1$. 
>***existencia***
Como mcd$\left(a,m\right) =1$, existen $s,t \in \mathbb{Z}$ tal que $s\cdot a + t\cdot m = 1$, por lo que tenemos la solucion $x=s$ para la ecuacion $a\cdot~x~\equiv~1~\left(~\mod~m~\right)$ Estos resultado los estudiamos en Conferencia .
***unicidad***
> Para la demostracion de la unicidad tenemos que demostrar que si $a~\cdot~s~\equiv~1~\left(\mod m\right)$  y $a~\cdot~s^{'}~\equiv~1~\left(\mod m\right)$ , entonces $s \equiv~s^{'}~\left(~\mod~m~\right)$. Para  ver que la solucion es unica modulo $m$, supongamos que $a\cdot s^{'} \equiv 1  \left( \mod m\right)$, luego restando tenemos $a(s-s^{'}) \equiv 0 \left(\mod m\right)$ de donde $m \vert a(s-s^{'})$, pero como el mcd $\left(a,m\right)=1$ entonces $m \vert (s-s^{'})$ de donde obtenemos que $s \equiv s^{'} \left( \mod m \right)$
>
>Luego podemos concluir que si mcd $\left( a, p \right)$ = 1 entonces $a \cdot x \equiv 1 \left(\mod p \right)$ tiene solución única $x = \bar{a}$ módulo $p$.

Luego con estos resultados entonces podemos calcular de forma eficiente $\binom{n}{k}$. Entonces la solucion eficente de nuestro problema usando resultados de *Combinatoria* y *Teoria de Numero* la resolvemo computacionalmente usando solo multiplicacion y division de numeros menores que $10^9+7$ . La solucion es la siguiente:

##### Codigo en Python

@import "../code/HBots.py" {class="line-numbers" line_begin=28 line_end=39}

##### Codigo en C#

@import "../code/codeinCSharp/Program.cs" {class="line-numbers" line_begin=56 line_end=94}

### Complejidad temporal

Lo primero que tenemos que hacer es calcular el factorial , pero ya vimos que podemos calcular el factorial multiplicando por le resultado previamente calculado modulo $10^9+7$ y guardandolo en un array de longitud no mucho mas grande que $2n$ , el resultado , esto se puede hacer en un simple recorrido , por lo que la complejidad temporal de esto es lineal.

Para calcular el coeficiente binomico con el array de factorial previamente calculado es simplemente multiplicar $n!$ por el inverso de $(n-k)!$  por el inverso de  $k!$ modulo $10^7+9$. Ya vimos que podemos calcular el inverso modulo $10^9+7$ elevendo a $10^9+7 - 2$ modulo $10^9+7$. Esto pude ser un poco costoso pues $10^9+7 - 2$  puede ser bastante costos, pero como estamos calculando todo modulo $10^9+7$ entonces podemos tomar la misma idea que utilizamos para calcular el factorial, por lo tanto  el costo seria lineal. Vamos a utilizar metodos ya implementados en las bibliotecas de python y de C# (esta claro que estas biblotecas son mucho mas eficientes que un oden lineal pues existen algunos algoritmos que disminuyen esta cuota,, aunque no se exactamente cual algoritmo utilizan , me imagino  deben ser bastante eficientes o por lo menos mas que un orden lineal , estos algoritmos de elevar a la potencia un numero modulo otro numero no lo voy a ver aqui ). En general , el orden del algoritmo es lineal es decir $O\left(n\right)$.

### Codigo Completo

#### En Python 

@import "../code/HBots.py" {class="line-numbers"}

#### En CSharp 

@import "../code/codeinCSharp/Program.cs" {class="line-numbers"}
