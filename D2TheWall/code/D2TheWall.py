import sys 

MOD = 10**6+3  # el modulo que es un numero primo 
fact = [1] * (7* 10**5 + 10)  #un array de tamano  7* 10**5 + 10 para guaradar los valores del factorial precalculado 

# para calcular el factorial modulo MOD hasta la cuota superior que es 5*10^5 + 2 * 10^5 
for i in range (1,len(fact)):
    fact[i] = (fact[i-1] * i) % MOD

# Calcula el Coeficiente binomico modulo MOD 
def C(n,k):
    return fact[n] * (pow (fact[k] , MOD -2,MOD)*pow (fact[n] , MOD -2,MOD)) % MOD   

def solution(n,C):
    return (C(n+C,C)) -1  # calcular el coeficiente binomico n+c en c y restarle el caso en el que el muro no tiene bloques , que es la s

# def isprime(n) :
#     if n < 4:
#         return True 
#     for i in range(2,int(math.sqrt(n))+1):
#         if n%i == 0 :
#             return False
#     return True
