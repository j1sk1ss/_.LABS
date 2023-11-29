from PYTHON_LABS.LABS.CRYPTO.EXTENDED.Extended import Extended

from PYTHON_LABS.LABS.DISCRET.FIRST_LAB.First import First as FirstDiscret

from PYTHON_LABS.LABS.METHODS.FIRST_LAB.First import First as FirstMethods
from PYTHON_LABS.LABS.METHODS.SECOND_LAB.Second import Second as SecondMethods
from PYTHON_LABS.LABS.METHODS.THIRD_LAB.Third import Third as ThirdMethods

methods_labs = [
    FirstMethods(),
    SecondMethods(),
    ThirdMethods()
]

crypto_labs = [
    Extended(),
]

discret_labs = [
    FirstDiscret()
]

while True:
    discret_labs[int(input(f'\r\nSelect lab number between 0 and {len(discret_labs) - 1}: '))].open()
