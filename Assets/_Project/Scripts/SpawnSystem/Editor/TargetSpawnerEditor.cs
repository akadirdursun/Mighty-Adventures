using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    [CustomEditor(typeof(TargetSpawner))]
    public class TargetSpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Spawn Targets"))
                SpawnTarget();
        }

        private void SpawnTarget()
        {
            var targetSpawner = (TargetSpawner)target;
            var spawnMethod = typeof(TargetSpawner).GetMethod("SpawnTarget", BindingFlags.Instance | BindingFlags.NonPublic);
            spawnMethod?.Invoke(targetSpawner, null);
        }
    }
}