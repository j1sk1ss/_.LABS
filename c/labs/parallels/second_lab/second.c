// gcc-14 -Wall first_lab/reference.c shared/std/* -fopenmp -o executables/ref
// avg. time: 7.77 seconds on 10000x10000 random matrix (5 times, same random seed)

#include "../shared/include/matrix.h"

#include <stdio.h>
#include <string.h>
#include <omp.h>
#include <stdlib.h>
#include <stdbool.h>


#define RANDOM


// Parallel for in OpenMP
// Разработайте программу для вычисления количества седловых
// элементов в матрице (элементы наименьшие в строке, но наибольшие в
// столбце)
int main(int argc, char* argv[]) {

#pragma region [Matrix setup]

    int x, y;
    if (argc <= 2) {
        printf("Type matrix size:\n");

        char x_size[50], y_size[50];
        printf("X: ");
        scanf("%s", x_size);

        printf("Y: ");
        scanf("%s", y_size);

        if (strlen(x_size) > 3 || strlen(y_size) > 3) {
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

    int count = 0;

    // OpenMP parallel for
    #pragma omp parallel for
    for (int i = 0; i < matrix->x; i++) {
        for (int j = 0; j < matrix->y; j++) {
            int current = matrix->body[i][j];
            bool is_min_in_row = true;
            bool is_max_in_col = true;

            // First we check if element is min in her element
            for (int k = 0; k < matrix->y; k++) {
                if (matrix->body[i][k] < current) {
                    is_min_in_row = false;
                    break;
                }
            }

            // If we already know that this element not target
            // We just skip this part
            if (is_min_in_row) {
                for (int k = 0; k < matrix->x; k++) {
                    if (matrix->body[k][j] > current) {
                        is_max_in_col = false;
                        break;
                    }
                }
            }

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
