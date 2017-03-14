﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//
// Please direct any bugs/comments/suggestions to http://www.flipwebapps.com
// 
// The copyright owner grants to the end user a non-exclusive, worldwide, and perpetual license to this Asset
// to integrate only as incorporated and embedded components of electronic games and interactive media and 
// distribute such electronic game and interactive media. End user may modify Assets. End user may otherwise 
// not reproduce, distribute, sublicense, rent, lease or lend the Assets. It is emphasized that the end 
// user shall not be entitled to distribute or transfer in any way (including, without, limitation by way of 
// sublicense) the Assets in any other way than as integrated components of electronic games and interactive media. 

// The above copyright notice and this permission notice must not be removed from any files.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------

using UnityEditor;
using UnityEngine;

namespace GameFramework.GameStructure.GameItems.Editor.AbstractClasses
{
    public abstract class UnlockGameItemButtonEditor : UnityEditor.Editor
    {
        SerializedProperty _unlockModeProperty;
        SerializedProperty _contextNumberProperty;
        SerializedProperty _contextReferenceProperty;
        SerializedProperty _maxFailedUnlocksProperty;

        SerializedProperty _showConfirmWindowProperty;
        SerializedProperty _confirmTitleTextProperty;
        SerializedProperty _confirmText1Property;
        SerializedProperty _confirmText2Property;
        SerializedProperty _confirmDialogSpriteTypeProperty;
        SerializedProperty _confirmDialogSpriteProperty;
        SerializedProperty _confirmContentPrefabProperty;
        SerializedProperty _confirmContentAnimatorControllerProperty;
        SerializedProperty _confirmContentShowsButtonsProperty;

        SerializedProperty _showUnlockWindowProperty;
        SerializedProperty _unlockTitleTextProperty;
        SerializedProperty _unlockedText1Property;
        SerializedProperty _unlockedText2Property;
        SerializedProperty _alreadyUnlockedText1Property;
        SerializedProperty _alreadyUnlockedText2Property;
        SerializedProperty _unlockContentPrefabProperty;
        SerializedProperty _unlockContentAnimatorControllerProperty;
        SerializedProperty _unlockContentShowsButtonsProperty;

