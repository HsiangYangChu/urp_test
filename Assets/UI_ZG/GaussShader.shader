// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with
// 'UnityObjectToClipPos(*)'

Shader "Custom/GaussShader" {
    Properties{_MainTex("Base (RGB)", 2D) = "white" {} _TimeX(
                   "Time", Range(0.0, 1.0)) = 1.0 _Distortion("_Distortion",
                                                              Range(0.0, 1.0)) =
                   0.3 _ScreenResolution("_ScreenResolution", Vector) =
                       (0., 0., 0., 0.)_Radius("_Radius", Range(0.0, 1000.0)) =
                           700.0 _Factor("_Factor", Range(0.0, 1000.0)) =
                               200.0} 
    SubShader {
        Tags { "RenderPipeline" = "UniversalPipeline"}
        Cull Off ZWrite Off ZTest Always
		Pass {
			HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/PostProcessing/Common.hlsl"

            uniform sampler2D _MainTex;
            uniform float _TimeX;
            uniform float _Distortion;
            uniform float4 _ScreenResolution;
            uniform float _Radius;
            uniform float _Factor;

            struct appdata {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                half2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half4 color : COLOR;
            };

            v2f vert(appdata IN) {
                v2f OUT;
                OUT.vertex = TransformObjectToHClip(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color;

                return OUT;
            }
            #define tex2D(sampler, uvs) tex2Dlod(sampler, float4((uvs), 0.0f, 0.0f))
            
            float4 frag(v2f i) : SV_Target {
                float factor = _Factor / _ScreenResolution.y * 64.0;
                float radius = _Radius / _ScreenResolution.x * 2.0;
                float4 col = 0.0;
                float4 accumColx = 0.0;
                float4 accumW = 0.0;
                for (float j = -5.0; j < 5.0; j += 1.0) {
                    for (float u = -5.0; u < 5.0; u += 1.0) {
                        float2 offsetx =
                            (1.0 / _ScreenResolution.xy) * float2(u + j, j - u);
                        col = tex2D(_MainTex, i.texcoord.xy + offsetx * radius);
                        float4 movie = 1.0 + col * col * col * factor;
                        accumColx = accumColx + col * movie;
                        accumW += movie;
                    }
                }
                accumColx = accumColx / accumW;
                // return accumColx;
				return (1.0, 0.0, 0.0, 1.0);
            }

            ENDHLSL
        }
    }
}
