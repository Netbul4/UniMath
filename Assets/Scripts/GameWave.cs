using System.Collections;
using UnityEngine;

public class GameWave : MonoBehaviour
{
    [SerializeField] GameObject problemObject;
    public Vector3 spawnValues;
    public float wait;
    public float startWait;
    public float waveWait;

    public static int score;

    public IEnumerator Spawn(float[] answers)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            AddProblemTarget(answers[i]);
            yield return new WaitForSeconds(wait);
        }
    }

    public void AddProblemTarget(float number)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        GameObject objTarget = Instantiate(problemObject.gameObject, spawnPos, Quaternion.identity);
        objTarget.GetComponent<ProblemTarget>().Initialize(number);
    }

    public void AddScore(int value)
    {
        score += value;
    }

}
