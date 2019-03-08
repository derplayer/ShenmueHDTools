#version 440 core

in vec2 v_uv;
in vec4 v_color;
in vec3 v_norm;
in mat4 v_mv;
in vec3 v_fragPos;

out vec4 color;

uniform sampler2D u_texture;
uniform vec4 u_stripColor;
uniform vec3 u_lightPos;
uniform vec3 u_lightColor;
uniform vec4 u_colorOverride;

// 0 = shaded
// 1 = flat
// 2 = normal
// 3 = uv
// 4 = color
// 5 = colorOverride
uniform int u_drawMode;

void main(void)
{
	vec3 n = normalize(mat3(v_mv) * v_norm);
	vec2 uv = v_uv;

	if (u_drawMode == 0)
	{
		//ambient
		float ambientStrength = 0.2;
		vec3 ambient = ambientStrength * u_lightColor;

		//diffuse
		vec3 norm = normalize(mat3(v_mv) * v_norm);
		vec3 lightDir = normalize(u_lightPos - v_fragPos);

		float diff = max(dot(norm, lightDir), 0.0);
		vec3 diffuse = diff * u_lightColor;
		
		/*if (uv.x < 0.0 || uv.y < 0.0)
		{
			vec3 result = (ambient + diffuse) * v_color.rgb;
			color.rgb = result * u_stripColor.rgb;
			color.a = v_color.a;
		}
		else
		{*/
			vec3 result = (ambient + diffuse) * texture2D(u_texture, uv).rgb;
			color.rgb = result * u_stripColor.rgb;
			color.a = texture2D(u_texture, uv).a;
		/*}*/
		if (color.a < 0.1)
		{
			discard;
		}
		return;
	}
	if (u_drawMode == 1)
	{
		/*if (uv.x < 0.0 || uv.y < 0.0)
		{
			color.rgb = v_color.rgb * u_stripColor.rgb;
			color.a = v_color.a;
		}
		else
		{*/
			color.rgb = texture2D(u_texture, uv).rgb * u_stripColor.rgb;;
			color.a = texture2D(u_texture, uv).a;
		/*}*/
		if (color.a < 0.1)
		{
			discard;
		}
		return;
	}
	if (u_drawMode == 2)
	{
		color.rgb = 0.5 + 0.5 * n;
		color.a = 1.0f;
		return;
	}
	if (u_drawMode == 3)
	{
		color.rgb = vec3(v_uv.x, v_uv.y, 0.0);
		color.a = 1.0f;
		return;
	}
	if (u_drawMode == 4)
	{
		color.rgb = v_color.rgb * u_stripColor.rgb;
		color.a = v_color.a;
		return;
	}
	if (u_drawMode == 5)
	{
		color = u_colorOverride;
		return;
	}
}