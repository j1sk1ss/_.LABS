// gcc-14 -Wall crypto/third_lab/third_lab.c -o second_crypto

#include <stdint.h>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>


uint8_t* generate_key(int length) {
    srand(time(0));
    uint8_t* key = (uint8_t*)malloc(length);

    for (int i = 0; i < length; i++)
        key[i] = rand() % 255;

    return key;
}

uint8_t* convert(uint8_t* message, int message_len, uint8_t* key, int key_len) {
    if (message_len != key_len)
        return NULL;

    uint8_t* output = (uint8_t*)malloc(message_len);
    for (int i = 0; i < message_len; i++)
        output[i] = message[i] ^ key[i];

    return output;
}

int main(int argc, char* argv[]) {
    char user_input[128];
    scanf("%s", user_input);

    uint8_t* key = generate_key(strlen(user_input));
    printf("Key: %s\n", key);

    uint8_t* encrypted_message = convert((uint8_t*)user_input, strlen(user_input), key, strlen(user_input));
    printf("Encrypted message: %s\n", encrypted_message);

    uint8_t* decrypted_message = convert(encrypted_message, strlen(user_input), key, strlen(user_input));
    printf("Decrypted message: %s\n", decrypted_message);

    return 1;
}
