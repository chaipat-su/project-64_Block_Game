using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   
    [SerializeField] private Image img;
    [SerializeField] private Sprite btnUp, btnDown;
    [SerializeField] private AudioClip compressClip, unCompressClip;
    [SerializeField] private AudioSource source;

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = btnDown;
        source.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.sprite = btnUp;
        source.Play();
    }
}
