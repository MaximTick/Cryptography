#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include <math.h>

int Euclidean(int val1, int val2)
{
	while (val1 != 0 && val2 != 0)
		if (val1 > val2) {
			val1 %= val2;
		}
		else {
			val2 %= val1;
		}
		return val1 + val2;
}

void gcdext(int a, int b, int *d, int *x, int *y)
{
	int s;
	if (b == 0)
	{
		*d = a; *x = 1; *y = 0;
		return;
	}
	gcdext(b, a % b, d, x, y);
	s = *y;
	*y = *x - (a / b) * (*y);
	*x = s;
}

long inverse(long a, long n)
{
	long d, x, y;
	gcdext(a, n, &d, &x, &y);
	if (d == 1) 
	{ 
		if (x < 0) {
			x = -(abs(x) % n) + n;
		}
		return x; 
	}
	return 0;
}

int main() {

	setlocale(LC_ALL, "RUS");

	int val1, val2;
	printf("Euclidean - input first variable: ");
	scanf("%d", &val1);
	printf("Euclidean - input first variable: ");
	scanf("%d", &val2);
	printf("NOD Euclidean = %d\n", Euclidean(val1, val2));
	

	long value_a = 13, value_n = 27;
	printf("the inverse of %ld module %2ld is %ld\n", value_a, value_n, inverse(value_a, value_n));
	value_a = 7, value_n = 17;
	printf("the inverse of %ld module %2ld is %ld\n", value_a, value_n, inverse(value_a, value_n));

	return 0;
}