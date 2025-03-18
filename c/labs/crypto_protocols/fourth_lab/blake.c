//gcc blake.c -o blake -lcrypto -lblake3
/*
Описание BLAKE2/BLAKE3:
BLAKE2b (512 бит) и BLAKE2s (256 бит) — хеш-функции, быстрее SHA-3, используются в криптографии и цифровых подписях.
BLAKE3 (256 бит) — улучшенная версия BLAKE2, использует дерево хеширования, быстрее на многопоточных системах.
*/

#include <stdio.h>
#include <string.h>
#include <openssl/evp.h>
#include "blake3.h"

void blake2b_hash(const char *data, char *output) {
    unsigned char hash[64];
    EVP_Digest(data, strlen(data), hash, NULL, EVP_blake2b512(), NULL);
    for (int i = 0; i < 64; i++) sprintf(output + (i * 2), "%02x", hash[i]);
    output[128] = '\0';
}

void blake2s_hash(const char *data, char *output) {
    unsigned char hash[32];
    EVP_Digest(data, strlen(data), hash, NULL, EVP_blake2s256(), NULL);
    for (int i = 0; i < 32; i++) sprintf(output + (i * 2), "%02x", hash[i]);
    output[64] = '\0';
}

void blake3_hash(const char *data, char *output) {
    uint8_t hash[BLAKE3_OUT_LEN];
    blake3_hasher hasher;
    blake3_hasher_init(&hasher);
    blake3_hasher_update(&hasher, data, strlen(data));
    blake3_hasher_finalize(&hasher, hash, BLAKE3_OUT_LEN);
    for (int i = 0; i < BLAKE3_OUT_LEN; i++) sprintf(output + (i * 2), "%02x", hash[i]);
    output[BLAKE3_OUT_LEN * 2] = '\0';
}

int main() {
    char text[1024], hash_b2b[129], hash_b2s[65], hash_b3[65];

    printf("Введите текст для хеширования: ");
    if (!fgets(text, sizeof(text), stdin)) {
        perror("Ошибка ввода");
        return 1;
    }
    text[strcspn(text, "\n")] = 0;

    blake2b_hash(text, hash_b2b);
    blake2s_hash(text, hash_b2s);
    blake3_hash(text, hash_b3);

    printf("BLAKE2b хеш: %s\n", hash_b2b);
    printf("BLAKE2s хеш: %s\n", hash_b2s);
    printf("BLAKE3 хеш: %s\n", hash_b3);

    return 0;
}
