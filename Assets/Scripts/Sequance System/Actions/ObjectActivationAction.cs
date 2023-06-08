using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationAction : Action
{
    public GameObject gameObject;
    public bool shouldActivateGameObject;

    public override IEnumerator ExecuteAction()
    {
        gameObject.SetActive(shouldActivateGameObject);
        yield return null;
    }
}
