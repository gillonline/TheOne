// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Hero_man+cube" 
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Main Mapping(RGBA)", 2D) = "white" {}
		_Cutoff ("Cutoff Value", Range(0,1)) = 0.8

	    _BSpeColor ("B_Spe Color", Color) = (0.5,0.5,0.5,0.0)
        _BSpeRange ("B_Spe Range", float) = 2.5
        
		_Cubemap ("CubeMap", CUBE) = ""{}
		_MainTex1 ("Metal Mask(RGB)", 2D) = "white" {}
		_LightEffH ("Metal Self Light", float) = 1.0
		_LightEffL ("Cloth Self Light", float) = 1.0
		_CubemapPow ("CubemapPow", float) = 1.0
	}

	SubShader
	{
        Pass
        {
            Tags
            {
               "LightMode"="ForwardBase"
               "Queue"="AlphaTest"
               "RenderType"="TransparentCutout"
            }

            Cull off
            LOD 200
              
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _Color;
            fixed4 _MainTex_ST;
            sampler2D _MainTex;
            fixed _Cutoff;

            fixed4 _BSpeColor;
            fixed _BSpeRange;
                        
		    sampler2D _MainTex1;
		    fixed _LightEffH;
		    fixed _LightEffL;
		    fixed _LightEffV;
		    samplerCUBE _Cubemap;
		    fixed _CubemapPow;

            struct vertexInput
            {
                fixed4 vertex : POSITION;
                fixed3 normal : NORMAL;
                fixed2 texcoord: TEXCOORD0;
            };

            struct vertexOutput
            {
                fixed4 pos : SV_POSITION;
                fixed4 posWorld : TEXCOORD0;
                fixed3 normalDir : TEXCOORD1;
                fixed3 vertexLighting : TEXCOORD2;
                LIGHTING_COORDS(3, 4)
                fixed2 uv : TEXCOORD5;
                fixed3 R : TEXCOORD6;
            };
            
            fixed3 reflect(fixed3 I,fixed3 N)
            {
                return I - 2.0*N *dot(N,I);
            }

            vertexOutput vert(vertexInput input)
            {
                vertexOutput output;
                                                                
                output.pos = UnityObjectToClipPos(input.vertex);
                output.posWorld = mul(unity_ObjectToWorld, input.vertex);
                output.normalDir =  normalize(mul(fixed4(input.normal, 0.0), unity_WorldToObject).xyz);             
                output.vertexLighting = fixed3(0,0,0);//SH/ambient
                
                #ifdef LIGHTMAP_OFF
                fixed3 shLight = ShadeSH9 (fixed4(output.normalDir, 1.0));
                output.vertexLighting = shLight;
                #endif // LIGHTMAP_OFF

                #ifdef VERTEXLIGHT_ON
                fixed3 vertexLight = Shade4PointLights
                (
                    unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
                    unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
                    unity_4LightAtten0, output.posWorld, output.normalDir
                );
                output.vertexLighting += vertexLight;
                #endif // VERTEXLIGHT_ON

                fixed3 posW = mul(unity_ObjectToWorld,input.vertex).xyz;
                fixed3 I = posW - _WorldSpaceCameraPos.xyz;
                fixed3 N = mul((fixed3x3)unity_ObjectToWorld,input.normal);
                N = normalize(N);
                output.R = reflect(I,N);
                
                vertexInput v = input;
                TRANSFER_VERTEX_TO_FRAGMENT(output);
                
                output.uv = TRANSFORM_TEX(input.texcoord, _MainTex);

                return output;
            }

            fixed4 frag(vertexOutput input):COLOR
            {
                fixed4 c = tex2D(_MainTex, input.uv) * _Color;
                fixed4 d = tex2D(_MainTex1, input.uv);
                fixed4 e = texCUBE(_Cubemap, input.R);                

                fixed3 lightDirection;
                fixed attenuation;
                attenuation = 1.0;
                lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                attenuation = LIGHT_ATTENUATION(input);

                fixed3 normalDirection = normalize(input.normalDir);
                fixed3 viewDirection = normalize(_WorldSpaceCameraPos - input.posWorld.xyz);

                fixed3 diffuseReflection = attenuation * (_LightColor0.rgb*50) * max(0.0, dot(normalDirection, lightDirection));

                fixed3 Bh = normalize (normalDirection - viewDirection);
                fixed Bnh = max (0, dot (normalDirection, Bh));
                fixed Bspec = pow (Bnh, _BSpeRange);
                fixed3 BspecularReflection = Bspec * _BSpeColor.rgb;

                fixed4 light = fixed4(input.vertexLighting +  diffuseReflection + BspecularReflection, 0.0);
           
			    if ( d.r == 0.0 )
			    {
				   _LightEffV = _LightEffL;
			    }
			    else
			    {
				   _LightEffV = _LightEffH * (e * _CubemapPow);
			    }                
                
                clip (c.a - _Cutoff);

                return (c * _LightEffV + c) * light;
            }
		   ENDCG
		}
	}
	Fallback "Transparent/Cutout/VertexLit"
}