function NOD(a, b) {
    if (typeof a != 'number' || typeof b != 'number') throw new Error('Bad type of value');
    let max = Math.max(a, b);
    let min = Math.min(a, b);
    let r = -1;
    while (r != 0) {
        r = max % min;
        max = min;
        min = r;
    }
    return max;
}

function GetNumberByMod(x, n) {
    if (typeof x != 'number' || typeof n != 'number') throw new Error('Bad value type');
    if (NOD(x, n) != 1) throw new Error('Числа должна быть взаимно простыми');
    let y = 1,
        k = 0;
    while (true) {
        k = (1 - x * y) / n;
        if (Number.isInteger(k))
            return y;
        else
            y++;
    }
}

function isPrimeNumber(number) {
    for (let i = 2; i < number / 2; ++i)
        if (number % i === 0)
            return false;
    return true;
}

function RSAInit(randomPrimeNumber1, randomPrimeNumber2) {
    if (typeof randomPrimeNumber1 !== 'number' ||
        typeof randomPrimeNumber2 !== 'number') throw new Error('Bad type of params');
    if (!isPrimeNumber(randomPrimeNumber1) || !isPrimeNumber(randomPrimeNumber2))
        throw new Error('Numbers are not prime');
    const n = randomPrimeNumber1 * randomPrimeNumber2;
    const fn = (randomPrimeNumber1 - 1) * (randomPrimeNumber2 - 1);
    const e = 7;
    const d = GetNumberByMod(e, fn);
    return {
        n,
        e,
        d
    };
}

function RSA({ n, e,}, message) {
    let crypto = "";
    const positionA = 'A'.charCodeAt(0);
    for (let i = 0, { length } = message; i < length; ++i) {
        const alphabetPosition = (message.charCodeAt(i) - positionA) + 1;
        crypto += String.fromCharCode((Math.pow(alphabetPosition, e) % n) - 1 + positionA);
    }
    return crypto;
}

function DecryptRSA({ n, d }, message) {
    let crypto = "";
    const positionA = 'A'.charCodeAt(0);
    for (let i = 0, { length } = message; i < length; ++i) {
        const alphabetPosition = (message.charCodeAt(i) - positionA) + 1;
        crypto += String.fromCharCode((Math.pow(alphabetPosition, d) % n) - 1 + positionA);
    }
    return crypto;
}

function ElGamalInit() {
    const [p, g, x] = [11, 2, 8];
    const y = Math.pow(g, x) % p;
    return {
        p,
        g,
        x,
        y
    }
}

function ElGamalSymbol({ p, g, x, y }, message) {
    const k = Math.round(Math.random() * (p - 1));
    const a = Math.pow(g, k) % p;
    const b = (Math.pow(y, k) * message) % p;
    return {
        a,
        b
    };
}

function ElGamal(keys, message) {
    const encrypt = [];
    for (let i = 0, { length } = message; i < length; ++i) {
        encrypt.push(ElGamalSymbol(keys, message[i]));
    }
    return encrypt;
}

function ElGamalSymbolDecrypt({ p, g, x, y }, { a, b }) {
    const m = b * Math.pow(a, p - 1 - x) % p;
    return m;
}

function ElGamalDecrypt(keys, message) {
    const decrypt = [];
    for (let i = 0, { length } = message; i < length; ++i) {
        decrypt.push(ElGamalSymbolDecrypt(keys, message[i]));
    }
    return decrypt;
}

const keys = RSAInit(3, 11);
const plainText = 'HELLO WORLD';
console.log('Открытый текст: ' + plainText);
const encryptMessage = RSA(keys, plainText);
console.log(`Зашифрованный текст: ${encryptMessage}`);
console.log('RSA DECRYPT: ' + DecryptRSA(keys, encryptMessage));
console.log("---------------------------");

const keysElGamal = ElGamalInit();
const encryptElGamal = ElGamal(keysElGamal, [1, 2, 3, 4, 6]);
console.log(`Encrypt`);
console.log(encryptElGamal);
console.log('Decrypt: ' + ElGamalDecrypt(keysElGamal, encryptElGamal));
console.log("---------------------------");

function generateG(q, p) {
    let g = 4;
    while ((Math.pow(g, q) % p) != 1) g++;
    return g;
}

function GetNumberByModWithNumber(x, n, number) {
    if (typeof x != 'number' || typeof n != 'number') throw new Error('Bad value type');
    if (NOD(x, n) != 1) throw new Error('Числа должна быть взаимно простыми');
    // let y = 1,
    //     k = 0;
    // while (true) {
    //     k = (number - x * y) / n;
    //     if (Number.isInteger(k))
    //         return y;
    //     else
    //         y++;
    // }
    let y = Math.pow(x, number) % n;
    return y;
}

function GenerateShnorrKeys(p, q) {
    if ((p - 1) % q != 0) throw new Error('Bad param q');
    let g = generateG(q, p);
    let w = Math.ceil(Math.random() * q);
    let y = GetNumberByModWithNumber(g, p, w);
    return {
        p,
        q,
        g,
        y,
        w
    };
}

function Schnorr({ p, q, g, y, w }) {
    const r = Math.floor(Math.random() * q);
    const x = Math.pow(g, r) % p;
    const e = 12;
    const s = (r + w * e) % q;
    const z = (Math.pow(g, s) * Math.pow(y, e)) % p;
    console.log(`Проверка ЭЦП  -- ${z === x}`);
}

let schnorrKeys = GenerateShnorrKeys(7, 3);
console.log(schnorrKeys);
Schnorr(schnorrKeys);
console.log("---------------------------");