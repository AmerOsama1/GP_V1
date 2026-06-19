using UnityEngine;

public class PlayerLevelMover : MonoBehaviour
{
    public Transform[] lvls;
    public string nameOfLevel;
   public float moveSpeed = 2f;

    Vector3 targetPosition;
    Animator animator;


   void Start()
{   
    animator = GetComponent<Animator>();
    
   int savedLevel = PlayerPrefs.GetInt(nameOfLevel, -1);

if (savedLevel == -1)
{
    savedLevel = 0;
    PlayerPrefs.SetInt(nameOfLevel, savedLevel);
    PlayerPrefs.Save();
}

Debug.Log(savedLevel);


    if (savedLevel >= lvls.Length)
    {
        savedLevel = 0;
        PlayerPrefs.SetInt(nameOfLevel, 0);
        PlayerPrefs.Save();
    }

    targetPosition = lvls[savedLevel].position;
}




     void Update()

    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0, targetRotation.eulerAngles.y, 0),
                10f * Time.deltaTime);
        }

        bool isMoving = Vector3.Distance(transform.position, targetPosition) > 0.1f;
        animator.SetBool("Run", isMoving);
    }
}