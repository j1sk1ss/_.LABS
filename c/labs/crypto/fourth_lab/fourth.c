#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>


uint8_t generate_gamma_byte(uint8_t* key, int key_len, int* offset, int offset_len) {
    uint8_t new_byte = 0;
    for (int i = 0; i < offset_len; i++)
        new_byte ^= key[offset[i]];

    uint8_t gamma = key[key_len - 1];
    for (int i = key_len - 1; i > 0; i--) {
        key[i] = key[i - 1];
    }

    key[0] = new_byte;
    return gamma;
}

char* convert(char* message, uint8_t* key, int key_len, int* offset, int offset_len) {
    char* output_message = (char*)malloc(256);
    int message_index = 0;

    uint8_t* key_copy = (uint8_t*)malloc(key_len);
    memcpy(key_copy, key, key_len);

    for (int i = 0; i < strlen(message); i++) {
        uint8_t char_bit = message[i];
        uint8_t gamma = 0;

        for (int j = 0; j < 8; j++)
            gamma |= generate_gamma_byte(key_copy, key_len, offset, offset_len);

        char converted_char = char_bit ^ gamma;
        output_message[message_index++] = converted_char;
    }

    output_message[message_index] = '\0';
    return output_message;
}

int main(int argc, char* argv[]) {
    if (argc < 3) {
        printf("Wrong count of args. Should be 3, provided %i\n", argc);
        return 0;
    }

    int offset[2] = { 0, 2 };
    char* raw_key = argv[1];
    uint8_t* key = (uint8_t*)malloc(strlen(raw_key));
    for (int i = 0; i < strlen(raw_key); i++) {
        key[i] = raw_key[i] - '0';
    }

    char* input_text = argv[2];
    printf("Input message: %s\n", input_text);

    char* decrypted = convert(input_text, key, strlen(raw_key), offset, 2);
    printf("Decrypted message: %s\n", decrypted);

    char* encrypted = convert(decrypted, key, strlen(raw_key), offset, 2);
    printf("Encrypted message: %s\n", encrypted);

    free(decrypted);
    free(encrypted);

    return 1;
}
