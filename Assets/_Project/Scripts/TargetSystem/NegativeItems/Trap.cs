using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.TargetSystem.NegativeItems
{
    public class Trap : AbstractTarget
    {
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;
        [SerializeField] private float damage;

        public override void OnHit()
        {
            base.OnHit();
            playerCharacterBehaviour.Damage(damage);
        }
    }
}