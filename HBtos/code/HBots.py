import sys

#PROPUESTA DE SOLUCION 1

count = 0 # un contador para ir contando los estados

# r -> el numero de pasos a la izquierda que se puedan dar todavia (o sea cuantos pasos me puedo mover con el bot rojo )
# b -> el numero de pasos a la derecha que se pueden dar todavia (o sea cuantos pasos me puedo mover con el bot azul )
def backtraking (r , b ):
    global count  #declarando el contador global (que la variable sea global)
    if r == 0 and b == 0: # si ya no se pueden dar mas  pasos  es porque estamos en un estado final y por lo tanto se aumenta el contador  
        count = count + 1 
    else:
        count = count + 1 #aumento el contador pues, si el algoritmo llega aqui es porque r > 0 o porque  b > 0 
        if r > 0 :  # si estoy en el caso en el que r > 0 entonce me muevo a un nuevo estado con el bor rojo (es decir a la izquierda)
            backtraking (r-1,b)
        if b > 0 :  # si estoy en el caso en el que b > 0 entonce me muevo a un nuevo estado con el bor azul (es decir a la derecha)
            backtraking (r,b-1)

# n -> el numero de pasos que pueden dar como maximo los bots
def solBacktraking(n):
    global count 
    count = 0   # pongo la variable del contador de estados en cero 
    backtraking(n,n)  # llamo a la funcion recursiva en los valores iniciales (esto seria con n pasos por dar a la izquierda y con n pasos a dar a la derecha )
    return count 

#PROPUESTA DE SOLUCION 2

MOD = 10**9+7  # declarando una variable para tener el modulo
fact = [1]*(2*10**6+5)  # declaro un array de longitud mayor que 2*10^6 +2 donde voy a tener el factorial previamente calculado modulo  10^9+7 

for i in range(1,len(fact)): # recorro todos los valores de array fact y calculo el factorial de un numero y lo guardo en el indice (para despues poder acceder a el en O(1))
    fact[i] = (fact[i-1]* i)% (MOD)  # el factiral de i es el factorial de i-1 por i , y me quedo con el su modulo 10^9+7 

# me devuelve n en k  (en este caso n-k = k , por lo que solo elevo al cuadrado )
# n cantidad de objetos 
# k tamano de los subconjuntos 
def C(n,k): 
    return (fact[n] * pow(fact[k], MOD - 2 , MOD)**2) % MOD

if __name__ == "__main__":
    n = int(input())
    print (C(2*n+2 , n+1) -1 )

    #print(solBacktraking(n))

