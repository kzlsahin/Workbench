﻿# CMakeList.txt : CMake project for CMakeProject1, include source and define
# project specific logic here.
#

# Add source to this project's executable.
include_directories("HeaderFiles")
include_directories("Cpp")
include_directories("Lib")

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
"HeaderFiles/bspline.h" 
"HeaderFiles/bsplineu.h" 
"HeaderFiles/dbasis.h" 
"HeaderFiles/dbasisu.h" 
"HeaderFiles/dbspline.h" 
"HeaderFiles/dbsplineu.h" 
"HeaderFiles/knot.h" 
"HeaderFiles/knotu.h" 
"HeaderFiles/knotc.h" 
"HeaderFiles/param.h" 
"Cpp/Ch2BezierCurves/dbezier.cpp" 
"Cpp/Ch2BezierCurves/tbezier.cpp" 
"Cpp/Ch2BezierCurves/tdbez.cpp" 
"Cpp/Ch2BezierCurves/tbezier.cpp" 
"Cpp/Ch2BezierCurves/bezier.cpp" 
"Cpp/Ch3BSplineCurves/basis.cpp" 
"Cpp/Ch3BSplineCurves/tbasis.cpp" 
"Cpp/Ch3BSplineCurves/bspline.cpp" 
"Cpp/Ch3BSplineCurves/dbasis.cpp"  
"Cpp/Ch3BSplineCurves/bsplineu.cpp" 
"Cpp/Ch3BSplineCurves/dbasisu.cpp" 
"Cpp/Ch3BSplineCurves/dbspline.cpp" 
"Cpp/Ch3BSplineCurves/knot.cpp" 
"Cpp/Ch3BSplineCurves/knotu.cpp" 
 "Cpp/Ch3BSplineCurves/knotc.cpp"
 "Cpp/Ch3BSplineCurves/param.cpp" 
)
target_link_libraries (CMakeProject1 PUBLIC "Lib/OpenGL32.Lib")
if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET CMakeProject1 PROPERTY CXX_STANDARD 20)
endif()

# TODO: Add tests and install targets if needed.
