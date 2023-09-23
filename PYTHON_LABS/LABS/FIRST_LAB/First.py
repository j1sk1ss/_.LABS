import math

import calendar

from PYTHON_LABS.LABS.FIRST_LAB.OBJECTS.Point import Point
from PYTHON_LABS.LABS.Quest import Quest


class First(Quest):
    def __init__(self):
        super().__init__([
            first_task,
            second_task,
            third_task
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
