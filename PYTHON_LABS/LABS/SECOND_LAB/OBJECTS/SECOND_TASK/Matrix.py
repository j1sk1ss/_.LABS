import random


class Matrix:
    body = []

    def __init__(self, height, width):
        self.height = height
        self.width = width

        for i in range(height):
            line = []
            for j in range(width):
                line.append(random.randint(-5, 20))

            self.body.append(line)

    def zero_diagonals(self):
        for i in range(self.height):
            for j in range(self.width):
                if i >= j:
                    self.body[i][j] = 0

    def find_and_replace_local_minimums(self):
        for i in range(self.height):
            for j in range(self.width):
                neighbors = [
                    self.body[max(0, i - 1)][j], self.body[min(i + 1, self.height - 1)][j],
                    self.body[i][max(0, j - 1)], self.body[i][min(j + 1, self.width - 1)],

                    self.body[max(0, i - 1)][max(0, j - 1)], self.body[min(i + 1, self.height - 1)][min(j + 1, self.width - 1)],
                    self.body[min(i + 1, self.height - 1)][max(0, j - 1)], self.body[max(0, i - 1)][min(j + 1, self.width - 1)],
                ]

                if self.body[i][j] <= min(neighbors):
                    self.body[i][j] = 0

    def sub_matrix(self, x1, y1, x2, y2):
        sub_body = [[]]
        for i in range(x1, x2):
            line = []
            for j in range(y1, y2):
                line.append(self.body[i][j])

            sub_body.append(line)

    def minimum(self):
        minimum = 0
        for line in self.body:
            for element in line:
                minimum = min(minimum, element)

        return minimum

    def print(self):
        for line in self.body:
            print(*line, sep=', ')
