import time


def timing_decorator(func):
    def wrapper(*args, **kwargs):
        start_time = time.time()
        result = func(*args, **kwargs)

        print(f"Function time: {func.__name__}: {time.time() - start_time} seconds")
        return result

    return wrapper
