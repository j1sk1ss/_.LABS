from PYTHON_LABS.LABS.FIRST_LAB.OBJECTS.Point import Point


class Vector:
    def __init__(self, start: Point, end: Point):
        self.start = start
        self.end = end

    def set_start(self, start: Point):
        self.start = start

    def set_end(self, end: Point):
        self.end = end

    def __add__(self, other):
        return Vector(self.start + other.start, self.end + other.end)

    def __sub__(self, other):
        return Vector(self.start - other.start, self.end - other.end)

    def __mul__(self, other):
        return self.start * other.start + self.end * other.end

    def __eq__(self, other):
        return self.start == other.start and self.end == other.end

    def print(self):
        return f'start: {self.start.print()}\nend: {self.end.print()}'