/*  Subroutine to generate a B-spline uniform (periodic) knot vector.

	c            = order of the basis function
	n            = the number of defining polygon vertices
	nplus2       = index of x() for the first occurence of the maximum knot vector value
	nplusc       = maximum value of the knot vector -- $n + c$
	x[]          = array containing the knot vector
*/

#include	<stdio.h>

void knotu(int n, int c, int x[])
{
	int nplusc, nplus2, i;

	nplusc = n + c;
	nplus2 = n + 2;

	x[1] = 0;
	for (i = 2; i <= nplusc; i++) {
		x[i] = i - 1;
	}
}

/*
	Test program for C code from An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: tknotu.c
	Purpose: To test knotu.c for generating a uniform periodic knot vector
	Language: C
	Subroutines called: tknotu.c
	Book reference: Section 3.3, p. 53 Ex. 3.1 with n=4, c=3
*/

void knotu_test()
{
	int x[22];
	int n, c, nplusc;
	int i;

	for (i = 0; i <= 21; i++) {
		x[i] = 0;
	}

	printf("Input number of polygon points and order separated by space n c ");
	scanf("%d %d", &n, &c);

	nplusc = n + c;

	if (nplusc <= 21) {
		knotu(n, c, x);
		printf("knot vector is \n");
		for (i = 1; i <= nplusc; i++) {
			printf(" %d %d \n", i, x[i]);
		}
	}
	else
	{
		printf("Program limits exceeded. n+c > 21.\n");
		printf("Knot vector not calculated.\n");
	}
}