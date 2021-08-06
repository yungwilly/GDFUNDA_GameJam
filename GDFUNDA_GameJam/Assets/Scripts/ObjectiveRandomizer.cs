using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> pool;
    [SerializeField] public List<GameObject> objectives;
    [SerializeField] public Text Objective1;
    [SerializeField] public Text Objective2;
    [SerializeField] public Text Objective3;
    [SerializeField] public Text Objective4;
    public List<Text> texts;

    // Start is called before the first frame update
    void Start()
    {
        ListAllChildren();
        RandomizeObjectives();
        texts.Add(Objective1);
        texts.Add(Objective2);
        texts.Add(Objective3);
        texts.Add(Objective4);
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
        for (int i = 0; i < 4; i++)
        {
            random = Random.Range(0, pool.Count - 1);
            //print(pool.Count);
            switch (i)
            {
                case 0:
                    Objective1.text = pool[random].name;
                    break;
                case 1:
                    Objective2.text = pool[random].name;
                    break;
                case 2:
                    Objective3.text = pool[random].name;
                    break;
                case 3:
                    Objective4.text = pool[random].name;
                    break;
                default: break;

            }
            print(pool[random].name);
            objectives.Add(pool[random]);
            pool.RemoveAt(random);

        }
    }

    List<GameObject> getObjectives()
    {
        return objectives;
    }
}
