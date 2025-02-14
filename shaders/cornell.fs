#version 330 core
in vec3 fragColor;   // 从顶点着色器传递的颜色
in vec3 fragNormal;   // 从顶点着色器传递的法线
in vec3 fragPos;      // 从顶点着色器传递的位置

out vec4 FragColor;   // 最终输出的颜色

// 光源和材质属性
uniform vec3 lightPos;  // 光源位置
uniform vec3 viewPos;   // 观察者位置
uniform vec3 lightColor; // 光源颜色

void main() {
    // 计算环境光
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;

    // 计算漫反射光
    vec3 norm = normalize(fragNormal);  // 法线单位化
    vec3 lightDir = normalize(lightPos - fragPos);  // 光源方向
    float diff = max(dot(norm, lightDir), 0.0); // 漫反射系数
    vec3 diffuse = diff * lightColor;

    // 计算镜面反射光
    float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - fragPos);  // 视线方向
    vec3 reflectDir = reflect(-lightDir, norm);  // 反射方向
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32); // 镜面反射系数
    vec3 specular = specularStrength * spec * lightColor;

    // 最终颜色是环境光、漫反射光和镜面反射光的组合
    vec3 result = (ambient + diffuse + specular) * fragColor;

    FragColor = vec4(result, 1.0); // 输出最终颜色
}