        public void OnEnable()
        {
            _unlockModeProperty = serializedObject.FindProperty("UnlockMode");
            _maxFailedUnlocksProperty = serializedObject.FindProperty("MaxFailedUnlocks");

            _showConfirmWindowProperty = serializedObject.FindProperty("ShowConfirmWindow");
            _confirmTitleTextProperty = serializedObject.FindProperty("ConfirmTitleText");
            _confirmText1Property = serializedObject.FindProperty("ConfirmText1");
            _confirmText2Property = serializedObject.FindProperty("ConfirmText2");
            _confirmDialogSpriteTypeProperty = serializedObject.FindProperty("ConfirmDialogSpriteType");
            _confirmDialogSpriteProperty = serializedObject.FindProperty("ConfirmDialogSprite");
            _confirmContentPrefabProperty = serializedObject.FindProperty("ConfirmContentPrefab");
            _confirmContentAnimatorControllerProperty = serializedObject.FindProperty("ConfirmContentAnimatorController");
            _confirmContentShowsButtonsProperty = serializedObject.FindProperty("ConfirmContentShowsButtons");

            _showUnlockWindowProperty = serializedObject.FindProperty("ShowUnlockWindow");
            _unlockTitleTextProperty = serializedObject.FindProperty("UnlockTitleText");
            _unlockedText1Property = serializedObject.FindProperty("UnlockedText1");
            _unlockedText2Property = serializedObject.FindProperty("UnlockedText2");
            _alreadyUnlockedText1Property = serializedObject.FindProperty("AlreadyUnlockedText1");
            _alreadyUnlockedText2Property = serializedObject.FindProperty("AlreadyUnlockedText2");
            _unlockContentPrefabProperty = serializedObject.FindProperty("UnlockContentPrefab");
            _unlockContentAnimatorControllerProperty = serializedObject.FindProperty("UnlockContentAnimatorController");
            _unlockContentShowsButtonsProperty = serializedObject.FindProperty("UnlockContentShowsButtons");

            var contextProperty = serializedObject.FindProperty("_context");
            _contextNumberProperty = contextProperty.FindPropertyRelative("_number");
            _contextReferenceProperty = contextProperty.FindPropertyRelative("_referencedGameItemContextBase");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_unlockModeProperty);
            EditorGUI.indentLevel++;
            if (_unlockModeProperty.enumValueIndex == 0)
                EditorGUILayout.PropertyField(_maxFailedUnlocksProperty);
            if (_unlockModeProperty.enumValueIndex == 4)    // ByNumber
                EditorGUILayout.PropertyField(_contextNumberProperty);
            if (_unlockModeProperty.enumValueIndex == 6)    // Reference
                EditorGUILayout.PropertyField(_contextReferenceProperty);
            EditorGUI.indentLevel--;
            EditorGUILayout.PropertyField(_showConfirmWindowProperty);
            if (_showConfirmWindowProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUI.indentLevel++;
                _showConfirmWindowProperty.isExpanded = EditorGUILayout.Foldout(_showConfirmWindowProperty.isExpanded, "Configuration");
                if (_showConfirmWindowProperty.isExpanded)
                {

                    EditorGUILayout.PropertyField(_confirmTitleTextProperty,
                        new GUIContent("Title", _confirmTitleTextProperty.tooltip));
                    EditorGUILayout.PropertyField(_confirmText1Property,
                        new GUIContent("Text 1", _confirmText1Property.tooltip));
                    EditorGUILayout.PropertyField(_confirmText2Property,
                        new GUIContent("Text 2", _confirmText2Property.tooltip));
                    EditorGUILayout.PropertyField(_confirmDialogSpriteTypeProperty,
                        new GUIContent("Image", _confirmDialogSpriteTypeProperty.tooltip));
                    if (_confirmDialogSpriteTypeProperty.enumValueIndex == 2)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.PropertyField(_confirmDialogSpriteProperty, GUIContent.none);
                        EditorGUI.indentLevel--;
                    }
                    EditorGUILayout.PropertyField(_confirmContentPrefabProperty,
                        new GUIContent("Content Prefab", _confirmContentPrefabProperty.tooltip));
                    EditorGUILayout.PropertyField(_confirmContentAnimatorControllerProperty,
                        new GUIContent("Content Animation", _confirmContentAnimatorControllerProperty.tooltip));
                    EditorGUILayout.PropertyField(_confirmContentShowsButtonsProperty,
                        new GUIContent("Content Shows Buttons", _confirmContentShowsButtonsProperty.tooltip));
                }
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(_showUnlockWindowProperty);
            if (_showUnlockWindowProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUI.indentLevel++;
                _showUnlockWindowProperty.isExpanded = EditorGUILayout.Foldout(_showUnlockWindowProperty.isExpanded, "Configuration");
                if (_showUnlockWindowProperty.isExpanded)
                {
                    EditorGUILayout.PropertyField(_unlockTitleTextProperty, new GUIContent("Title", _unlockTitleTextProperty.tooltip));
                    EditorGUILayout.PropertyField(_unlockedText1Property);
                    EditorGUILayout.PropertyField(_unlockedText2Property);
                    if (_unlockModeProperty.enumValueIndex == 0)
                    {
                        EditorGUILayout.PropertyField(_alreadyUnlockedText1Property);
                        EditorGUILayout.PropertyField(_alreadyUnlockedText2Property);
                    }
                    EditorGUILayout.PropertyField(_unlockContentPrefabProperty, new GUIContent("Content Prefab", _unlockContentPrefabProperty.tooltip));
                    EditorGUILayout.PropertyField(_unlockContentAnimatorControllerProperty, new GUIContent("Content Animation", _unlockContentAnimatorControllerProperty.tooltip));
                    EditorGUILayout.PropertyField(_unlockContentShowsButtonsProperty, new GUIContent("Content Shows Buttons", _unlockContentShowsButtonsProperty.tooltip));
                }
                EditorGUI.indentLevel--;
                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
