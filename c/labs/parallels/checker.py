import argparse
import subprocess
import time

from statistics import mean 


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description='Work bot')
    parser.add_argument('--path', required=True, help='Path to exucatable')
    parser.add_argument('--arg', nargs='+', action='append', metavar='args', help='Arguments for programm')
    parser.add_argument('--count', required=True, help='Iteration count')
    return parser.parse_args()


def measure_execution_time(path: str, args: list[str]) -> None:
    start_time = time.time()
    try:
        subprocess.run([path, *args], check=True)
    except subprocess.CalledProcessError as e:
        print(f"Ошибка при выполнении программы: {e}")
        return
    
    end_time = time.time()
    return end_time - start_time


if __name__ == "__main__":
    args = parse_args()
    print("\nAverage time:", mean([measure_execution_time(args.path, args.arg[0]) for i in range(int(args.count))]))
    