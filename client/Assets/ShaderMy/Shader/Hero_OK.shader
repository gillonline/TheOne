//角色使用的基礎材質球(初版)
//簡單的顏色控制,貼圖自發光
//使用頂點光照,全透空,雙面

Shader "Custom/Hero_OK"
{
   Properties
   {
      _Color ("Main Color", Color) = (1,1,1,1)
      _MainTex ("Main Mapping(RGBA)", 2D) = "white" {}
      _Cutoff ("Cutoff Value", Range(0,1)) = 0.5
      _SelfLight ("Main Mapping Self Light", float) = 0.5
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
      #pragma surface surf Lambert alphatest:_Cutoff exclude_path:prepass approxview nolightmap halfasview noforwardadd
				
      fixed4 _Color;
      sampler2D _MainTex;
      fixed _SelfLight;

      struct Input
      {
         fixed2 uv_MainTex;
      };
		
      void surf (Input IN, inout SurfaceOutput o)
      {				
         fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
      
         o.Albedo = c.rgb;
	     o.Emission = c.rgb *_SelfLight;
	     o.Alpha = c.a;
      }
		
      ENDCG

   }
   
   FallBack "Transparent/Cutout/Diffuse"

}