using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_generator : MonoBehaviour
{
    public GameObject root_ref;
    public GameObject player;
    public GameObject[] prefabs;
    public double padding = 10;
    public float interval = 0.5f;

    private Vector2 screen_size;

    // Start is called before the first frame update
    void Start()
    {
        screen_size.x = Screen.width * 1.2f;
        screen_size.y = Screen.height * 1.9f;
        StartCoroutine(mine_generator());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(root_ref.transform.localPosition.y);
        
    }

    IEnumerator mine_generator()
    {
        while(true)
        {
            Vector3 v = new Vector3(Random.Range(0 - screen_size.x, 0 + screen_size.x), root_ref.transform.localPosition.y * -1 + screen_size.y, 0);
            {
                GameObject t = Instantiate(prefabs[0], root_ref.transform);
                t.transform.localPosition = v;
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
