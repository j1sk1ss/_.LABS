#ifndef MATRIX_H_
#define MATRIX_H_

#include <time.h>
#include <stdlib.h>
#include <stdio.h>
#include <omp.h>
#include <string.h>


struct Matrix {
    int x;
    int y;
    uint8_t** body;

   void (*print)(struct Matrix* matrix);
   void (*fill_rand)(struct Matrix* matrix);
   void (*fill_input)(struct Matrix* matrix);
} typedef matrix_t;


matrix_t* new_matrix(int x, int y);
matrix_t* copy_matrix(matrix_t* matrix);

void print_matrix(matrix_t* matrix);
void fill_random(matrix_t* matrix);
void input_matrix(matrix_t* matrix);
void free_matrix(matrix_t* matrix);

matrix_t* load_matrix_from_file(char* save_path);
int save_matrix2file(char* save_path, matrix_t* matrix);

#endif
