//----------------------------------------------------------------------------------------------------------------------
// Macro

// Custom variables
//#define LIL_CUSTOM_PROPERTIES \
//    float _CustomVariable;
#define LIL_CUSTOM_PROPERTIES \
    int _CM_usual_0; \
    int _CM_Camera_0; \
    int _CM_Mirror_0; \
    int _CM_CameraMirror_0; \
    int _CM_usual_1; \
    int _CM_Camera_1; \
    int _CM_Mirror_1; \
    int _CM_CameraMirror_1; \
    int _CM_usual_2; \
    int _CM_Camera_2; \
    int _CM_Mirror_2; \
    int _CM_CameraMirror_2; \
    float4  _CM_MainColor_1; \
    float4  _CM_EmissionColor_1; \
    float4  _CM_OutlineColor_1; \
    float4  _CM_MainColor_2; \
    float4  _CM_EmissionColor_2; \
    float4  _CM_OutlineColor_2; \
    int _VRChatCameraMode; \
    int _VRChatMirrorMode; \
\
    int _CM_usual_Use; \
    int _CM_usual_invisible; \
\
    int _CM_Camera_Use; \
    int _CM_Camera_invisible; \
    float4 _CM_Camera_MainColor; \
    float4 _CM_Camera_EmissionColor; \
    float4 _CM_Camera_OutlineColor; \
\
    int _CM_Mirror_Use; \
    int _CM_Mirror_invisible; \
    float4 _CM_Mirror_MainColor; \
    float4 _CM_Mirror_EmissionColor; \
    float4 _CM_Mirror_OutlineColor; \
\
    int _CM_CameraMirror_Use; \
    int _CM_CameraMirror_invisible; \
    float4 _CM_CameraMirror_MainColor; \
    float4 _CM_CameraMirror_EmissionColor; \
    float4 _CM_CameraMirror_OutlineColor;

// Custom textures
#define LIL_CUSTOM_TEXTURES \
    TEXTURE2D(_CM_MainTex_1); \
    TEXTURE2D(_CM_EmissionTex_1); \
    TEXTURE2D(_CM_OutlineTex_1); \
    TEXTURE2D(_CM_MainTex_2); \
    TEXTURE2D(_CM_EmissionTex_2); \
    TEXTURE2D(_CM_OutlineTex_2); \
    TEXTURE2D(_CM_Camera_MainTex); \
    TEXTURE2D(_CM_Camera_EmissionTex); \
    TEXTURE2D(_CM_Camera_OutlineTex); \
    TEXTURE2D(_CM_Mirror_MainTex); \
    TEXTURE2D(_CM_Mirror_EmissionTex); \
    TEXTURE2D(_CM_Mirror_OutlineTex); \
    TEXTURE2D(_CM_CameraMirror_MainTex); \
    TEXTURE2D(_CM_CameraMirror_EmissionTex); \
    TEXTURE2D(_CM_CameraMirror_OutlineTex);

    // SAMPLER(sampler_CM_MainTex_1);

#define LIL_CUSTOM_VERT_COPY \
    if (_CM_SelectTex() < 0) { \
        LIL_INITIALIZE_STRUCT(v2f, LIL_V2F_OUT_BASE); \
        LIL_V2F_OUT_BASE.positionCS = 0.0 / 0.0; \
        return LIL_V2F_OUT; \
    }

// Inserting a process into the vertex shader
//#define LIL_CUSTOM_VERTEX_OS
//#define LIL_CUSTOM_VERTEX_WS

// Inserting a process into pixel shader
//#define BEFORE_xx
//#define OVERRIDE_xx

//----------------------------------------------------------------------------------------------------------------------
// Information about variables
//----------------------------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------------------------
// Vertex shader inputs (appdata structure)
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   input.positionOS        POSITION
// float2   input.uv0               TEXCOORD0
// float2   input.uv1               TEXCOORD1
// float2   input.uv2               TEXCOORD2
// float2   input.uv3               TEXCOORD3
// float2   input.uv4               TEXCOORD4
// float2   input.uv5               TEXCOORD5
// float2   input.uv6               TEXCOORD6
// float2   input.uv7               TEXCOORD7
// float4   input.color             COLOR
// float3   input.normalOS          NORMAL
// float4   input.tangentOS         TANGENT
// uint     vertexID                SV_VertexID

