/*  Subroutine to generate a B-spline curve using an uniform open knot vector

C code for An Introduction to NURBS
by David F. Rogers. Copyright (C) 2000 David F. Rogers,
All rights reserved.

Name: dbspline.c
Language: C
Subroutines called: knot.c, basis.c, fmtmul.c
Book reference: Section 3.5, Ex. 3.4, Alg. p. 288

b[]        = array containing the defining polygon vertices
              b[1] contains the x-component of the vertex
              b[2] contains the y-component of the vertex
              b[3] contains the z-component of the vertex
d1[]       = array containing the first derivative of the curve
              d1[1] contains the x-component
              d1[2] contains the y-component
              d1[3] contains the z-component
d2[]       = array containing the second derivative of the curve
              d2[1] contains the x-component
              d2[2] contains the y-component
              d2[3] contains the z-component
d1nbasis[]  = array containing the first derivative of the basis functions for a single value of t
d2nbasis[]  = array containing the second derivative of the basis functions for a single value of t
k           = order of the \bsp basis function
nbasis      = array containing the basis functions for a single value of t
nplusc      = number of knot values
npts        = number of defining polygon vertices
p[]         = array containing the curve points
              p[1] contains the x-component of the point
              p[2] contains the y-component of the point
              p[3] contains the z-component of the point
p1          = number of points to be calculated on the curve
t           = parameter value 0 <= t <= 1
x[]         = array containing the knot vector
*/
#include <stdio.h>


void dbspline(int npts, int k, int p1, float b [], float p [], float d1 [], float d2 [])
{
    int i, j, icount, jcount;
    int i1;
    int x[30];        /* allows for 20 data points with basis function of order 5 */
    int nplusc;

    float step;
    float t;
    float nbasis[20];
    float d1nbasis[20];
    float d2nbasis[20];
    float temp;


    nplusc = npts + k;

    /*  zero and redimension the knot vector and the basis arrays */

    for (i = 0; i <= npts; i++) {
        nbasis[i] = 0.;
        d1nbasis[i] = 0.;
        d2nbasis[i] = 0.;
    }

    for (i = 0; i <= nplusc; i++) {
        x[i] = 0.;
    }

    /* generate the uniform open knot vector */

    knotu(npts, k, x);

    /*
        printf("The knot vector is ");
        for (i = 1; i <= nplusc; i++){
            printf(" %d ", x[i]);
        }
        printf("\n");
    */

    icount = 0;

    /*    calculate the points on the bspline curve */

    t = k - 1;
    step = ((float)(npts - (k - 1))) / ((float)(p1 - 1));

    for (i1 = 1; i1 <= p1; i1++) {

        if ((float)npts - t < 5e-6) {
            t = (float)npts;
        }

        dbasisu(k, t, npts, x, nbasis, d1nbasis, d2nbasis);      /* generate the basis function for this value of t */
        /*
                printf("t = %f \n",t);
                printf("nbasis = ");
                for (i = 1; i <= npts; i++){
                    printf("%f  ",nbasis[i]);
                }
                printf("\n");
        */
        /*
                printf("t = %f \n",t);
                printf("d1nbasis = ");
                for (i = 1; i <= npts; i++){
                    printf("%f  ",d1nbasis[i]);
                }
                printf("\n");
        */
        /*
                printf("t = %f \n",t);
                printf("d2nbasis = ");
                for (i = 1; i <= npts; i++){
                    printf("%f  ",d2nbasis[i]);
                }
                printf("\n");
        */

        for (j = 1; j <= 3; j++) {      /* generate a point on the curve */
            jcount = j;
            p[icount + j] = 0.;
            d1[icount + j] = 0.;
            d2[icount + j] = 0.;

            for (i = 1; i <= npts; i++) { /* Do local matrix multiplication */
                p[icount + j] = p[icount + j] + nbasis[i] * b[jcount];
                d1[icount + j] = d1[icount + j] + d1nbasis[i] * b[jcount];
                d2[icount + j] = d2[icount + j] + d2nbasis[i] * b[jcount];
                /*
                                printf("jcount,nbasis,b,nbasis*b,p = %d %f %f %f %f\n",jcount,nbasis[i],b[jcount],temp,p[icount+j]);
                */
                jcount = jcount + 3;
            }
        }

        /*        printf("icount, p %d %f %f %f \n",icount,p[icount+1],p[icount+2],p[icount+3]);*/

        icount = icount + 3;
        t = t + step;
    }
}


/*
    Test program for C code from An Introduction to NURBS
    by David F. Rogers. Copyright (C) 2000 David F. Rogers,
    All rights reserved.

    Name: tdbsplu.c
    Purpose: Periodic B-spline curve and derivative generator
    Language: C
    Subroutines called: dbsplinu.c
    Book reference:  Chapter 3, Sec. 3.12, Ex. 3.8, Alg. p. 290
*/

void dbsplineu_test() {

    int i;
    int npts, k, p1;
    int ch;

    float b[31];  /* allows for up to 10  control vertices */
    float p[103];  /* allows for up to 100 points on curve */
    float d1[103];  /* allows for up to 100 points on curve */
    float d2[103];  /* allows for up to 100 points on curve */

    npts = 4;
    k = 2;     /* second order, change to 4 to get fourth order */
    p1 = 11;   /* eleven points on curve */

    for (i = 1; i <= 3 * npts; i++) {
        b[i] = 0.;
    }

    for (i = 1; i <= 3 * p1; i++) {
        p[i] = 0.;
    }


    /*
        Define the control polygon, Ex. 3.4 in the z=1 plane because
        this is three dimensional routine. x=b[1], y=b[2], z=b[3], etc.
    */
    b[1] = 1;
    b[2] = 1;
    b[3] = 1;
    b[4] = 2;
    b[5] = 3;
    b[6] = 1;
    b[7] = 4;
    b[8] = 3;
    b[9] = 1;
    b[10] = 3;
    b[11] = 1;
    b[12] = 1;

    dbspline(npts, k, p1, b, p, d1, d2);

    printf("\nPolygon points\n\n");

    for (i = 1; i <= 3 * npts; i = i + 3) {
        printf(" %f %f %f \n", b[i], b[i + 1], b[i + 2]);
    }

    ch = getchar();

    printf("\nCurve points\n\n");

    for (i = 1; i <= 3 * p1; i = i + 3) {
        printf(" %f %f %f \n", p[i], p[i + 1], p[i + 2]);
    }

    ch = getchar();

    printf("\nCurve first derivatives\n\n");

    for (i = 1; i <= 3 * p1; i = i + 3) {
        printf(" %f %f %f \n", d1[i], d1[i + 1], d1[i + 2]);
    }
    ch = getchar();

    printf("\nCurve second derivatives\n\n");

    for (i = 1; i <= 3 * p1; i = i + 3) {
        printf(" %f %f %f \n", d2[i], d2[i + 1], d2[i + 2]);
    }
}