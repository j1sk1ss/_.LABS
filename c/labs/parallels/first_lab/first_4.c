// gcc-14 -Wall first_lab/first_4.c shared/std/* -fopenmp -o executables/first2.bin
// avg. time: 23.34 seconds on 100000x100000 random matrix (5 times, same matrix)
// avg. time: 2.55 seconds on 50000x50000 random matrix (5 times, same matrix)
// avg. time: 0.11 seconds on 10000x10000 random matrix (5 times, same matrix)

#include "../shared/include/matrix.h"

#include <stdio.h>
#include <string.h>
#include <omp.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>


#define RANDOM
#define OMP_SECTIONS_NUM 4

// Sections in OpenMP
// Разработайте программу для вычисления количества седловых
// элементов в матрице (элементы наименьшие в строке, но наибольшие в
// столбце)
int main(int argc, char* argv[]) {

#pragma region [Matrix setup]

    matrix_t* matrix = NULL;

    int x = 0, y = 0;
    if (argc < 2) {
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

        matrix = new_matrix(x, y);
#ifndef RANDOM
        matrix->fill_input(matrix);
#else
        matrix->fill_rand(matrix);
#endif

    } else {
        matrix = load_matrix_from_file(argv[1]);
        if (matrix == NULL) return -1;
    }

#pragma endregion

#pragma region [Calculatings]

    int count = 0;
    #pragma omp parallel reduction(+ : count)
    {
        #pragma omp sections
        {
            #pragma omp section
            {
                for (int i = 0; i < x / OMP_SECTIONS_NUM; i++) {
                    for (int j = 0; j < y; j++) {
                        int current = matrix->body[i][j];
                        bool is_min_in_row = true;
                        bool is_max_in_col = true;
                        for (int k = 0; k < y; k++) {
                            if (matrix->body[i][k] < current) {
                                is_min_in_row = false;
                                break;
                            }
                        }

                        if (is_min_in_row)
                            for (int k = 0; k < x; k++) {
                                if (matrix->body[k][j] > current) {
                                    is_max_in_col = false;
                                    break;
                                }
                            }

                        if (is_max_in_col && is_min_in_row) {
                            count++;
                        }
                    }
                }
            }

            #pragma omp section
            {
                for (int i = x / OMP_SECTIONS_NUM; i < (x / OMP_SECTIONS_NUM) * 2; i++) {
                    for (int j = 0; j < y; j++) {
                        int current = matrix->body[i][j];
                        bool is_min_in_row = true;
                        bool is_max_in_col = true;
                        for (int k = 0; k < y; k++) {
                            if (matrix->body[i][k] < current) {
                                is_min_in_row = false;
                                break;
                            }
                        }

                        if (is_min_in_row)
                            for (int k = 0; k < x; k++) {
                                if (matrix->body[k][j] > current) {
                                    is_max_in_col = false;
                                    break;
                                }
                            }

                        if (is_max_in_col && is_min_in_row) {
                            count++;
                        }
                    }
                }
            }

            #pragma omp section
            {
                for (int i = (x / OMP_SECTIONS_NUM) * 2; i < (x / OMP_SECTIONS_NUM) * 3; i++) {
                    for (int j = 0; j < y; j++) {
                        int current = matrix->body[i][j];
                        bool is_min_in_row = true;
                        bool is_max_in_col = true;
                        for (int k = 0; k < y; k++) {
                            if (matrix->body[i][k] < current) {
                                is_min_in_row = false;
                                break;
                            }
                        }

                        if (is_min_in_row)
                            for (int k = 0; k < x; k++) {
                                if (matrix->body[k][j] > current) {
                                    is_max_in_col = false;
                                    break;
                                }
                            }

                        if (is_max_in_col && is_min_in_row) {
                            count++;
                        }
                    }
                }
            }

            #pragma omp section
            {
                for (int i = (x / OMP_SECTIONS_NUM) * 3; i < x; i++) {
                    for (int j = 0; j < y; j++) {
                        int current = matrix->body[i][j];
                        bool is_min_in_row = true;
                        bool is_max_in_col = true;
                        for (int k = 0; k < y; k++) {
                            if (matrix->body[i][k] < current) {
                                is_min_in_row = false;
                                break;
                            }
                        }

                        if (is_min_in_row)
                            for (int k = 0; k < x; k++) {
                                if (matrix->body[k][j] > current) {
                                    is_max_in_col = false;
                                    break;
                                }
                            }

                        if (is_max_in_col && is_min_in_row) {
                            count++;
                        }
                    }
                }
            }
        }
    }

#pragma endregion

    printf("Answer: %i\n", count);
    free_matrix(matrix);
    return 0;
}
