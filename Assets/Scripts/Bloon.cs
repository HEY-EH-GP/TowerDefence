using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour
{
    public Rigidbody rb;

    [Range(1,10)]
    public float pushForce = 1;
    public Transform[] pathPoints;

    private void Start()
    {
        #region Loops
        /*
        ///FOR LOOP///
        for(int i = 0 , y = 2; i < 10; i++, y += 10)
        {
            y /= 5; // y = y / 5;
            y *= 2; // y = y * 2;
            y += 5; // y = y + 5;
            y -= 2; // y = y - 2;

            Debug.Log("Index ha valore " + i);
        }
      
        ///DO WHILE LOOP///
        
        int index = 0;
        do
        {
            index++;
            Debug.Log("Index ha valore " + index);
        } while (index < 10);

        ///WHILE LOOP
        int index2 = 0;
        while (index2 < 10)
        {
            index2++;
            Debug.Log("Index ha valore " + index2);
        }

        //FOR EACH LOOP
        int index3 = 0;
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // 0 -> Array.Lenght - 1
        foreach (int number in numbers)
        {
            Debug.Log("Index ha valore " + numbers[index3]);
            index3++;
            Debug.Log("Index ha valore " + number);
        }
        */
        #endregion
    }

    private void Update()
    {

    }

}
