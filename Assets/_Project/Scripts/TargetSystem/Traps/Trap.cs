using MightyAdventures.CharacterSystem;
using UnityEngine;

namespace MightyAdventures.TargetSystem.Traps
{
    public class Trap : AbstractTarget
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private float damage;

        public override void OnHit()
        {
            base.OnHit();
            playerCharacterData.Damage(damage);
        }
    }
}