int _CM_mode(bool u, bool C, bool M, bool CM){
    // usual,Camera,Mirror,CameraMirrorの4値をとって表示/非表示を判定
	int _mode = 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode == 0 && u == 1 ? 1 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode == 0 && C == 1 ? 1 : 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode != 0 && M == 1 ? 1 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode != 0 && CM == 1 ? 1 : 0;
    return _mode;
}

int _CM_SelectTex_(){
    //メイン、サブ1、サブ2のうちどれを表示するか判定 何も表示しない場合は-1を返す
    int T0 = _CM_mode(_CM_usual_0,_CM_Camera_0,_CM_Mirror_0,_CM_CameraMirror_0);
    int T1 = _CM_mode(_CM_usual_1,_CM_Camera_1,_CM_Mirror_1,_CM_CameraMirror_1);
    int T2 = _CM_mode(_CM_usual_2,_CM_Camera_2,_CM_Mirror_2,_CM_CameraMirror_2);

	int _mode = 0;
    _mode += T0 != 1 && T1 == 1 ? 1 : 0;
    _mode += T0 != 1 && T1 != 1 && T2 == 1 ? 2 : 0;
    _mode += T0 != 1 && T1 != 1 && T2 != 1 ? -1 : 0;
    return _mode;
}

int _CM_SelectTex(){
    //メイン、カメラ、ミラー、カメラミラーのうちどれを表示するか判定 何も表示しない場合は-1を返す
	int _mode = 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode == 0 && 1 == 1 && _CM_usual_invisible == 1 ? -1 : 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode == 0 && 1 == 1 && _CM_usual_invisible == 0 ? 1 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode == 0 && _CM_Camera_Use == 1 && _CM_Camera_invisible == 1 ? -1 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode == 0 && _CM_Camera_Use == 1 && _CM_Camera_invisible == 0 ? 2 : 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode != 0 && _CM_Mirror_Use == 1 && _CM_Mirror_invisible == 1 ? -1 : 0;
	_mode += _VRChatCameraMode == 0 && _VRChatMirrorMode != 0 && _CM_Mirror_Use == 1 && _CM_Mirror_invisible == 0 ? 3 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode != 0 && _CM_CameraMirror_Use == 1 && _CM_CameraMirror_invisible == 1 ? -1 : 0;
	_mode += _VRChatCameraMode != 0 && _VRChatMirrorMode != 0 && _CM_CameraMirror_Use == 1 && _CM_CameraMirror_invisible == 0 ? 4 : 0;
    return _mode;
}

float4 CD_GetMainTex(lilFragData fd) {
    float4 tex;

    // LIL_GET_MAIN_TEX マクロの代わりの処理
#if defined(LIL_PASS_FORWARD_NORMAL_INCLUDED)
    /*if (_CM_SelectTex() == 1) {
        // サブ1のサンプリング
        tex = LIL_SAMPLE_2D_POM(_CM_MainTex_1, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain);
    } else if(_CM_SelectTex() == 2) {
        // サブ2のサンプリング
        tex = LIL_SAMPLE_2D_POM(_CM_MainTex_2, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain);
    } else {
        // 通常のサンプリング
        tex = LIL_SAMPLE_2D_POM(_MainTex, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain);
    }*/
    tex = 
    _CM_SelectTex() == 2 ? LIL_SAMPLE_2D_POM(_CM_Camera_MainTex, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain)
    : _CM_SelectTex() == 3 ? LIL_SAMPLE_2D_POM(_CM_Mirror_MainTex, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain)
    : _CM_SelectTex() == 4 ? LIL_SAMPLE_2D_POM(_CM_CameraMirror_MainTex, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain)
    : LIL_SAMPLE_2D_POM(_MainTex, sampler_MainTex, fd.uvMain, fd.ddxMain, fd.ddyMain);
#else
    /*if (_CM_SelectTex() == 1) {
        // サブ1のサンプリング
        tex = LIL_SAMPLE_2D(_CM_MainTex_1, sampler_MainTex, fd.uvMain);
    } else if(_CM_SelectTex() == 2) {
        // サブ2のサンプリング
        tex = LIL_SAMPLE_2D(_CM_MainTex_2, sampler_MainTex, fd.uvMain);
    } else {
        // 通常のサンプリング
        tex = LIL_SAMPLE_2D(_MainTex, sampler_MainTex, fd.uvMain);
    }*/
    tex = 
    _CM_SelectTex() == 2 ? LIL_SAMPLE_2D(_CM_Camera_MainTex, sampler_MainTex, fd.uvMain)
    : _CM_SelectTex() == 3 ? LIL_SAMPLE_2D(_CM_Mirror_MainTex, sampler_MainTex, fd.uvMain)
    : _CM_SelectTex() == 4 ? LIL_SAMPLE_2D(_CM_CameraMirror_MainTex, sampler_MainTex, fd.uvMain)
    : LIL_SAMPLE_2D(_MainTex, sampler_MainTex, fd.uvMain);
#endif

    return tex;
}

