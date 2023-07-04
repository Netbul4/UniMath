using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xAxis;
    [SerializeField] float yAxis;
    [SerializeField] float sensitivity;
    [SerializeField] Animator playerAnimator;

    private void Start()
    {
    }
    private void Update()
    {
        SetupCharacter();
        OnInteraction();
    }

    private void SetupCharacter()
    {
        xAxis += Input.GetAxis("Mouse X") * sensitivity;
        yAxis += Input.GetAxis("Mouse Y") * sensitivity;

        playerAnimator.SetFloat("x", xAxis);
        playerAnimator.SetFloat("y", yAxis);
    }

    void OnInteraction()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<ProblemTarget>() != null)
                {
                    StartCoroutine(hit.collider.GetComponent<ProblemTarget>().DestroyTarget());
                }
            }
        }
    }

}
