cmake_minimum_required(VERSION 3.10)

project(CornellBox)

set(CMAKE_CXX_STANDARD 17)

include_directories(include)

add_subdirectory(external)

add_executable(CornellBox src/main.cpp)

target_link_libraries(CornellBox PRIVATE ImGui)

find_package(OpenGL REQUIRED)
find_package(GLFW3 REQUIRED)
find_package(GLEW REQUIRED)
find_package(GLM REQUIRED)

target_link_libraries(CornellBox PRIVATE OpenGL::GL glfw GLEW::GLEW glm::glm)

file(COPY shaders/ DESTINATION ${CMAKE_BINARY_DIR}/shaders)

if(CMAKE_BUILD_TYPE STREQUAL "Debug")
    message(STATUS "Building in Debug mode")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g")
elseif(CMAKE_BUILD_TYPE STREQUAL "Release")
    message(STATUS "Building in Release mode")
endif()
