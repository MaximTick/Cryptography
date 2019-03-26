#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

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

/* calculates a * *x + b * *y = gcd(a, b) = *d */
void extended_euclid(long a, long b, long *x, long *y, long *d)
{
	long q, r, x1, x2, y1, y2;
	if (b == 0) {
		*d = a, *x = 1, *y = 0;
		return;
	}
	x2 = 1, x1 = 0, y2 = 0, y1 = 1;
	while (b > 0) {
		q = a / b, r = a - q * b;

		*x = x2 - q * x1, *y = y2 - q * y1;
		a = b, b = r;
		x2 = x1, x1 = *x, y2 = y1, y1 = *y;
	}
	*d = a, *x = x2, *y = y2;
}

/* computes the inverse of a modulo n */
long inverse(long a, long n)
{
	long d, x, y;
	extended_euclid(a, n, &x, &y, &d);
	if (d == 1) return x;
	return 0;
}

int main() {

	int val1, val2;
	printf("Euclidean - input first variable: ");
	scanf("%d", &val1);
	printf("Euclidean - input first variable: ");
	scanf("%d", &val2);
	printf("NOD Euclidean = %d\n", Euclidean(val1, val2));
	

	long value_a = 5, value_n = 7;
	printf("the inverse of %ld modulo %2ld is %ld\n", value_a, value_n, inverse(value_a, value_n));
	value_a = 4589, value_n = 789;
	printf("the inverse of %ld modulo %2ld is %ld\n", value_a, value_n, inverse(value_a, value_n));

	//Extended Euclideab
	
	long a, b;
	long p = 1, q = 0, r = 0, s = 1;
	long x, y;

	printf("input first variable: ");
	scanf("%d", &a);
	printf("input second variable: ");
	scanf("%d", &b);

	while (a && b) {
		if (a >= b) {
			a = a - b;
			p = p - r;
			q = q - s;
		}
		else
		{
			b = b - a;
			r = r - p;
			s = s - q;
		}
	}
	if (a) {
		x = p;
		y = q;
	}
	else
	{
		x = r;
		y = s;
	}
	printf("Output %d and %d\n", x, y);
	//End Extended Euclidean

	return 0;
}