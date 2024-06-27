using System;
using UnityEngine;
using static MinimalIconPack.ButtonMapper;


namespace MinimalIconPack
{
    [ExecuteInEditMode]
    public class ButtonManager : MonoBehaviour
    {
        [Header("Button specifics")]
        public Sprite iconSprite;
        public ButtonStyle style;

        private ButtonMapper buttonMapper;
        private RectTransform shadowRect;
        private RectTransform outlineRect;
        private Animator buttonAnim;


        /**/


        private void Awake()
        {
            buttonMapper = this.GetComponent<ButtonMapper>();
            buttonAnim = this.GetComponent<Animator>();

            outlineRect = buttonMapper.outline.GetComponent<RectTransform>();
            shadowRect = buttonMapper.shadow.GetComponent<RectTransform>();

            UpdateIcon();
            UpdateColor();
            UpdateOutline();
            UpdateShadow();
            UpdateShape();
            UpdateAnimation();
        }


        //runs in editor only
        private void Update()
        {
            try
            {
                if (Application.isEditor && !Application.isPlaying)
                {
                    buttonMapper = this.GetComponent<ButtonMapper>();
                    buttonAnim = this.GetComponent<Animator>();

                    outlineRect = buttonMapper.outline.GetComponent<RectTransform>();
                    shadowRect = buttonMapper.shadow.GetComponent<RectTransform>();

                    UpdateColor();
                    UpdateOutline();
                    UpdateShadow();
                }
            }
            catch (Exception e)
            {
                //Debug.Log("Couldn't update the button");
            }
        }

        //runs in editor only
        private void OnValidate()
        {
            try
            {
                if (Application.isEditor && !Application.isPlaying)
                {
                    UpdateIcon();
                    UpdateShape();
                }
            }
            catch (Exception e)
            {
                //Debug.Log("Couldn't update the button");
            }
        }


        private void UpdateColor()
        {
            buttonMapper.icon.color = style.iconColor;
            buttonMapper.background.color = style.backgroundColor;

            float backgroundRatio = 0.8f + (0.4f / 100) * style.buttonBackgroundRatio;
            buttonMapper.backgroundParent.localScale = new Vector3(backgroundRatio, backgroundRatio, 0);
        }


        private void UpdateShape()
        {
            if (style.backgroundShape == BackgroundShapeMapper.Circular)
            {
                buttonMapper.background.sprite = buttonMapper.backgroundCircular;
                buttonMapper.shadow.sprite = buttonMapper.backgroundCircular;
                buttonMapper.outline.sprite = buttonMapper.backgroundCircular;
            }
            else if (style.backgroundShape == BackgroundShapeMapper.Squared)
            {
                buttonMapper.background.sprite = buttonMapper.backgroundSquared;
                buttonMapper.shadow.sprite = buttonMapper.backgroundSquared;
                buttonMapper.outline.sprite = buttonMapper.backgroundSquared;
            }
            else if (style.backgroundShape == BackgroundShapeMapper.SquaredSmooth)
            {
                buttonMapper.background.sprite = buttonMapper.backgroundSquaredSmooth;
                buttonMapper.shadow.sprite = buttonMapper.backgroundSquaredSmooth;
                buttonMapper.outline.sprite = buttonMapper.backgroundSquaredSmooth;
            }
        }


        private void UpdateOutline()
        {
            buttonMapper.outline.enabled = style.enableOutline;

            buttonMapper.outline.color = style.outlineColor;
            outlineRect.sizeDelta = new Vector2(200 + style.outlineSize, 200 + style.outlineSize);
        }


        private void UpdateShadow()
        {
            buttonMapper.shadow.enabled = style.enableShadow;

            buttonMapper.shadow.color = style.shadowColor;
            shadowRect.localPosition = style.shadowOffset;
            shadowRect.sizeDelta = new Vector2(200 + style.shadowSize, 200 + style.shadowSize);
        }


        private void UpdateAnimation()
        {
            if (style.animationType == AnimationMapper.MoveUp) buttonAnim.SetInteger("AnimType", 0);
            else if (style.animationType == AnimationMapper.Pop) buttonAnim.SetInteger("AnimType", 1);
            else buttonAnim.SetInteger("AnimType", 2);
        }


        private void UpdateIcon()
        {
            buttonMapper.icon.sprite = iconSprite;
            buttonMapper.iconOverlay.sprite = iconSprite;
        }
    }
}