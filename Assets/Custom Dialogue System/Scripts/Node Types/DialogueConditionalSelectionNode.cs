using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueConditionalSelectionNode : DialogueNode
{
    public override DialogueNodeType type { get { return DialogueNodeType.CONDITIONAL_SELECTION; } }

    [Serializable]
    public struct ConditionalSelection
    {
        [SerializeField] public InformationOrigin condition;
        [SerializeField] public DialogueSelectionNode.Selection selection;
    }

    [SerializeField] ConditionalSelection[] selections;

    public ConditionalSelection[] Selections { get { return selections; } }
}