//----------------------------------------------------------------------------------------------------------------------
// Vertex shader outputs or pixel shader inputs (v2f structure)
//
// The structure depends on the pass.
// Please check lil_pass_xx.hlsl for details.
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   output.positionCS       SV_POSITION
// float2   output.uv01             TEXCOORD0 TEXCOORD1
// float2   output.uv23             TEXCOORD2 TEXCOORD3
// float3   output.positionOS       object space position
// float3   output.positionWS       world space position
// float3   output.normalWS         world space normal
// float4   output.tangentWS        world space tangent

//----------------------------------------------------------------------------------------------------------------------
// Variables commonly used in the forward pass
//
// These are members of `lilFragData fd`
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   col                     lit color
// float3   albedo                  unlit color
// float3   emissionColor           color of emission
// -------- ----------------------- --------------------------------------------------------------------
// float3   lightColor              color of light
// float3   indLightColor           color of indirectional light
// float3   addLightColor           color of additional light
// float    attenuation             attenuation of light
// float3   invLighting             saturate((1.0 - lightColor) * sqrt(lightColor));
// -------- ----------------------- --------------------------------------------------------------------
// float2   uv0                     TEXCOORD0
// float2   uv1                     TEXCOORD1
// float2   uv2                     TEXCOORD2
// float2   uv3                     TEXCOORD3
// float2   uvMain                  Main UV
// float2   uvMat                   MatCap UV
// float2   uvRim                   Rim Light UV
// float2   uvPanorama              Panorama UV
// float2   uvScn                   Screen UV
// bool     isRightHand             input.tangentWS.w > 0.0;
// -------- ----------------------- --------------------------------------------------------------------
// float3   positionOS              object space position
// float3   positionWS              world space position
// float4   positionCS              clip space position
// float4   positionSS              screen space position
// float    depth                   distance from camera
// -------- ----------------------- --------------------------------------------------------------------
// float3x3 TBN                     tangent / bitangent / normal matrix
// float3   T                       tangent direction
// float3   B                       bitangent direction
// float3   N                       normal direction
// float3   V                       view direction
// float3   L                       light direction
// float3   origN                   normal direction without normal map
// float3   origL                   light direction without sh light
// float3   headV                   middle view direction of 2 cameras
// float3   reflectionN             normal direction for reflection
// float3   matcapN                 normal direction for reflection for MatCap
// float3   matcap2ndN              normal direction for reflection for MatCap 2nd
// float    facing                  VFACE
// -------- ----------------------- --------------------------------------------------------------------
// float    vl                      dot(viewDirection, lightDirection);
// float    hl                      dot(headDirection, lightDirection);
// float    ln                      dot(lightDirection, normalDirection);
// float    nv                      saturate(dot(normalDirection, viewDirection));
// float    nvabs                   abs(dot(normalDirection, viewDirection));
// -------- ----------------------- --------------------------------------------------------------------
// float4   triMask                 TriMask (for lite version)
// float3   parallaxViewDirection   mul(tbnWS, viewDirection);
// float2   parallaxOffset          parallaxViewDirection.xy / (parallaxViewDirection.z+0.5);
// float    anisotropy              strength of anisotropy
// float    smoothness              smoothness
// float    roughness               roughness
// float    perceptualRoughness     perceptual roughness
// float    shadowmix               this variable is 0 in the shadow area
// float    audioLinkValue          volume acquired by AudioLink
// -------- ----------------------- --------------------------------------------------------------------
// uint     renderingLayers         light layer of object (for URP / HDRP)
// uint     featureFlags            feature flags (for HDRP)
// uint2    tileIndex               tile index (for HDRP)


#define OVERRIDE_MAIN \
    fd.col = CD_GetMainTex(fd); \
    LIL_APPLY_MAIN_TONECORRECTION \
    fd.col *= CD_GetMainColor(); \

#define OVERRIDE_EMISSION_1ST \
	EmissionPlus_Emission1st(fd LIL_SAMP_IN(sampler_MainTex)); \

//#define BEFORE_OUTPUT \
    //clip(_CM_SelectTex() + 0.5); \

#define OVERRIDE_OUTLINE_COLOR \
    fd.col = CM_GetOutlineTex(fd); \
    LIL_APPLY_OUTLINE_TONECORRECTION \
    fd.col *= CM_GetOutlineColor(); \