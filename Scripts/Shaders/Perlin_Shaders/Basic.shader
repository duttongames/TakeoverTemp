Shader "Custom/Basic"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"RenderType"="Opaque"}
        LOD 100

        // A BASIC PASS FOR THE SHADER
        // INCLUDES VERTEXT AND FRAGMENT DATA TO INSINUATE HOW LIGHT BOUNCES OFF
        // THE OBJECTS.
        Pass
        {
            #pragma vertex VERT;
            #pragma fragment FRAG;

            #include "UnityCG.cginc"

            struct GEO_DATA
            {
                float4 VERTEX : POSITION;
                float2 UV : TEXCOORD0;
            };

            struct VECTOR2_FLOAT
            {
                float2 UV : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 VERTEX : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
        }
    }
    FallBack "Diffuse"
}
