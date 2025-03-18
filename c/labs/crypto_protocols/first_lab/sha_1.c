/*
Размер хеша: 160 бит
Разработан: 1995 год (NIST)
Структура: Модифицированная версия MD5, использует схему Merkle–Damgård с 80 раундами.
Безопасность: В 2017 году был взломан (атаку коллизий нашли в Google и CWI).
Применение: Ранее использовался для цифровых подписей, но сейчас считается небезопасным.

Алгоритм:
Дополняет сообщение до длины, кратной 512 битам.
Разбивает на блоки по 512 бит.
Каждый блок проходит 80 раундов с нелинейными функциями и побитовым сдвигом.
В конце объединяет промежуточные состояния в 160-битный хеш.
*/

#include <stdio.h>
#include <stdint.h>
#include <string.h>


#define ROTLEFT(a, b) (((a) << (b)) | ((a) >> (32 - (b))))


void sha1_transform(unsigned int state[5], const unsigned char data[]);
void sha1(unsigned char* message, size_t len, unsigned char hash[20]);


void sha1(unsigned char* message, size_t len, unsigned char hash[20]) {
    unsigned int state[5] = {
        0x67452301, 0xEFCDAB89, 0x98BADCFE, 0x10325476, 0xC3D2E1F0
    };
    
    size_t new_len = len + 1;
    while (new_len % 64 != 56) new_len++;
    
    unsigned char padded_msg[new_len + 8];
    memcpy(padded_msg, message, len);
    padded_msg[len] = 0x80;
    memset(padded_msg + len + 1, 0, new_len - len - 1);
    
    uint64_t bit_len = len * 8;
    for (int i = 0; i < 8; i++) {
        padded_msg[new_len + i] = (bit_len >> (56 - i * 8)) & 0xFF;
    }
    
    for (size_t i = 0; i < new_len + 8; i += 64) {
        sha1_transform(state, padded_msg + i);
    }
    
    for (int i = 0; i < 5; i++) {
        hash[i * 4] = (state[i] >> 24) & 0xFF;
        hash[i * 4 + 1] = (state[i] >> 16) & 0xFF;
        hash[i * 4 + 2] = (state[i] >> 8) & 0xFF;
        hash[i * 4 + 3] = state[i] & 0xFF;
    }
}

void sha1_transform(unsigned int state[5], const unsigned char data[]) {
    unsigned int w[80];
    for (int i = 0; i < 16; i++) {
        w[i] = (data[i * 4] << 24) | (data[i * 4 + 1] << 16) | (data[i * 4 + 2] << 8) | data[i * 4 + 3];
    }
    for (int i = 16; i < 80; i++) {
        w[i] = ROTLEFT(w[i - 3] ^ w[i - 8] ^ w[i - 14] ^ w[i - 16], 1);
    }
    
    unsigned int a = state[0], b = state[1], c = state[2], d = state[3], e = state[4];
    
    for (int i = 0; i < 80; i++) {
        unsigned int f, k;
        if (i < 20) {
            f = (b & c) | (~b & d);
            k = 0x5A827999;
        } else if (i < 40) {
            f = b ^ c ^ d;
            k = 0x6ED9EBA1;
        } else if (i < 60) {
            f = (b & c) | (b & d) | (c & d);
            k = 0x8F1BBCDC;
        } else {
            f = b ^ c ^ d;
            k = 0xCA62C1D6;
        }
        unsigned int temp = ROTLEFT(a, 5) + f + e + k + w[i];
        e = d;
        d = c;
        c = ROTLEFT(b, 30);
        b = a;
        a = temp;
    }
    
    state[0] += a;
    state[1] += b;
    state[2] += c;
    state[3] += d;
    state[4] += e;
}

int main() {
    char input[256] = { 0 };
    printf("Input message: ");
    fgets(input, sizeof(input), stdin);
    size_t len = strlen(input);

    if (input[len - 1] == '\n') input[len - 1] = '\0';
    len = strlen(input);
    
    unsigned char hash[20] = { 0 };
    sha1((unsigned char*)input, len, hash);
    
    printf("SHA-1: ");
    for (int i = 0; i < 20; i++) {
        printf("%02x", hash[i]);
    }

    printf("\n");
    return 0;
}