// g++-14 -Wall first_lab/first.c shared/std/* -fopenmp -o executables/tar
// avg. time: 91.19 seconds on 10000x10000 random matrix (5 times, same random seed)

#include "../shared/include/matrix.h"

#include <stdio.h>
#include <string.h>
#include <omp.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>


#define RANDOM

// Sections in OpenMP
// Разработайте программу для вычисления количества седловых
// элементов в матрице (элементы наименьшие в строке, но наибольшие в
// столбце)
int main(int argc, char* argv[]) {

#pragma region [Matrix setup]

    int x = 0, y = 0;
    if (argc <= 2) {
        printf("Type matrix size:\n");

        char x_size[50], y_size[50];
        printf("X: ");
        scanf("%s", x_size);

        printf("Y: ");
        scanf("%s", y_size);

        if (strlen(x_size) >= 4 || strlen(y_size) >= 4) {
            printf("[WARN] Cols and Rows to large!\n");
        }

        x = atoi(x_size);
        y = atoi(y_size);
    } else {
        x = atoi(argv[1]);
        y = atoi(argv[2]);
    }

    matrix_t* matrix = new_matrix(x, y);

#ifndef RANDOM
    matrix->fill_input(matrix);
#else
    matrix->fill_rand(matrix);
#endif

#pragma endregion

#pragma region [Calculatings]

    int count = 0, k = 0, m = 0;
    for (int i = 0; i < matrix->x; i++) {
        for (int j = 0; j < matrix->y; j++) {
            int current = matrix->body[i][j];
            bool is_min_in_row = true;
            bool is_max_in_col = true;

            // Num threads are equals 1 cuz compiler optimizпation
            #pragma omp parallel sections private(k, m) num_threads(1)
            {
                #pragma omp section 
                {
                    // This section check that element is minimum in row
                    for (k = 0; k < matrix->y; k++) {
                        if (matrix->body[i][k] < current || !is_max_in_col) {
                            is_min_in_row = false;
                            break;
                        }
                    }
                }

                #pragma omp section 
                {
                    // This section check that element maximum in column
                    for (m = 0; m < matrix->x; m++) {
                        if (matrix->body[m][j] > current || !is_min_in_row) {
                            is_max_in_col = false;
                            break;
                        }
                    }
                }
            }

            // If both states are checked, we add one
            if (is_max_in_col && is_min_in_row) {
                #pragma omp atomic
                count++;
            }
        }
    }

#pragma endregion

    printf("Answer: %i\n", count);
    free_matrix(matrix);
    return 0;
}
