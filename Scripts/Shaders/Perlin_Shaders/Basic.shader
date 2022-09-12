Shader "Unlit/Basic"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColour("Base Colour", COLOUR) = {1,1,1,1}
    }
    SubShader
    {
        Tags {"RenderType"="Opaque"}
        LOD 100
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        CBUFFER_START(UnityPerMaterial)
        float _BaseColour;
        CBUFFER_END

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

        ENDHLSL

        // A BASIC PASS FOR THE SHADER
        // INCLUDES VERTEXT AND FRAGMENT DATA TO INSINUATE HOW LIGHT BOUNCES OFF
        // THE OBJECTS.
        
        PASS
        {
            CGPROGRAM
            #pragma vertex VERTEX
            #pragma fragment FRAGMENT

            struct GEO_DATA
            {
                float4 vertex : POSITION;
            };

            struct VECTOR2_FLOAT
            {
                float4 vertex : SV_POSTION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            VECTOR2_FLOAT VERTEX (GEO_DATA v)
            {
                VECTOR2_FLOAT o;
                o.VERTEX = UnityObjectToClipPos(v.VERTEX);
                return o;
            }

            // THE FRAGMENT OF THE MAT PROVIDES THE DIFFUSE
            // FOR BASIC DEMONSTRATION, THIS WILL RETURN A WHITE COLOUR
            // IN ACCORDANCE WITH RGBA

            fixed4 FRAG (VECTOR2_FLOAT i) : SV_TARGET
            {
                return float4(1,0,0,1);
            }

            ENDCG
        }
    }
}
