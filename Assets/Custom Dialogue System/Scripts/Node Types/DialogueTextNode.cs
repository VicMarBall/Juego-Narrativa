using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueTextNode : DialogueNode
{
	public override DialogueNodeType type { get { return DialogueNodeType.TEXT; } }

	[SerializeField] string text;

    [SerializeField] DialogueNode next;

    public string Text { get { return text; } }

	public DialogueNode Next { get { return next; } }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
