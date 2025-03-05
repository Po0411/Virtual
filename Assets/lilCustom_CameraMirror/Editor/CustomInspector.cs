#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace lilToon
{
    public class lilCustom_CameraMirrorInspector : lilToonInspector
    {
        MaterialProperty _CM_usual_0;
        MaterialProperty _CM_Camera_0;
        MaterialProperty _CM_Mirror_0;
        MaterialProperty _CM_CameraMirror_0;

        MaterialProperty _CM_usual_1;
        MaterialProperty _CM_Camera_1;
        MaterialProperty _CM_Mirror_1;
        MaterialProperty _CM_CameraMirror_1;
        MaterialProperty _CM_MainColor_1;
        MaterialProperty _CM_MainTex_1;
        MaterialProperty _CM_EmissionColor_1;
        MaterialProperty _CM_EmissionTex_1;
        MaterialProperty _CM_OutlineColor_1;
        MaterialProperty _CM_OutlineTex_1;

        MaterialProperty _CM_usual_2;
        MaterialProperty _CM_Camera_2;
        MaterialProperty _CM_Mirror_2;
        MaterialProperty _CM_CameraMirror_2;
        MaterialProperty _CM_MainColor_2;
        MaterialProperty _CM_MainTex_2;
        MaterialProperty _CM_EmissionColor_2;
        MaterialProperty _CM_EmissionTex_2;
        MaterialProperty _CM_OutlineColor_2;
        MaterialProperty _CM_OutlineTex_2;

        MaterialProperty _CM_usual_Use;
        MaterialProperty _CM_usual_invisible;

        MaterialProperty _CM_Camera_Use;
        MaterialProperty _CM_Camera_invisible;
        MaterialProperty _CM_Camera_MainColor;
        MaterialProperty _CM_Camera_MainTex;
        MaterialProperty _CM_Camera_EmissionColor;
        MaterialProperty _CM_Camera_EmissionTex;
        MaterialProperty _CM_Camera_OutlineColor;
        MaterialProperty _CM_Camera_OutlineTex;

        MaterialProperty _CM_Mirror_Use;
        MaterialProperty _CM_Mirror_invisible;
        MaterialProperty _CM_Mirror_MainColor;
        MaterialProperty _CM_Mirror_MainTex;
        MaterialProperty _CM_Mirror_EmissionColor;
        MaterialProperty _CM_Mirror_EmissionTex;
        MaterialProperty _CM_Mirror_OutlineColor;
        MaterialProperty _CM_Mirror_OutlineTex;

        MaterialProperty _CM_CameraMirror_Use;
        MaterialProperty _CM_CameraMirror_invisible;
        MaterialProperty _CM_CameraMirror_MainColor;
        MaterialProperty _CM_CameraMirror_MainTex;
        MaterialProperty _CM_CameraMirror_EmissionColor;
        MaterialProperty _CM_CameraMirror_EmissionTex;
        MaterialProperty _CM_CameraMirror_OutlineColor;
        MaterialProperty _CM_CameraMirror_OutlineTex;
        // Custom properties
        //MaterialProperty customVariable;

        private static bool isShowCustomProperties;
        private const string shaderName = "lilCustom_CameraMirror";



        private void TextureGUI(GUIContent guiContent, MaterialProperty textureName, MaterialProperty rgba, MaterialProperty scrollRotate, MaterialProperty uvMode, bool useCustomUV, bool useUVAnimation)
        {
            if(useCustomUV)
            {
                // Make space for foldout
                EditorGUI.indentLevel++;
                Rect rect = m_MaterialEditor.TexturePropertySingleLine(guiContent, textureName, rgba);
                EditorGUI.indentLevel--;
                //rect.x += isCustomEditor ? 0 : 10;
                EditorGUI.indentLevel++;
                if(useUVAnimation)  UVSettingGUI(textureName, scrollRotate);
                else                m_MaterialEditor.TextureScaleOffsetProperty(textureName);
                m_MaterialEditor.ShaderProperty(uvMode, "UV Mode|UV0|UV1|UV2|UV3|Rim");
                EditorGUI.indentLevel--;
            }
            else
            {
                m_MaterialEditor.TexturePropertySingleLine(guiContent, textureName, rgba);
            }
        }
        private void UVSettingGUI(MaterialProperty uvst, MaterialProperty uvsr)
        {
            EditorGUILayout.LabelField(GetLoc("sUVSetting"), boldLabel);
            m_MaterialEditor.TextureScaleOffsetProperty(uvst);
            m_MaterialEditor.ShaderProperty(uvsr, BuildParams(GetLoc("sAngle"), GetLoc("sUVAnimation"), GetLoc("sScroll"), GetLoc("sRotate")));
        }
        private void TextureGUI(GUIContent guiContent, MaterialProperty textureName, MaterialProperty rgba, MaterialProperty scrollRotate, bool useCustomUV, bool useUVAnimation)
        {
            if(useCustomUV)
            {
                // Make space for foldout
                EditorGUI.indentLevel++;
                Rect rect = m_MaterialEditor.TexturePropertySingleLine(guiContent, textureName, rgba);
                EditorGUI.indentLevel--;
                rect.x += 0;
                EditorGUI.indentLevel++;
                if(useUVAnimation)  UVSettingGUI(textureName, scrollRotate);
                else                m_MaterialEditor.TextureScaleOffsetProperty(textureName);
                EditorGUI.indentLevel--;
            }
            else
            {
                m_MaterialEditor.TexturePropertySingleLine(guiContent, textureName, rgba);
            }
        }




        protected override void LoadCustomProperties(MaterialProperty[] props, Material material)
        {
            isCustomShader = true;

            // If you want to change rendering modes in the editor, specify the shader here
            ReplaceToCustomShaders();
            isShowRenderMode = !material.shader.name.Contains("Optional");

            // If not, set isShowRenderMode to false
            //isShowRenderMode = false;
            _CM_usual_0 = FindProperty("_CM_usual_0", props);
            _CM_Camera_0 = FindProperty("_CM_Camera_0", props);
            _CM_Mirror_0 = FindProperty("_CM_Mirror_0", props);
            _CM_CameraMirror_0 = FindProperty("_CM_CameraMirror_0", props);
            _CM_usual_1 = FindProperty("_CM_usual_1", props);
            _CM_Camera_1 = FindProperty("_CM_Camera_1", props);
            _CM_Mirror_1 = FindProperty("_CM_Mirror_1", props);
            _CM_CameraMirror_1 = FindProperty("_CM_CameraMirror_1", props);

            _CM_MainColor_1 = FindProperty("_CM_MainColor_1", props);
            _CM_MainTex_1 = FindProperty("_CM_MainTex_1", props);

            _CM_EmissionColor_1 = FindProperty("_CM_EmissionColor_1", props);
            _CM_EmissionTex_1 = FindProperty("_CM_EmissionTex_1", props);
            _CM_OutlineColor_1 = FindProperty("_CM_OutlineColor_1", props);
            _CM_OutlineTex_1 = FindProperty("_CM_OutlineTex_1", props);

            _CM_usual_2 = FindProperty("_CM_usual_2", props);
            _CM_Camera_2 = FindProperty("_CM_Camera_2", props);
            _CM_Mirror_2 = FindProperty("_CM_Mirror_2", props);
            _CM_CameraMirror_2 = FindProperty("_CM_CameraMirror_2", props);

            _CM_MainColor_2 = FindProperty("_CM_MainColor_2", props);
            _CM_MainTex_2 = FindProperty("_CM_MainTex_2", props);

            _CM_EmissionColor_2 = FindProperty("_CM_EmissionColor_2", props);
            _CM_EmissionTex_2 = FindProperty("_CM_EmissionTex_2", props);
            _CM_OutlineColor_2 = FindProperty("_CM_OutlineColor_2", props);
            _CM_OutlineTex_2 = FindProperty("_CM_OutlineTex_2", props);

            _CM_usual_Use = FindProperty("_CM_usual_Use", props);
            _CM_usual_invisible = FindProperty("_CM_usual_invisible", props);

            _CM_Camera_Use = FindProperty("_CM_Camera_Use", props);
            _CM_Camera_invisible = FindProperty("_CM_Camera_invisible", props);
            _CM_Camera_MainColor = FindProperty("_CM_Camera_MainColor", props);
            _CM_Camera_MainTex = FindProperty("_CM_Camera_MainTex", props);
            _CM_Camera_EmissionColor = FindProperty("_CM_Camera_EmissionColor", props);
            _CM_Camera_EmissionTex = FindProperty("_CM_Camera_EmissionTex", props);
            _CM_Camera_OutlineColor = FindProperty("_CM_Camera_OutlineColor", props);
            _CM_Camera_OutlineTex = FindProperty("_CM_Camera_OutlineTex", props);

            _CM_Mirror_Use = FindProperty("_CM_Mirror_Use", props);
            _CM_Mirror_invisible = FindProperty("_CM_Mirror_invisible", props);
            _CM_Mirror_MainColor = FindProperty("_CM_Mirror_MainColor", props);
            _CM_Mirror_MainTex = FindProperty("_CM_Mirror_MainTex", props);
            _CM_Mirror_EmissionColor = FindProperty("_CM_Mirror_EmissionColor", props);
            _CM_Mirror_EmissionTex = FindProperty("_CM_Mirror_EmissionTex", props);
            _CM_Mirror_OutlineColor = FindProperty("_CM_Mirror_OutlineColor", props);
            _CM_Mirror_OutlineTex = FindProperty("_CM_Mirror_OutlineTex", props);

            _CM_CameraMirror_Use = FindProperty("_CM_CameraMirror_Use", props);
            _CM_CameraMirror_invisible = FindProperty("_CM_CameraMirror_invisible", props);
            _CM_CameraMirror_MainColor = FindProperty("_CM_CameraMirror_MainColor", props);
            _CM_CameraMirror_MainTex = FindProperty("_CM_CameraMirror_MainTex", props);
            _CM_CameraMirror_EmissionColor = FindProperty("_CM_CameraMirror_EmissionColor", props);
            _CM_CameraMirror_EmissionTex = FindProperty("_CM_CameraMirror_EmissionTex", props);
            _CM_CameraMirror_OutlineColor = FindProperty("_CM_CameraMirror_OutlineColor", props);
            _CM_CameraMirror_OutlineTex = FindProperty("_CM_CameraMirror_OutlineTex", props);

            //LoadCustomLanguage("");
            //customVariable = FindProperty("_CustomVariable", props);
        }

        protected override void DrawCustomProperties(Material material)
        {
            // GUIStyles Name   Description
            // ---------------- ------------------------------------
            // boxOuter         outer box
            // boxInnerHalf     inner box
            // boxInner         inner box without label
            // customBox        box (similar to unity default box)
            // customToggleFont label for box

            isShowCustomProperties = Foldout("Camera_Mirror", "Custom Properties", isShowCustomProperties);
            if(isShowCustomProperties)
            {
                /*EditorGUILayout.BeginVertical(boxOuter);
                EditorGUILayout.LabelField(GetLoc("メイン?示設定"), customToggleFont);
                EditorGUILayout.BeginVertical(boxInnerHalf);

                m_MaterialEditor.ShaderProperty(_CM_usual_0, GetLoc("通常"));
                m_MaterialEditor.ShaderProperty(_CM_Camera_0, GetLoc("カメラ"));
                m_MaterialEditor.ShaderProperty(_CM_Mirror_0, GetLoc("?ラ?"));
                m_MaterialEditor.ShaderProperty(_CM_CameraMirror_0, GetLoc("カメラ内?ラ?"));

                //m_MaterialEditor.ShaderProperty(customVariable, "Custom Variable");

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();



                EditorGUILayout.BeginVertical(boxOuter);
                EditorGUILayout.LabelField(GetLoc("サブ1?示設定"), customToggleFont);
                EditorGUILayout.BeginVertical(boxInnerHalf);

                m_MaterialEditor.ShaderProperty(_CM_usual_1, GetLoc("通常"));
                m_MaterialEditor.ShaderProperty(_CM_Camera_1, GetLoc("カメラ"));
                m_MaterialEditor.ShaderProperty(_CM_Mirror_1, GetLoc("?ラ?"));
                m_MaterialEditor.ShaderProperty(_CM_CameraMirror_1, GetLoc("カメラ内?ラ?"));

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("メインカラ?1"), _CM_MainTex_1, _CM_MainColor_1);

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("エ?ッション1"), _CM_EmissionTex_1, _CM_EmissionColor_1);

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("輪郭線1"), _CM_OutlineTex_1, _CM_OutlineColor_1);

                //m_MaterialEditor.ShaderProperty(customVariable, "Custom Variable");

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();



                EditorGUILayout.BeginVertical(boxOuter);
                EditorGUILayout.LabelField(GetLoc("サブ2?示設定"), customToggleFont);
                EditorGUILayout.BeginVertical(boxInnerHalf);

                m_MaterialEditor.ShaderProperty(_CM_usual_2, GetLoc("通常"));
                m_MaterialEditor.ShaderProperty(_CM_Camera_2, GetLoc("カメラ"));
                m_MaterialEditor.ShaderProperty(_CM_Mirror_2, GetLoc("?ラ?"));
                m_MaterialEditor.ShaderProperty(_CM_CameraMirror_2, GetLoc("カメラ内?ラ?"));

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("メインカラ?2"), _CM_MainTex_2, _CM_MainColor_2);

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("エ?ッション2"), _CM_EmissionTex_2, _CM_EmissionColor_2);

                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("輪郭線2"), _CM_OutlineTex_2, _CM_OutlineColor_2);

                //m_MaterialEditor.ShaderProperty(customVariable, "Custom Variable");

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();*/






                EditorGUILayout.BeginVertical(boxOuter);
                //m_MaterialEditor.ShaderProperty(_CM_usual_Use, "通常 ?示設定"); //4thエ?ッション使うか使わないか
                //if(_CM_usual_Use.floatValue == 1)
                //{
                    EditorGUILayout.LabelField(GetLoc("通常 ?示設定"), customToggleFont);
                    EditorGUILayout.BeginVertical(boxInnerHalf);

                    m_MaterialEditor.ShaderProperty(_CM_usual_invisible, GetLoc("メッシュ非?示"));

                    EditorGUILayout.EndVertical();
                //}
                EditorGUILayout.EndVertical();



                EditorGUILayout.BeginVertical(boxOuter);
                m_MaterialEditor.ShaderProperty(_CM_Camera_Use, "カメラ内 ?示設定"); //4thエ?ッション使うか使わないか
                if(_CM_Camera_Use.floatValue == 1)
                {
                    EditorGUILayout.BeginVertical(boxInnerHalf);

                    m_MaterialEditor.ShaderProperty(_CM_Camera_invisible, GetLoc("メッシュ非?示"));

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("メインカラ?"), _CM_Camera_MainTex, _CM_Camera_MainColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("エ?ッション"), _CM_Camera_EmissionTex, _CM_Camera_EmissionColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("輪郭線"), _CM_Camera_OutlineTex, _CM_Camera_OutlineColor);

                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();


                EditorGUILayout.BeginVertical(boxOuter);
                m_MaterialEditor.ShaderProperty(_CM_Mirror_Use, "?ラ?内 ?示設定"); //4thエ?ッション使うか使わないか
                if(_CM_Mirror_Use.floatValue == 1)
                {
                    EditorGUILayout.BeginVertical(boxInnerHalf);

                    m_MaterialEditor.ShaderProperty(_CM_Mirror_invisible, GetLoc("メッシュ非?示"));

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("メインカラ?"), _CM_Mirror_MainTex, _CM_Mirror_MainColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("エ?ッション"), _CM_Mirror_EmissionTex, _CM_Mirror_EmissionColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("輪郭線"), _CM_Mirror_OutlineTex, _CM_Mirror_OutlineColor);

                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();


                EditorGUILayout.BeginVertical(boxOuter);
                m_MaterialEditor.ShaderProperty(_CM_CameraMirror_Use, "カメラ内かつ?ラ?内 ?示設定"); //4thエ?ッション使うか使わないか
                if(_CM_CameraMirror_Use.floatValue == 1)
                {
                    EditorGUILayout.BeginVertical(boxInnerHalf);

                    m_MaterialEditor.ShaderProperty(_CM_CameraMirror_invisible, GetLoc("メッシュ非?示"));

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("メインカラ?"), _CM_CameraMirror_MainTex, _CM_CameraMirror_MainColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("エ?ッション"), _CM_CameraMirror_EmissionTex, _CM_CameraMirror_EmissionColor);

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("輪郭線"), _CM_CameraMirror_OutlineTex, _CM_CameraMirror_OutlineColor);

                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();
            }
        }

        protected override void ReplaceToCustomShaders()
        {
            lts         = Shader.Find(shaderName + "/lilToon");
            ltsc        = Shader.Find("Hidden/" + shaderName + "/Cutout");
            ltst        = Shader.Find("Hidden/" + shaderName + "/Transparent");
            ltsot       = Shader.Find("Hidden/" + shaderName + "/OnePassTransparent");
            ltstt       = Shader.Find("Hidden/" + shaderName + "/TwoPassTransparent");

            ltso        = Shader.Find("Hidden/" + shaderName + "/OpaqueOutline");
            ltsco       = Shader.Find("Hidden/" + shaderName + "/CutoutOutline");
            ltsto       = Shader.Find("Hidden/" + shaderName + "/TransparentOutline");
            ltsoto      = Shader.Find("Hidden/" + shaderName + "/OnePassTransparentOutline");
            ltstto      = Shader.Find("Hidden/" + shaderName + "/TwoPassTransparentOutline");

            ltsoo       = Shader.Find(shaderName + "/[Optional] OutlineOnly/Opaque");
            ltscoo      = Shader.Find(shaderName + "/[Optional] OutlineOnly/Cutout");
            ltstoo      = Shader.Find(shaderName + "/[Optional] OutlineOnly/Transparent");

            ltstess     = Shader.Find("Hidden/" + shaderName + "/Tessellation/Opaque");
            ltstessc    = Shader.Find("Hidden/" + shaderName + "/Tessellation/Cutout");
            ltstesst    = Shader.Find("Hidden/" + shaderName + "/Tessellation/Transparent");
            ltstessot   = Shader.Find("Hidden/" + shaderName + "/Tessellation/OnePassTransparent");
            ltstesstt   = Shader.Find("Hidden/" + shaderName + "/Tessellation/TwoPassTransparent");

            ltstesso    = Shader.Find("Hidden/" + shaderName + "/Tessellation/OpaqueOutline");
            ltstessco   = Shader.Find("Hidden/" + shaderName + "/Tessellation/CutoutOutline");
            ltstessto   = Shader.Find("Hidden/" + shaderName + "/Tessellation/TransparentOutline");
            ltstessoto  = Shader.Find("Hidden/" + shaderName + "/Tessellation/OnePassTransparentOutline");
            ltstesstto  = Shader.Find("Hidden/" + shaderName + "/Tessellation/TwoPassTransparentOutline");

            ltsl        = Shader.Find(shaderName + "/lilToonLite");
            ltslc       = Shader.Find("Hidden/" + shaderName + "/Lite/Cutout");
            ltslt       = Shader.Find("Hidden/" + shaderName + "/Lite/Transparent");
            ltslot      = Shader.Find("Hidden/" + shaderName + "/Lite/OnePassTransparent");
            ltsltt      = Shader.Find("Hidden/" + shaderName + "/Lite/TwoPassTransparent");

            ltslo       = Shader.Find("Hidden/" + shaderName + "/Lite/OpaqueOutline");
            ltslco      = Shader.Find("Hidden/" + shaderName + "/Lite/CutoutOutline");
            ltslto      = Shader.Find("Hidden/" + shaderName + "/Lite/TransparentOutline");
            ltsloto     = Shader.Find("Hidden/" + shaderName + "/Lite/OnePassTransparentOutline");
            ltsltto     = Shader.Find("Hidden/" + shaderName + "/Lite/TwoPassTransparentOutline");

            ltsref      = Shader.Find("Hidden/" + shaderName + "/Refraction");
            ltsrefb     = Shader.Find("Hidden/" + shaderName + "/RefractionBlur");
            ltsfur      = Shader.Find("Hidden/" + shaderName + "/Fur");
            ltsfurc     = Shader.Find("Hidden/" + shaderName + "/FurCutout");
            ltsfurtwo   = Shader.Find("Hidden/" + shaderName + "/FurTwoPass");
            ltsfuro     = Shader.Find(shaderName + "/[Optional] FurOnly/Transparent");
            ltsfuroc    = Shader.Find(shaderName + "/[Optional] FurOnly/Cutout");
            ltsfurotwo  = Shader.Find(shaderName + "/[Optional] FurOnly/TwoPass");
            ltsgem      = Shader.Find("Hidden/" + shaderName + "/Gem");
            ltsfs       = Shader.Find(shaderName + "/[Optional] FakeShadow");

            ltsover     = Shader.Find(shaderName + "/[Optional] Overlay");
            ltsoover    = Shader.Find(shaderName + "/[Optional] OverlayOnePass");
            ltslover    = Shader.Find(shaderName + "/[Optional] LiteOverlay");
            ltsloover   = Shader.Find(shaderName + "/[Optional] LiteOverlayOnePass");

            ltsm        = Shader.Find(shaderName + "/lilToonMulti");
            ltsmo       = Shader.Find("Hidden/" + shaderName + "/MultiOutline");
            ltsmref     = Shader.Find("Hidden/" + shaderName + "/MultiRefraction");
            ltsmfur     = Shader.Find("Hidden/" + shaderName + "/MultiFur");
            ltsmgem     = Shader.Find("Hidden/" + shaderName + "/MultiGem");
        }

        // You can create a menu like this
        [MenuItem("Assets/lilCustom_CameraMirror/Convert material to custom shader", false, 1100)]
        private static void ConvertMaterialToCustomShaderMenu()
        {
            if(Selection.objects.Length == 0) return;
            lilCustom_CameraMirrorInspector inspector = new lilCustom_CameraMirrorInspector();
            for(int i = 0; i < Selection.objects.Length; i++)
            {
                if(Selection.objects[i] is Material)
                {
                    inspector.ConvertMaterialToCustomShader((Material)Selection.objects[i]);
                }
            }
        }

        [MenuItem("Assets/lilCustom_CameraMirror/Convert material to original shader", false, 1101)]
        private static void ConvertMaterialToOriginalShaderMenu()
        {
            var objects = Selection.objects;
            if (objects.Length == 0)
            {
                return;
            }
            for (int i = 0; i < objects.Length; i++)
            {
                var material = objects[i] as Material;
                if (material == null)
                {
                    continue;
                }

                var shader = GetCorrespondingOriginalShader(material.shader);
                if (shader == null)
                {
                    continue;
                }

                var renderQueue = lilMaterialUtils.GetTrueRenderQueue(material);
                material.shader = shader;
                material.renderQueue = renderQueue;
            }
        }

        private static Shader GetCorrespondingOriginalShader(Shader customShader)
        {
            var customShaderName = GetCorrespondingOriginalShaderName(customShader.name);
            return customShaderName == null ? null : Shader.Find(customShaderName);
        }

        private static string GetCorrespondingOriginalShaderName(string customShaderName)
        {
            return customShaderName == shaderName + "/lilToon" ? "lilToon"
                : customShaderName == "Hidden/" + shaderName + "/Cutout" ? "Hidden/lilToonCutout"
                : customShaderName == "Hidden/" + shaderName + "/Transparent" ? "Hidden/lilToonTransparent"
                : customShaderName == "Hidden/" + shaderName + "/OnePassTransparent" ? "Hidden/lilToonOnePassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/TwoPassTransparent" ? "Hidden/lilToonTwoPassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/OpaqueOutline" ? "Hidden/lilToonOutline"
                : customShaderName == "Hidden/" + shaderName + "/CutoutOutline" ? "Hidden/lilToonCutoutOutline"
                : customShaderName == "Hidden/" + shaderName + "/TransparentOutline" ? "Hidden/lilToonTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/OnePassTransparentOutline" ? "Hidden/lilToonOnePassTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/TwoPassTransparentOutline" ? "Hidden/lilToonTwoPassTransparentOutline"
                : customShaderName == shaderName + "/[Optional] OutlineOnly/Opaque" ? "_lil/[Optional] lilToonOutlineOnly"
                : customShaderName == shaderName + "/[Optional] OutlineOnly/Cutout" ? "_lil/[Optional] lilToonCutoutOutlineOnly"
                : customShaderName == shaderName + "/[Optional] OutlineOnly/Transparent" ? "_lil/[Optional] lilToonTransparentOutlineOnly"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/Opaque" ? "Hidden/lilToonTessellation"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/Cutout" ? "Hidden/lilToonTessellationCutout"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/Transparent" ? "Hidden/lilToonTessellationTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/OnePassTransparent" ? "Hidden/lilToonTessellationOnePassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/TwoPassTransparent" ? "Hidden/lilToonTessellationTwoPassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/OpaqueOutline" ? "Hidden/lilToonTessellationOutline"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/CutoutOutline" ? "Hidden/lilToonTessellationCutoutOutline"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/TransparentOutline" ? "Hidden/lilToonTessellationTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/OnePassTransparentOutline" ? "Hidden/lilToonTessellationOnePassTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/Tessellation/TwoPassTransparentOutline" ? "Hidden/lilToonTessellationTwoPassTransparentOutline"
                : customShaderName == shaderName + "/lilToonLite" ? "Hidden/lilToonLite"
                : customShaderName == "Hidden/" + shaderName + "/Lite/Cutout" ? "Hidden/lilToonLiteCutout"
                : customShaderName == "Hidden/" + shaderName + "/Lite/Transparent" ? "Hidden/lilToonLiteTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Lite/OnePassTransparent" ? "Hidden/lilToonLiteOnePassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Lite/TwoPassTransparent" ? "Hidden/lilToonLiteTwoPassTransparent"
                : customShaderName == "Hidden/" + shaderName + "/Lite/OpaqueOutline" ? "Hidden/lilToonLiteOutline"
                : customShaderName == "Hidden/" + shaderName + "/Lite/CutoutOutline" ? "Hidden/lilToonLiteCutoutOutline"
                : customShaderName == "Hidden/" + shaderName + "/Lite/TransparentOutline" ? "Hidden/lilToonLiteTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/Lite/OnePassTransparentOutline" ? "Hidden/lilToonLiteOnePassTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/Lite/TwoPassTransparentOutline" ? "Hidden/lilToonLiteTwoPassTransparentOutline"
                : customShaderName == "Hidden/" + shaderName + "/Refraction" ? "Hidden/lilToonRefraction"
                : customShaderName == "Hidden/" + shaderName + "/RefractionBlur" ? "Hidden/lilToonRefractionBlur"
                : customShaderName == "Hidden/" + shaderName + "/Fur" ? "Hidden/lilToonFur"
                : customShaderName == "Hidden/" + shaderName + "/FurCutout" ? "Hidden/lilToonFurCutout"
                : customShaderName == "Hidden/" + shaderName + "/FurTwoPass" ? "Hidden/lilToonFurTwoPass"
                : customShaderName == shaderName + "/[Optional] FurOnly/Transparent" ? "_lil/[Optional] lilToonFurOnly"
                : customShaderName == shaderName + "/[Optional] FurOnly/Cutout" ? "_lil/[Optional] lilToonFurOnlyCutout"
                : customShaderName == shaderName + "/[Optional] FurOnly/TwoPass" ? "_lil/[Optional] lilToonFurOnlyTwoPass"
                : customShaderName == "Hidden/" + shaderName + "/Gem" ? "Hidden/lilToonGem"
                : customShaderName == shaderName + "/[Optional] FakeShadow" ? "_lil/lilToonFakeShadow"
                : customShaderName == shaderName + "/[Optional] Overlay" ? "_lil/[Optional] lilToonOverlay"
                : customShaderName == shaderName + "/[Optional] OverlayOnePass" ? "_lil/[Optional] lilToonOverlayOnePass"
                : customShaderName == shaderName + "/[Optional] LiteOverlay" ? "_lil/[Optional] lilToonLiteOverlay"
                : customShaderName == shaderName + "/[Optional] LiteOverlayOnePass" ? "_lil/[Optional] lilToonLiteOverlayOnePass"
                : customShaderName == shaderName + "/lilToonMulti" ? "_lil/lilToonMulti"
                : customShaderName == "Hidden/" + shaderName + "/MultiOutline" ? "Hidden/lilToonMultiOutline"
                : customShaderName == "Hidden/" + shaderName + "/MultiRefraction" ? "Hidden/lilToonMultiRefraction"
                : customShaderName == "Hidden/" + shaderName + "/MultiFur" ? "Hidden/lilToonMultiFur"
                : customShaderName == "Hidden/" + shaderName + "/MultiGem" ? "Hidden/lilToonMultiGem"
                : null;
        }
    }
}
#endif
