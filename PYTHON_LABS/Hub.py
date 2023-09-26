from PYTHON_LABS.LABS.CRYPTO.EXTENDED.Extended import Extended

from PYTHON_LABS.LABS.METHODS.FIRST_LAB.First import First
from PYTHON_LABS.LABS.METHODS.SECOND_LAB.Second import Second
from PYTHON_LABS.LABS.METHODS.THIRD_LAB.Third import Third

methods_labs = [
    First(),
    Second(),
    Third()
]

crypto_labs = [
    Extended()
]

while (True):
    crypto_labs[int(input(f'\r\nSelect lab number between 0 and {len(crypto_labs) - 1}: '))].open()
