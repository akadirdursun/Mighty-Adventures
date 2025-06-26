using System.Reflection;
using MightyAdventures.Utilities;
using UnityEditor;
using UnityEngine;

namespace MightyAdventures.PowerUps
{
    [CustomEditor(typeof(PowerUpDatabase))]
    public class PowerUpDatabaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Refresh Database"))
                RefreshPowerUpDatabase();
        }

        private void RefreshPowerUpDatabase()
        {
            var database = (PowerUpDatabase)target;
            var powerUpsField = typeof(PowerUpDatabase).GetField("powerUps", BindingFlags.Instance | BindingFlags.NonPublic);
            var powerUpInstances = EditorUtilities.GetInstances<AbstractPowerUpData>();
            powerUpsField?.SetValue(database, powerUpInstances);
            EditorUtility.SetDirty(database);
        }
    }
}