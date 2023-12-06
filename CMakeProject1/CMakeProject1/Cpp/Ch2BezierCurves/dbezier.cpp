/*  Subroutine to generate a Bezier curve.
    Copyright (c) 2000 David F. Rogers. All rights reserved.

    b[]        = array containing the defining polygon vertices
                  b[1] contains the x-component of the vertex
                  b[2] contains the y-component of the vertex
                  b[3] contains the z-component of the vertex
    Basis      = function to calculate the Bernstein basis value (see MECG Eq 5-65)
    cpts       = number of points to be calculated on the curve
    d1[]       = array containing the first derivative of the curve
                 d1[1] contains the x-component of the first derivative
                 d1[2] contains the y-component of the first derivative
                 d1[3] contains the z-component of the first derivative
    d2[]       = array containing the second derivative of the curve
                 d2[1] contains the x-component of the second derivative
                 d2[2] contains the y-component of the second derivative
                 d2[3] contains the z-component of the second derivative
    Fractrl    = function to calculate the factorial of a number
    j[]        = array containing the basis functions for a single value of t
    npts       = number of defining polygon vertices
    p[]        = array containing the curve points
                 p[1] contains the x-component of the point
                 p[2] contains the y-component of the point
                 p[3] contains the z-component of the point
    t          = parameter value 0 <= t <= 1
*/

#include <math.h>
#include <cstdio>
/* function to calculate the factorial */

float factrl(int n)
{
    static int ntop = 6;
    static float a[33] = { 1.0,1.0,2.0,6.0,24.0,120.0,720.0 }; /* fill in the first few values */
    int j1;

    if (n < 0) printf("\nNegative factorial in routine FACTRL\n");
    if (n > 32) printf("\nFactorial value too large in routine FACTRL\n");

    while (ntop < n) { /* use the precalulated value for n = 0....6 */
        j1 = ntop++;
        a[n] = a[j1] * ntop;
    }
    return a[n]; /* returns the value n! as a floating point number */
}

/* function to calculate the factorial function for Bernstein basis */

float Ni(int n, int i)
{
    float ni;
    ni = factrl(n) / (factrl(i) * factrl(n - i));
    return ni;
}

/* function to calculate the Bernstein basis */

float Basis(int n, int i, float t)
{
    float basis;
    float ti; /* this is t^i */
    float tni; /* this is (1 - t)^i */

    /* handle the special cases to avoid domain problem with pow */

    if (t == 0. && i == 0) ti = 1.0; else ti = pow(t, i);
    if (n == i && t == 1.) tni = 1.0; else tni = pow((1 - t), (n - i));
    basis = Ni(n, i) * ti * tni; /* calculate Bernstein basis function */
    return basis;
}

/* Bezier curve subroutine */

void dbezier(int npts, float b[], int cpts,float p[], float d1[], float d2[])
{
    int i;
    int j;
    int i1;
    int icount;
    int jcount;
    int n;

    float step;
    float t;
    float tempbasis;
    float temp1;
    float temp2;

    float factrl(int);
    float Ni(int, int);
    float Basis(int, int, float);

    /* calculate the points on the Bezier curve */

    icount = 0;
    t = 0;
    step = 1.0 / ((float)(cpts - 1));

    for (i1 = 1; i1 <= cpts; i1++) { /* main loop */

        if ((1.0 - t) < 5e-6) t = 1.0;

        for (j = 1; j <= 3; j++) { /* generate a point on the curve */
            jcount = j;
            p[icount + j] = 0.;
            d1[icount + j] = 0.;
            d2[icount + j] = 0.;

            if (t == 0.) { /* derivatives at t=0, jcount = 1,2,3 for x,y,z */
                d1[icount + j] = (npts - 1) * (b[jcount + 3] - b[jcount]);
                d2[icount + j] = (npts - 1) * (npts - 2) * (b[jcount] - 2 * b[jcount + 3] + b[jcount + 6]);
            }

            for (i = 1; i <= npts; i++) { /* Do x,y,z components */
                tempbasis = Basis(npts - 1, i - 1, t);
                p[icount + j] = p[icount + j] + tempbasis * b[jcount];
                if (t != 0. && t != 1.) {
                    d1[icount + j] = d1[icount + j] + (((i - 1) - (npts - 1) * t) / (t * (1 - t))) * tempbasis * b[jcount];
                    temp1 = ((i - 1) - (npts - 1) * t) * ((i - 1) - (npts - 1) * t);
                    temp2 = temp1 - (npts - 1) * t * t - (i - 1) * (1 - 2 * t);
                    d2[icount + j] = d2[icount + j] + ((temp2) / (t * t * (1 - t) * (1 - t))) * tempbasis * b[jcount];
                }

                if (t == 1.) { /* derivatives at t=1, jcount = cpts-2,1,0 for x,y,z */
                    d1[icount + j] = (npts - 1) * (b[jcount] - b[jcount - 3]);
                    d2[icount + j] = (npts - 1) * (npts - 2) * (b[jcount] - 2 * b[jcount - 3] + b[jcount - 6]);
                }
                jcount = jcount + 3;
            }
        }

        icount = icount + 3;
        t = t + step;
    }
}

