# D2TheWall

## Orden del Problema
> ## In Inglish
>>Heidi the Cow is aghast: cracks in the northern Wall? Zombies gathering outside, forming groups, preparing their assault? This must not happen! Quickly, she fetches her HC2 (Handbook of Crazy Constructions) and looks for the right chapter:
>>
>> *How to build a wall:*
>>
>> - 1.*Take a set of bricks.*
>>
>> - 2.*Select one of the possible wall designs. Computing the number of possible designs is left as an exercise to the reader.*
>>
>> - 3.*Place bricks on top of each other, according to the chosen design.*
>>
>>This seems easy enough. But Heidi is a Coding Cow, not a Constructing Cow. Her mind keeps coming back to point 2b. Despite the imminent danger of a zombie onslaught, she wonders just how many possible walls she could build with up to n bricks.
>>
>>A *wall* is a set of wall segments as defined in the easy version. How many different walls can be constructed such that the wall consists of at least 1 and at most n bricks? Two walls are different if there exist a column c and a row r such that one wall has a brick in this spot, and the other does not.
>>
>>Along with n, you will be given C, the width of the wall (as defined in the easy version). Return the number of different walls modulo 106 + 3.
>>## Input
>>>The first line contains two space-separated integers n and C, 1 ≤ n ≤ 500000, 1 ≤ C ≤ 200000.
>>## Output
>>>Print the number of different walls that Heidi could build, modulo 106 + 3.
>
>## En Espanol
>>Heidi la vaca está horrorizada: ¿grietas en el muro norte? ¿Zombis reunidos afuera, formando grupos, preparando su asalto? ¡Esto no debe suceder! Rápidamente, busca su HC2 (Manual de construcciones locas) y busca el capítulo correcto:
>>
>> *Cómo construir un muro:*
>>
>> - 1. *Toma un juego de ladrillos.*
>>
>> - 2. *Seleccione uno de los posibles diseños de pared. Calcular el número de diseños posibles se deja como ejercicio para el lector.*
>>
>> - 3. *Coloque los ladrillos uno encima del otro, según el diseño elegido.*
>>
>>Esto parece bastante fácil. Pero Heidi es una vaca codificadora, no una vaca constructora. Su mente sigue volviendo al punto 2b. A pesar del peligro inminente de un ataque zombi, se pregunta cuántas paredes posibles podría construir con hasta n ladrillos.
>>
>>Una pared es un conjunto de segmentos de pared tal como se define en la versión fácil. ¿Cuántos muros diferentes se pueden construir de modo que el muro esté formado por al menos 1 y como máximo n ladrillos? Dos paredes son diferentes si existe una columna cy una fila r de tal manera que una pared tenga un ladrillo en este lugar y la otra no.
>>
>>Junto con n, se le dará C, el ancho de la pared (como se define en la versión fácil). Devuelve el número de paredes diferentes módulo 106 + 3.
>>## Entrada
>>>La primera línea contiene dos números enteros n y C separados por espacios, 1 ≤ n ≤ 500000, 1 ≤ C ≤ 200000.
>>## Salida
>>>Imprime el número de muros diferentes que Heidi podría construir, módulo $10^6 + 3$.






#### Example 1:
```
Imput
5 1
Output
5
```
#### Example 2:
```
Imput
2 2
Output
5
```
#### Example 3:
```
Imput
3 2
Output
9
```
#### Example 4:
```
Imput
11 5
Output
4367
```
#### Example 5:
```
Imput
37 63
Output
230574
```

### Analisis del Problema 

El problema consiste en contruir un muro con a lo sumo $n$ bloques. Y la pregunta es: De cuantas formas se puede construir el muro. O sea contar el numeros de forma con $1~\leq~i~\leq~n$  en que se pueden distribuir $i$ bloques iguales en $C$ columnas diferentes.

Primero vamos a centrarnos en resolver el problema para un $i$ fijo. Es decir poder determinar de cuantas formas podemos ubicar  $i$ bloques iguales en $C$ columnas diferentes.

