using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private GameObject[] _interlocutors;
    private bool _triggered = false; // prevents any triggers after the first
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        _triggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // will return first active object, order in hierarchy matters
    }
    public bool EnterRadius()
    {
        _interlocutors = GameObject.FindGameObjectsWithTag("player");

        return (this.transform.position - _interlocutors[0].transform.position).magnitude < 3;
        // if the distance between the dialogue NPC and the player is < 3, then trigger the dialogue

    }

    void Update()
    {
        if (EnterRadius() && !_triggered) TriggerDialogue();
    }
}
