# import sys 

# count = 0

# def backtraking (r , b ):
#     global count 
#     if r == 0 and b == 0:
#         count = count + 1 
#     else:
#         count = count + 1 
#         if r > 0 : 
#             backtraking (r-1,b)
#         if b > 0 :
#             backtraking (r,b-1)

# def combination ( n , k):
#     if n == k :
#         return 1
#     elif k==1 :
#         return n  
#     return combination(n-1,k) % (10**9 +7 )+ combination(n-1,k-1) % (10**9 +7 )


# def solutionCombinatoric (n):
#     return combination(2*n+2 , n+1) - 1 

# def solutionRecursive (n):
#     global count 
#     count = 0 
#     backtraking(n,n)
#     return count 


# def tester ():
    
#     for n in range(2,12):
       
#         print(solutionCombinatoric(n))
#         print (solutionRecursive(n))
#         print("---------------------")


# tester() 


import math


def combination ( n , k):
    if n == k :
        return 1
    elif k==1 :
        return n  
    return combination(n-1,k) % (10**9 +7 )+ combination(n-1,k-1) % (10**9 +7 )

def solutionCombinatoric (n):
    return combination(2*n+2 , n+1) - 1 

def othersolution (n):
    count = 1
    for i in range (n+2 , 2*(n+1)+1):
        count = (count *i) % (10**9 +7) 

    fact = 1 
    for i in range (1,(n+1)+1):
        fact = (fact * i) % (10**9 + 7)   

    return count // fact -1 


#other solutions 

binomios = []

def init (n):
    for i in range (n):
        aux = [] 
        for j in range(i+1):
            aux.append(-1)
        binomios.append(aux)   
    binomios[0][0] = 1 


def printbinomios ():
    for item in binomios:
        print(item)

def coeficientbinomico (n,k):
    if n < 0 or k < 0 :
        return 0 
    elif n==k or n==0:
        return 1 
    else :
        if  binomios[n][k] == -1:
            result = coeficientbinomico(n-1,k-1) % (10**9+7) + coeficientbinomico(n-1,k)% (10**9+7)
            binomios[n][k] = result
            binomios[n][n-k] = result 
        return binomios[n][k]

def optsolution (n):
    init(2*n+2 +1 )
    result = coeficientbinomico(2*n+2,n+1)
    return result -1 

MOD = 10**9+7 
fact = [1]*(2*10**6+5)

for i in range(1,len(fact)):
    fact[i] = (fact[i-1]* i)% (MOD)

if __name__ == "__main__":
    #n = int(input())
    #print(solutionCombinatoric(n))
    #print(othersolution(n))
    
    print(combination(6,3))

    #init(10)
    
    #printbinomios() 

    #print(coeficientbinomico(6,3))

    #print(optsolution(n))

    print(fact[:10]) 