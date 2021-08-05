using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> pool;
    //[SerializeField] private List<GameObject> objectives;
    [SerializeField] private Text Objective1;
    [SerializeField] private Text Objective2;
    [SerializeField] private Text Objective3;
    [SerializeField] private Text Objective4;

    // Start is called before the first frame update
    void Start()
    {
        ListAllChildren();
        RandomizeObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ListAllChildren()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            pool.Add(transform.GetChild(i).gameObject);
    }

    void RandomizeObjectives()
    {
        int random;
        for(int i = 0; i<4; i++)
        {
            random = Random.Range(0, pool.Count-1);
            //print(pool.Count);
            switch(i)
            {
                case 0: 
                    Objective1.text = pool[random].name;
                    break;
                case 1: Objective2.text = pool[random].name;
                    break;
                case 2: Objective3.text = pool[random].name;
                    break;
                case 3: Objective4.text = pool[random].name;
                    break;
                default: break;
              
            }
            print(pool[random].name);
            pool.RemoveAt(random);

        }
    }
}
