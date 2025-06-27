using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private const string BasicAttackAnimationParameter = "OnBasicAttack";
        private const string HeavyAttackAnimationParameter = "OnHeavyAttack";
        private const string DamagedAnimationParameter = "OnDamaged";
        private const string DeathAnimationParameter = "OnDied";
        
        //https://gamedev.stackexchange.com/questions/200837/why-use-animator-stringtohash
        private static readonly int OnBasicAttackHash = Animator.StringToHash(BasicAttackAnimationParameter);
        private static readonly int OnHeavyAttackHash = Animator.StringToHash(HeavyAttackAnimationParameter);
        private static readonly int OnDamagedHash = Animator.StringToHash(DamagedAnimationParameter);
        private static readonly int OnDiedHash = Animator.StringToHash(DeathAnimationParameter);

        [ContextMenu("Basic Attack")]
        public void OnBasicAttackUsed()
        {
            animator.SetTrigger(OnBasicAttackHash);
        }

        [ContextMenu("Heavy Attack")]
        public void OnHeavyAttackUsed()
        {
            animator.SetTrigger(OnHeavyAttackHash);
        }

        [ContextMenu("Damaged")]
        public void OnDamaged()
        {
            animator.SetTrigger(OnDamagedHash);
        }

        [ContextMenu("Died")]
        public void OnDied()
        {
            animator.SetTrigger(OnDiedHash);
        }
    }
}