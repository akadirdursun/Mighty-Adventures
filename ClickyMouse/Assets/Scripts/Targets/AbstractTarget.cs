using UnityEngine;
using System.Collections;

namespace ClickyMause.Targets
{
    public abstract class AbstractTarget : MonoBehaviour
    {
        [SerializeField] protected int pointValue;
        [SerializeField] protected PlayerData playerData;
        [SerializeField] protected ParticleColor partickleColor;
        [Header("Audio")]
        [SerializeField] protected AudioClip onClickAudioClip;

        protected AudioSource targetAudioSource;
        protected Rigidbody targetRB;
        protected MeshRenderer targetMeshRenderer;

        protected ObjectPool particlePool;

        protected float minForce = 10f;
        protected float maxForce = 15f;
        protected float torqueValue = 10f;

        protected bool isGameActive = true;

        public ObjectPool ParticlePool { get => particlePool; set => particlePool = value; }

        private void Awake()
        {
            targetRB = GetComponent<Rigidbody>();
            targetAudioSource = GetComponent<AudioSource>();
            targetMeshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            StaticEvents.GameOver += IsGameOver;
            targetRB.AddForce(RandomForce(), ForceMode.Impulse);
            targetRB.AddTorque(RandomTarque(), RandomTarque(), RandomTarque(), ForceMode.Impulse);
        }

        private void OnDisable()
        {
            StaticEvents.GameOver -= IsGameOver;
        }

        private void IsGameOver()
        {
            isGameActive = false;
        }

        private void OnMouseDown()
        {
            if (isGameActive)
            {
                StartCoroutine(OnClickTargetCoroutine());
            }
        }

        private IEnumerator OnClickTargetCoroutine()
        {
            playerData.AddScore(pointValue);
            TargetActions();
            ParticleSystem particle = particlePool.GetParticle(partickleColor);
            particle.gameObject.transform.position = transform.position;
            particle.gameObject.SetActive(true);
            targetMeshRenderer.enabled = false;
            targetAudioSource.PlayOneShot(onClickAudioClip);
            yield return new WaitForSeconds(onClickAudioClip.length);
            gameObject.SetActive(false);
            targetMeshRenderer.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            targetRB.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minForce, maxForce);
        }

        private float RandomTarque()
        {
            return Random.Range(-torqueValue, torqueValue);
        }

        protected virtual void TargetActions()
        {
        }
    }
}