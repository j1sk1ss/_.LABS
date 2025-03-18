// gcc sha512.c -o sha512 -lcrypto
/*
SHA-512 — это криптографическая хеш-функция из семейства SHA-2, разработанная NSA.

Ключевые характеристики:
Выходной размер: 512 бит (64 байта)
Размер блока: 1024 бита
Принцип работы:
Дополнение данных: Исходное сообщение дополняется до длины, кратной 1024 битам.
Разбиение на блоки: Сообщение разбивается на 1024-битные блоки.
Инициализация: Используется фиксированный набор 64-битных констант.
Обработка блоков: Каждый блок проходит через 80 раундов с битовыми сдвигами, перестановками и побитными операциями.
Выходное значение: После обработки всех блоков формируется 512-битный хеш.
SHA-512 обеспечивает высокую стойкость к коллизиям и широко используется в безопасности (пароли, цифровые подписи).
*/

#include <stdio.h>
#include <string.h>
#include <openssl/sha.h>

void sha512_hash(const char *data, char *output) {
    unsigned char hash[SHA512_DIGEST_LENGTH];
    SHA512((unsigned char *)data, strlen(data), hash);

    for (int i = 0; i < SHA512_DIGEST_LENGTH; i++) {
        sprintf(output + (i * 2), "%02x", hash[i]);
    }
    output[SHA512_DIGEST_LENGTH * 2] = '\0';
}

int main() {
    char text[1024];
    char hash_result[SHA512_DIGEST_LENGTH * 2 + 1];

    printf("Введите текст для хеширования: ");
    if (!fgets(text, sizeof(text), stdin)) {
        perror("Ошибка ввода");
        return 1;
    }

    text[strcspn(text, "\n")] = 0;
    sha512_hash(text, hash_result);
    printf("SHA-512 хеш: %s\n", hash_result);

    return 0;
}
