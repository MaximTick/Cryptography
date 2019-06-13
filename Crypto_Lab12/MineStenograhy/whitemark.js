var bit0 = '\u0020'
var bit1 = '\u00A0'
//var bit0 = '\u02C2'
//var bit1 = '\u02C3'

// Кодируем данную строку символов в битовую строку из 8-битных значений в
// 10-битные кадры с начальным битом 1 и стоповым битом 0.

function tobits(data) {
	var bits = '';

	for (var i = 0; i < data.length; i++) {
		var c = data.charCodeAt(i);

		bits += bit1;
		bits += (c & 128) ? bit1 : bit0;
		bits += (c &  64) ? bit1 : bit0;
		bits += (c &  32) ? bit1 : bit0;
		bits += (c &  16) ? bit1 : bit0;
		bits += (c &   8) ? bit1 : bit0;
		bits += (c &   4) ? bit1 : bit0;
		bits += (c &   2) ? bit1 : bit0;
		bits += (c &   1) ? bit1 : bit0;
		bits += bit0;
	}
	return bits
}


// Определяем, синхронизируется ли данная битовая строка, начиная с бита i
// проверяя наличие 10-битных кадров с 1 стартовым битом и 0 стопом битом. 
//Подтвердите наличие n хороших кадров.


function checksync(bits, i, n) {
	for (var j = i; j < i + 10 * n; j += 10) {
		if (j + 9 < bits.length) {
			if (bits[j + 0] != bit1) return false;
			if (bits[j + 9] != bit0) return false;
		}
	}
	return true
}


// Декодируем данную битовую строку, предполагая 8-битное кодирование в 10-битных кадрах.
// Подтверждение синхронизации потока битов на каждом шаге. 
//В случае потери просканируйте вперед, пока не увидите несколько последовательных хороших кадров.

function frombits(bits) {
	var insync = checksync(bits, 0, 1);
	var data   = '';

	for (var i = 0; i < bits.length; ) {

		if (insync) {

			if (checksync(bits, i, 1)) {

				var c = 0;

				if (bits[i + 1] == bit1) c |= 128
				if (bits[i + 2] == bit1) c |=  64
				if (bits[i + 3] == bit1) c |=  32
				if (bits[i + 4] == bit1) c |=  16
				if (bits[i + 5] == bit1) c |=   8
				if (bits[i + 6] == bit1) c |=   4
				if (bits[i + 7] == bit1) c |=   2
				if (bits[i + 8] == bit1) c |=   1

				data += String.fromCharCode(c);

				i += 10;

			} else {
				insync = false;
			}

		} else {

			if (checksync(bits, i, 4))
				insync = true;
			else
				i += 1;
		}
	}
	return data;
}

// Решаем, будет ли символ c сигнализировать об окончании отступа в
// начало строки.

function istext(c) {
	return (c != '\u0020' && c != '\u00A0' && c != '\t');
}

// Решаем, будет ли символ c сигнализировать о конце строки.

function iseol(c) {
	return (c == '\n');
}

// Декодируем и возвращаем битовую строку, вставленную в пробел данной строки данных. 
//Игнорировать пропуски отступов.

function decode(data) {
	var intext = false;
	var bits   = '';

	for (var i = 0; i < data.length; i++) {
		if (intext) {
			if (data[i] == bit0)
				bits += bit0;
			if (data[i] == bit1)
				bits += bit1;
		}

		if (istext(data[i])) intext = true;
		if (iseol (data[i])) intext = false;
	}
	return bits;
}


// Кодируем данную битовую строку в пустое пространство данной текстовой строки.
// Игнорировать пропуски отступов.

function encode(text, bits) {
	var intext = false;
	var data   = '';
	var j      = 0;

	for (var i = 0; i < text.length; i++) {
		if (intext && j < bits.length && (text[i] == bit0 || text[i] == bit1))
			data += bits[j++];
		else
			data += text[i];

		if (istext(text[i])) intext = true;
		if (iseol (text[i])) intext = false;
	}
	return data;
}

// Убрать любую белую метку из заданного текста.
function sanitize(data) {
	return data.replace(/\u00A0/g, '\u0020');
}

//Подтвердите, что строка, закодированная в стеготексте, соответствует тексту сообщения.
// Может произойти сбой, если сообщение слишком длинное или текст слишком короткий.

function confirm() {
	var plain   = document.getElementById("plain");
	var message = document.getElementById("message");
	var stego   = document.getElementById("stego");

	if (message.value.localeCompare(frombits(decode(stego.value))))
		stego.style.color = 'red';
	else
		stego.style.color = 'black';
}

// Trigger кодирования и декодирования в ответ на изменения текстовых областей.

function plainChange() {
	var plain   = document.getElementById("plain");
	var message = document.getElementById("message");
	var stego   = document.getElementById("stego");

	stego.value = encode(plain.value, tobits(message.value));

	confirm();
}

function messageChange() {
	var plain   = document.getElementById("plain");
	var message = document.getElementById("message");
	var stego   = document.getElementById("stego");

	stego.value = encode(plain.value, tobits(message.value));

	confirm();
}

function stegoChange() {
	var plain   = document.getElementById("plain");
	var message = document.getElementById("message");
	var stego   = document.getElementById("stego");

	message.value = frombits(decode(stego.value));
	plain.value   = sanitize(stego.value);

	confirm();
}

