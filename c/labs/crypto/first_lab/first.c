#include "../shared/include/dict.h"
#include <ctype.h>


const char* codes[] = {
    "AAAAA", // 'А'
    "AAAAB", // 'Б'
    "AAABA", // 'В'
    "AAABB", // 'Г'
    "AABAA", // 'Д'
    "AABAB", // 'Е'
    "AABBA", // 'Ж'
    "AABBB", // 'З'
    "ABAAA", // 'И'
    "ABAAB", // 'Й'
    "ABABA", // 'К'
    "ABABB", // 'Л'
    "ABBAA", // 'М'
    "ABBAB", // 'Н'
    "ABBBA", // 'О'
    "ABBBB", // 'П'
    "BAAAA", // 'Р'
    "BAAAB", // 'С'
    "BAABA", // 'Т'
    "BAABB", // 'У'
    "BABAA", // 'Ф'
    "BABAB", // 'Х'
    "BABBA", // 'Ц'
    "BABBB", // 'Ч'
    "BBAAA", // 'Ш'
    "BBAAB", // 'Щ'
    "BBABA", // 'Ъ'
    "BBABB", // 'Ы'
    "BBBAA", // 'Ь'
    "BBBAB", // 'Э'
    "BBBBA", // 'Ю'
    "BBBBB"  // 'Я'
};


char* bacon_encrypt(const char* text, const char* cover_text);
char* bacon_decrypt(const char* encoded_message);


char* bacon_encrypt(const char* text, const char* cover_text) {
    static char encrypted_text[1024] = "";
    int index = 0;

    for (const char* p = text; *p; ++p) {
        char upper_char = toupper(*p);
        if (upper_char >= 'A' && upper_char <= 'Z') {
            int char_index = upper_char - 'A';
            strcat(encrypted_text, codes[char_index]);
        }
    }

    static char encoded_message[1024] = "";
    index = 0;

    for (const char* p = cover_text; *p; ++p) {
        if (isalpha(*p)) {
            if (index < (int)strlen(encrypted_text)) {
                if (encrypted_text[index] == 'A') {
                    strncat(encoded_message, (char[]){(char)tolower(*p), '\0'}, 1);
                } else {
                    strncat(encoded_message, (char[]){(char)toupper(*p), '\0'}, 1);
                }
                index++;
            } else {
                strncat(encoded_message, (char[]){*p, '\0'}, 1);
            }
        } else {
            strncat(encoded_message, (char[]){*p, '\0'}, 1);
        }
    }

    return encoded_message;
}

char* bacon_decrypt(const char* encoded_message) {
    static char decoded_message[1024];
    char decoded_bits[1024] = "";
    int index = 0;

    for (const char* p = encoded_message; *p; ++p) {
        if (isalpha(*p)) {
            if (islower(*p)) {
                decoded_bits[index++] = 'A';
            } else {
                decoded_bits[index++] = 'B';
            }
        }
    }

    decoded_bits[index] = '\0';
    index = 0;
    for (int i = 0; i < (int)strlen(decoded_bits); i += 5) {
        char letter_bits[6] = {0};
        strncpy(letter_bits, &decoded_bits[i], 5);

        for (int j = 0; j < 32; j++) {
            if (strcmp(letter_bits, codes[j]) == 0) {
                decoded_message[index++] = 'A' + j;
                break;
            }
        }
    }
    
    decoded_message[index] = '\0';
    return decoded_message;
}

int main(int argc, char* argv[]) {
    if (argc < 3) {
        printf("Syntax: <mode> <message> <additional params>\n");
        return -1;
    }

    char* answer;
    if (strcmp(argv[1], "enc") == 0) {
        answer = bacon_encrypt(argv[2], argv[3]);
    }
    else if (strcmp(argv[1], "dec") == 0) {
        answer = bacon_decrypt(argv[2]);
    }

    printf("Operation [%s] \t Answer: %s\n", argv[1], answer);
}
