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

### Solucion 

### Como calcular el $\binom{n}{k}$ modulo $m$ eficientemente 

Necesitamos calcular $\binom{n}{k}$ modulo $m$  eficientemente. Si vemos en nuestro caso $m = 10^6 + 3$ es un numero primo. Si vemos para valores de $n$ mayores $\binom{n}{k}$ puede ser bastante grande si $k$ se aproxima a $\frac{n}{2}$. Por lo que necesitamo un resultado que nos permita clacular esos valores binomiales modulo $m$.

> **El Pequeno teorema de Fermat (estudiado en clases)**
> Sea  $p$ primo y $a \in \mathbb{Z}$ 
> - Si mcd $\left(a,p\right) =1$ entonces, $a^{p-1} \equiv 1 \left(\mod p \right)$  
> - Para cualquier $a \in \mathbb{Z}^+$ se tiene $a^p \equiv a \left(\mod p\right)$

Pero tenemos que usando los resultados del Pequeno teorema de Fermat podemos obtener el siguiente resultado:

> Sea $p$ primo y a cualquier entero tal que $p \nmid  a$. Entonces, $a^{p-2}$ es el inverso de $a$ modulo $p$
>
> **Demostracion**
> Por el Pequeno Teorema de Fermat tenemos que $a^{p-1} \equiv 1\left(\mod p \right)$ , entonces tenemos que $a \cdot a^{p-2} \equiv 1 \left(\mod p \right)$, ahora sea $\bar{a}$ el inverso de $a$ modulo $p$ entonces $a^{p-2} \equiv \bar{a} \left(\mod p \right)$

El resultado de anterior  lo podemos justificar por el resulado estudiado en clases:
> Si mcd $\left( a, p \right)$ = 1 entonces $a \cdot x \equiv 1 \left(\mod p \right)$ tiene solución única $x = \bar{a}$ módulo $p$.
>
>**Demostracion**
>Tenemos que resolver la congruencia $a\cdot x \equiv 1 \left(\mod m\right)$ es equivalnete a resolver la ecuacion $a\cdot x + m\cdot y = 1$. Como mcd$\left(a,m\right) =1$, existen $s,t \in \mathbb{Z}$ tal que $s\cdot a + t\cdot m = 1$, por lo que tenemos la solucion $x=s$ para la ecuacion $a\cdot~x~\equiv~1~\left(~\mod~m~\right)$ .
> Para la demostracion de la unicidad tenemos que demostrar que si $a\cdot s \equiv 1 $ 