# DAlexandJulian

## Orden del Problema

>## In Inglish
>>Boy Dima gave Julian a birthday present - set B consisting of positive integers. However, he didn't know, that Julian hates sets, but enjoys bipartite graphs more than anything else!.
>>
>>Julian was almost upset, but her friend Alex said, that he can build an undirected graph using this set in such way: let all integer numbers be vertices, then connect any two i and j with an edge if |i−j| belongs to B.
>>
>>Unfortunately, Julian doesn't like the graph, that was built using B. Alex decided to rectify the situation, so he wants to erase some numbers form B, so that graph built using the new set is bipartite. The difficulty of this task is that the graph, Alex has to work with, has an infinite number of vertices and edges! It is impossible to solve this task alone, so Alex asks you for help. Write a program that erases a subset of minimum size from B so that graph constructed on the new set is bipartite.
>>
>>Recall, that graph is bipartite if all its vertices can be divided into two disjoint sets such that every edge connects a vertex from different sets.
>>## Imput
>>>First line contains an integer n (1⩽n⩽200000) — size of B.
>>>
>>>Second line contains n integers b1,b2,…,bn (1⩽bi⩽1018) — numbers of B, all bi are unique.
>>## Output
>>>In first line print single integer k – number of erased elements. In second line print k integers – values of erased elements.
>>>
>>>If there are multiple answers, print any of them.
>## En Espanol
>>Boy Dima le dio a Julian un regalo de cumpleaños: el conjunto B que consta de números enteros positivos. Sin embargo, no sabía que Julian odia los conjuntos, ¡pero disfruta de los gráficos bipartitos más que cualquier otra cosa !.
>>
>>Julian estaba casi molesto, pero su amiga Alex dijo que él puede construir un gráfico no dirigido usando este conjunto de tal manera: deje que todos los números enteros sean vértices, luego conecte dos iyj cualesquiera con una arista si | i − j | pertenece a B.
>>
>>Desafortunadamente, a Julian no le gusta el gráfico, que se construyó con B. Alex decidió rectificar la situación, por lo que quiere borrar algunos números de B, de modo que el gráfico construido con el nuevo conjunto sea bipartito. La dificultad de esta tarea es que el gráfico con el que Alex tiene que trabajar tiene un número infinito de vértices y aristas. Es imposible resolver esta tarea solo, por lo que Alex te pide ayuda. Escriba un programa que borre un subconjunto de tamaño mínimo de B para que el gráfico construido en el nuevo conjunto sea bipartito.
>>
>>Recuerde, esa gráfica es bipartita si todos sus vértices se pueden dividir en dos conjuntos disjuntos de modo que cada borde conecte un vértice de conjuntos diferentes.
>>## Entrada
>>>La primera línea contiene un número entero n (1⩽n⩽200000) - tamaño de B.
>>>
>>>La segunda línea contiene n enteros $b_1, b_2,\dots, b_n$$\left(1⩽bi⩽10^{18}\right)$ -números de B, todos los $b_i$ son únicos.
>>## Salida
>>>En la primera línea, imprima un único entero $k$ - número de elementos borrados. En la segunda línea, imprima k enteros: valores de elementos borrados.
>>>
>>>Si hay varias respuestas, imprima cualquiera de ellas.
#### Examples 1:
```
Intput
3
1 2 3
Output
1
2 
```
#### Examples 2:
```
Intput
2
2 6
Output
0
```
$\alpha$

```ditaa {cmd = true}

  +-----+     +-----+
  |hello| --> |world|
  +-----+     +-----+

```

### Solucion 
Si hacemos un analisis del problema tenemos que el grafo que se nos forma tiene una cantidad de nodos y aristas infinito. de tal manera que las aristas unen vertices que son multiplos de los $b_i$ consecutivos. Es decir une vertices de la forma $q\cdot b_i \Leftrightarrow (q+1)b_i$ con $q \geq 0$. Nuestro objetivo es que el grafo sea bipartito. Para que el grafo sea bipartito tiene que existir una forma de particionar los nodos del grafo en dos conjuntos $A$ y $B$ de forma tal que las aristas unan vertices que se encuentran en conjuntos diferentes.

Uno de los resultados vistos en *Teoria de Grafo* es el siguiete:
 **Un grafo es bipartito si solo si no contiene ciclos de longitud impar**
 el cual vamos a usar para dar solucion a nuestro problema. Entonces nustro problema ahora toma otro enfoque. Seria entonces detectar si existen ciclos de longitud impar y tratar de eliminar las condicionantes que nos traigan resultados como la existencia de ciclos de longitud impar en nustre grafo.

 Como detectar entonces en nuestro grafo los ciclos. Si nos damos cuenta podemos ver que por la construccion de nustro grafo las aristas solo unen a vertices que son multiplos consecutivos de algun $b_i$ por lo que si cogemos dos $b_i$ cualesquiera, sean estos $b_i$ y $b_j$ con $i\neq j$ se forma un ciclo de la siguiete forma. Vamos a denotar a $m$ como el minimo comun multiplo de $b_i$ y $b_j$ , $m = mcm(b_i,b_j)$. Entonces $m$ es un vertice del grafo, al cual se puede acceder desde $b_i$ y $b_j$, por lo tanto existe un camino $c_1$que pasa por $m$ que une a $b_i$ con $b_j$, ahora si tomamo al vertice $0$ que tambien pertenece al grafo , entonces podemos tomar la arista  $b_i \leftrightarrow 0$  y la arista   $b_j \leftrightarrow 0$  que tambien petenecen al grafo. Entonces si tomamo el camino que va por $c_1$ desde $b_j$ hasta $m$ , vemos que ese camino tiene longitud $\frac{m}{b_j}-1$, igual si analizamos el camino que va por $c_1$ desde $b_i$ hasta $m$, tiene lomgitud $\frac{m}{b_i}-1$, ahora el ciclo que se nos forma con el camino $c_1$ y las aristas  $b_i \leftrightarrow 0$ y $b_j \leftrightarrow 0$ tiene longitud $\frac{m}{b_i} + \frac{m}{b_j}$

