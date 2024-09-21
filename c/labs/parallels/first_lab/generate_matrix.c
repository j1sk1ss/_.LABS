#include "../shared/include/matrix.h"

#include <stdio.h>
#include <string.h>


int main(int argc, char* argv[]) {
    if (argc < 3) {
        printf("3 arguments!\n");
        return -1;
    }

    matrix_t* matrix = new_matrix(atoi(argv[1]), atoi(argv[2]));
    matrix->fill_rand(matrix);
    save_matrix2file(argv[3], matrix);
}