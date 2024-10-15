#include "../../shared/include/matrix.h"

#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>
#include <string.h>
#include <time.h>


#define HEIGHT  6
#define WIDTH   6


matrix_t* rotate_matrix(matrix_t* grid);
matrix_t* encrypt(char* message, matrix_t* grille);
char* decrypt(matrix_t* grid, matrix_t* grille, int message_len);
int main(int argc, char* argv[]);

matrix_t* grille;


matrix_t* rotate_matrix(matrix_t* grid) {
    matrix_t* rotated = new_matrix(HEIGHT, WIDTH);
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
            rotated->body[j][HEIGHT - 1 - i] = grid->body[i][j];
        }
    }

    return rotated;
}

void print_message_iterations(matrix_t* grid, matrix_t* grille, int message_len) {
    matrix_t* rot_grille = copy_matrix(grille);
    int message_index = 0;
    for (int turn = 0; turn < 4; turn++) {
        printf("Iretaion %i:\n", turn + 1);
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                if (rot_grille->body[i][j] == 1 && message_index < message_len) {
                    printf("%c\t", grid->body[i][j]);
                    message_index++;
                }
                else {
                    printf("-\t");
                }
            }

            printf("\n");
        }

        matrix_t* temp_grille = rotate_matrix(rot_grille);
        free_matrix(rot_grille);
        rot_grille = temp_grille;
    }

    free_matrix(rot_grille);
}

matrix_t* encrypt(char* message, matrix_t* grille) {
    matrix_t* rot_grille = copy_matrix(grille);
    matrix_t* grid = new_matrix(HEIGHT, WIDTH);
    int message_index = 0;

    for (int turn = 0; turn < 4; turn++) {
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                if (rot_grille->body[i][j] == 1 && message_index < strlen(message)) {
                    grid->body[i][j] = message[message_index];
                    message_index++;
                }
            }
        }

        matrix_t* temp_grille = rotate_matrix(rot_grille);
        free_matrix(rot_grille);
        rot_grille = temp_grille;
    }

    srand(time(0));
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
            if (grid->body[i][j] == '\0') {
                grid->body[i][j] = rand() % 128;
            }
        }
    }

    free_matrix(rot_grille);
    return grid;
}

char* decrypt(matrix_t* grid, matrix_t* grille, int message_len) {
    matrix_t* rot_grille = copy_matrix(grille);
    char* decrypted_message = (char*)malloc(message_len);
    int message_index = 0;

    for (int turn = 0; turn < 4; turn++) {
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                if (rot_grille->body[i][j] == 1 && message_index < message_len) {
                    decrypted_message[message_index] = grid->body[i][j];
                    message_index++;
                }
            }
        }

        matrix_t* temp_grille = rotate_matrix(rot_grille);
        free_matrix(rot_grille);
        rot_grille = temp_grille;
    }

    free_matrix(rot_grille);
    return decrypted_message;
}

int main(int argc, char* argv[]) {
    grille = new_matrix(HEIGHT, WIDTH);

    grille->body[0][1] = 1;
    grille->body[0][3] = 1;
    grille->body[3][1] = 1;

    char user_input[128] = { '\0' };
    scanf("%s", user_input);

    matrix_t* encrypted_grid = encrypt(user_input, grille);
    encrypted_grid->print(encrypted_grid, "%c\t");

    print_message_iterations(encrypted_grid, grille, strlen(user_input));

    char* decrypted_message = decrypt(encrypted_grid, grille, strlen(user_input));
    printf("Decrypted: %s\n", decrypted_message);
    free(decrypted_message);
}
