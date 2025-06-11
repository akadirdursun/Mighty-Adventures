using System.Reflection;
using MightyAdventures.CharacterSystem;
using MightyAdventures.Utilities;
using UnityEditor;
using UnityEngine;

namespace MightyAdventures.MainMenu
{
    [CustomEditor(typeof(CharacterSelectionAreaController))]
    public class CharacterSelectionAreaControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Refresh Character Templates"))
                RefreshCharacterTemplates();
        }

        private void RefreshCharacterTemplates()
        {
            var controller = (CharacterSelectionAreaController)target;
            var characterTemplateField =
                typeof(CharacterSelectionAreaController).GetField("characterTemplates", BindingFlags.Instance | BindingFlags.NonPublic);
            var templateInstances = EditorUtilities.GetInstances<PlayerCharacterTemplate>();
            characterTemplateField?.SetValue(controller, templateInstances);
            EditorUtility.SetDirty(controller);
        }
    }
}