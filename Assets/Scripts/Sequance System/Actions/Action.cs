using System.Collections;
using UnityEngine;
public abstract class Action:MonoBehaviour
{
    public abstract IEnumerator ExecuteAction();
}