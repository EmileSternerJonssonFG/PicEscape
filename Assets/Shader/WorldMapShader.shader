Shader "Custom/WorldMapShader" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	}

	// Shader info learned from http://www.shaderslab.com/demo-55---worldspace-texture.html

	SubShader{
	Tags { "RenderType" = "Opaque" }

	CGPROGRAM
	#pragma surface surf Standard

	sampler2D _MainTex;

	struct Input {float3 worldNormal;float3 worldPos;};

	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		if (abs(IN.worldNormal.y) > 0.5)
		{
			o.Albedo = tex2D(_MainTex, IN.worldPos.xz);
		}
		else if (abs(IN.worldNormal.x) > 0.5)
		{
			o.Albedo = tex2D(_MainTex, IN.worldPos.yz);
		}
		else
		{
			o.Albedo = tex2D(_MainTex, IN.worldPos.xy);
		}

		//o.Emission = float4(0,0,0,0);
	}
		ENDCG

	}
	FallBack "Diffuse"
}
