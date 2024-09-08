from collections import Counter

from PYTHON_LABS.LABS.METHODS.FIRST_LAB.OBJECTS.Point import Point
from PYTHON_LABS.LABS.Quest import Quest
from PYTHON_LABS.LABS.METHODS.SECOND_LAB.OBJECTS.SECOND_TASK.Matrix import Matrix


class Second(Quest):
    def __init__(self):
        super().__init__([
            first_task,
            second_task,
            third_task,
            fourth_task
        ])


# Дано множество A из N точек (N > 2, точки заданы своими координатами x, y).
# Найти такую точку из данного множества, сумма расстояний от которой до
# остальных его точек минимальна, и саму эту сумму.
def first_task():
    points = []
    for i in range(0, int(input('N: '))):
        points.append(Point(int(input('X: ')), int(input('Y: '))))

    sums = []
    for point in points:
        summary = 0
        for second_point in points:
            if second_point == point:
                continue

            summary += point.distance(second_point)

        sums.append({
            "Point": len(sums),
            "Sum of dist": summary
        })

    print(max(sums, key=lambda x:x['Sum of dist']))


# Дана матрица размера M × N. Элемент матрицы называется ее локальным
# минимумом, если он меньше всех окружающих его элементов. Заменить все
# локальные минимумы данной матрицы на нули. При решении допускается
# использовать вспомогательную матрицу.
def second_task():
    matrix = Matrix(5, 5)
    print('\nOld matrix:')
    matrix.print()

    print('\nNew matrix:')
    matrix.find_and_replace_local_minimums()
    matrix.print()


# Дана квадратная матрица порядка M. Обнулить элементы матрицы, лежащие
# одновременно ниже главной диагонали (включая эту диагональ) и ниже побочной
# диагонали (также включая эту диагональ). Условный оператор не использовать.
def third_task():
    matrix = Matrix(5, 5)
    print('\nOld matrix:')
    matrix.print()

    print('\nNew matrix:')
    matrix.zero_diagonals()
    matrix.print()


# Дан текст: в первой строке записано количество строк в тексте, а затем сами
# строки. Выведите все слова, встречающиеся в тексте, по одному на каждую строку.
# Слова должны быть отсортированы по убыванию их количества появления в
# тексте, а при одинаковой частоте появления — в лексикографическом порядке.
def fourth_task():
    with open('/Users/nikolaj/PycharmProjects/_.LABS/PYTHON_LABS/LABS/SECOND_LAB/FILES/FOURTH_TASK/text.txt') as f:
        lines = f.readlines()
        raw_words = []
        for line in lines:
            raw_words.extend(line.split(sep=' '))

        word_count = Counter(raw_words)
        sorted_words = sorted(word_count.items(), key=lambda x: (-x[1], x[0]))

        for word, count in sorted_words:
            print(word)