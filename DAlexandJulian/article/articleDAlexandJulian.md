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
>>>La segunda línea contiene n enteros b1, b2,…, bn (1⩽bi⩽1018) - números de B, todos bi son únicos.
>>## Salida
>>>En la primera línea, imprima un único entero k - número de elementos borrados. En la segunda línea, imprima k enteros: valores de elementos borrados.
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