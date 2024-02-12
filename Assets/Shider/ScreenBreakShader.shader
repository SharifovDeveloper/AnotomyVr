Shader "Custom/ScreenBreakShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _ShatterAmount ("Shatter Amount", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed _ShatterAmount;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed2 offset = (tex2D(_MainTex, IN.uv_MainTex).rg - 0.5) * 2 * _ShatterAmount;
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex + offset).rgb;
        }
        ENDCG
    }

    Fallback "Diffuse"
}
