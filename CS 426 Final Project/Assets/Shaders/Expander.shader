Shader "Pulse/Normal Extrusion" {
    Properties{
      _MainTex("Texture", 2D) = "white" {}
      _Amount("Extrude Amount", Range(0,0.03)) = 0.02
    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM
          #pragma surface surf Lambert vertex:vert
          struct Input {
              float2 uv_MainTex;
          };
          float _Amount;
          void vert(inout appdata_full v) {
              v.vertex.xyz += v.normal * _Amount * (sin(_Time.y) + 1);
          }
          sampler2D _MainTex;
          void surf(Input IN, inout SurfaceOutput o) {
              o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
          }
          ENDCG
      }
          Fallback "Diffuse"
}