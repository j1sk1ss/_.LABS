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

    for i in congruences:
        x = chinese_remainder(i)
        print("Answer:", x)


def egcd(a, b):
    if 0 == b:
        return 1, 0, a

    x, y, q = egcd(b, a % b)
    x, y = y, (x - a // b * y)

    return x, y, q


def chinese_remainder(pairs):
    mod_list, remainder_list = [p[0] for p in pairs], [p[1] for p in pairs]
    mod_product = reduce(lambda x, y: x * y, mod_list)
    mi_list = [mod_product // x for x in mod_list]
    mi_inverse = [egcd(mi_list[i], mod_list[i])[0] for i in range(len(mi_list))]
    x = 0

    for i in range(len(remainder_list)):
        x += mi_list[i] * mi_inverse[i] * remainder_list[i]
        x %= mod_product

    return x / [p[2] for p in pairs][0]
