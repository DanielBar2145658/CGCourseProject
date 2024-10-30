Shader "Custom/ToonShader"
{
    Properties
    {
        //Textures
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white" {}
        
        _DitherMask("Dither Mask", 2D) = "white" {}

        //Colour Range
        _RampText("Ramp Texture", 2D) = "white" {}

        //rim
        _RimColor("Rim Color", Color) = (0.5,0.5,0.0)
        _RimPower("Rim Power", Range(0.0,8.0)) = 3.0

        _RimOffset ("Rim Offset", Range(0.0,1.0)) = 0.5





        //Halftone

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        

        
        CGPROGRAM
        #pragma surface surf ToonRamp

        sampler2D _MainTex;
        float4 _Color;
        
        sampler2D _RampText;


        float4 _RimColor;
        float _RimPower;

        float _RimOffset;
        //float _RimInfluence;

        float4 LightingToonRamp(SurfaceOutput s, fixed3 lightdir, fixed atten)
        {
            float diff= dot(s.Normal, lightdir);
            float h = diff * 0.5 + 0.5;
            float2 rh = h;
            float3 cs =_LightColor0.rgb;


            
            
            
            
            float3 ramp = tex2D(_RampText, rh).rgb ;

            float4 c;
            c.rgb = s.Albedo *( h * ramp * cs);
            c.a = s.Alpha;
            return c;


        }
        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            
        };
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;


            
            half rim = _RimPower - saturate(dot(normalize(IN.viewDir),o.Normal));
            //half lighter = dot(rim, -o.Normal);
            
            o.Emission = _RimColor.rgb * pow(rim, _RimPower);

            

            o.Emission = rim > 0.8 ? _RimColor.rgb : 0;
            

            
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex));
            

            //o.Albedo = _Color.rgb;
        }

        ENDCG
        

    }
    FallBack "Diffuse"
}
