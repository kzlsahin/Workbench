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
"Cpp/dbezier.cpp" 
"Cpp/tbezier.cpp" 
"Cpp/tdbez.cpp" 
"Cpp/basis.cpp" 
"Cpp/tbezier.cpp" 
"Cpp/tdbez.cpp" 
"Cpp/bezier.cpp" 
"Cpp/basis.cpp" 
"Cpp/tbasis.cpp"
 "Cpp/knot.cpp" "HeaderFiles/knot.h")

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET CMakeProject1 PROPERTY CXX_STANDARD 20)
endif()

# TODO: Add tests and install targets if needed.
