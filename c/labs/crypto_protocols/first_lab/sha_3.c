/*
Размеры хеша: 224, 256, 384, 512 бит
Разработан: 2015 год (NIST)
Структура: Основан на губчатой (sponge) функции, не использует схему Merkle–Damgård.
Безопасность: Более устойчив к коллизиям, длинорасширенным атакам и атакам сторонних каналов.
Применение: Будущая замена SHA-2, используется в криптографии и блокчейне.

Алгоритм:
Сообщение заполняется до нужной длины, затем разбивается на блоки фиксированного размера.
Каждый блок проходит через раундовую функцию Keccak-f (24 итерации), состоящую из перестановок и XOR.
После всех итераций оставшиеся данные "выжимают" (squeeze), формируя итоговый хеш.
*/

#include <stdio.h>
#include <stdint.h>
#include <string.h>


#define SHA3_256_RATE 136
#define KECCAK_F_ROUNDS 24


typedef struct {
    unsigned long long state[5][5];
    unsigned char buffer[SHA3_256_RATE];
    size_t buffer_size;
} sha3_256_ctx;

static const unsigned long long keccak_round_constants[KECCAK_F_ROUNDS] = {
    0x0000000000000001ULL, 0x0000000000008082ULL, 0x800000000000808AULL,
    0x8000000080008000ULL, 0x000000000000808BULL, 0x0000000080000001ULL,
    0x8000000080008081ULL, 0x8000000000008009ULL, 0x000000000000008AULL,
    0x0000000000000088ULL, 0x0000000080008009ULL, 0x000000008000000AULL,
    0x000000008000808BULL, 0x800000000000008BULL, 0x8000000000008089ULL,
    0x8000000000008003ULL, 0x8000000000008002ULL, 0x8000000000000080ULL,
    0x000000000000800AULL, 0x800000008000000AULL, 0x8000000080008081ULL,
    0x8000000000008080ULL, 0x0000000080000001ULL, 0x8000000080008008ULL
};


static void keccak_f(unsigned long long state[5][5]) {
    unsigned long long C[5], D[5];
    for (int round = 0; round < KECCAK_F_ROUNDS; round++) {
        for (int x = 0; x < 5; x++) {
            C[x] = state[x][0] ^ state[x][1] ^ state[x][2] ^ state[x][3] ^ state[x][4];
        }
        for (int x = 0; x < 5; x++) {
            D[x] = C[(x + 4) % 5] ^ ((C[(x + 1) % 5] << 1) | (C[(x + 1) % 5] >> 63));
        }
        for (int x = 0; x < 5; x++) {
            for (int y = 0; y < 5; y++) {
                state[x][y] ^= D[x];
            }
        }
        state[0][0] ^= keccak_round_constants[round];
    }
}

static void sha3_256_absorb(sha3_256_ctx *ctx, const unsigned char *data, size_t length) {
    while (length > 0) {
        size_t to_copy = SHA3_256_RATE - ctx->buffer_size;
        if (to_copy > length) to_copy = length;
        memcpy(ctx->buffer + ctx->buffer_size, data, to_copy);
        ctx->buffer_size += to_copy;
        data += to_copy;
        length -= to_copy;
        if (ctx->buffer_size == SHA3_256_RATE) {
            keccak_f(ctx->state);
            ctx->buffer_size = 0;
        }
    }
}

static void sha3_256_finalize(sha3_256_ctx *ctx, unsigned char hash[32]) {
    ctx->buffer[ctx->buffer_size] = 0x06;
    ctx->buffer[SHA3_256_RATE - 1] |= 0x80;
    keccak_f(ctx->state);
    memcpy(hash, ctx->state, 32);
}

void sha3_256(unsigned char *hash, const unsigned char *data, size_t length) {
    sha3_256_ctx ctx = {0};
    sha3_256_absorb(&ctx, data, length);
    sha3_256_finalize(&ctx, hash);
}

int main() {
    char message[256] = { 0 };
    printf("Input message: ");
    fgets(message, sizeof(message), stdin);
    size_t len = strcspn(message, "\n");
    message[len] = '\0';
    
    unsigned char hash[32] = { 0 };
    sha3_256(hash, (unsigned char*)message, len);
    
    printf("SHA3-256: ");
    for (int i = 0; i < 32; i++) {
        printf("%02x", hash[i]);
    }

    printf("\n");
    return 0;
}