float4 CD_GetMainColor() {
    float4 color;
    /*if (_CM_SelectTex() == 1) {
        // サブ1のカラー
        color = _CM_MainColor_1;
    } else if(_CM_SelectTex() == 2) {
        // サブ2のカラー
        color = _CM_MainColor_2;
    } else {
        // 通常のカラー
        color = _Color;
    }*/
    color = 
    _CM_SelectTex() == 2 ? _CM_Camera_MainColor
    : _CM_SelectTex() == 3 ? _CM_Mirror_MainColor
    : _CM_SelectTex() == 4 ? _CM_CameraMirror_MainColor
    : _Color;
    return color;
}


float4 CM_GetOutlineTex(lilFragData fd) {
    float4 tex;
    /*if (_CM_SelectTex() == 1) {
        // サブ1のサンプリング
        tex = LIL_SAMPLE_2D(_CM_OutlineTex_1, sampler_OutlineTex, fd.uvMain);
    } else if(_CM_SelectTex() == 2) {
        // サブ2のサンプリング
        tex = LIL_SAMPLE_2D(_CM_OutlineTex_2, sampler_OutlineTex, fd.uvMain);
    } else {
        // 通常のサンプリング
        tex = LIL_SAMPLE_2D(_OutlineTex, sampler_OutlineTex, fd.uvMain);
    }*/
    tex = 
    _CM_SelectTex() == 2 ? LIL_SAMPLE_2D(_CM_Camera_OutlineTex, sampler_OutlineTex, fd.uvMain)
    : _CM_SelectTex() == 3 ? LIL_SAMPLE_2D(_CM_Mirror_OutlineTex, sampler_OutlineTex, fd.uvMain)
    : _CM_SelectTex() == 4 ? LIL_SAMPLE_2D(_CM_CameraMirror_OutlineTex, sampler_OutlineTex, fd.uvMain)
    : LIL_SAMPLE_2D(_OutlineTex, sampler_OutlineTex, fd.uvMain);

    return tex;
}
float4 CM_GetOutlineColor() {
    float4 color;
    /*if (_CM_SelectTex() == 0) {
        // 通常のカラー
        color = _OutlineColor;
    } else if(_CM_SelectTex() == 1) {
        // サブ1のカラー
        color = _CM_OutlineColor_1;
    } else {
        // サブ2のカラー
        color = _CM_OutlineColor_2;
    }*/
    #if defined(LIL_LITE)
        float4 outlineColor = _OutlineColor;
    #elif defined(LIL_FAKESHADOW)
        float4 outlineColor = float4(0.0, 0.0, 0.0, 0.0);
    #elif defined(LIL_BAKER)
        float4 outlineColor = float4(0.0, 0.0, 0.0, 0.0);
    #elif defined(LIL_MULTI)
        #if defined(LIL_MULTI_INPUTS_OUTLINE)
        float4 outlineColor = _OutlineColor;
        #else
        float4 outlineColor = float4(0.0, 0.0, 0.0, 0.0);
        #endif
    #elif !defined(LIL_FUR) && !defined(LIL_REFRACTION) && !defined(LIL_GEM)
        float4 outlineColor = _OutlineColor;
    #else
        float4 outlineColor = float4(0.0, 0.0, 0.0, 0.0);
    #endif
    color =
    _CM_SelectTex() == 2 ? _CM_Camera_OutlineColor
    : _CM_SelectTex() == 3 ? _CM_Mirror_OutlineColor
    : _CM_SelectTex() == 4 ? _CM_CameraMirror_OutlineColor
    : outlineColor;
    return color;
}

