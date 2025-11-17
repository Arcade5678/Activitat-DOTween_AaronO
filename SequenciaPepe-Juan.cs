using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SequenciaPepe : MonoBehaviour
{
    public GameObject prSaltoPepe;
    public GameObject segSaltoPepe;
    public GameObject movJuan;
    public GameObject SaltoJuan;
    public GameObject PosOrigPepe;
    public GameObject PosOrigJuan;
    public Rigidbody Pepe;
    public Rigidbody Juan;
    public Button inicio;
    public Button reset;

    public float duracionSalto = 1f;
    public float potenciaSalto = 5f;

    private DG.Tweening.Sequence mySequence;

    void Start()
    {
        if (inicio != null)
        {
            inicio.onClick.AddListener(StartSequence);
        }
        if (reset != null)
        {
            reset.onClick.AddListener(ResetPositions);
        }
    }

    void StartSequence()
    {
        mySequence = DOTween.Sequence();

        mySequence.Append(Pepe.transform.DOJump(prSaltoPepe.transform.position, potenciaSalto, 1, duracionSalto));
        mySequence.Join(Juan.transform.DOMove(movJuan.transform.position, duracionSalto));

        mySequence.Append(Pepe.transform.DOJump(segSaltoPepe.transform.position, potenciaSalto, 1, duracionSalto));
        mySequence.Join(Pepe.transform.DORotate(new Vector3(0, 360, 0), duracionSalto, RotateMode.FastBeyond360));

        mySequence.Join(Juan.transform.DOJump(SaltoJuan.transform.position, potenciaSalto, 1, duracionSalto));
        mySequence.Join(Juan.transform.DORotate(new Vector3(0, 360, 0), duracionSalto, RotateMode.FastBeyond360));

        mySequence.Restart();
    }

    void ResetPositions()
    {
        if (mySequence != null)
        {
            mySequence.Kill();
        }

        if (PosOrigPepe != null && Pepe != null)
        {
            Pepe.transform.position = PosOrigPepe.transform.position;
            Pepe.velocity = Vector3.zero;
            Pepe.angularVelocity = Vector3.zero;
        }
        if (PosOrigJuan != null && Juan != null)
        {
            Juan.transform.position = PosOrigJuan.transform.position;
            Juan.velocity = Vector3.zero;
            Juan.angularVelocity = Vector3.zero;
        }
    }
}
