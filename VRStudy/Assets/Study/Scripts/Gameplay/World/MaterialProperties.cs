using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace World
{
    public class MaterialProperties : MonoBehaviour
    {
        public Vector2 scale;
        public int materialIndex;
        private Renderer myRenderer;
        private MaterialPropertyBlock propBlock;
        private static readonly int Offset = Shader.PropertyToID("_TexWorldScale");
        private static readonly int BaseColorMap = Shader.PropertyToID("_BaseColorMap");

        private Vector2[] default_uvs;
        private Mesh mesh;
        private Vector3[] vertices;

        public bool showDebug;

        private void OnGUI()
        {
        }

        private void Start()
        {
            mesh = GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            default_uvs = mesh.uv;
        }


        public void MapUV()
        {
            float texScale = scale.y * transform.localScale.y;
 
            Vector2[] uvs = new Vector2[vertices.Length];
 
            int[] indicies = mesh.GetTriangles(materialIndex);

            float ymiddle = default_uvs[indicies[0]].y + default_uvs[indicies[1]].y + default_uvs[indicies[2]].y;
            ymiddle /= 3;

            for (int i = 0; i < default_uvs.Length; i++)
            {
                if (indicies.Contains(i))
                {
                    uvs[i] = default_uvs[i];
                    if (uvs[i].y >= ymiddle)
                    {
                        uvs[i].y = texScale;
                    }
                }
            }
 
            mesh.uv = uvs;
        }
 
        public void ResetUVs()
        {
            mesh.uv = default_uvs;
        }

        public void SetOffset()
        {
            propBlock = new MaterialPropertyBlock();
            myRenderer = GetComponent<Renderer>();

            Material mat = null;
            
#if UNITY_EDITOR
            mat = myRenderer.sharedMaterials[materialIndex];
#else
            mat = myRenderer.materials[materialIndex];
#endif
            
            mat.SetTextureScale(BaseColorMap, new Vector2(scale.x, scale.y*transform.localScale.y));

           // _renderer.GetPropertyBlock(propBlock, 0);
            // Assign our new value.
         //   propBlock.SetVector(Offset, new Vector4(scale.x, scale.y, 0, 0));
            // Apply the edited values to the renderer.
         //   _renderer.SetPropertyBlock(propBlock);
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(MaterialProperties))]
    public class TextureOffsetSetterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            MaterialProperties trg = (MaterialProperties) target;

            if (GUILayout.Button("Update"))
            {
                trg.MapUV();
            }
            if (GUILayout.Button("Reset"))
            {
                trg.ResetUVs();
            }
        }
    }
#endif
}