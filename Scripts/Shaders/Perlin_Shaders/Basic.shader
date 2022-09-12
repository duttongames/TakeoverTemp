Shader "Custom/Basic"
{
    Properties
    {
       // _MainTex ("Albedo (RGB)", 2D) = "white" {}
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
            };

            struct VECTOR2_FLOAT
            {
                float4 VERTEX : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            VECTOR2_FLOAT VERT (GEO_DATA GD)
            {
                VECTOR2_FLOAT O;
                O.VERTEX = UnityObjectToClipPos(GD.VERTEX);
                return O;
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
    FallBack "Diffuse"
}
