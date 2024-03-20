using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI PersonNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;
    private Animator animator;
    private bool isHidden = false;

    private enum State
    {
        PLAYING, COMPLETED
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        if (!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
    }

    public void ClearText()
    {
        barText.text = "";
    }


    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextScene();
    }
    public void PlayNextScene()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        PersonNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        PersonNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool isLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }
    
    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);

            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
            }
        }
    }
}
