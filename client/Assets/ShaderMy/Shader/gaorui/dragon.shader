//給火龍單獨編寫的,除了基礎的角色功能,添加了用一張黑白圖控制需要特別發亮的眼睛,添加了用一張灰階圖控制火龍身上的岩漿斑紋明暗閃動的功能
//頂點光源

Shader "Custom/gaorui/dragon" 
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 1, 1, 1)
		_MainTex ("Main Mapping(RGBA)", 2D) = "white" {}
		_MainTex1 ("Metal Mask(RGB)", 2D) = "white" {}
		_MainTex2 ("EYE Mask(RGB)", 2D) = "white" {}
	}
	
	SubShader
	{
		Tags
		{
		    "Queue"="AlphaTest"
		    "RenderType"="TransparentCutout"
		}
		
		Cull off
        LOD 200

		CGPROGRAM
		#pragma surface surf Lambert alphatest:_Cutoff exclude_path:prepass approxview nolightmap halfasview noforwardadd nodirlightmap
		#pragma fragmentoption ARB_precision_hint_fastest
        //#pragma 

        fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _MainTex1;
	    sampler2D _MainTex2;

        struct Input
		{
			fixed2 uv_MainTex;
		};
		
		void surf (Input IN, inout SurfaceOutput o)
		{				
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) + _Color * 0.1f;
			fixed4 body = tex2D(_MainTex1, IN.uv_MainTex);
			fixed4 eye = tex2D(_MainTex2, IN.uv_MainTex);

            if (body.r > 0)
			    o.Albedo = c.rgb + c.rgb * body.r * (1 + 0.5f * sin(_Time*5));
            else
            {
                o.Albedo = c.rgb * 0.5f;
			    o.Emission = c.rgb * 0.5f;
            }

			o.Alpha = c.a;
		}

		ENDCG
   }
   
   FallBack "Transparent/Cutout/Diffuse"

}