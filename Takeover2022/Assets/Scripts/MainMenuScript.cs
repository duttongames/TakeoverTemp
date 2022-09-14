using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // The object representing the "press anything to start" prompt
    public GameObject prompt;
    private TMPro.TextMeshProUGUI promptText;
    private Color promptColour;

    // The speed at which the start prompt flashes in and out
    // in cycles per second
    public float promptBlinkSpeed = 1.0f;
    // How close the prompt comes to being invisible when it fades out
    // from 0 to 1
    public float promptBlinkIntensity = 1.0f;

    private float promptBlinkStartTime = 0.0f;

    void Start()
    {
        promptText = prompt.GetComponent<TMPro.TextMeshProUGUI>();
        promptColour = promptText.color;
    }

    void Update()
    {
        float blink = (Mathf.Cos((Time.time - promptBlinkStartTime) * Mathf.PI * 2.0f * promptBlinkSpeed) + 1.0f) / 2.0f + 0.5f;
        promptColour.a = 1.0f - (blink * promptBlinkIntensity);
        promptText.color = promptColour;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut()
    {
        promptBlinkSpeed = 5.0f;
        promptBlinkStartTime = Time.time;

        var promptClone = Instantiate(prompt, transform);
        var promptCloneText = promptClone.GetComponent<TMPro.TextMeshProUGUI>();
        var promptCloneTextColor = promptCloneText.color;
        promptCloneTextColor.a = 1.0f;

        float t = 0.0f;
        while (true)
        {
            t += Time.deltaTime;

            float promptCloneScale = 1.0f + t;
            promptClone.transform.localScale = new Vector3(promptCloneScale, promptCloneScale);
            
            promptCloneTextColor.a = 0.5f - t;
            promptCloneText.color = promptCloneTextColor;

            if (t > 0.25f)
            {
                float fade = (t - 0.25f) * 1.5f;
                GetComponent<CanvasGroup>().alpha = 1.0f - fade;
                if (fade >= 1.0f)
                {
                    Destroy(this);
                }
            }
            yield return null;
        }
    }

}
