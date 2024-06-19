using System.Collections;
using UnityEngine.Serialization;

namespace Modules.AbilitySystem
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class AttributeContainer: MonoBehaviour
    {
        [FormerlySerializedAs("AssignedAttributes")] public List<Attribute> assignedAttributes;
        public List<Attribute> Attributes { get; private set; } = new List<Attribute>();

        private void Awake()
        {
            InitializeAttributes();
        }

        private void InitializeAttributes()
        {
            foreach (var attribute in assignedAttributes)
            {
                Attributes.Add(ScriptableObject.Instantiate(attribute));
            }
        }

        public Attribute GetAttributeByName(string attributeName)
        {
            return Attributes.Find(attribute => attribute.Name == attributeName);
        }
        
        public void ProcessAbility(Ability ability)
        {
            foreach (var effect in ability.Effects)
            {
                var attribute = GetAttributeByName(effect.AffectsAttribute);
                effect.ApplyEffect(attribute, this);
            }
        }
    }
}
