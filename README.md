# Cornell Box

This is a simple Cornell Box scene rendered with OpenGL and GLSL.

## How to run

1. Clone the repository
2. Vcpkg is required to install the dependencies. Follow the instructions:

```bash
vcpkg install glfw3
vcpkg install glew
vcpkg install glm
```

If you don't have vcpkg installed, you can download it from [here](https://learn.microsoft.com/en-us/vcpkg/get_started/overview)

After installing the dependencies, you should check the CmakePresets.json file.

3. Run the following commands:

```bash
cd CornellBox
cmake --preset=Release
cmake --build build --config Release
./build/Release/CornellBox.exe
```

