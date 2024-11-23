using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(ButtonExtended))]
public class ButtonExtendedEditor : ButtonEditor
{
    SerializedProperty m_secondTransition;
    SerializedProperty m_thirdTransition;
    SerializedProperty m_additionalTransitions;

    new void OnEnable()
    {
        base.OnEnable();
        m_additionalTransitions = serializedObject.FindProperty("additionalTransitions");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(m_additionalTransitions);
        serializedObject.ApplyModifiedProperties();
    }
}
