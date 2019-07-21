using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UTalk
{
    [CustomEditor(typeof(ConversationTrigger))]
    public class ConversationTriggerEditor : UnityEditor.Editor
    {
        private static int mIndex = 0;

        public void OnEnable()
        {
            ConversationTrigger myTarget = this.target as ConversationTrigger;

            if (myTarget == null || ConversationManager.Instance.Database == null ||
                ConversationManager.Instance.Database.Conversations == null)
                return;

            int i = 0;
            foreach (var conversation in ConversationManager.Instance.Database.Conversations)
            {
                if (conversation.Name == myTarget.ConversationName)
                {
                    mIndex = i;
                    break;
                }
                i++;
            }
        }


        public override void OnInspectorGUI()
        {

            ConversationTrigger myTarget = this.target as ConversationTrigger;

            if (myTarget == null || ConversationManager.Instance.Database == null ||
    ConversationManager.Instance.Database.Conversations == null)
                return;

            SerializedProperty script = serializedObject.FindProperty("m_Script");

            EditorGUILayout.PropertyField(script);

            SerializedProperty onConversationStart = serializedObject.FindProperty("OnConversationStart");

            EditorGUILayout.PropertyField(onConversationStart);

            SerializedProperty onConversationStop = serializedObject.FindProperty("OnConversationStop");

            EditorGUILayout.PropertyField(onConversationStop);

            List<string> guiConversations = new List<string>();

            foreach (var conversation in ConversationManager.Instance.Database.Conversations)
            {
                guiConversations.Add(conversation.Name);
            }

            mIndex = EditorGUILayout.Popup("Conversation", mIndex, guiConversations.ToArray(), new GUILayoutOption[0]);

            myTarget.ConversationName = guiConversations[mIndex];

            serializedObject.ApplyModifiedProperties();


            if (GUI.changed)
            {
                EditorUtility.SetDirty(this.target);
            }

        }

    }
}
