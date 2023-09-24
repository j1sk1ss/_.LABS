from PYTHON_LABS.LABS.FIRST_LAB.OBJECTS.Point import Point
from PYTHON_LABS.LABS.THIRD_LAB.CLASSES.Vector import Vector
from PYTHON_LABS.LABS.THIRD_LAB.DECORATORS.Timer import timing_decorator
from PYTHON_LABS.LABS.Quest import Quest


class Third(Quest):
    def __init__(self):
        super().__init__([
            first_task,
            second_task,
            third_task,
            fourth_task
        ])


# Написать функцию выделения уникальных чисел из переданного
# ей кортежа чисел (функция должна возвращать список из уникальных чисел).
def first_task():
    numbers_tuple = (1, 2, 2, 3, 4, 4, 5)
    print(f'Unique: {list(set(numbers_tuple))}')


# Написать функцию-генератор для формирования
# последовательности простых чисел, начиная с числа 1
def second_task():
    primes = []
    num = 2

    maximum = int(input('Maximum: '))

    while True:
        is_prime = True

        for prime in primes:
            if prime * prime > num:
                break

            if num % prime == 0:
                is_prime = False
                break

        if is_prime:
            primes.append(num)
            if len(primes) >= maximum:
                break

        num += 1

    print(f'Primes: {primes}')


# Напишите декоратор для оценки времени вычислений функций
# из заданий своего варианта. И оцените время выполнения функций с его
# помощью.
@timing_decorator
def third_task():
    number = 0
    for i in range(10000):
        for j in range(100):
            number += i * j - j - i


# Написать класс Vector для работы с векторами на плоскости. В
# классе реализовать дескрипторы для задания начальной и конечной
# координат, а также переопределить операторы для сложения, скалярного
# умножения и сравнения (== и !=) двух векторов. Прописать геттер,
# возвращающий текущие координаты вектора.
def fourth_task():
    first_vector = Vector(Point(0, 0), Point(1, 0))
    second_vector = Vector(Point(0, 0), Point(2, 2))

    vector_add = first_vector + second_vector
    vector_sub = first_vector - second_vector
    vector_mul = first_vector * second_vector
    vector_eq = first_vector == second_vector

    print(f'\nAdd: \n{vector_add.print()}\n\nSub: \n{vector_sub.print()}\n\nMul: \n{vector_mul.print()}\n\nEq: \n{vector_eq}')

