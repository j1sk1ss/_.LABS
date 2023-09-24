import math

import calendar

from PYTHON_LABS.LABS.METHODS.FIRST_LAB.OBJECTS.Point import Point
from PYTHON_LABS.LABS.Quest import Quest


class First(Quest):
    def __init__(self):
        super().__init__([
            first_task,
            second_task,
            third_task,
            fourth_task,
            fifes_task
        ])


# Даны координаты трех вершин треугольника: (x1, y1), (x2, y2), (x3, y3). Найти
# его периметр и площадь, используя формулу для расстояния между двумя точками на
# плоскости. Для нахождения площади треугольника со сторонами a, b, c использовать
# формулу Герона:
def first_task():
    first_point = Point(10, 10)
    second_point = Point(20, 10)
    third_point = Point(0, 0)

    a = first_point.distance(second_point)
    b = second_point.distance(third_point)
    c = third_point.distance(first_point)

    perimeter = (a + b + c) / 2

    p = perimeter / 2
    square = math.pow((p * (p - a) * (p - b) * (p - c)), 1 / 2)

    print(f'Perimeter is: {perimeter}')
    print(f'Square is: {square}')


# Дано трехзначное число. В нем зачеркнули первую справа цифру и
# приписали ее слева. Вывести полученное число.
def second_task():
    number = input('Write number: ')
    print(f'{number[len(number) - 1:]}{number[:len(number) - 1]}')


# Дан номер года (положительное целое число). Определить количество дней
# в этом году, учитывая, что обычный год насчитывает 365 дней, а високосный — 366 дней.
# Високосным считается год, делящийся на 4, за исключением тех годов, которые делятся
# на 100 и не делятся на 400 (например, годы 300, 1300 и 1900 не являются високосными,
# а 1200 и 2000 — являются).
def third_task():
    print(365 + calendar.isleap(int(input('Year: '))))


# Дано целое число N (> 0). Последовательность вещественных чисел AK
# определяется следующим образом:
def fourth_task():
    max_count = int(input('Set N: '))
    if max_count < 0:
        print('Was set wrong value. Changed to 1')
        max_count = 1

    array = [2]
    for i in range(0, max_count):
        array.append(2 + 1 / array[i])

    print(*array, sep=", ")


# Дано целое число N (> 1). Последовательность чисел Фибоначчи FK
# определяется следующим образом:
# F1 = 1, F2 = 1, FK = FK−2 + FK−1, K = 3, 4, … .
# Проверить, является ли число N числом Фибоначчи. Если является, то вывести
# true, если нет — вывести false.
def fifes_task():
    expected = int(input('Set N: '))
    if expected < 1:
        print('Was set wrong value. Changed to 2')
        expected = 2

    array = [1, 1]
    number = 0
    while number < expected:
        number = array[-2] + array[-1]
        array.append(number)

    if expected in array:
        print(f'{number} in this array')
    else:
        print('This number not exist in array')

