using System;

namespace MightyAdventures.StatSystem
{
    [Serializable]
    public abstract class AbstractStat
    {
        public Action OnStatChanged;
        
        public abstract float Value { get; }

        public abstract string GetValueText();
        
        //public abstract AbstractStat Clone();
    }
}