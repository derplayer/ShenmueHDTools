#version 440 core

layout(location = 0) in vec3 position;
layout(location = 1) in vec3 normal;
layout(location = 2) in vec2 uv;
layout(location = 3) in vec4 color;

out vec2 v_uv;
out vec4 v_color;
out vec3 v_norm;
out mat4 v_mv;
out vec3 v_fragPos;

uniform mat4 u_model;
uniform mat4 u_view;
uniform mat4 u_projection;

void main(void)
{
	v_norm = normal;
	v_mv = u_view * u_model;
	v_uv = uv;
	v_color = color;
	v_fragPos = vec3(u_model * vec4(position, 1.0));

	gl_Position = u_projection * u_view * u_model * vec4(position, 1.0);
	gl_PointSize = 2.0;
	//gl_PointSize = 2.0 * 1.5 / gl_Position.w;
}