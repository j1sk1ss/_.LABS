#include "../include/dict.h"


elem_t* new_elem(char* key, char* value) {
    elem_t* elem = (elem_t*)malloc(sizeof(elem_t));

    elem->key = key;
    elem->value = value;
    elem->next = NULL;

    return elem;
}

int update_elem(elem_t* head, char* key, char* value) {
    elem_t* current = head;
    while (current->next != NULL) {
        // If key found
        if (strcmp(current->key, key) == 0) {
            free(current->value);
            current->value = value;
            break;
        }

        current = current->next;
    }

    return 1;
}

elem_t* get_elem(elem_t* head, char* key) {
    elem_t* current = head;
    while (current->next != NULL) {
        // If key found
        if (strcmp(current->key, key) == 0) {
            return current;
        }

        current = current->next;
    }

    return NULL;
}

int find_elem(elem_t* head, char* key) {
    elem_t* current = head;
    while (current->next != NULL) {
        // If key found
        if (strcmp(current->key, key) == 0) {
            return 1;
        }

        current = current->next;
    }

    return 1;
}

int add_elem(elem_t* head, elem_t* elem) {
    elem_t* current = head;
    while (current->next != NULL) {
        current = current->next;
    }

    current->next = elem;
    return 1;
}

int delete_elem(elem_t* head, char* key) {
    elem_t* prev = head;
    elem_t* current = head;
    while (current->next != NULL) {
        // If key found
        if (strcmp(current->key, key) == 0) {
            prev->next = current->next;
            free(current);
            return 1;
        }

        prev = current;
        current = current->next;
    }

    return 0;
}

int free_elem(elem_t* elem) {
    free(elem->key);
    free(elem->value);
    free(elem);
}
