using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class CamShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public GameObject player;
    public Transform camTransform;
	
    // How long the object should shake for.
    float shakeDuration;
    public float shakeDurationTotal = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
	
    Vector3 originalPos;
    private bool shakingNow = false;

    public PostProcessingBehaviour m_PostPro;
    public PostProcessingProfile m_ProfileDead;
	
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

        shakeDuration = shakeDurationTotal;
    }

    void Update()
    {
        originalPos = camTransform.localPosition;

        if (player.GetComponent<PlayerUnit>().isShot)
            shakingNow = true;
        
        if (shakingNow)
            CamShaking();

        /*
        if (player.GetComponent<Player>().health <= 3)
        {
            m_PostPro.profile = m_ProfileDead;
        }
        */
    }

    void CamShaking()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = shakeDurationTotal;
            camTransform.localPosition = originalPos;
            shakingNow = false;
        }
    }
}