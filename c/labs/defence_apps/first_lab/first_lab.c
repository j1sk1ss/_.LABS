#include <stdio.h>
#include "snapshot.c"


int main(int argc, char* argv[]) {
    int snap_result = check_snapshot();
    if (snap_result == -1) {
        return 2;
    }
    else if (snap_result == 0) {
        printf("Wrong system!\n");
        return -1;
    }

    char *new_argv[] = {"./cdbms_x86-64", NULL};
    execvp(new_argv[0], new_argv);
}