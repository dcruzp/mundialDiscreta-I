import sys 

count = 0

def solutionRecursive (r , b ):
    global count 
    if r == 0 and b == 0:
        count = count + 1 
    else:
        count = count + 1 
        if r > 0 : 
            solutionRecursive (r-1,b)
        if b > 0 :
            solutionRecursive (r,b-1)


n = 2

solutionRecursive(n,n) 

print(count) 