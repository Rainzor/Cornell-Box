#version 330 core
layout(location = 0) in vec3 aPos;  // 顶点位置
layout(location = 1) in vec3 aColor; // 顶点颜色
layout(location = 2) in vec3 aNormal; // 顶点法线

out vec3 fragColor;  // 传递给片段着色器的颜色
out vec3 fragNormal; // 传递给片段着色器的法线
out vec3 fragPos;    // 传递给片段着色器的世界空间位置

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main() {
    fragColor = aColor; // 传递颜色到片段着色器
    fragNormal = mat3(transpose(inverse(model))) * aNormal; // 将法线转换到世界空间
    fragPos = vec3(model * vec4(aPos, 1.0)); // 将顶点位置转换到世界空间
    gl_Position = projection * view * vec4(fragPos, 1.0); // 计算最终的顶点位置
}
