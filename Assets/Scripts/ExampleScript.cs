using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField] private int myInteger = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("My Integer Value is: " + myInteger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
