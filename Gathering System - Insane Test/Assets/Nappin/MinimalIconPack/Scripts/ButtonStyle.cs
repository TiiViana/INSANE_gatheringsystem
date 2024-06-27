using UnityEngine;
using static MinimalIconPack.ButtonMapper;


namespace MinimalIconPack
{
    [CreateAssetMenu(fileName = "Style", menuName = "Button Style")]
    public class ButtonStyle : ScriptableObject
    {
        [Header("Button style")]
        public Color iconColor = Color.white;
        public Color backgroundColor = Color.black;
        [Range(0, 100)]
        public float buttonBackgroundRatio;


        [Header("Outline style")]
        [Space(25)]
        public bool enableOutline;
        [Space(10)]
        public Color outlineColor;
        [Range(0, 350)]
        public int outlineSize;


        [Header("Shadow style")]
        [Space(25)]
        public bool enableShadow;
        [Space(10)]
        public Color shadowColor;
        [Range(0, 500)]
        public int shadowSize;
        public Vector2 shadowOffset;


        [Header("Animtion type")]
        [Space(25)]
        public BackgroundShapeMapper backgroundShape;
        public AnimationMapper animationType;
    }
}