add_library(ImGui STATIC
    ImGui/imgui.cpp
    ImGui/imgui_demo.cpp
    ImGui/imgui_draw.cpp
    ImGui/imgui_impl_glfw.cpp
    ImGui/imgui_impl_opengl3.cpp
    ImGui/imgui_tables.cpp
    ImGui/imgui_widgets.cpp
)

# 包含头文件目录
target_include_directories(ImGui PUBLIC
    ImGui
)

# 设置与 OpenGL 和 GLFW 的链接
find_package(OpenGL REQUIRED)
find_package(glfw3 REQUIRED)

target_link_libraries(ImGui PRIVATE OpenGL::GL glfw)