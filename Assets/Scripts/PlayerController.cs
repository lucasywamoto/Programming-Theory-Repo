using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    float targetX = 1.2f;
    const float posX = 1.2f;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.Play("AmbulanceAnimClip");
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetX = -posX;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetX = posX;
            }
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
