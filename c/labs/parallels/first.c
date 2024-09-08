#include "shared/include/matrix.h"

#include <stdio.h>
#include <string.h>
#include <omp.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>


#define OMP_SECTIONS_NUM    2


// SECTIONS
// Разработайте программу для вычисления количества седловых
// элементов в матрице (элементы наименьшие в строке, но наибольшие в
// столбце)
int main(void) {

#pragma region [Matrix setup]

    printf("Type matrix size:\n");

    char x_size[50], y_size[50];
    printf("X: ");
    scanf("%s", x_size);

    printf("Y: ");
    scanf("%s", y_size);

    if (strlen(x_size) > 3 || strlen(y_size) > 3) {
        printf("[WARN] Cols and Rows to large!");
    }

    int x, y;
    x = atoi(x_size);
    y = atoi(y_size);

    matrix_t* matrix = new_matrix(x, y);

    printf("\nOutput matrix:\n");
    matrix->fill_input(matrix);
    matrix->print(matrix);

#pragma endregion

#pragma region [Calculatings]

    int count = 0;
    #pragma omp parallel
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

                        for (int k = 0; k < x; k++) {
                            if (matrix->body[k][j] > current) {
                                is_max_in_col = false;
                                break;
                            }
                        }

                        if (is_max_in_col == true && is_min_in_row == true) {
                            #pragma omp atomic
                            count++;
                        }
                    }
                }
            }

            #pragma omp section
            {
                for (int i = x / OMP_SECTIONS_NUM; i < x; i++) {
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

                        for (int k = 0; k < x; k++) {
                            if (matrix->body[k][j] > current) {
                                is_max_in_col = false;
                                break;
                            }
                        }

                        if (is_max_in_col == true && is_min_in_row == true) {
                            #pragma omp atomic
                            count++;
                        }
                    }
                }
            }
        }
    }

#pragma endregion

    printf("\nAnswer: %i", count);
    free_matrix(matrix);
    return 0;
}
