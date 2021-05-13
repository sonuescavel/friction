using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Selectable[] allButtons;

    UIEffect tempUIEffect;
    UIShadow tempUIShadow;
    float tempAlpha;

    private void Update()
    {
        tempAlpha = Mathf.PingPong(Time.time, 1f);

        if(Input.GetMouseButtonDown(0))
        {
            if (tempUIEffect != null)
                Destroy(tempUIEffect);

            if (tempUIShadow != null)
                Destroy(tempUIShadow);

            int random = Random.Range(0, allButtons.Length);
            tempUIEffect = allButtons[random].gameObject.AddComponent<UIEffect>();
            tempUIEffect.colorMode = ColorMode.Fill;
            tempUIEffect.colorFactor = 0f;

            tempUIShadow = allButtons[random].gameObject.AddComponent<UIShadow>();
            tempUIShadow.style = ShadowStyle.Outline;
            tempUIShadow.effectDistance = new Vector2(5f, 5f);
        }

        if(tempUIShadow != null)
            tempUIShadow.effectColor = new Color(1f, 0f, 0f, tempAlpha);
    }
}