Vamos a denotar $x_j$ como la cantidad de bloques que hay en la columna $j$ con $1 \leq j \leq C$. y tenemos que $x_j \geq 0$ y ademas se tiene que cumplir que $\sum_{}^{} x_j = i$. Ahora si hacemos la analogia de nuestro problema con el numero de soluciones de la ecuacion:

$$x_1 + \dots + x_C = i$$ 

con $x_j \geq 0$. entonces si le damos solucion a la interrogante entonces podemos tener la solucion a lo que estamos buscando, pues esta claro que es equivalente el analisis (hallar el numero de soluciones enteras de la ecuacion es lo mismo que distribuir $i$ objetos iguales en $C$ casillas  distintas , donde pueden haber casillas vacias)

>En Conferencia vimos (en la $2^{da}$ Conferencia ) que: *El numero formas  de repartir $n$ objetos iguales en $k$ categorias distintas es :*
> $$ \binom{n+k-1}{k-1}$$ 

Por lo tanto tenemos una formula para poder saber la cantidad de muros que se pueden construir con exactamente $i$ bloques. Por lo tanto tendriamos que el numero de muros distintos que se pueden construr con $C$ columnas usando exactamente $i$ bloques es: 

$$\binom {i+C-1}{C-1}$$

Ahora ya tenemos una formula para calcular la cantidad de muros diferentes que se pueden construir de $C$ columnas con exactamente $i$ bloques. 

Pero el ejercicio nos pide determinar el numero total de muros de $i$ bloques con $1\leq i \leq n$. Entonces ahora tenemos que calcular la cantidad total de muros, esto es la suma de todos los muros que se pueden crear para cada $i$ (es decir con una cantida  de exactamente $i$ bloques). Por lo que podemos plantearnos que la cantidad total de muros es:

$$\displaystyle \sum_{i=1}^{n} \binom{i+C-1}{C-1}$$

Ahora vemos que la sumatoria tiene una similitud con la identidad de ....


>El siguiente resultado nos va a ayudar a dar una solucion a nuestro problema. Entonces con el siguiente resultado vamos a deducir una formula para nuestro problema en terminos de combinatoria, y el resultado es el siguiente:
>
>$$\sum_{i=0}^{n} \binom{i+C-1}{C-1} = \binom{n+C}{C} $$
>
> **Demostracion**
> Vamos a hacerlo por induccion en $n$ 
>
>**Caso Base** 
>para $n=0$ tenemos: 
>$$\sum_{i=0}^{n=0} \binom {i+C-1}{C-1} = \binom{C-1}{C-1} = 1 = \binom{C}{C}$$ 
> Luego se cumple para el caso base la igualdad, vamos a suponer ahora que se cumple para un $k$ determinado y vamos a demostrar que se cumple para $k+1$
>
>**Paso Inductivo**
>Ahora tenemos que para un $k$ la desigualdad se cumple, por lo tanto tenemos que: 
>$$\sum_{i=0}^{k+1} \binom{i+C-1}{C-1} = \sum_{i=0}^{k} \binom{i+C-1}{C-1} + \binom{k+1+C-1}{C-1}$$
>pero sabemos por hipotesis de induccion que:
>$$\sum_{i=0}^{k} \binom{i+C-1}{C-1}  = \binom{k+C}{C}$$
>Luego, tenemos entonces que: 
>$$\sum_{i=0}^{k+1} \binom{i+C-1}{C-1} = \binom{k+C}{C} + \binom{k+C}{C-1}$$
>Luego en conferencia vimos la siguiente popiedad que cumplen los coheficientes binomicos, y es que: 
>$$\binom{n}{k} = \binom{n-1}{k} + \binom{n-1}{k-1}$$
>Por lo tanto tenemos que si sustituimos y tenemos en cuenta todos los pasos  y demostraciones anteriores:
> $$\sum_{i=0}^{k+1} \binom{i+C-1}{C-1} = \binom{\left(k+1\right)+C}{C}$$
> Por lo tanto hemos demostrado que para cualquier $k$ se cumple la igualdad. Entonces se cumple en general que:
>$$\sum_{i=0}^{n} \binom{i+C-1}{C-1} = \binom{n+C}{C}$$

