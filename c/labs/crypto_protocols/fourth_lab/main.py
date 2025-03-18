import hashlib
import blake3

def blake2b_hash(data: str) -> str:
    return hashlib.blake2b(data.encode('utf-8')).hexdigest()

def blake2s_hash(data: str) -> str:
    return hashlib.blake2s(data.encode('utf-8')).hexdigest()

def blake3_hash(data: str) -> str:
    return blake3.blake3(data.encode('utf-8')).hexdigest()

if __name__ == "__main__":
    text = input("Введите текст для хеширования: ")
    print("BLAKE2b хеш:", blake2b_hash(text))
    print("BLAKE2s хеш:", blake2s_hash(text))
    print("BLAKE3 хеш:", blake3_hash(text))
