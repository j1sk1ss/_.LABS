from PYTHON_LABS.LABS.FIRST_LAB.First import First
from PYTHON_LABS.LABS.SECOND_LAB.Second import Second
from PYTHON_LABS.LABS.THIRD_LAB.Third import Third

labs = [
    First(),
    Second(),
    Third()
]

while (True):
    labs[int(input(f'\r\nSelect lab number between 0 and {len(labs) - 1}: '))].open()
