import math


class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def distance(self, point):
        return math.sqrt(math.pow(point.x - self.x, 2) + math.pow(point.y - self.y, 2))

    def __add__(self, other):
        return Point(self.x + other.x, self.y + other.y)

    def __sub__(self, other):
        return Point(self.x - other.x, self.y - other.y)

    def __mul__(self, other):
        return Point(self.x * other.x, self.y * other.y)

    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

    def print(self):
        return f'x: {self.x} | y: {self.y}'

    def __str__(self):
        return f'x: {self.x} | y: {self.y}'
