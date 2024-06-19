using Modules.WS;
using UnityEngine.InputSystem;

namespace Modules.AbilitySystem
{
    using System;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class AbilitySystemComponent : MonoBehaviour
    {
        public AttributeContainer AttributeContainer { get; private set; }
        public Ability TakeDamage;

        private void Awake()
        {
            AttributeContainer = GetComponent<AttributeContainer>();
            BindAttributeListeners();
        }

        private void BindAttributeListeners()
        {
            AttributeContainer.GetAttributeByName("Health").AttributeChanged += OnHealthChanged;
        }

        private void OnHealthChanged(float oldValue, float newValue)
        {
            Debug.Log($"Health Attribute Changed\n Old: {oldValue} New: {newValue}");
        }

        private async void OnTakeDamage(InputValue inputValue)
        {
            await WSManager.SendMessageAsync("Test Message");
        }
    }
}
