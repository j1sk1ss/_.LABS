/*
Размеры хеша: 224, 256, 384, 512 бит
Разработан: 2001 год (NIST)
Структура: Улучшенная версия SHA-1, использует более сложные логические операции и больше раундов.
Безопасность: На 2024 год считается надежным, но SHA-256 более устойчив, чем SHA-1.
Применение: Криптовалюта (Bitcoin — SHA-256), TLS, цифровые подписи.

Алгоритм:
Сообщение дополняется до длины, кратной 512 или 1024 битам (в зависимости от варианта).
Блоки проходят через 64, 80 или 96 раундов, используя нелинейные функции, XOR и побитовые сдвиги.
В конце объединяются промежуточные значения, образуя итоговый хеш.
*/

#include <stdio.h>
#include <stdint.h>
#include <string.h>


static const unsigned int K[64] = {
    0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5,
    0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
    0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3,
    0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
    0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc,
    0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
    0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7,
    0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
    0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13,
    0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
    0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3,
    0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
    0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5,
    0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
    0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208,
    0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
};


#define ROTR(x, n) ((x >> n) | (x << (32 - n)))
#define CH(x, y, z) ((x & y) ^ (~x & z))
#define MAJ(x, y, z) ((x & y) ^ (x & z) ^ (y & z))
#define SIG0(x) (ROTR(x, 2) ^ ROTR(x, 13) ^ ROTR(x, 22))
#define SIG1(x) (ROTR(x, 6) ^ ROTR(x, 11) ^ ROTR(x, 25))
#define LSIG0(x) (ROTR(x, 7) ^ ROTR(x, 18) ^ (x >> 3))
#define LSIG1(x) (ROTR(x, 17) ^ ROTR(x, 19) ^ (x >> 10))


static unsigned int H[8] = {
    0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a,
    0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19
};


void sha256_transform(unsigned int *h, const unsigned char *chunk) {
    unsigned int w[64], a, b, c, d, e, f, g, h_var;

    for (int i = 0; i < 16; i++) {
        w[i] = (chunk[i * 4] << 24) | (chunk[i * 4 + 1] << 16) |
               (chunk[i * 4 + 2] << 8) | chunk[i * 4 + 3];
    }

    for (int i = 16; i < 64; i++) {
        w[i] = LSIG1(w[i - 2]) + w[i - 7] + LSIG0(w[i - 15]) + w[i - 16];
    }

    a = h[0]; b = h[1]; c = h[2]; d = h[3];
    e = h[4]; f = h[5]; g = h[6]; h_var = h[7];

    for (int i = 0; i < 64; i++) {
        unsigned int temp1 = h_var + SIG1(e) + CH(e, f, g) + K[i] + w[i];
        unsigned int temp2 = SIG0(a) + MAJ(a, b, c);
        h_var = g;
        g = f;
        f = e;
        e = d + temp1;
        d = c;
        c = b;
        b = a;
        a = temp1 + temp2;
    }

    h[0] += a;
    h[1] += b;
    h[2] += c;
    h[3] += d;
    h[4] += e;
    h[5] += f;
    h[6] += g;
    h[7] += h_var;
}

void sha256(const unsigned char *data, size_t len, unsigned char *hash) {
    unsigned int h[8] = { 0 };
    memcpy(h, H, sizeof(H));
    unsigned char chunk[64] = { 0 };
    size_t i = 0;

    for (i = 0; i + 64 <= len; i += 64) {
        sha256_transform(h, data + i);
    }

    memcpy(chunk, data + i, len - i);
    chunk[len - i] = 0x80;
    memset(chunk + len - i + 1, 0, 64 - (len - i + 1));

    if (len - i >= 56) {
        sha256_transform(h, chunk);
        memset(chunk, 0, 64);
    }

    uint64_t bit_len = len * 8;
    for (int j = 0; j < 8; j++) {
        chunk[56 + j] = (bit_len >> ((7 - j) * 8)) & 0xFF;
    }

    sha256_transform(h, chunk);

    for (i = 0; i < 8; i++) {
        hash[i * 4] = (h[i] >> 24) & 0xFF;
        hash[i * 4 + 1] = (h[i] >> 16) & 0xFF;
        hash[i * 4 + 2] = (h[i] >> 8) & 0xFF;
        hash[i * 4 + 3] = h[i] & 0xFF;
    }
}

int main() {
    char input[256] = { 0 };
    printf("Input message: ");
    fgets(input, sizeof(input), stdin);

    unsigned char hash[32];
    sha256((unsigned char*)input, strlen(input), hash);
    printf("SHA-256: ");
    for (int i = 0; i < 32; i++) {
        printf("%02x", hash[i]);
    }

    printf("\n");
    return 0;
}
