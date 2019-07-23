using UnityEngine;
using System.Collections;

using Pathfinding;
public class m_AIDestinationSetter : VersionedMonoBehaviour
{
    /// <summary>The object that the AI should move to</summary>
    public Vector3 target = Vector3.zero;
    private Animator animator;
    IAstarAI ai;
    

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        ai = GetComponent<IAstarAI>();
        // Update the destination right before searching for a path as well.
        // This is enough in theory, but this script will also update the destination every
        // frame as the destination is used for debugging and may be used for other things by other
        // scripts as well. So it makes sense that it is up to date every frame.
        if (ai != null) ai.onSearchPath += Update;
        
        Debug.Log("ai Enabled");
    }

    void OnDisable()
    {
        animator = GetComponent<Animator>();
        if (ai != null) ai.onSearchPath -= Update;
        Debug.Log("ai Disabled");
    }

    /// <summary>Updates the AI's destination every frame</summary>
    void Update()
    {
        if (!target.Equals(Vector3.zero) && ai != null)
        {
            animator.SetBool("run", true);
            ai.destination = target;
        }
        if (ai.reachedDestination || ai.reachedEndOfPath)
        {

            animator.SetBool("run", false);
        }
    }
}
