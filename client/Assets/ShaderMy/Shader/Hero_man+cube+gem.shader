//主要功能用在(角色身上的寶石或金屬物件),基於角色材質上的追加,並追加了Cubemap的效果
//角色附帶遮罩層,可以用一張圖的A通道控制哪裡是金屬與非金屬
//使用連續陣列圖來表現寶石或金屬的流光效果,附帶遮罩層,可以用一張圖的A通道控制哪裡有流光效果
//流光的計算用了fixed,造成移動的效果,如果使用int則會在原地流動
//使用頂點光照,全透空,雙面

Shader "Custom/Hero_man+cube+gem" 
{
	Properties
	{
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Main Mapping(RGBA)", 2D) = "white" {}
		_Cutoff ("Cutoff Value", Range(0,1)) = 0.8
		_MainTex1 ("Metal Mask(A)", 2D) = "white" {}		
        _Cubemap ("CubeMap", CUBE) = ""{}
        
        _gemmap ("Gem Mapping(RGBA)(X,Y)", 2D) = "white" {}
        _gemmask ("Gem Mask(A)", 2D) = "white" {}
        _gemLight ("Gem Self Light", float) = 1.0
        _SizeX ("Sequence Mapping(X)", Float) = 4
        _SizeY ("Sequence Mapping(Y)", Float) = 4
        _Speed ("Sequence Mapping Speed", Float) = 200
                
        _ReflAmountH ("Metal Reflection Amount", float) = 0.0
        _ReflAmountL ("Cloth Reflection Amount", float) = 0.0
		_LightEffH ("Metal Self Light", float) = 0.0
		_LightEffL ("Cloth Self Light", float) = 1.0
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
				
		fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _MainTex1;
		fixed _LightEffH;
		fixed _LightEffL;
		fixed _LightEffV;
	    samplerCUBE _Cubemap;
	    fixed _ReflAmount;
	    fixed _ReflAmountH;
	    fixed _ReflAmountL;
	    
	    sampler2D _gemmap;
		sampler2D _gemmask;
		fixed _gemLight;
        uniform fixed _SizeX;
        uniform fixed _SizeY;
        uniform fixed _Speed;		
		
        struct Input
		{
			fixed2 uv_MainTex;
			fixed3 worldRefl;
		};
		
		void surf (Input IN, inout SurfaceOutput o)
		{				
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed4 d = tex2D(_MainTex1, IN.uv_MainTex);

			if ( d.r == 0.0 )
			{
				_LightEffV = _LightEffL;
			}
			else
			{
				_LightEffV = _LightEffH;
			}

						
			if ( d.r == 0.0 )
			{
				_ReflAmount = _ReflAmountL;
			}
			else
			{
				_ReflAmount = _ReflAmountH;
			}			
			
	        fixed index = floor(_Time .x * _Speed);
	        fixed indexY = index/_SizeX;
            fixed indexX = index - indexY*_SizeX;
	        fixed2 testUV = fixed2(IN.uv_MainTex.x /_SizeX, IN.uv_MainTex.y /_SizeY);
	        testUV.x += indexX/_SizeX;
	        testUV.y += (indexY/_SizeY)*3;												
			
            fixed4 e = tex2D(_gemmap, testUV) * _Color  * _gemLight;
            fixed4 f = tex2D (_gemmask, IN.uv_MainTex);																																							
																																							
			o.Albedo = c.rgb * _LightEffV + c.rgb;
			o.Emission = c.rgb * texCUBE(_Cubemap, IN.worldRefl).rgb * _ReflAmount + e.rgb * f.r;
			o.Alpha = c.a;
		}
			
		ENDCG

   }
   
   FallBack "Transparent/Cutout/Diffuse"

}