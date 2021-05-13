using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableHighlighter : MonoBehaviour
{
    [SerializeField] public EffectType effetType;
    [SerializeField] Color targetColor = Color.red;
    [SerializeField] float speed = 3f;

    Selectable selectableToHighlight;
    Image selectableImageComp;
    Color selectableColor;
    Color tempColor;

    float minAlpha = 0.1f;
    float maxAlpha = 1f;
    float tempAlpha;

    bool isHighlighting;
    bool isIncreasingTempAlpha = false;

    private void Update()
    {
        if (isHighlighting)
        {
            switch (effetType)
            {
                case EffectType.ChangeColor:
                    tempColor = Color.Lerp(selectableColor, targetColor, Mathf.PingPong(Time.time, 1f / speed));
                    selectableImageComp.color = tempColor;
                    break;

                case EffectType.ChangeAlpha:
                    if (isIncreasingTempAlpha)
                    {
                        tempAlpha += Time.deltaTime * speed;

                        if (tempAlpha > (maxAlpha - 0.1f))
                        {
                            isIncreasingTempAlpha = false;
                        }
                    }

                    if (!isIncreasingTempAlpha)
                    {
                        tempAlpha -= Time.deltaTime * speed;

                        if (tempAlpha < (minAlpha + 0.1f))
                        {
                            isIncreasingTempAlpha = true;
                        }
                    }

                    selectableColor.a = tempAlpha;

                    selectableImageComp.color = selectableColor;
                    break;
                default:
                    break;
            }
        }
    }

    //---------------------------------------------------------------------------------------------------------
    public void StartHighlighting(Selectable selectableToHighlight_)
    {
        if (selectableToHighlight != null && selectableImageComp != null) //Set previous as normal
        {
            selectableColor.a = 1f;
            selectableImageComp.color = selectableColor;
        }

        selectableToHighlight = selectableToHighlight_;

        selectableImageComp = selectableToHighlight.GetComponent<Image>();
        selectableColor = selectableImageComp.color;

        isHighlighting = true;
    }

    public void StopHighlighting(Selectable selectableToStopHighlight_)
    {
        selectableColor.a = 1f;
        selectableToStopHighlight_.GetComponent<Image>().color = selectableColor;

        isHighlighting = false;
    }

    public enum EffectType
    {
        ChangeColor,
        ChangeAlpha
    }



}

