from PYTHON_LABS.LABS.Quest import Quest
from functools import reduce


class Extended(Quest):
    def __init__(self):
        super().__init__([
            first_task
        ])


group_number = 21

first_a = group_number + 3 * 1
second_a = group_number + 3 * 2
third_a = group_number + 3 * 3


def first_task():
    congruences = [[(first_a, 3, 1),
                   (second_a, 5, 1),
                   (third_a, 7, 1)],

                   [(first_a, 4, 2),
                   (second_a, 5, 1),
                   (third_a, 9, 1)],

                   [(first_a, 3, 3),
                   (second_a, 5, 1),
                   (third_a, 9, 1),
                   (first_a, 4, 4),
                   (second_a, 5, 1),
                   (third_a, 11, 1)],

                   [(first_a, 4, 5),
                   (second_a, 7, 1),
                   (third_a, 11, 1)],

                   [(first_a, 3, 6),
                   (second_a, 5, 1),
                   (third_a, 11, 1)],

                   [(first_a, 13, 7),
                   (second_a, 5, 1),
                   (third_a, 7, 1)]]

    for congruence in congruences:
        x = chinese_remainder(congruence)
        if x is not None:
            # Print the answer in the "x = n mod d" format
            n, d = x, congruence[0][1]  # Assuming the first modulus in the congruence list
            print(f"x = {n} mod {d}")
        else:
            print("No solution for congruence:", congruence)


# Recursive function to calculate the greatest common divisor (GCD)
def gcd(a, b):
    if b == 0:
        return a

    return gcd(b, a % b)


# Extended Euclidean Algorithm to find modular multiplicative inverse
def extended_gcd(a, b):
    if a == 0:
        return b, 0, 1
    else:
        g, x, y = extended_gcd(b % a, a)
        return g, y - (b // a) * x, x


# Chinese Remainder Theorem evaluation for a list of congruences
def chinese_remainder(congruences):
    n = len(congruences)
    a = [cong[0] for cong in congruences]
    m = [cong[1] for cong in congruences]

    # Calculate the product of all moduli
    M = 1
    for mi in m:
        M *= mi

    result = 0
    for i in range(n):
        # Calculate m_i
        mi = M // m[i]
        # Calculate the modular multiplicative inverse of mi modulo m[i]
        _, _, inv = extended_gcd(mi, m[i])
        # Add to the result
        result += a[i] * mi * inv

    # Ensure the result is non-negative by taking the modulo of M
    result = result % M

    return result
