using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class BottleFlip : MonoBehaviour
{

    public List<GameObject> prizeAreas;
    int randomValue;
    [SerializeField] TMP_Text prizeNameText = null;

    bool isRotate = false;
    Quaternion targetRotation;

    public Button button;
    public float animSpeed = 1;
    public int startRotateNumber = 3;   //başlangıçta çarkın döndüğü tur sayısı




    void Start()
    {
        button.onClick.AddListener(GetRandom);
    }


    void Update()
    {

        if (isRotate)
            Rotating();
    }

    void Rotating()
    {
        if (transform.rotation.eulerAngles.y < targetRotation.eulerAngles.y)
            transform.eulerAngles += new Vector3(0, 180 * 2 * animSpeed * Time.deltaTime, 0);
        else
        {
            Debug.Log("hedef ödülün önüne geldi");
            prizeNameText.text = "ödül " + prizeAreas[randomValue].name;
        }
    }



    public void GetRandom()
    {
        button.interactable = false;

        randomValue = Random.Range(0, prizeAreas.Count);
        Debug.Log(randomValue + " sayısı üretildi");



        transform.DORotate(new Vector3(0, 180, 0), 0.5f / animSpeed).SetLoops(startRotateNumber * 2, LoopType.Incremental).SetEase(Ease.Linear).OnKill(() =>
       {
           isRotate = true;
       });



        targetRotation = Quaternion.LookRotation(new Vector3(
                prizeAreas[randomValue].transform.position.x,
                0,
                prizeAreas[randomValue].transform.position.z)
                - transform.position);

        Debug.Log("targetRotation: " + targetRotation.eulerAngles);
    }

}
