# HBots

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
>>>utput should contain a single integer – number of possible states modulo 109 + 7.
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
>>>La salida debe contener un solo entero: número de estados posibles módulo 109 + 7.

#### Example
>| Input |
>|-------|
>|2      |
>
>|Output |
>|-------|
>|19     |


![Caption](img/image1.png)  

$$\binom{0}{0}$$
$$\binom{1}{0} \hspace{0.5cm} \binom{1}{1}$$
$$\binom{2}{0} \hspace{0.5cm} \binom{2}{1}\hspace{0.5cm} \binom{2}{2}$$
$$\binom{3}{0} \hspace{0.5cm} \binom{3}{1} \hspace{0.5cm} \binom{3}{2} \hspace{0.5cm} \binom{3}{3}$$
$$\binom{4}{0} \hspace{0.5cm} \binom{4}{1} \hspace{0.5cm} \binom{4}{2} \hspace{0.5cm} \binom{4}{3} \hspace{0.5cm} \binom{4}{4}  $$


### Solution 
>El problema nos pide calcualr la cantidad de estados posibles en que se puede encontrar 
>