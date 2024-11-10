using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFloor : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //GecisReklami.instance.GecisReklamiOlustur();
           // GecisReklami.instance.GecisReklamiGoster();
        }
    }

   
}
