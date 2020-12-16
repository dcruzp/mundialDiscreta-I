# DAlexandJulian

## Orden del Problema
>Boy Dima gave Julian a birthday present - set B consisting of positive integers. However, he didn't know, that Julian hates sets, but enjoys bipartite graphs more than anything else!.
>
>Julian was almost upset, but her friend Alex said, that he can build an undirected graph using this set in such way: let all integer numbers be vertices, then connect any two i and j with an edge if |i−j| belongs to B.
>
>Unfortunately, Julian doesn't like the graph, that was built using B. Alex decided to rectify the situation, so he wants to erase some numbers form B, so that graph built using the new set is bipartite. The difficulty of this task is that the graph, Alex has to work with, has an infinite number of vertices and edges! It is impossible to solve this task alone, so Alex asks you for help. Write a program that erases a subset of minimum size from B so that graph constructed on the new set is bipartite.
>
>Recall, that graph is bipartite if all its vertices can be divided into two disjoint sets such that every edge connects a vertex from different sets.

## Imput
>First line contains an integer n (1⩽n⩽200000) — size of B.
>
>Second line contains n integers b1,b2,…,bn (1⩽bi⩽1018) — numbers of B, all bi are unique.

## Output
>In first line print single integer k – number of erased elements. In second line print k integers – values of erased elements.
>
>If there are multiple answers, print any of them.
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