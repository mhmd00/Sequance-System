using System.Collections;
using UnityEngine;

public class AnimationAction : Action
{
    public Animator animator;
    public string animationName;
    public bool shouldWaitForCompletion;

    private float animationLength;

    private void Start()
    {
        AnimationClip clip = GetAnimationClip(animationName);
        if (clip != null)
        {
            animationLength = clip.length;
        }
    }

    private AnimationClip GetAnimationClip(string name)
    {
        if (animator != null)
        {
            foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == name)
                {
                    return clip;
                }
            }
        }
        return null;
    }

    public override IEnumerator ExecuteAction()
    {
        if (animator != null)
        {
            animator.Play(animationName);
            if (shouldWaitForCompletion)
            {
                yield return new WaitForSeconds(animationLength);
            }
        }
    }
}
