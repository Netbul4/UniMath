using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProblemTarget : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] TextMeshProUGUI answerText;
    [SerializeField] int answer;  // identifier number for this tube
                        // called when something enters the tube's collider

    public void Initialize(float number)
    {
        answer = (int)number;
        answerText.text = answer.ToString();
    }

    public IEnumerator DestroyTarget()
    {
        Debug.Log("SHOT");
        GameManager.instance.OnPlayerShot(answer);
        explosionParticle.Play();
        Destroy(this.gameObject);
        yield return 0;
    }
}
