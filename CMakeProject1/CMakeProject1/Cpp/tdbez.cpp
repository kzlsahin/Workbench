/*
    Test program for C code from An Introduction to NURBS
    by David F. Rogers. Copyright (C) 2000 David F. Rogers,
    All rights reserved.

    Name: tdbez.c
    Purpose: test Bezier curve derivative generator
    Language: C
    Subroutines called: dbezier.c
    Book reference:  Chapter 2, Sec. 2.3, Alg. p. 277
*/
#include <stdio.h>
#include <cstdio>
#include "..\HeaderFiles\dbezier.h"
void tdbez_test() {

    int i;
    int npts, cpts;
    int ch;

    float b[31];  /* allows for up to 10  control vertices */
    float p[103];  /* allows for up to 100 points on curve */
    float d1[103];
    float d2[103];

    npts = 4;
    cpts = 11;   /* eleven points on curve */

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

    dbezier(npts, b, cpts, p, d1, d2);

    printf("\nPolygon points\n\n");

    for (i = 1; i <= 3 * npts; i = i + 3) {
        printf(" %f %f %f \n", b[i], b[i + 1], b[i + 2]);
    }

    ch = getchar();

    printf("\nCurve points\n\n");

    for (i = 1; i <= 3 * cpts; i = i + 3) {
        printf(" %f %f %f \n", p[i], p[i + 1], p[i + 2]);
    }

    ch = getchar();

    printf("\nFirst Derivative of Curve\n\n");

    for (i = 1; i <= 3 * cpts; i = i + 3) {
        printf(" %f %f %f \n", d1[i], d1[i + 1], d1[i + 2]);
    }

    ch = getchar();

    printf("\nSecond Derivative of Curve\n\n");

    for (i = 1; i <= 3 * cpts; i = i + 3) {
        printf(" %f %f %f \n", d2[i], d2[i + 1], d2[i + 2]);
    }
}