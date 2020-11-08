using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform rightHandTransform;
    [SerializeField] int throwForce = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var rock = Instantiate(rockPrefab);
            rock.transform.position = rightHandTransform.position;
            rock.GetComponent<Rigidbody>().AddRelativeForce(Camera.main.transform.forward * throwForce);
        }
    }
}
