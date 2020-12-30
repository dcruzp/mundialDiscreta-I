import sys 

MOD = 10**6+3  # el modulo que es un numero primo 
fact = [1] * (7* 10**5 + 10)  #un array de tamano  7* 10**5 + 10 para guaradar los valores del factorial precalculado 

# para calcular el factorial modulo MOD hasta la cuota superior que es 5*10^5 + 2 * 10^5 
for i in range (1,len(fact)):
    fact[i] = (fact[i-1] * i) % MOD

# Calcula el Coeficiente binomico modulo MOD 
def Binom(n,k):
    return (fact[n] * (pow (fact[n-k] , MOD -2,MOD)*pow (fact[k] , MOD -2,MOD)) % MOD)%MOD

# n-> numero total de bloques con los que se pueden armar el muro 
# C-> cantidad de columnas que tiene que tener el muro a construir 
def solution(n,C):
    return (Binom(n+C,C)) -1  # calcular el coeficiente binomico n+c en c y restarle el caso en el que el muro no tiene bloques que es en un caso (por lo tanto se le resta 1 )

if __name__ == "__main__":
    n,c = map(int,input().split())
    print(solution(n,c))