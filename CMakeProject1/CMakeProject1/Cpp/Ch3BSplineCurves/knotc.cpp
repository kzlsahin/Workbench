/*  Subroutine to generate a nonuniform open knot vector proportional to the
	chord lengths between defining polygon vertices

	c           = order of the basis function
	chord       = chord distance between defining polygon vertices
	csum        = accummulated sum of the chord distances from the first defining polygon vertex
	maxchord    = sum of the chord distances between defining polygon vertices
	npts        = the number of defining polygon vertices
	nplusc      = maximum value of the knot vector -- $n + c$
	numerator   = numerator of Eq. (5--86)
	x()         = array containing the knot vector
	xchord      = x-component of the distance between defining polygon vertices
	ychord      = y-component of the distance between defining polygon vertices
*/

#include <math.h>

void knotc(int npts, int c, float b[], float x[])
{
	int i, j;
	int icount;
	int nplusc, n;

	float chord[31];
	float maxchord;
	float xchord, ychord, zchord;
	float csum;
	float numerator;
	float temp1;
	float temp2;


	nplusc = npts + c;
	n = npts - 1;

	/*    zero and redimension the knot vector and chord values	*/

	for (i = 0; i <= npts; i++) {
		chord[i] = 0;
	}

	/*    determine chord distance between defining polygon vertices and their sum	*/

	maxchord = 0;
	icount = 0;
	for (i = 4; i <= 3 * npts; i = i + 3) {
		icount = icount + 1;
		xchord = b[i] - b[i - 3];
		ychord = b[i + 1] - b[i - 2];
		zchord = b[i + 2] - b[i - 1];
		chord[icount] = sqrt(xchord * xchord + ychord * ychord + zchord * zchord);
		maxchord = maxchord + chord[icount];
	}

	/*    multiplicity of c=order zeros at the beginning of the open knot vector */

	for (i = 1; i <= c; i++) {
		x[i] = 0;
	}

	/*    generate the internal knot values	*/

	for (i = 1; i <= n - c + 1; i++) {

		csum = 0;
		for (j = 1; j <= i; j++) {
			csum = csum + chord[j];
		}

		numerator = ((float)i) / ((float)(n - c + 2)) * chord[i + 1] + csum;
		x[c + i] = (numerator / maxchord) * ((float)(n - c + 2));

	}

	/*    multiplicity of c=order zeros at the end of the open knot vector	*/

	for (i = n + 2; i <= nplusc; i++) {
		x[i] = n - c + 2;
	}

}