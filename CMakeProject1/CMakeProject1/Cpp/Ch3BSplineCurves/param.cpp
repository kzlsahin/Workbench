/* Subroutine to calculate parameter values based on chord distances.

    C code for An Introduction to NURBS
    by David F. Rogers. Copyright (C) 2000 David F. Rogers,
    All rights reserved.

    Name: param.c
    Language: C
    Subroutines called: none
    Book reference: Alg. p. 295

    d[]        = array containing the data points
    dpts       = number of data points
    isum       = incremental sum of the chord distances
    sum        = sum of all the chord distances
    tparm[]    = array containing the parameter values
*/

#include <math.h>

void param(int dpts, float d[], double tparm[])
{
    int i;
    int icount;

    float sum;
    float isum;
    float tempdx;
    float tempdy;
    float tempdz;

    sum = 0.;
    isum = 0.;
    tparm[1] = 0.;

    /*    calculate the sum of the chord distances for all the data points */

    for (i = 1; i < 3 * (dpts - 1); i = i + 3) {
        tempdx = (d[i + 3] - d[i]) * (d[i + 3] - d[i]);
        tempdy = (d[i + 4] - d[i + 1]) * (d[i + 4] - d[i + 1]);
        tempdz = (d[i + 5] - d[i + 2]) * (d[i + 5] - d[i + 2]);
        sum = sum + sqrt(tempdx + tempdy + tempdz);
    }

    /*    calculate the parameter values */

    icount = 2;

    for (i = 1; i < 3 * (dpts - 1); i = i + 3) {
        tempdx = (d[i + 3] - d[i]) * (d[i + 3] - d[i]);
        tempdy = (d[i + 4] - d[i + 1]) * (d[i + 4] - d[i + 1]);
        tempdz = (d[i + 5] - d[i + 2]) * (d[i + 5] - d[i + 2]);
        isum = isum + sqrt(tempdx + tempdy + tempdz);
        tparm[icount] = isum / sum;
        icount = icount + 1;
    }
}
