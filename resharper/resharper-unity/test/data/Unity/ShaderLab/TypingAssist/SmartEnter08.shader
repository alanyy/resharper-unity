// ${CHAR:Enter}
// ${SMART_INDENT_ON_ENTER:true} 
Shader "Unlit/NewUnlitShader" {
  
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
  }
  SubShader {
    Tags
    {
      "RenderType"="Opaque"
    }
      LOD 100{caret}
  }
}