Shader "Unlit/Guide"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ZTestAddValue("Z Test Add Value",float) = 1
        _Alpha("Alpha",Range(0,1)) = 0
    }
    SubShader
    {    
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ZTestAddValue;
            float _Alpha;

            v2f vert (appdata v)
            {
                v2f o;
                float4 clipPos = UnityObjectToClipPos(v.vertex);
                // #if UNITY_REVERSED_Z
                //     clipPos.z+=_ZTestAddValue;
        	    //     clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);//限定在范围内
        	    // #else
                //     clipPos.z-=_ZTestAddVal;
        	    //     clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);//限定在范围内
        	    // #endif
                o.vertex = clipPos;

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a *= _Alpha;
                return col;
            }
            ENDCG
        }
    }
}
