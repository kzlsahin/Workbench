/*
	Test program for C code from An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: tbasis.c
	Purpose: Test the open uniform basis function
	Language: C
	Subroutines called: knot.c, basis.c
	Book reference: Section 3.4, Ex. 3.2, p. 55
*/

#include 	<stdio.h>
#include "basis.cpp"

void tbasis_test()
{
	int i;
	int c, npts, nplusc;
	int x[22];
	float t;
	float n[20];
	float sum;


	printf("Input number of polygon points and order separated by a space npts c ");
	scanf("%d %d", &npts, &c);

	t = 0.;

	nplusc = npts + c;

	knot(npts, c, x);
	printf("The knot vector is ");
	for (i = 1; i <= nplusc; i++) {
		printf(" %d ", x[i]);
	}

	printf("\n");

	while ((t >= 0.) && (t <= (float)x[nplusc])) {
		printf("Input the parameter value t (Control C to end) ");
		scanf("%f", &t);
		printf("t = ");
		printf("%f\n", t);
		basis(c, t, npts, x, n);
		printf("Basis function is ");
		sum = 0;
		for (i = 1; i <= npts; i++) {
			sum = sum + n[i];
		}
		for (i = 1; i <= npts; i++) {
			printf("%f ", n[i]);
		}
		printf("\n");
		printf("Sum of the Basis functions is %f \n", sum);
		printf("\n");
	}
	printf("t is outside the parameter range, program ends \n");
}
