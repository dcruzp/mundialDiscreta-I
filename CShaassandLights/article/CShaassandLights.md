---
header-includes:
  - \usepackage[ruled,vlined,linesnumbered]{algorithm2e}
---

# CShaassandLights

## Orden del Problema

> ## In Inglish 
>>There are n lights aligned in a row. These lights are numbered 1 to n from left to right. Initially some of the lights are switched on. Shaass wants to switch all the lights on. At each step he can switch a light on (this light should be switched off at that moment) if there's at least one -adjacent light which is already switched on. 
>>
>>He knows the initial state of lights and he's wondering how many different ways there exist to switch all the lights on. Please find the required number of ways modulo 1000000007 (109 + 7).
>>## Input
>>>The first line of the input contains two integers n and m where n is the number of lights in the sequence and m is the number of lights which are initially switched on, (1 ≤ n ≤ 1000, 1 ≤ m ≤ n). The second line contains m distinct integers, each between 1 to n inclusive, denoting the indices of lights which are initially switched on.
>>## Output
>>>In the only line of the output print the number of different possible ways to switch on all the lights modulo 1000000007 (109 + 7).
>
>## En Espanol
>> Hay n luces alineadas en una fila. Estas luces están numeradas del 1 al n de izquierda a derecha. Inicialmente, algunas de las luces están encendidas. Shaass quiere encender todas las luces. A cada paso, puede encender una luz (esta luz debe estar apagada en ese momento) si hay al menos una luz adyacente que ya está encendida.
>>
>>Conoce el estado inicial de las luces y se pregunta cuántas formas diferentes existen de encender todas las luces. Encuentre el número requerido de vías módulo 1000000007 (109 + 7).
>>## Entrada
>>>La primera línea de la entrada contiene dos números enteros nym donde n es el número de luces en la secuencia y m es el número de luces que se encienden inicialmente, (1 ≤ n ≤ 1000, 1 ≤ m ≤ n). La segunda línea contiene m enteros distintos, cada uno entre 1 a n inclusive, que denota los índices de luces que se encienden inicialmente.
>>## Salida
>>>En la única línea de la salida imprima el número de diferentes formas posibles de encender todas las luces módulo 1000000007 (109 + 7).
#### Example 1:
```
Input
3 1
1
Output
1
```
#### Example 2:
```
Input
4 2
1 4
Output
2
```
#### Example 3:
```
Input
11 2
4 8
Output
6720
```


## Solucion

### Propuesta de  Solucion 1

Una solucion al ejercicio es la siguiente: 
  1. Dada una dispocicion inicial, recorriendo las luces alineadas de izquierda a derecha buscar una luz $x$ que se puede ancencer (es decir aquellas que se encuentran con una luz adyacente que este encendida en ese momento)
  2. Encender la luz $x$ y ahora con la nueva diposicion de luces encendidadas volver al punto 1 para contunuar con el procedimiento hasta que las luces esten todad encendidas
  3. Despues apagamos la luz $x$ y seguimos buscando en el array posibles candidatas a ser encendidad y hacer el mismo procedimiento del punto 2  

Esta solucion es trivial y por supuesto que lo que estamos haciendo es probar todas las posiles maneras de encender todas las luces.

<!-- ```console
1. BACKTRAKING (light,n)
2. if n == len(light):
3.    count = count + 1 
4. else
5.     foerach l in light
6.          if l cant swich ON 
7.              l <- ON
8.              BACKTRAKING (light , n+1)
9.              l <- OFF 
``` -->

#### Correctitud
EL algoritmo termina , pues cada vez que se encinde una luz , se procede a analizar las demas luces que quedan con encender y esta luz no se apaga mas hasta que todas hallan sido encendidas , por lo que cada punto que determina encender una luz y se procede a chequear las restantes que quedan por analizar en es dispocicion , esta no se apaga hasta que todas esten encendidas.
Una vez analizada una dispocicion la luz que se encendio en ese punto , se apaga y se procede a analizar las dispociciones de las luces que falta en el recorrido de izquierda a derecha en la fila de luces. Por lo tanto una vez analizada todas las luces para cada instancia nueva que se crea el algoritmo termina y nos retorna la cnatidad de veces donde todad las luces fueron encendidad. 
Esta claro que todas  las disposiciones son analizadas para cada luz que puede ser encendida con una dispocicion inical determinada. 

#### Complejidad Temporal

Esto es la idea basica de un backtraking, por lo tanto es un fuerza bruta y la complejidad temporal del algoritmo es exponencial con respecto a la cantidad de luces apagadas en la dispocicion inicial del algoritmo, o sea la cantidad de luces a encender en total para cada dispocion de luces encendidas

#### Pseudocodigo

@import "algorithms/algorithm1.tex" {cmd =true hide}

#### Codigo en Python

@import "../code/CShaassandLights.py" {class="line-numbers" line_begin=2 line_end=43 code_block=true}

#### Codigo en CSharp

@import "../code/codeinCSharp/Program.cs" {class="line-numbers" line_begin=24 line_end=66 }


### Propuesta de  Solucion 2


```python {cmd=/usr/bin/python3 matplotlib=true}
import matplotlib.pyplot as plt
plt.plot([1,2,3, 4])
plt.show() # show figure
```

<div class="container">
  <div class="child">Bloque sin centrar</div>
</div>

<style>
.container {
  background: #e0e0e0;
  margin: 0 0 1rem;
  height: 10rem;
  display: flex;
  /* align-items por defecto tiene el valor `stretch` */
  align-items: start;
}
.child {
  background: #60e0b0;
  padding: .2rem;
}
</style>



<div class="container center-h center-v">
  <div class="child">
  </div>
  
</div>

<style>
.container {
  background: #e0e0e0;
  margin: 0 0 1rem;
  height: 10rem;
  display: flex;
  /* align-items por defecto tiene el valor `stretch` */
  align-items: start;
}
.center-h {
  justify-content: center;
}
.center-v {
  align-items: center;
}
.child {
  background: #60e0b0;
  padding: .2rem;
}
</style>