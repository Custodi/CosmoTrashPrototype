using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ship_movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Coroutine cor;
    private int height, width;
    private RectTransform ship_rect;
    public GameObject ship;
    public double inner_radius; // Внутренний радиус игнорирования
    public double outer_radius; // Внешний радиус направления
    public double speed = 20f;

    // Start is called before the first frame update
    void Start()
    {   
        height = Screen.currentResolution.height;
        width = Screen.currentResolution.width;
        ship_rect = ship.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        cor = StartCoroutine(MoveCor(eventData.position));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(cor);
    }
    IEnumerator MoveCor(Vector3 anchor_pos)
    {
        while(true)
        {
            yield return null;
            double k;
            Vector3 current_pos = Input.mousePosition;
            
            double length = (current_pos - anchor_pos).magnitude;
            if (length <= inner_radius) k = 0;
            else if (length >= outer_radius) k = 1;
            else
            {
                k = (length - inner_radius) / (outer_radius - inner_radius);
            }
            Vector3 move_vector = current_pos - anchor_pos;
            move_vector.y = 0;
            offset(ship, move_vector.normalized, k * speed);
        }
        
    }

    private void offset(GameObject t, Vector3 offset_vector, double factor = 1)
    {
        Rect rect = ship_rect.rect;
        rect.x += offset_vector.x * (float)factor;
        rect.y += offset_vector.y * (float)factor;

        t.transform.localPosition =
            new Vector3(t.transform.localPosition.x + offset_vector.x * (float)factor, t.transform.localPosition.y + offset_vector.y * (float)factor);
    }
}
