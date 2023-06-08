using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioAction : Action
{
    public SoundEffect soundEffect;
    public bool shouldWaitForCompletion;

    public override IEnumerator ExecuteAction()
    {
        SoundManager.Instance.PlaySound(soundEffect);
        AudioClip actionAudioClip=SoundManager.Instance.GetSoundEffectClipByEnum(soundEffect);
        if (shouldWaitForCompletion)
        {
            yield return new WaitForSeconds(actionAudioClip.length);
        }
    }
}
