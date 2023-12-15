using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image Bgimage;
    private Image Joystickimage;

    public Vector2 InputDir;
    public float offset = 2f; //pengalih, titiknya mengikuti jari kita sejauh apa

    public GameObject ObjekGerak; //objek yang digerakkan

    public float SpeedMax = 5f; //set kecepatan maksimal
    public float Zaxis; //titik putarnya

    // Start is called before the first frame update
    void Start()
    {
        Bgimage = GetComponent<Image>();
        Joystickimage = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ObjekGerak.transform.Translate(InputDir.x * SpeedMax * Time.deltaTime, 0, InputDir.y * SpeedMax * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //setiap ngedra, fungsi ini terpanggil. joysticknya jadi ngikutin arah jari
        Vector2 pos = Vector2.zero;
        float bgimagesizeX = Bgimage.rectTransform.sizeDelta.x;
        //float bgimagesizeY = Bgimage.rectTransform.sizeDelta.y;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Bgimage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= bgimagesizeX;
            //pos.y /= bgimagesizeY;

            InputDir = new Vector2(pos.x, 0/*pos.y*/);
            InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;

            Joystickimage.rectTransform.anchoredPosition = new Vector2
                (InputDir.x * (bgimagesizeX / offset), 0/*InputDir.y * (bgimagesizeY / offset)*/);

            //ini rotasi dari data sumbu x dan y
            //Zaxis = Mathf.Atan2(InputDir.x, InputDir.y) * Mathf.Rad2Deg;

            //ObjekPutar.transform.eulerAngles = new Vector3(0, Zaxis, 0);

        }


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //kalo tangan kita nyentuh tombol dan ketekan, dia langsung panggil ondrag
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //kalo pointernya dilepas setelah ditekan, joystick tengahnya harus kembali ke posisi 0 atau tengah
        InputDir = Vector2.zero;
        Joystickimage.rectTransform.anchoredPosition = Vector2.zero;
    }

}
