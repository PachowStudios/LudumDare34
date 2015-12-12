using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace LudumDare34
{
  [CustomEditor(typeof(ScaleWidthCamera))]
  public class ScaleWidthCameraEditor : Editor
  {
    private SerializedProperty defaultFOVProperty;
    private SerializedProperty useWorldSpaceUIProperty;
    private SerializedProperty worldSpaceUIProperty;

    private AnimBool showWorldSpaceUI;

    private ScaleWidthCamera Target => (ScaleWidthCamera)target;

    private int DefaultFOV
    {
      get { return this.defaultFOVProperty.intValue; }
      set { this.defaultFOVProperty.intValue = value; }
    }

    private bool UseWorldSpaceUI
    {
      get { return this.useWorldSpaceUIProperty.boolValue; }
      set { this.useWorldSpaceUIProperty.boolValue = value; }
    }

    private RectTransform WorldSpaceUI
    {
      get { return (RectTransform)this.worldSpaceUIProperty.objectReferenceValue; }
      set { this.worldSpaceUIProperty.objectReferenceValue = value; }
    }

    private void OnEnable()
    {
      this.defaultFOVProperty = serializedObject.FindProperty("defaultFOV");
      this.useWorldSpaceUIProperty = serializedObject.FindProperty("useWorldSpaceUI");
      this.worldSpaceUIProperty = serializedObject.FindProperty("worldSpaceUI");

      this.showWorldSpaceUI = new AnimBool(UseWorldSpaceUI);
    }

    public override void OnInspectorGUI()
    {
      serializedObject.Update();

      EditorGUILayout.LabelField("Current FOV", Target.CurrentFOV.ToString());
      EditorGUILayout.Space();

      Target.CurrentFOV = DefaultFOV = EditorGUILayout.IntField("Default FOV", DefaultFOV);

      this.showWorldSpaceUI.target = EditorGUILayout.Toggle("Use World Space UI", this.showWorldSpaceUI.target);
      UseWorldSpaceUI = this.showWorldSpaceUI.value;

      if (EditorGUILayout.BeginFadeGroup(this.showWorldSpaceUI.faded))
      {
        EditorGUI.indentLevel++;

        WorldSpaceUI = (RectTransform)EditorGUILayout.ObjectField("World Space UI", WorldSpaceUI, typeof(RectTransform), true);

        if (WorldSpaceUI == null)
          EditorGUILayout.HelpBox("No world space UI selected!", MessageType.Error);

        EditorGUI.indentLevel--;
      }

      EditorGUILayout.EndFadeGroup();

      if (GUI.changed)
        EditorUtility.SetDirty(Target);

      serializedObject.ApplyModifiedProperties();
      Repaint();
    }
  }
}