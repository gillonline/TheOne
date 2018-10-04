//提供遊戲假影子使用的shader

Shader "Custom/Hero_shadows" 
{
	Properties 
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Main Mapping(RGBA)", 2D) = "white" {}
    }

    SubShader 
    {
      Tags 
      {
          "Queue"="Transparent-1"
          "RenderType"="Transparent"
      }
      
    LOD 200
    
    CGPROGRAM
    #pragma surface surf Lambert alpha exclude_path:prepass approxview nolightmap halfasview noforwardadd nodirlightmap noambient

    sampler2D _MainTex;
    fixed4 _Color;

    struct Input 
      {
          fixed2 uv_MainTex;
      };

    void surf (Input IN, inout SurfaceOutput o) 
      {    
          fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
          o.Albedo = c.rgb;
          o.Emission = c.rgb * _Color;
          o.Alpha = c.a;
      }
      
      ENDCG
      
    }

    Fallback "Transparent/VertexLit"
    
}