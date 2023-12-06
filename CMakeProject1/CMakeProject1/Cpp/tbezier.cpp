// CMakeProject1.cpp : Defines the entry point for the application.
//

#include "CMakeProject1.h"
#include "bezier.h"
#include <cstdio>

using namespace std;
using namespace Bezier;
/*
    Test program for C code from An Introduction to NURBS
    by David F. Rogers. Copyright (C) 2000 David F. Rogers,
    All rights reserved.

    Name: tbezier.c
    Purpose: test Bezier curve generator
    Language: C
    Subroutines called: bezier.c
    Book reference:  Chapter 2, Sec. 2.1, Alg. p. 276
*/
void tbezier_test() {

    int i;
    int npts, cpts;
    int ch;

    float b[31];  /* allows for up to 10  control vertices */
    float p[103];  /* allows for up to 100 points on curve */
    npts = 4;
    cpts = 21;   /* eleven points on curve */

    for (i = 1; i <= 3 * npts; i++) {
        b[i] = 0.;
    }

    for (i = 1; i <= 3 * cpts; i++) {
        p[i] = 0.;
    }


    /*
        Define the control polygon, Ex. 2.1 in the z=1 plane because
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

    bezier(npts, b, cpts, p);

    printf("\nPolygon points\n\n");

    for (i = 1; i <= 3 * npts; i = i + 3) {
        printf(" %f %f %f \n", b[i], b[i + 1], b[i + 2]);
    }

    ch = getchar();

    printf("\nCurve points\n\n");

    for (i = 1; i <= 3 * cpts; i = i + 3) {
        printf(" %f %f %f \n", p[i], p[i + 1], p[i + 2]);
    }
}
