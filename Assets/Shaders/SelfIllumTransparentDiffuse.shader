Shader "Self-Illumin/Transparent/Diffuse"
{
	Properties
    {
		_MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Diffuse Color", Color) = (1,1,1,1)
        _Emission ("Emission Color", Color) = (1,1,1,1)
	}
	SubShader
    {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;

		struct Input
        {
			float2 uv_MainTex;
		};
        
        half4 _Color;
        half4 _Emission;

		void surf (Input IN, inout SurfaceOutput o)
        {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb * _Color.rgb;
            o.Emission = c.rgb * _Emission.rgb;
			o.Alpha = c.a * _Color.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
