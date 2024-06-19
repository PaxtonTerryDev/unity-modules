namespace Modules.AbilitySystem
{
    using System;
    using UnityEngine;
    using System.Collections;

    [CreateAssetMenu(fileName = "New Effect", menuName = "Ability System/Effect")]
    public class Effect : ScriptableObject
    {
        public string AffectsAttribute;
        public EEffectType EffectType = EEffectType.Immediate;
        public EValueChangeType ValueChangeType;
        public float Amount = 0f;
        public float Duration = 0f;

        public void ApplyEffect(Attribute attribute, MonoBehaviour monoBehaviour)
        {
            switch (EffectType)
            {
                case EEffectType.Immediate:
                    ApplyImmediateEffect(attribute);
                    break;
                case EEffectType.Duration:
                    monoBehaviour.StartCoroutine(ApplyDurationEffect(attribute));
                    break;
            }
        }

        private void ApplyImmediateEffect(Attribute attribute)
        {
            switch (ValueChangeType)
            {
                case EValueChangeType.Decrease:
                    attribute.Value -= Amount;
                    break;
                case EValueChangeType.Increase:
                    attribute.Value += Amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator ApplyDurationEffect(Attribute attribute)
        {
            var elapsedTime = 0f;
            var applyPerSecond = Amount / Duration; // Determine the amount to apply each second

            while (elapsedTime < Duration)
            {
                switch (ValueChangeType)
                {
                    case EValueChangeType.Decrease:
                        attribute.Value -= applyPerSecond * Time.deltaTime;
                        break;
                    case EValueChangeType.Increase:
                        attribute.Value += applyPerSecond * Time.deltaTime;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                elapsedTime += Time.deltaTime;
                yield return null; // Wait until the next frame
            }
        }
    }

}
