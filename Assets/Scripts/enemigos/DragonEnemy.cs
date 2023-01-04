using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitedTimeToAttack = 3 ;
    public Animator animator;
    public GameObject BulletPrefab;
    public Transform lauchSpawnPoint;
    // Start is called before the first frame update
    private void Start()
    {
        waitedTime = waitedTimeToAttack;
    }

    // Update is called once per frame
    private void Update()
    {
        if(waitedTime<=0)
        {
            waitedTime = waitedTimeToAttack;
            animator.Play("attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(BulletPrefab, lauchSpawnPoint.position, lauchSpawnPoint.rotation);
    }
}
