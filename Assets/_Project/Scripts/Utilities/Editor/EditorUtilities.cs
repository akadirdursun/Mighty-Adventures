using UnityEditor;
using UnityEngine;

namespace MightyAdventures.Utilities
{
    public static class EditorUtilities
    {
        public static T[] GetInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            var instanceCount = guids.Length;
            var results = new T[instanceCount];
            for (int i = 0; i < instanceCount; i++)
            {
                var instancePath = AssetDatabase.GUIDToAssetPath(guids[i]);
                results[i] = AssetDatabase.LoadAssetAtPath<T>(instancePath);
            }

            return results;
        }
    }
}