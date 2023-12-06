/*
	Subroutine to generate a B-spline open knot vector with multiplicity
	equal to the order at the ends.

	c            = order of the basis function
	n            = the number of defining polygon vertices
	nplus2       = index of x() for the first occurence of the maximum knot vector value
	nplusc       = maximum value of the knot vector -- $n + c$
	x()          = array containing the knot vector
*/
#include <cstdio>

void knot(int n, int c, int x[])
{
	int nplusc, nplus2, i;

	nplusc = n + c;
	nplus2 = n + 2;

	x[1] = 0;
	for (i = 2; i <= nplusc; i++) {
		if ((i > c) && (i < nplus2))
			x[i] = x[i - 1] + 1;
		else
			x[i] = x[i - 1];
	}
}


/*
	Test program for C code from An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: tknot.c
	Purpose: Test program for knot.c to generate an open knot vector.
	Language: C
	Subroutines called: tknot.c
	Book reference: Section 3.3, p. 49 for test examples with n=5, c=2,3,4
*/

void knot_test()
{
	int x[22];
	int n, c, nplusc;
	int i;

	for (i = 0; i <= 21; i++) {
		x[i] = 0;
	}

	printf("\nInput number of polygon points and order separated by a space n c ");
	scanf("%d %d", &n, &c);

	nplusc = n + c;

	if (nplusc <= 21) {
		knot(n, c, x);
		printf("knot vector is ");
		for (i = 1; i <= nplusc; i++) {
			printf(" %d ", x[i]);
		}
		printf("\n");
	}
	else
	{
		printf("Program limits exceeded. n+c > 21.\n");
		printf("Knot vector not calculated.\n");
	}
}