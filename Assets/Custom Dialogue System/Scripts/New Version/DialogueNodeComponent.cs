using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueNewVersion
{
    public abstract class DialogueNodeComponent : MonoBehaviour
    {
        public virtual DialogueNodeType type { get; }
    }
}