﻿#if UNITY_EDITOR
using FishNet.Editing;
using GameKit.Dependencies.Utilities;
using UnityEditor;
using UnityEngine;
using LayoutTools = GameKit.Dependencies.Utilities.EditorGuiLayoutTools;


namespace FishNet.Component.Transforming.Editing
{
    [CustomEditor(typeof(NetworkTransform), true)]
    [CanEditMultipleObjects]
    public class NetworkTransformEditor : Editor
    {
        private SerializedProperty _componentConfiguration;
        private SerializedProperty _synchronizeParent;
        private SerializedProperty _packing;
        private SerializedProperty _interpolation;
        private SerializedProperty _extrapolation;
        private SerializedProperty _enableTeleport;
        private SerializedProperty _teleportThreshold;
        private SerializedProperty _clientAuthoritative;
        private SerializedProperty _sendToOwner;
        private SerializedProperty _interval;
        private SerializedProperty _synchronizePosition;
        private SerializedProperty _positionSnapping;
        private SerializedProperty _synchronizeRotation;
        private SerializedProperty _rotationSnapping;
        private SerializedProperty _synchronizeScale;
        private SerializedProperty _scaleSnapping;


        protected virtual void OnEnable()
        {
            _componentConfiguration = serializedObject.FindProperty(nameof(_componentConfiguration));
            _synchronizeParent = serializedObject.FindProperty("_synchronizeParent");
            _packing = serializedObject.FindProperty("_packing");
            _interpolation = serializedObject.FindProperty("_interpolation");
            _extrapolation = serializedObject.FindProperty("_extrapolation");
            _enableTeleport = serializedObject.FindProperty("_enableTeleport");
            _teleportThreshold = serializedObject.FindProperty("_teleportThreshold");
            _clientAuthoritative = serializedObject.FindProperty("_clientAuthoritative");
            _sendToOwner = serializedObject.FindProperty("_sendToOwner");
            _interval = serializedObject.FindProperty(nameof(_interval));
            _synchronizePosition = serializedObject.FindProperty("_synchronizePosition");
            _positionSnapping = serializedObject.FindProperty("_positionSnapping");
            _synchronizeRotation = serializedObject.FindProperty("_synchronizeRotation");
            _rotationSnapping = serializedObject.FindProperty("_rotationSnapping");
            _synchronizeScale = serializedObject.FindProperty("_synchronizeScale");
            _scaleSnapping = serializedObject.FindProperty("_scaleSnapping");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            LayoutTools.AddObjectField("Script:", MonoScript.FromMonoBehaviour((NetworkTransform)target), typeof(NetworkTransform), false, EditorLayoutEnableType.Disabled);

            bool isPro = false;
            
            if (isPro)
                EditorGUILayout.HelpBox(EditingConstants.PRO_ASSETS_UNLOCKED_TEXT, MessageType.None);
            else
                EditorGUILayout.HelpBox(EditingConstants.PRO_ASSETS_LOCKED_TEXT, MessageType.Warning);

            //Misc.
            EditorGUILayout.LabelField("Misc", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_componentConfiguration);
            EditorGUILayout.PropertyField(_synchronizeParent, new GUIContent("Synchronize Parent"));
            EditorGUILayout.PropertyField(_packing);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            //Smoothing.
            EditorGUILayout.LabelField("Smoothing", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_interpolation);
            EditorGUILayout.PropertyField(_extrapolation, new GUIContent("* Extrapolation"));
            EditorGUILayout.PropertyField(_enableTeleport);
            if (_enableTeleport.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_teleportThreshold);
                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            //Authority.
            EditorGUILayout.LabelField("Authority", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_clientAuthoritative);
            if (!_clientAuthoritative.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_sendToOwner);
                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            //Synchronizing.
            EditorGUILayout.LabelField("Synchronizing.", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            //Interval.
            EditorGUILayout.PropertyField(_interval, new GUIContent("Send Interval"));
            //Position.
            EditorGUILayout.PropertyField(_synchronizePosition);
            if (_synchronizePosition.boolValue)
            {
                EditorGUI.indentLevel += 2;
                EditorGUILayout.PropertyField(_positionSnapping);
                EditorGUI.indentLevel -= 2;
            }

            //Rotation.
            EditorGUILayout.PropertyField(_synchronizeRotation);
            if (_synchronizeRotation.boolValue)
            {
                EditorGUI.indentLevel += 2;
                EditorGUILayout.PropertyField(_rotationSnapping);
                EditorGUI.indentLevel -= 2;
            }

            //Scale.
            EditorGUILayout.PropertyField(_synchronizeScale);
            if (_synchronizeScale.boolValue)
            {
                EditorGUI.indentLevel += 2;
                EditorGUILayout.PropertyField(_scaleSnapping);
                EditorGUI.indentLevel -= 2;
            }

            EditorGUI.indentLevel--;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif