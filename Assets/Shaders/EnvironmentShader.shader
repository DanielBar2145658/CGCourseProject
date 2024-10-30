Shader "Custom/EnvironmentShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo", 2D) = "white" {}
        _NormalMap("Normal Map", 2D) = "white"{}
        _NormalSlider ("Bump Amount", Range(0,5)) = 1
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;
        sampler2D _Bump;

        half _NormalSlider;
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_Bump;
        };


        half _Metallic;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));
            o.Normal *= float3(_NormalSlider,_NormalSlider,1);
            o.Metallic = _Metallic;

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
