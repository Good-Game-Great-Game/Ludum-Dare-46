using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int hope = 2;

    public static void OnHopeIncrease()
    {
        hope++;
    }
    public static void OnHopeDecrease()
    {
        hope--;
    }

    public static void HopeReset()
    {
        hope = 2;
    }
}
