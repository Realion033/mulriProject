Shader "Custom/monster"
{
    Properties
    {
        _Color("Trail Color", Color) = (1, 1, 1, 1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Speed("Trail Speed", Range(0.1, 10)) = 1
    }

        SubShader
        {
            Tags { "Queue" = "Transparent" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _Color;
                float _Speed;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    float2 uv = i.uv;
                    uv.x -= _Time.y * _Speed; // 시간에 따라 UV 좌표를 이동
                    half4 col = tex2D(_MainTex, uv);
                    col *= _Color;
                    return col;
                }
                ENDCG
            }
        }
}
