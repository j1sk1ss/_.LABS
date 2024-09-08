#ifndef MATRIX_H_
#define MATRIX_H_

#include <time.h>
#include <stdlib.h>
#include <stdio.h>


struct Matrix {
    int x;
    int y;
    int** body;

   void (*print)(struct Matrix* matrix);
   void (*fill_rand)(struct Matrix* matrix); 
   void (*fill_input)(struct Matrix* matrix); 
} typedef matrix_t;


void print_matrix(matrix_t* matrix);
void fill_random(matrix_t* matrix);
void input_matrix(matrix_t* matrix);
matrix_t* new_matrix(int x, int y);
void free_matrix(matrix_t* matrix);

#endif