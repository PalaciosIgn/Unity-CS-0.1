using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public Transform target;
    public bool activar = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        target = GameObject.Find("PlayerController(Clone)").GetComponent<Transform>();
        activar = true;
    }

    void Update()
    {
        if (activar)
        {
            Seguir();
        }
    }

    public void Seguir()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);

        //// Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        //transform.LookAt(target, Vector3.zero);


    }
}
