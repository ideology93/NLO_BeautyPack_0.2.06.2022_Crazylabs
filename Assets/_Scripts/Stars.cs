using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Stars : MonoBehaviour
{

    public AudioManager am;
    [Header("Camera Positions")]
    public Transform startPos, targetPos1, targetPos2, targetPos3;
    [Header("Arrays")]
    public Transform[] positions;
    public Transform[] particles;
    [Header("GameObjects")]
    public GameObject star;
    private GameObject obj;
    public GameObject particle;

    [Header("Scripts")]
    public SliderScripts ss;
    [HideInInspector]
    public static int StarCount;

    // Start is called before the first frame update
    void Awake()
    {

        positions = new Transform[] { targetPos1, targetPos2, targetPos3 };


    }

    public void StarsScore(int a)
    {
        int c = a;
        StartCoroutine(GetStars(c));
    }

    // Update is called once per frame

    public IEnumerator GetStars(int a)
    {

        for (int i = 0; i < a; i++)
        {

            obj = Instantiate(star) as GameObject;
            obj.transform.SetParent(gameObject.transform, false);
            obj.SetActive(true);
            obj.transform.position = startPos.position;
            Tween m = obj.transform.DOMove(positions[i].position, 0.5f, false);
            Tween r = obj.transform.DOLocalRotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(0.2f);

            if (i == 2)
            {
                am.PlayClip(2);
            }
            else
                am.PlayClip(1);
            if (a == 0)
            {
                am.PlayClip(3);
            }
            particles[i].gameObject.SetActive(true);





        }
        StarCount += a;
        
    }


}
