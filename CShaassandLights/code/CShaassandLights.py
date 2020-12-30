import sys

# contador para sabre la cantidad de formas de encender 
# todas las luces dada una dixposicion inicial  
count = 0  

# i -> indice de la posicion de la luz que se quiere saber si tiene luces adyacentes encendidas
# light -> array de bool donde estan representado los estados de las luces (true -> encendido , false -> apagado)
# returna si la luz que esta en la posicion i tiene luces  adyacentes que estan encendidas 
def cantSwichOn (i,light):
    #verifica que los indices adyacentes no estan fuera del rango en el array light,
    # y en caso de que alguna luz adyacente este encendida entonces retorna true 
    return ((i-1 >=0) and (light[i-1])) or ((i+1 < len(light)) and (light[i+1]))


# light -> array de bool , que me representa el estado de las luces (true -> encendido , false -> apagado)
# n -> es la cantida de luces que estan encendidas en el momento del llamado a la funcion 
# count -> una referencia a una variable global que es el contador de estados finales (en que todas las luces estan encendidas)
def backtraking (light,n):
    global count 

    #si se llega a un estado en el que todas las luces fueron 
    #encendidas entonces se aumenta el contador en 1
    if n == len(light):
        count = count + 1 
    else:    
        #se recorre todo el array y se pregunta por cada una de las luces 
        for i in range (len(light)):
            # si la luz en el array con indice i esta apagada y tiene una luz adyacente encendida
            # entonces la enciendo y vuelvo a llamar el metodo para probar todos los posibles estados 
            # en los que a partir de este punto se encendio la luz con indice i 
            if (not light[i]) and cantSwichOn(i,light):

                # se enciende la luz con indice i 
                light[i] = True 

                # se llama al metodo con las referencias al mismo array  y el contador 
                # aumentandole en 1 la cantidad de luces encendidas
                backtraking (light,n +1 )

                # una vez analizada todos los posibles casos en los que la i-esima luz se 
                # encendio la apago para continuar con el analisis de los casos de la i+1  en adelante
                light[i] = False
                

MOD= 1000000007
fact = [1]*2000
for i in range(1,2000):
    fact[i]=fact[i-1]*i%MOD

n,m = map(int,input().split())
a = sorted(map(int,input().split()))
b = []
for i in range (1,m):
    x=a[i]-a[i-1]-1
    if(x>0):
        b.append(x)

count = pow(2,sum(b)-len(b),MOD)*fact[n-m]%MOD

b = [a[0]-1]+b+[n-a[-1]]
print(b)
for i in b:
	count = count*pow(fact[i],MOD-2,MOD)%MOD

print(count)