using System.Reflection;
using MightyAdventures.Utilities;
using UnityEditor;
using UnityEngine;

namespace MightyAdventures.EnemySystem
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Refresh Enemy Templates"))
                RefreshEnemyTemplates();
        }

        private void RefreshEnemyTemplates()
        {
            var spawner = (EnemySpawner)target;
            var enemyTemplatesField = typeof(EnemySpawner).GetField("enemyTemplates", BindingFlags.Instance | BindingFlags.NonPublic);
            var templateInstances = EditorUtilities.GetInstances<EnemyTemplate>();
            enemyTemplatesField?.SetValue(spawner, templateInstances);
            EditorUtility.SetDirty(spawner);
        }
    }
}