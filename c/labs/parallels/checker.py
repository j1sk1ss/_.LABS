import os
import csv
import time
import argparse
import subprocess

from statistics import mean


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description='Work bot')
    parser.add_argument('--dir', required=True, help='Path to directory with executables')
    parser.add_argument('--args', nargs='+', action='append', metavar='args', help='Groups of arguments for executables')
    parser.add_argument('--count', required=True, help='Iteration count')
    parser.add_argument('--output', required=True, help='Path to output CSV file')
    return parser.parse_args()


def measure_execution_time(path: str, args: list[str]) -> float:
    start_time = time.time()
    try:
        subprocess.run([path, *args], check=True)
    except subprocess.CalledProcessError as e:
        print(f"Error running program: {e}")
        return 0.0

    end_time = time.time()
    return end_time - start_time


def write_to_csv(csv_file: str, data: list[dict]):
    fieldnames = ['executable', 'args', 'execution_time']
    with open(csv_file, mode='w', newline='') as file:
        writer = csv.DictWriter(file, fieldnames=fieldnames)
        writer.writeheader()
        for row in data:
            writer.writerow(row)


if __name__ == "__main__":
    args = parse_args()
    results = []

    for executable in os.listdir(args.dir):
        exec_path = os.path.join(args.dir, executable)
        if os.path.isfile(exec_path) and os.access(exec_path, os.X_OK):
            for arg_group in args.args:
                times = [measure_execution_time(exec_path, arg_group) for _ in range(int(args.count))]
                avg_time = mean(filter(None, times)) if times else None
                if avg_time is not None:
                    results.append({
                        'executable': executable,
                        'args': ' '.join(arg_group),
                        'execution_time': avg_time
                    })
    
    write_to_csv(args.output, results)
    print(f"Results written to {args.output}")
