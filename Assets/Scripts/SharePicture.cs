using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SharePicture : MonoBehaviour
{
    // Start is called before the first frame update
    public void click()
    {
        //GameObject.Find("").GetComponent<Button>().onClick.Invoke();
        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        new NativeShare().AddFile(filePath).SetSubject("Cerealis").SetText("#cerealis #coloring #AR").Share();

    }


}
