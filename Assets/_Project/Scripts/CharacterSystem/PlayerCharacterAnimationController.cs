using UnityEngine;

namespace MightyAdventures.CharacterSystem
{
    public class PlayerCharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterBehaviour playerCharacterBehaviour;
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
        private void OnBasicAttackUsed()
        {
            animator.SetTrigger(OnBasicAttackHash);
        }

        [ContextMenu("Heavy Attack")]
        private void OnHeavyAttackUsed()
        {
            animator.SetTrigger(OnHeavyAttackHash);
        }

        [ContextMenu("Damaged")]
        private void OnDamaged()
        {
            animator.SetTrigger(OnDamagedHash);
        }

        [ContextMenu("Died")]
        private void OnDied()
        {
            animator.SetTrigger(OnDiedHash);
        }
        
        #region MonoBehaviour Methods

        private void OnEnable()
        {
            playerCharacterBehaviour.OnPerformBasicAttack += OnBasicAttackUsed;
            playerCharacterBehaviour.OnPerformHeavyAttack += OnHeavyAttackUsed;
            playerCharacterBehaviour.OnDamaged += OnDamaged;
            playerCharacterBehaviour.OnDied += OnDied;
        }

        private void OnDisable()
        {
            playerCharacterBehaviour.OnPerformBasicAttack -= OnBasicAttackUsed;
            playerCharacterBehaviour.OnPerformHeavyAttack -= OnHeavyAttackUsed;
            playerCharacterBehaviour.OnDamaged -= OnDamaged;
            playerCharacterBehaviour.OnDied -= OnDied;
        }

        #endregion
    }
}