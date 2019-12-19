using System;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixerSnapshot outOfAction;
    public AudioMixerSnapshot inAction;
    public AudioMixerSnapshot outOfBuildMode;
    public AudioMixerSnapshot inBuildMode;
    public AudioMixerSnapshot outOfCloseAction;
    public AudioMixerSnapshot inCloseAction;
    public AudioMixerSnapshot outOfActionBuildMode;
    public AudioMixerSnapshot inActionBuildMode;
    public float bpm = 137f;


    private float _transitionIn;
    private float _transitionOut;
    private float _quarterNote;
    private MusicState _musicState = MusicState.Quiet;

    // Use this for initialization
    private void Start()
    {
        _quarterNote = 60f / bpm;
        _transitionIn = _quarterNote * 3 ;
        _transitionOut = _quarterNote * 3;

    }

    public void EnterAction()
    {
        _musicState |= MusicState.Action;
        inAction.TransitionTo(_transitionIn);
    }

    public void ExitAction()
    {
        _musicState &= ~MusicState.Action;
        outOfAction.TransitionTo(_transitionOut);
    }

    public void EnterCloseAction()
    {
        _musicState |= MusicState.CloseAction;
        inCloseAction.TransitionTo(_transitionIn);
    }

    public void ExitCloseAction()
    {
        _musicState &= ~MusicState.CloseAction;
        if (_musicState.HasFlag(MusicState.Action))
            EnterAction();
        else
            outOfCloseAction.TransitionTo(_transitionOut);
    }

    public void EnterBuildMode()
    {
        if (_musicState.HasFlag(MusicState.Action) || _musicState.HasFlag(MusicState.CloseAction))
        {
            EnterActionBuildMode();
        }
        else
        {
            _musicState |= MusicState.BuildMode;
            inBuildMode.TransitionTo(_transitionIn);
        }
    }

    public void ExitBuildMode()
    {
        _musicState &= ~MusicState.BuildMode;
        if (_musicState.HasFlag(MusicState.Action))
            EnterAction();
        else if (_musicState.HasFlag(MusicState.CloseAction))
            EnterCloseAction();
        else
            outOfBuildMode.TransitionTo(_transitionOut * 2);
    }

    public void EnterActionBuildMode()
    {
        _musicState |= MusicState.ActionBuildMode;
        inActionBuildMode.TransitionTo(_transitionIn);
    }

    public void ExitActionBuildMode()
    {
        _musicState &= ~MusicState.ActionBuildMode;
            outOfActionBuildMode.TransitionTo(_transitionOut * 2);
    }
}

[Flags]
public enum MusicState
{
    Quiet,
    BuildMode,
    Action,
    CloseAction,
    ActionBuildMode
}