Por resultados vistos en *Teoria de numeros* tenemos que: 

$$mcm\left(a,b\right) = \frac{a\cdot b}{mcd\left(a,b\right)}$$

de donde  se deduce que se cumple la siguiente igualdad: 

$$\frac{mcm\left(a,b\right)}{a} = \frac{b}{mcd\left(a,b\right)}$$

Vamos a denotar ahora  a $a$ y a $b$ que son dos numeros enteros y vamos a denotar ***len*** de la siguiente manera:
$$len  = \frac {mcm\left(a,b\right)}{a}  + \frac {mcm\left(a,b\right)}{b}  = \frac {a}{mcd\left(a,b\right)} + \frac{b}{mcd\left(a,b\right)}$$

> ***len*** es impar si solo si $a$ y $b$ tienen diferente potencia de dos en su factorizacion.
>
> $\Rightarrow$ 
>*Si $\frac{a+b}{mcd\left(a,b\right)}$ es impar entonces $a$ y $b$ contienen distinta potencia de dos en su factorizacion*  
>**Demostracion**
> Vamos a suponer que $\frac{a+b}{mcd\left(a,b\right)}$ es impar y que $a$ y $b$ contiene igual potencia de dos en su factorizacion, vamos a suponer que es $2^{q}$ entonces $a$ y $b$ se descomponen de la siguiente manera : $a = 2^q\left(n\right)$ y $b = 2^q\left(m\right)$ entonces tenemos que como $a$ y $b$ tienen igual potencia de $2$ entonces el $mcd\left(a,b\right) = 2^q\left(p\right)$. Luego entonces podemos plantearnos que :
>
>$$\frac{a+b}{mcd\left(a,b\right)} = \frac{2^q\left(n\right)+ 2^q\left(m\right)}{2^q \left(p\right)} = \frac{2^q\left(n+m\right)}{2^q \left(p\right)} = \frac {m+n}{p}$$
>
>pero tenemos que $m \equiv 1 \left(\mod 2\right)$ y $n\equiv 1 \left(\mod 2\right)$ luego $ 2 \vert \left(n+m\right)$ y como $p\equiv 1 \left(\mod 2\right)$ entonces tenemos que  $ \frac {m+n}{p} = 2 \frac{z}{p}$ entonces hemos encontrado que  $\frac{a+b}{mcd\left(a,b\right)}$  es par . Contradiccion pues habiamos partido de que era impar
>Luego tenemos que si  $\frac{a+b}{mcd\left(a,b\right)}$ es impar entonces $a$ y $b$ contiene diferente potencia de dos en su factorizacion
>
>$\Leftarrow$ 
>*Si $a$ y $b$ contienen distinta potencia de dos en su factorizacion entonces $\frac{a+b}{mcd\left(a,b\right)}$ es impar*
>**Demostracion**
> Supongamos sin perdida de generalidad que $a= 2^p(n)$ y que $b =2^{p+r}(m)$ con $r>0$ entonces tenemos que:
$$a+b = 2^p(n) + 2^{p}2^{r}(m) = 2^p(n+ 2^r(m))$$
Pero ademas sabemos que $mcd\left(a,b\right)$ se puede escribir de la siguiente manera $mcd\left(a,b\right) = 2^p(q)$. Entonces si divimos por $2^p$ ebtenemos que: 
$$\frac{a+b}{mcd\left(a,b\right)}= \frac{2^p(n+ 2^r(m))}{2^p(q)}= \frac{n+ 2^r(m)}{q}$$
Entonces temos que $n+ 2^r(m) \equiv 1 \left(\mod 2\right)$ y que $q\equiv 1 \left(\mod 2\right)$.Entonces tenemos que $z\cdot q = n+ 2^r(m)$. De donde obtenemos que $z\equiv 1 \left(\mod 2\right)$. 
Entonces obtenemos que $z$ es impar.
>Luego podemos concluir que si $a$ y $b$ contienen distinta potencia de dos en su factorizacion entonces $\frac{a+b}{mcd\left(a,b\right)}$ es impar

Entonces tenemos que para que el grafo sea bipartito todos los $b_i$ con $1\leq i \leq n$ tienen que tener igual potencia de dos en su fatorizacion. Entonces como tenemos que borrar un subconjunto de tamano minimo de $B$ tal que el grafo sea bipartito entonces tenemo que encontrar un subconjunto maximo de $B$ donde todos los elementos del subconjunto tengan igual potencia de dos en su factorizacion.

### Codigo

#### codigo en Python

@import "../code/DAlexandJulian.py" 