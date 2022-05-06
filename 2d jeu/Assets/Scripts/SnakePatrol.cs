
using UnityEngine;

public class SnakePatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer snake;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0]; 
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed *Time.deltaTime,Space.World);
       
        //si l'enemi est quasiment arrivé a ca destination 
        if (Vector3.Distance(transform.position,target.position)< 0.3f) 
        {
            //"%" en c# ca recupere le reste d'une division
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            snake.flipX = !snake.flipX;
        }
    }
}
