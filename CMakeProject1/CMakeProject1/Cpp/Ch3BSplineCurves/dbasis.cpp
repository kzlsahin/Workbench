/* Subroutine to generate B-spline basis functions and their derivatives for uniform open knot vectors.
	C code for An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: dbasis.c
	Language: C
	Subroutines called: none
	Book reference: Section 3.10, Ex. 3.18, Alg. p. 283


	b1        = first term of the basis function recursion relation
	b2        = second term of the basis function recursion relation
	c         = order of the B-spline basis function
	d1[]      = array containing the derivative of the basis functions
				d1[1]) contains the derivative of the basis function associated with B1 etc.
	d2[]      = array containing the derivative of the basis functions
				d2[1] contains the derivative of the basis function associated with B1 etc.
	f1        = first term of the first derivative of the basis function recursion relation
	f2        = second term of the first derivative of the basis function recursion relation
	f3        = third term of the first derivative of the basis function recursion relation
	f4        = fourth term of the first derivative of the basis function recursion relation
	npts      = number of defining polygon vertices
	n[]       = array containing the basis functions
				n[1]) contains the basis function associated with B1 etc.
	nplusc    = constant -- npts + c -- maximum knot value
	s1        = first term of the second derivative of the basis function recursion relation
	s2        = second term of the second derivative of the basis function recursion relation
	s3        = third term of the second derivative of the basis function recursion relation
	s4        = fourth term of the second derivative of the basis function recursion relation
	t         = parameter value
	temp[]    = temporary array
	x[]       = knot vector
*/

#include	<stdio.h>
#include	<math.h>
#include "knot.h"

void dbasis(int c, float t, int npts, int x[], float n[], float d1[], float d2[])
{

	int nplusc;
	int i, k;
	float b1, b2;
	float f1, f2, f3, f4;
	float s1, s2, s3, s4;
	float temp[36];		/* allows for 35 defining polygon vertices */
	float temp1[36];
	float temp2[36];

	nplusc = npts + c;

	/*    zero the temporary arrays */

	for (i = 1; i <= nplusc; i++) {
		temp[i] = 0.;
		temp1[i] = 0.;
		temp2[i] = 0.;
	}

	/* calculate the first order basis functions n[i] */

	for (i = 1; i <= nplusc - 1; i++) {
		if ((t >= x[i]) && (t < x[i + 1]))
			temp[i] = 1;
		else
			temp[i] = 0;
	}

	if (t == (float)x[nplusc]) {		/*    pick up last point	*/
		temp[npts] = 1;
	}

	/* calculate the higher order basis functions */

	for (k = 2; k <= c; k++) {
		for (i = 1; i <= nplusc - k; i++) {
			if (temp[i] != 0)    /* if the lower order basis function is zero skip the calculation */
				b1 = ((t - x[i]) * temp[i]) / (x[i + k - 1] - x[i]);
			else
				b1 = 0;

			if (temp[i + 1] != 0)     /* if the lower order basis function is zero skip the calculation */
				b2 = ((x[i + k] - t) * temp[i + 1]) / (x[i + k] - x[i + 1]);
			else
				b2 = 0;

			/*       calculate first derivative */

			if (temp[i] != 0)       /* if the lower order basis function is zero skip the calculation */
				f1 = temp[i] / (x[i + k - 1] - x[i]);
			else
				f1 = 0;

			if (temp[i + 1] != 0)     /* if the lower order basis function is zero skip the calculation */
				f2 = -temp[i + 1] / (x[i + k] - x[i + 1]);
			else
				f2 = 0;

			if (temp1[i] != 0)      /* if the lower order basis function is zero skip the calculation */
				f3 = ((t - x[i]) * temp1[i]) / (x[i + k - 1] - x[i]);
			else
				f3 = 0;

			if (temp1[i + 1] != 0)    /* if the lower order basis function is zero skip the calculation */
				f4 = ((x[i + k] - t) * temp1[i + 1]) / (x[i + k] - x[i + 1]);
			else
				f4 = 0;

			/*       calculate second derivative */

			if (temp1[i] != 0)      /* if the lower order basis function is zero skip the calculation */
				s1 = (2 * temp1[i]) / (x[i + k - 1] - x[i]);
			else
				s1 = 0;

			if (temp1[i + 1] != 0)      /* if the lower order basis function is zero skip the calculation */
				s2 = (-2 * temp1[i + 1]) / (x[i + k] - x[i + 1]);
			else
				s2 = 0;

			if (temp2[i] != 0)       /* if the lower order basis function is zero skip the calculation */
				s3 = ((t - x[i]) * temp2[i]) / (x[i + k - 1] - x[i]);
			else
				s3 = 0;

			if (temp2[i + 1] != 0)    /* if the lower order basis function is zero skip the calculation */
				s4 = ((x[i + k] - t) * temp2[i + 1]) / (x[i + k] - x[i + 1]);
			else
				s4 = 0;

			temp[i] = b1 + b2;
			temp1[i] = f1 + f2 + f3 + f4;
			temp2[i] = s1 + s2 + s3 + s4;
		}
	}

	/* put in n array	*/

	for (i = 1; i <= npts; i++) {
		n[i] = temp[i];
		d1[i] = temp1[i];
		d2[i] = temp2[i];
	}
}

/*
	Test program for C code from An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: tdbasis.c
	Purpose: test dbasis.c uniform open B-spline basis functions
			 and their derivatives
	Language: C
	Subroutines called: dbasis.c, knot.c
	Book reference: p. 283
*/

#include 	<stdio.h>

void dbasis_test()
{
	int i;
	int c, npts, nplusc;
	int x[22];
	float t;
	float n[20], d1[20], d2[20];
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

	printf("\n\n");

	while ((t >= 0.) && (t <= (float)x[nplusc])) {
		printf("Input a parameter value t (Control C to end) ");
		scanf("%f", &t);
		printf("t = ");
		printf("%f\n", t);
		dbasis(c, t, npts, x, n, d1, d2);
		sum = 0;
		for (i = 1; i <= npts; i++) {
			sum = sum + n[i];
		}
		printf("Basis functions are \n");
		for (i = 1; i <= npts; i++) {
			printf("%f ", n[i]);
		}
		printf("\n");
		printf("Sum of the Basis functions is %f \n", sum);
		printf("First derivatives of the basis functions are \n");
		for (i = 1; i <= npts; i++) {
			printf("%f ", d1[i]);
		}
		printf("\n");
		printf("Second derivatives of the basis functions are \n");
		for (i = 1; i <= npts; i++) {
			printf("%f ", d2[i]);
		}
		printf("\n\n");
	}
}