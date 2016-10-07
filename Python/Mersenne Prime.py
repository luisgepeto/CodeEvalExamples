import sys
from math import *


def get_mersenne(number):
    return int(pow(2, number) - 1)


def is_prime(number):
    if number == 0 or number == 1:
        return False
    if number == 2 or number == 3:
        return True
    for i in range(2, int(sqrt(number))+1):
        if number % i == 0:
            return False
    return True

with open(sys.argv[1], 'r') as test_cases:
    first_test = True
    for test in test_cases:
        if not first_test: print()
        else: first_test = False
        number = int(test)
        max_mersenne_exponent = int(log(number+1, 2))
        mersenne_primes = []
        for i in range(1, max_mersenne_exponent+1):
            mersenne = get_mersenne(i)
            if mersenne < number and is_prime(mersenne):
                mersenne_primes.append(mersenne)
        print(', '.join(map(str, mersenne_primes)), end="")