using System;


namespace Project.Scripts.Common.Infrastructure
{
    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
        
        public static implicit operator T(ReactiveProperty<T> reactiveValue)
        {
            return reactiveValue._value;
        }  
    }
}