using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JoseSalto : MonoBehaviour
{
    public Rigidbody body;
    public GameObject Salto;
    public GameObject PosOrigen;
    public float TiempoSalto;
    public float PotenciaSalto;
    public Button Saltar;
    public Button Reset;

    void Start()
    {
        if (Saltar != null)
        {
            Saltar.onClick.AddListener(DoJump);
        }
        if (Reset != null)
        {
            Reset.onClick.AddListener(ResetPosition);
        }
    }

    void DoJump()
    {
        if (body != null && Salto != null)
        {
            body.transform.DOJump(Salto.transform.position, PotenciaSalto, 1, TiempoSalto);
        }
    }
    void ResetPosition()
    {
        if (PosOrigen != null)
        {
            body.transform.DOKill();
            transform.position = PosOrigen.transform.position;
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
    }
}
