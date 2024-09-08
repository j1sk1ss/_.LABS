#include "../include/matrix.h"


matrix_t* new_matrix(int x, int y) {
    int** matrix_raw = (int**)malloc(x * sizeof(int*));
    #pragma omp parallel for
    for (int i = 0; i < x; i++) {
        matrix_raw[i] = (int*)malloc(y * sizeof(int));
        for (int j = 0; j < y; j++) {
            matrix_raw[i][j] = 0;
        }
    }

    matrix_t* matrix = (matrix_t*)malloc(sizeof(matrix_t));
    matrix->body = matrix_raw;
    matrix->x = x;
    matrix->y = y;

    matrix->print = print_matrix;
    matrix->fill_rand = fill_random;
    matrix->fill_input = input_matrix;

    return matrix;
}

void print_matrix(matrix_t* matrix) {
    for (int i = 0; i < matrix->x; i++) {
        for (int j = 0; j < matrix->y; j++) {
            printf("%i\t", matrix->body[i][j]);
        }

        printf("\n");
    } 
}

void fill_random(matrix_t* matrix) {
    srand(time(0)); 
    #pragma omp parallel for
    for (int i = 0; i < matrix->x; i++) {
        for (int j = 0; j < matrix->y; j++) {
            matrix->body[i][j] = rand() % 100; 
        }
    }
}

void input_matrix(matrix_t* matrix) {
    printf("Input matrix %i %i\n", matrix->x, matrix->y);
    for (int i = 0; i < matrix->x; i++) {
        for (int j = 0; j < matrix->y; j++) {
            printf("Element %i %i: ", i, j);

            char input[25];
            scanf("%s", input);

            matrix->body[i][j] = atoi(input); 
        }
    }
}

void free_matrix(matrix_t* matrix) {
    free(matrix->body);
    free(matrix);
}