using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    Transform[] patrolPoints;

    bool frozen = false;

    private void Awake()
    {
        _instances.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position;
            index = 1;
        }
    }

    Vector2 startPos, dest;
    float t = 0f;
    int index = 1;
    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            Patrol();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (frozen)
            {
                UnFreezeMe();
            }
            else
            {
                FreezeMe();
            }
        }
    }

    void Patrol()
    {
        if (t == 0f)
        {
            Debug.Log("Index :: " + index);

            startPos = transform.position;
            dest = patrolPoints[index].position;
        }

        if (t >= 1)
        {
            transform.position = dest;
            t = 0f;
            index = ++index % patrolPoints.Length;
        }
        else
        {
            t += Time.deltaTime * speed;

            Vector2 newPos = startPos;
            newPos.x = Mathf.Lerp(startPos.x, dest.x, t);
            newPos.y = Mathf.Lerp(startPos.y, dest.y, t);

            transform.position = newPos;
        }
    }

    public void FreezeMe()
    {
        frozen = true;
    }

    public void UnFreezeMe()
    {
        frozen = false;
    }

    private static List<NPCController> _instances = new List<NPCController>();

    public static void Freeze()
    {
        foreach (NPCController npc in _instances)
        {
            npc.FreezeMe();
        }
    }

    public static void UnFreeze()
    {
        foreach (NPCController npc in _instances)
        {
            npc.UnFreezeMe();
        }
    }
}
