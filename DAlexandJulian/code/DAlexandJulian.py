n = int(input()) # leo de la entrada  a n 
a= list (map(int, input.split())) # leo de la entrada a los b_i 

# Esto es para saber la cantidad de numeros que tiene en su descomposicion i como potencia de dos en su descomposicion
# o sea b[i] es la cantidad de numeros que tienen a i como potencia de dos en su descompocicion  (es < 100 ) porque 2**99 es un numero mayor que 10**18
b = [0]*100

# para saber el la potencia de dos en su descomposicion prime (de modo que c[i] es la potencia de dos
# que tiene el i esimo elemento en el array de entrada)
c = [0]*n

# es la potencia de dos que mayor cantidad de numeros de los b_i tiene en su descomposicion  
p = 0 

# hao un for por todos los elementos de la entradaa 
for i in  range(n):
    aux= a[i]
    count = 0 # contador para saber la potencia de dos en la factorizacion de a[i]

    # hago un ciclo hasta que ya no se pueda dividor por dos para saber la potencia de 
    # dos en la factorizacion de a[i]
    while(aux%2==0):
        count = count + 1 
        aux //=2

    b[count] += 1 # sumo en una unidad la cantidad de numeros que tienen una potencia de dos igual a count 
    c[i] = count # en al array c en la posicion del elemento i que petenece al elemento a[i] pongo su potencia de 2 en su descomposicion 

# hago un for por b para saber cual es la potencia de dos que tienen en su descomposicion mas elemetos de los b_i 
# y pongo en p el indice , o sea la potencia de dos  que mas se repite  entre los b_i 
for i in range(100):
    if b[i] > b[p] : 
        p = i 

# imprimo la cantidad de elemntos que no tiene a p como potencia de 2 en su factorizacion         
print(n -b[p])

# y por ultimo imprimo los elementos de la entrad que  no tiene a p como potencia de dos en su descomposicion 
print(*[a[i] for i in range(n) if c[i]!=p])