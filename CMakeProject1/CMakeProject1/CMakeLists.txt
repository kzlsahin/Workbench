# CMakeList.txt : CMake project for CMakeProject1, include source and define
# project specific logic here.
#

# Add source to this project's executable.
include_directories("HeaderFiles")
include_directories("Cpp")
add_executable (
CMakeProject1 
"CMakeProject1.cpp" 
"HeaderFiles/CMakeProject1.h" 
"HeaderFiles/bezier.h"
"HeaderFiles/basis.h" 
"HeaderFiles/tdbez.h"
"HeaderFiles/dbezier.h" 
"HeaderFiles/tbezier.h"
"HeaderFiles/tdbez.h" 
"HeaderFiles/basis.h" 
"HeaderFiles/tbasis.h" 
"HeaderFiles/tbezier.h" 
"HeaderFiles/knot.h"
"HeaderFiles/dbasis.h"
"HeaderFiles/bspline.h"
"HeaderFiles/bsplineu.h"
"HeaderFiles/knotu.h"
"Cpp/Ch2BezierCurves/dbezier.cpp" 
"Cpp/Ch2BezierCurves/tbezier.cpp" 
"Cpp/Ch2BezierCurves/tdbez.cpp" 
"Cpp/Ch2BezierCurves/tbezier.cpp" 
"Cpp/Ch2BezierCurves/bezier.cpp" 
"Cpp/Ch3BSplineCurves/basis.cpp" 
"Cpp/Ch3BSplineCurves/tbasis.cpp"
"Cpp/Ch3BSplineCurves/knot.cpp" 
"Cpp/Ch3BSplineCurves/bspline.cpp" 
"Cpp/Ch3BSplineCurves/dbasis.cpp"  
"Cpp/Ch3BSplineCurves/bsplineu.cpp" 
"Cpp/Ch3BSplineCurves/knotu.cpp"
)

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET CMakeProject1 PROPERTY CXX_STANDARD 20)
endif()

# TODO: Add tests and install targets if needed.
