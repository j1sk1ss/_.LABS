#ifndef DICT_H_
#define DICT_H_

#include <stdio.h>
#include <stdlib.h>
#include <string.h>


struct elem {
    uint8_t* key;
    uint8_t* value;

    struct elem* next;
} typedef elem_t;


// Create new element
elem_t* new_elem(char* key, char* value);

// Update element value by key
int update_elem(elem_t* head, char* key, char* value);

// Find element by key
// Return 0 if not found, 1 if found
int find_elem(elem_t* head, char* key);

// Get element by key
// Return NULL if not found
elem_t* get_elem(elem_t* head, char* key);

// Add element to head list
int add_elem(elem_t* head, elem_t* elem);

// Delete element from head list
// Return 1 if delete success, 0 - if not
int delete_elem(elem_t* head, char* key);

// Realise element
int free_elem(elem_t* elem);

#endif