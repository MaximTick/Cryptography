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
int main() {

	int val1, val2;
	printf("Euclidean - input first variable: ");
	scanf("%d", &val1);
	printf("Euclidean - input first variable: ");
	scanf("%d", &val2);
	printf("NOD Euclidean = %d\n", Euclidean(val1, val2));

	
	//Extended
	int a, b;
	int p = 1, q = 0, r = 0, s = 1;
	int x, y;

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
	return 0;
}