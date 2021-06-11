using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_script: MonoBehaviour
{
    public GameObject background_elem_instance;
    public float speed;

    private double step = 0;
    private double y = 0;
    private double current_coord = 0;
    private GameObject[] back_elems = new GameObject[3];

    void Start()
    {
        step = background_elem_instance.GetComponent<RectTransform>().rect.height / 2;
        current_coord = 0 - step;

        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(0, (float)(step*2 - i*step*2), 0);
            back_elems[i] = Instantiate(background_elem_instance, gameObject.transform);
            back_elems[i].transform.localPosition = pos;
        }

        //StartCoroutine(Background_movement());
    }

    void Update()
    {
        y = y - speed;
        gameObject.transform.localPosition = new Vector3(0, (float)y, 0);
        if (y < current_coord)
        {
            GameObject t = back_elems[2];
            current_coord -= 2 * step;
            t.transform.localPosition = new Vector3(0, (float)(t.transform.localPosition.y + 6 * step), 0);
            back_elems[2] = back_elems[1];
            back_elems[1] = back_elems[0];
            back_elems[0] = t;
            //Debug.Log(y + "|" + current_coord);
        }
    }

    /*IEnumerator Background_movement()
    {
        Debug.Log(1);
       
        yield return null;
        
    }*/
}
