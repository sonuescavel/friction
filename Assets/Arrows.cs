using UnityEngine;
using System.Collections;

public class Arrows : MonoBehaviour
{

    public GameObject Force;
    public GameObject Friction;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Force.transform.localScale = new Vector3(2, 2, 2);
            //Friction.transform.localScale = new Vector3(2, 1, 1);
           Force.transform.localScale = Force.transform.localScale + new Vector3(0, 0, Time.deltaTime);

        }
        
    }
    //private IEnumerator applyPowerUp(string type, GameObject player)
    //{
    //    GameObject originPlayer = new GameObject();
    //    originPlayer = player;

    //    if (type == "Bigger")
    //    {
    //        Debug.Log("make it big");
    //        player.transform.localScale = new Vector3(1.25f, 2.9f, 0);
    //        player.transform.position = new Vector2(player.transform.position.x + 0.4f, player.transform.position.y);
    //        yield return new WaitForSeconds(5);
    //        player = originPlayer;
    //    }
    //}
}