void EmissionPlus_Emission1st(inout lilFragData fd LIL_SAMP_IN_FUNC(samp))
{
    #if defined(LIL_FEATURE_EMISSION_1ST) && !defined(LIL_LITE)
        if(_UseEmission)
        {
            float4 emissionColor;
            /*if (_CM_SelectTex() == 1) {
                // サブ1のカラー
                emissionColor = _CM_EmissionColor_1;
            } else if(_CM_SelectTex() == 2) {
                // サブ2のカラー
                emissionColor = _CM_EmissionColor_2;
            } else {
                // 通常のカラー
                emissionColor = _EmissionColor;
            }*/
            emissionColor =
            _CM_SelectTex() == 2 ? _CM_Camera_EmissionColor
            : _CM_SelectTex() == 3 ? _CM_Mirror_EmissionColor
            : _CM_SelectTex() == 4 ? _CM_CameraMirror_EmissionColor
            : _EmissionColor;
            // UV
            float2 emissionUV = fd.uv0;
            if(_EmissionMap_UVMode == 1) emissionUV = fd.uv1;
            if(_EmissionMap_UVMode == 2) emissionUV = fd.uv2;
            if(_EmissionMap_UVMode == 3) emissionUV = fd.uv3;
            if(_EmissionMap_UVMode == 4) emissionUV = fd.uvRim;
            //if(_EmissionMap_UVMode == 4) emissionUV = fd.uvPanorama;
            float2 _EmissionMapParaTex = emissionUV + _EmissionParallaxDepth * fd.parallaxOffset;
            // Texture
            #if defined(LIL_FEATURE_EmissionMap)
                #if defined(LIL_FEATURE_ANIMATE_EMISSION_UV)
                    /*if (_CM_SelectTex() == 1) {
                        // サブ1のサンプリング
                        emissionColor *= LIL_SAMPLE_2D(_CM_EmissionTex_1, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate));
                    } else if(_CM_SelectTex() == 2) {
                        // サブ2のサンプリング
                        emissionColor *= LIL_SAMPLE_2D(_CM_EmissionTex_2, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate));
                    } else {
                        // 通常のサンプリング
                        emissionColor *= LIL_SAMPLE_2D(_EmissionMap, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate));
                    }*/
                    emissionColor *= 
                    _CM_SelectTex() == 2 ? LIL_SAMPLE_2D(_CM_Camera_EmissionTex, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate))
                    : _CM_SelectTex() == 3 ? LIL_SAMPLE_2D(_CM_Mirror_EmissionTex, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate))
                    : _CM_SelectTex() == 4 ? LIL_SAMPLE_2D(_CM_CameraMirror_EmissionTex, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate))
                    : LIL_SAMPLE_2D(_EmissionMap, sampler_EmissionMap, lilCalcUV(_EmissionMapParaTex, _EmissionMap_ST, _EmissionMap_ScrollRotate));
                #else
                    /*if (_CM_SelectTex() == 1) {
                        // サブ1のサンプリング
                        emissionColor *= _CM_EmissionTex_1.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw);
                    } else if(_CM_SelectTex() == 2) {
                        // サブ2のサンプリング
                        emissionColor *= _CM_EmissionTex_2.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw);
                    } else {
                        // 通常のサンプリング
                        emissionColor *= _EmissionMap.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw);
                    }*/
                   emissionColor *= 
                    _CM_SelectTex() == 2 ? _CM_Camera_EmissionTex.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw)
                    : _CM_SelectTex() == 3 ? _CM_Mirror_EmissionTex.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw)
                    : _CM_SelectTex() == 4 ? _CM_CameraMirror_EmissionTex.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw)
                    : _EmissionMap.Sample(sampler_EmissionMap,_EmissionMapParaTex*_EmissionMap_ST.xy+_EmissionMap_ST.zw);
                #endif
            #endif
            // Mask
            #if defined(LIL_FEATURE_EmissionBlendMask)
                #if defined(LIL_FEATURE_ANIMATE_EMISSION_MASK_UV)
                    emissionColor *= LIL_GET_EMIMASK(_EmissionBlendMask, fd.uv0);
                #else
                    emissionColor *= LIL_SAMPLE_2D_ST(_EmissionBlendMask, samp, fd.uvMain);
                #endif
            #endif
            // Gradation
            #if defined(LIL_FEATURE_EmissionGradTex)
                #if defined(LIL_FEATURE_EMISSION_GRADATION) && defined(LIL_FEATURE_AUDIOLINK)
                    if(_EmissionUseGrad)
                    {
                        float gradUV = _EmissionGradSpeed * LIL_TIME + fd.audioLinkValue * _AudioLink2EmissionGrad;
                        emissionColor *= LIL_SAMPLE_1D_LOD(_EmissionGradTex, lil_sampler_linear_repeat, gradUV, 0);
                    }
                #elif defined(LIL_FEATURE_EMISSION_GRADATION)
                    if(_EmissionUseGrad) emissionColor *= LIL_SAMPLE_1D(_EmissionGradTex, lil_sampler_linear_repeat, _EmissionGradSpeed * LIL_TIME);
                #endif
            #endif
            #if defined(LIL_FEATURE_AUDIOLINK)
                if(_AudioLink2Emission) emissionColor.a *= fd.audioLinkValue;
            #endif
            emissionColor.rgb = lerp(emissionColor.rgb, emissionColor.rgb * fd.invLighting, _EmissionFluorescence);
            emissionColor.rgb = lerp(emissionColor.rgb, emissionColor.rgb * fd.albedo, _EmissionMainStrength);
            float emissionBlend = _EmissionBlend * lilCalcBlink(_EmissionBlink) * emissionColor.a;
            #if LIL_RENDER == 2 && !defined(LIL_REFRACTION)
                emissionBlend *= fd.col.a;
            #endif
            fd.col.rgb = lilBlendColor(fd.col.rgb, emissionColor.rgb, emissionBlend, _EmissionBlendMode);
        }
    #elif defined(LIL_LITE)
        if(_UseEmission)
            float emissionBlinkSeq = lilCalcBlink(_EmissionBlink);
            float4 emissionColor = _EmissionColor;
            float2 emissionUV = fd.uv0;
            if(_EmissionMap_UVMode == 1) emissionUV = fd.uv1;
            if(_EmissionMap_UVMode == 2) emissionUV = fd.uv2;
            if(_EmissionMap_UVMode == 3) emissionUV = fd.uv3;
            if(_EmissionMap_UVMode == 4) emissionUV = fd.uvRim;
            /*if (_CM_SelectTex() == 1) {
                // サブ1のサンプリング
                emissionColor *= LIL_SAMPLE_2D(_CM_EmissionTex_1, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate));
            } else if(_CM_SelectTex() == 2) {
                // サブ2のサンプリング
                emissionColor *= LIL_SAMPLE_2D(_CM_EmissionTex_2, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate));
            } else {
                // 通常のサンプリング
                emissionColor *= LIL_SAMPLE_2D(_EmissionMap, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate));
            }*/
            emissionColor *=
            _CM_SelectTex() == 2 ? LIL_SAMPLE_2D(_CM_Camera_EmissionTex, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate))
            : _CM_SelectTex() == 3 ? LIL_SAMPLE_2D(_CM_Mirror_EmissionTex, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate))
            : _CM_SelectTex() == 4 ? LIL_SAMPLE_2D(_CM_CameraMirror_EmissionTex, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate))
            : LIL_SAMPLE_2D(_EmissionMap, sampler_EmissionMap, lilCalcUV(emissionUV, _EmissionMap_ST, _EmissionMap_ScrollRotate));
            fd.emissionColor += emissionBlinkSeq * fd.triMask.b * emissionColor.rgb;
    #endif
}