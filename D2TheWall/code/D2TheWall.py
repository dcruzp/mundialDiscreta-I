import sys 
import math

MOD = 10**6+3
n=2

fact = [1] * (5* 10**5 + 10) 

for i in range (1,len(fact)):
    fact[i] = (fact[i-1] * i) % MOD

def C(n,k):
    return fact[n] * (pow (fact[k] , MOD -2,MOD)**2) % MOD 

def isprime(n) :
    if n < 4:
        return True 
    for i in range(2,int(math.sqrt(n))+1):
        if n%i == 0 :
            return False
    return True
