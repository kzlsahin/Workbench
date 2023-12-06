/*  Subroutine to generate a B-spline curve using an uniform open knot vector

	C code for An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: bsplineu.c
	Language: C
	Subroutines called: knotu.c, basis.c, fmtmul.c
	Book reference: Section 3.8, Ex. 3.7, Alg. p. 282

	b[]        = array containing the defining polygon vertices
				  b[1] contains the x-component of the vertex
				  b[2] contains the y-component of the vertex
				  b[3] contains the z-component of the vertex
	k           = order of the B-spline basis function
	nbasis      = array containing the basis functions for a single value of t
	nplusc      = number of knot values
	npts        = number of defining polygon vertices
	p[,]        = array containing the curve points
				  p[1] contains the x-component of the point
				  p[2] contains the y-component of the point
				  p[3] contains the z-component of the point
	p1          = number of points to be calculated on the curve
	t           = parameter value 0 <= t <= 1
	x[]         = array containing the knot vector
*/

#include <cstdio>
#include "knotu.h"
#include "basis.h"
void bsplineu(int npts, int k, int p1, float b[], float p[])
{
	int i, j, icount, jcount;
	int i1;
	int x[30];		/* allows for 20 data points with basis function of order 5 */
	int nplusc;

	float step;
	float t;
	float nbasis[20];
	float temp;


	nplusc = npts + k;

	/*  zero and redimension the knot vector and the basis array */

	for (i = 0; i <= npts; i++) {
		nbasis[i] = 0.;
	}

	for (i = 0; i <= nplusc; i++) {
		x[i] = 0.;
	}

	/* generate the uniform open knot vector */

	knotu(npts, k, x);


	printf("The knot vector is ");
	for (i = 1; i <= nplusc; i++) {
		printf(" %d ", x[i]);
	}
	printf("\n");

	printf("The usable parameter range is ");
	for (i = k; i <= npts + 1; i++) {
		printf(" %d ", x[i]);
	}
	printf("\n");


	icount = 0;

	/*    calculate the points on the bspline curve */

	t = k - 1; /* special parameter range for periodic basis functions */
	step = ((float)((npts)-(k - 1))) / ((float)(p1 - 1));

	for (i1 = 1; i1 <= p1; i1++) {
		if ((float)(npts)-t < 5e-6) {
			t = (float)((npts));
		}

		basis(k, t, npts, x, nbasis);      /* generate the basis function for this value of t */
		/*
				printf("t = %f \n",t);
				printf("nbasis = ");
				for (i = 1; i <= npts; i++){
					printf("%f  ",nbasis[i]);
				}
				printf("\n");
		*/
		for (j = 1; j <= 3; j++) {      /* generate a point on the curve */
			jcount = j;
			p[icount + j] = 0.;

			for (i = 1; i <= npts; i++) { /* Do local matrix multiplication */
				temp = nbasis[i] * b[jcount];
				p[icount + j] = p[icount + j] + temp;
				/*
								printf("jcount,nbasis,b,nbasis*b,p = %d %f %f %f %f\n",jcount,nbasis[i],b[jcount],temp,p[icount+j]);
				*/
				jcount = jcount + 3;
			}
		}
		/*
				printf("icount, p %d %f %f %f \n",icount,p[icount+1],p[icount+2],p[icount+3]);
		*/
		icount = icount + 3;
		t = t + step;
	}
}

/*
	Test program for C code from An Introduction to NURBS
	by David F. Rogers. Copyright (C) 2000 David F. Rogers,
	All rights reserved.

	Name: tbspline.c
	Purpose: B-spline curve generator for periodic curves Chap3, Sec. 3.7
	Language: C
	Subroutines called: bsplineu.c
	Book reference:  Chapter 3
*/
void bsplineu_test() {

	int i;
	int npts, k, p1;

	float b[34];  /* allows for up to 11  control vertices */
	float p[103];  /* allows for up to 100 points on curve */

	npts = 11;
	k = 4;     /* fourth order */
	p1 = 21;   /* eleven points on curve */

	for (i = 1; i <= 3 * npts; i++) {
		b[i] = 0.;
	}

	for (i = 1; i <= 3 * p1; i++) {
		p[i] = 0.;
	}


	/*
		Define the control polygon, Ex. 3.7 in the z=1 plane because
		this is three dimensional routine. x=b[1], y=b[2], z=b[3], etc.
		Although this is the Ex. 3.7 control polygon, matrix methods
		are NOT used to generated the curve.
	*/
	b[1] = 0;
	b[2] = 0;
	b[3] = 1;
	b[4] = 2;
	b[5] = 0;
	b[6] = 1;
	b[7] = 4;
	b[8] = 0;
	b[9] = 1;
	b[10] = 4;
	b[11] = 2;
	b[12] = 1;
	b[13] = 4;
	b[14] = 4;
	b[15] = 1;
	b[16] = 2;
	b[17] = 4;
	b[18] = 1;
	b[19] = 0;
	b[20] = 4;
	b[21] = 1;
	b[22] = 0;
	b[23] = 2;
	b[24] = 1;
	b[25] = 0;
	b[26] = 0;
	b[27] = 1;
	b[28] = 2;
	b[29] = 0;
	b[30] = 1;
	b[31] = 4;
	b[32] = 0;
	b[33] = 1;

	/*	Comment out the above control polygon, change npts to npts = 4
		and uncomment the control polygon below to test Ex. 3.6	on p. 70.
	*/

	/*
		b[1]=0;
		b[2]=0;
		b[3]=1;
		b[4]=3;
		b[5]=9;
		b[6]=1;
		b[7]=6;
		b[8]=3;
		b[9]=1;
		b[10]=9;
		b[11]=6;
		b[12]=1;
	*/
	bsplineu(npts, k, p1, b, p);

	printf("\nPolygon points\n\n");

	for (i = 1; i <= 3 * npts; i = i + 3) {
		printf(" %f %f %f \n", b[i], b[i + 1], b[i + 2]);
	}

	printf("\nCurve points\n\n");

	for (i = 1; i <= 3 * p1; i = i + 3) {
		printf(" %f %f %f \n", p[i], p[i + 1], p[i + 2]);
	}
}