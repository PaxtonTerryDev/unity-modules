namespace Modules.AbilitySystem
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Ability", menuName = "Ability System/Ability")]
    public class Ability : ScriptableObject
    {
        public List<Effect> AssignedEffects;
        public List<Effect> Effects { get; private set; } = new List<Effect>();

        private void OnEnable()
        {
            initializeEffects();
        }

        private void initializeEffects()
        {
            foreach (var effect in AssignedEffects)
            {
                Effects.Add(ScriptableObject.Instantiate(effect));
            }
        }

        public void Execute(AbilitySystemComponent abilitySystemComponent)
        {
            abilitySystemComponent.AttributeContainer.ProcessAbility(this);
        }
    }
}
