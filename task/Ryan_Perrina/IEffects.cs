using System;

namespace model.effects
{
    public interface IEffects
    {
        /// <summary>
        /// use the effects of the Cards
        /// </summary>
        /// <param name="Table"></param>
        /// <param name=""></param>
        void UseEffect(Table table);
    }
}
