using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace DialogueNewVersion
{
    [CustomEditor(typeof(Dialogue))]
    public class DialogueEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Dialogue dialogue = (Dialogue)target;

            if (GUILayout.Button("Hello"))
            {
                dialogue.nodes.Add(new DialogueTextNode());
            }

            GUI.Box(new Rect(new Vector2(0, 0), new Vector2(10, 10)), "Hello!");

            //foreach (var dialogueNode in dialogue.nodes)
            //{
            //    switch (dialogueNode.type)
            //    {
            //        case DialogueNodeType.TEXT:
            //            //DialogueTextNode textNode = (DialogueTextNode)dialogueNode;
            //            break;
            //        case DialogueNodeType.SELECTION:

            //            break;
            //        case DialogueNodeType.BIFURCATION_EVENT:

            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    }

}