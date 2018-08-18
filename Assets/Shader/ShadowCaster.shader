
Shader "ProjectorShadow/ShadowCaster"
{
	Properties
	{
		_ShadowColor("Main Color", COLOR) = (1, 1, 1, 1)
	}
	
	SubShader
	{
		Tags{ "RenderType" = "Opaque" "Queue" = "Geometry" }

		Pass
		{
			ZWrite Off
			Cull Off

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			
			struct v2f
			{
				float4 pos : POSITION;
			};
			
			v2f vert(float4 vertex:POSITION)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				return o;
			}

			float4 frag(v2f i) :SV_TARGET
			{
				return 1;
			}
			
			ENDCG
		}
	}
}
