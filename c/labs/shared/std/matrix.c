#include "../include/matrix.h"


matrix_t* new_matrix(int x, int y) {
    uint8_t** matrix_raw = (uint8_t**)malloc(x * sizeof(uint8_t*));
    #pragma omp parallel for
    for (int i = 0; i < x; i++) {
        matrix_raw[i] = (uint8_t*)malloc(y * sizeof(uint8_t));
        for (int j = 0; j < y; j++) {
            matrix_raw[i][j] = 0;
        }
    }

    matrix_t* matrix = (matrix_t*)calloc(1, sizeof(matrix_t));

    matrix->body = matrix_raw;
    matrix->x = x;
    matrix->y = y;

    matrix->print = print_matrix;
    matrix->fill_rand = fill_random;
    matrix->fill_input = input_matrix;

    return matrix;
}

matrix_t* copy_matrix(matrix_t* matrix) {
    matrix_t* copy = new_matrix(matrix->x, matrix->y);
    for (int i = 0; i < copy->x; i++)
        for (int j = 0; j < copy->y; j++)
            copy->body[i][j] = matrix->body[i][j];

    return copy;
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
            matrix->body[i][j] = rand() % 255;
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
    for (int i = 0; i < matrix->x; i++)
        free(matrix->body[i]);

    free(matrix->body);
    free(matrix);
}

matrix_t* load_matrix_from_file(char* save_path) {
    FILE* file = fopen(save_path, "rb");
    if (file == NULL) {
        printf("Matrix not found at [%s]\n", save_path);
        return NULL;
    }

    // Allocate memory for the matrix structure
    matrix_t* matrix = (matrix_t*)malloc(sizeof(matrix_t));

    // Read the dimensions of the matrix
    fread(&(matrix->x), sizeof(int), 1, file);
    fread(&(matrix->y), sizeof(int), 1, file);

    // Create the matrix with the read dimensions
    matrix->body = (uint8_t**)malloc(matrix->x * sizeof(uint8_t*));
    for (int i = 0; i < matrix->x; i++) {
        matrix->body[i] = (uint8_t*)malloc(matrix->y * sizeof(uint8_t));
    }

    // Read the matrix values
    for (int i = 0; i < matrix->x; i++) {
        fread(matrix->body[i], sizeof(uint8_t), matrix->y, file);
    }

    fclose(file);
    return matrix;
}

int save_matrix2file(char* save_path, matrix_t* matrix) {
    FILE* file = fopen(save_path, "wb");
    if (file == NULL) return -1;

    // Write the dimensions of the matrix first
    fwrite(&(matrix->x), sizeof(int), 1, file);
    fwrite(&(matrix->y), sizeof(int), 1, file);

    // Write the matrix data
    for (int i = 0; i < matrix->x; i++) {
        fwrite(matrix->body[i], sizeof(uint8_t), matrix->y, file);
    }

    fclose(file);
    return 1;
}