Pero una de las restricciones del problema es que el muro tiene que tener al menos un bloque (o sea que $1\leq i \leq n$). Pero tenemos una forma de calcular todos los posibles muros incluyendo los que no tienen bloque (o sea $i=0$) por el resultado anterior.

Entonces podemos deducir lo siguiente usando las demostraciones que hemos visto: 

$$\sum_{i=0}^{n} \binom{i+C-1}{C-1} = \binom{C-1}{C-1} + \sum_{i=1}^{n} \binom{i+C-1}{C-1}$$

Pero el caso $\binom{C-1}{C-1}$ es el caso en el que $i=0$ (es decir que el muro no contiene bloques ) y para nustra solucion debemos quitar esa opcion de todas las posibles (que el muro no tenga ningun bloque). Entonces: 

$$\binom{n+C}{C} =  \binom{C-1}{C-1} + \sum_{i=1}^{n} \binom{i+C-1}{C-1}$$

Luego tenemos entonces que se cumple que: 

$$\sum_{i=1}^{n} \binom{i+C-1}{C-1} = \binom{n+C}{C} - \binom{C-1}{C-1}$$

$$\sum_{i=1}^{n} \binom{i+C-1}{C-1} = \binom{n+C}{C} - 1$$

Entonces con el resultado enterior nos reduce el problema de calcular la cantidad de muros que se pueden hacer de $C$ columnas y $n$ bloques al calculo del coeficiente binomico:

$$\binom{n+C}{C} - 1$$

Las restricciones del problema nos dice que $n$ es un valor que puede ser grande $1~\leq~n~\leq~500000$ y $C$ tambien puede ser grande  $1~\leq~C~\leq~200000$ . Por lo tanto calcular $\binom{n+C}{C} - 1$ puede ser algo costoso en terminos computacionales para un $n$ y un $k$ relativamente grande. Entonces

Como calcular el coeficiente binomico eficientemente. Para esto vamos a usar algunos resultados vistos en Teoria de numeros 

### Como calcular el $\binom{n}{k}$ modulo $m$ eficientemente 

Necesitamos calcular $\binom{n}{k}$ modulo $m$  eficientemente. Si vemos en nuestro caso $m = 10^6 + 3$ es un numero primo. Si vemos para valores de $n$ grandes, $\binom{n}{k}$ puede ser un numero bastante grande si $k$ se aproxima a $\frac{n}{2}$. Por lo que necesitamo un resultado que nos permita calcular esos valores binomiales modulo $m$ eficientemente. 

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

Entonces con los resultados vistos sabemos que  tenemos que calcular el coeficiente binomial:

$$\binom {n+C}{C} = \frac{\left(n+C\right)!}{n!\cdot C!}$$

Entonces usando los resultados de teoria de numeros podemos calcular el factorial de todos los numeros menores que $700010$ (una cuota superior a $n+C$), modulo $10^6+3$ con complejidad temporal lineal usando un array para ir guadando los resultados.

Dado que $10^6+3$ es un numero primo y el calculo de cualquier numero factorial modulo $10^6+3$ es un numero menor que  $10^6+3$ entonces podemos afirmar lo siguiente por los resultados de teoria de numero vistos de Teoria de numeros 

$$\bar{n!} \equiv {(n!)}^{10^6+3 - 2}\left(\mod 10^6+3  \right)$$
lo mismo podemos plantear para $C!$ , es decir :
$$\bar{C!} \equiv {(C!)}^{10^6+3 - 2}\left(\mod 10^6+3  \right)$$

Luego calcular $\binom{n+C}{C}$ modulo $10^6+3$  es equivalente a calcular : 

$$\left( n+C \right)!  \cdot {(n!)}^{10^6+3 - 2}\cdot {(C!)}^{10^6+3 - 2} \left(\mod 10^6+3  \right)$$

Luego usando este resultado es facil calcular el coeficiente binomico que nos plantea la solucion al problema.

### Codigo

#### Codigo en Python

@import "../code/D2TheWall.py" {class="line-numbers" line_begin=0 line_end=16}

#### Codigo en CSharp