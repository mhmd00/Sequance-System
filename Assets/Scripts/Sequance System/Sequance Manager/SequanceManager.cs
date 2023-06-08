using System.Collections;
using UnityEngine;

public class ActionsSequanceManager : MonoBehaviour
{
    public Action[] sequenceActions;

    private Coroutine sequenceCoroutine;
    private bool isPaused=false;

    private void Start()
    {
        StartActionsequence();
    }
    [ContextMenu("Test Starting Sequance")]
    public void StartActionsequence()
    {
        sequenceCoroutine = StartCoroutine(RunActionsSequence());
    }

    public void PauseActionsSequence()
    {
        if (sequenceCoroutine != null)
        {
            isPaused = true;
            StopCoroutine(sequenceCoroutine);
        }
    }

    public void ContinueActionsSequence()
    {
        if (isPaused)
        {
            isPaused = false;
            sequenceCoroutine = StartCoroutine(RunActionsSequence());
        }
    }

    private IEnumerator RunActionsSequence()
    {
        foreach (Action action in sequenceActions)
        {
            yield return StartCoroutine(action.ExecuteAction());

            while (isPaused) 
            {
                yield return null;
            }
        }
    }
}
