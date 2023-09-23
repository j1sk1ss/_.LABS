from PYTHON_LABS.LABS.FIRST_LAB.First import First

labs = [
    First()
]

while (True):
    labs[int(input(f'\r\nSelect lab number between 0 and {len(labs) - 1}: '))].open()
