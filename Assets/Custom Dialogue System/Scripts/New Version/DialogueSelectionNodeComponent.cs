using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueNewVersion
{
    public class DialogueSelectionNodeComponent : DialogueNodeComponent
    {
        public override DialogueNodeType type { get { return DialogueNodeType.SELECTION; } }

        [Serializable]
        public struct Selection
        {
            [SerializeField] public string text;
            [SerializeField] public DialogueNodeComponent next;
            [SerializeField] public UnityEvent onSelectEvents;
        }

        [SerializeField] Selection[] selections;

        public Selection[] Selections { get { return selections; } }

    }
}