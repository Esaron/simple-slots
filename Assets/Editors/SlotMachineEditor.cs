using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(SlotMachine))]
    public class SlotMachineEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SlotMachine slotMachine = (SlotMachine)target;

            if (GUILayout.Button("Spin!"))
            {
                slotMachine.Spin();
            }
        }
    }
}