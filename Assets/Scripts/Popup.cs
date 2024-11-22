using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Popup : MonoBehaviour
{
    public enum State
    {
        None,
        Hidden,
        Shown
    }

    [Header("Initial state")] 
    public bool startHidden;
    [Header("Animation")]
    public float showTime = 0.3f;
    public float hideTime = 0.15f;

    private bool initDone;
    private bool isAnimating;
    private CanvasGroup cgroup;
    private RectTransform myRect;
    public State CurrentState { get; private set; } = State.None;

    private void Awake()
    {
        CheckInit();
        if (startHidden)
            Hide(true);
        else
            Show(true);
    }

    private void CheckInit()
    {
        if (initDone) return;

        cgroup = GetComponent<CanvasGroup>();
        myRect = transform as RectTransform;

        initDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Animate(bool show, bool instant = false)
    {
        isAnimating = true;
        float phase = 0.0f;
        var time = instant ? 0.0f : (show ? showTime : hideTime);
        while (phase < time)
        {
            cgroup.alpha = show ? Mathf.Lerp(0, 1, phase / time) : Mathf.Lerp(1, 0, phase / time);
            myRect.localScale = show ? Vector3.Lerp(Vector3.zero, Vector3.one, phase / time) : Vector3.Lerp(Vector3.one, Vector3.zero, phase / time);
            phase += Time.deltaTime;
            yield return null;
        }
        cgroup.alpha = show ? 1 : 0;
        myRect.localScale = show ? Vector3.one : Vector3.zero;

        isAnimating = false;
        CurrentState = show ? State.Shown : State.Hidden;
        gameObject.SetActive(show);
    }    

    public void Show(bool instant = false)
    {
        CheckInit();

        if (isAnimating || CurrentState == State.Shown)
            return;

        gameObject.SetActive(true);
        StartCoroutine(Animate(true, instant));
    }

    public void Hide(bool instant = false)
    {
        CheckInit();

        if (isAnimating || CurrentState == State.Hidden)
            return;

        StartCoroutine(Animate(false, instant));
    }
}
