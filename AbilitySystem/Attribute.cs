namespace Modules.AbilitySystem
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "new Attribute", menuName = "Ability System/Attribute")]
    public class Attribute : ScriptableObject
    {
        public delegate void AttributeChangedDelegate(float oldValue, float newValue);

        public event AttributeChangedDelegate AttributeChanged;
        
        public string Name;
        [SerializeField] private float _value;

        public float Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                
                AttributeChanged?.Invoke(_value, value);
                _value = value;
            }
        }

    }
}
