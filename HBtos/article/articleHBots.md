# HBots

## Orden del Probema
>Sasha and Ira are two best friends. But they aren’t just friends, they are software engineers and experts in artificial  intelligence. They are developing an algorithm for two bots playing a two-player game. The game is cooperative and turn based. In each turn, one of the players makes a move (it doesn’t matter which player, it's possible that players turns do not alternate).
>
>Algorithm for bots that Sasha and Ira are developing works by keeping track of the state the game is in. Each time either bot makes a move, the state changes. And, since the game is very dynamic, it will never go back to the state it was already in at any point in the past.
>
>Sasha and Ira are perfectionists and want their algorithm to have an optimal winning strategy. They have noticed that in the optimal winning strategy, both bots make exactly N moves each. But, in order to find the optimal strategy, their algorithm needs to analyze all possible states of the game (they haven’t learned about alpha-beta pruning yet) and pick the best sequence of moves.
>
>They are worried about the efficiency of their algorithm and are wondering what is the total number of states of the game that need to be analyzed?

### Input

> The first and only line contains integer N.
> - 1 ≤ N ≤ 106

### Output 
>Output should contain a single integer – number of possible states modulo 109 + 7.

#### Example

>| Input |
>|-------|
>|2      |
>
>|Output |
>|-------|
>|19     |
