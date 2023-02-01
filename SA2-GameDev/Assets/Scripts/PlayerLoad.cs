using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLoad : MonoBehaviour
{

   public float Xpos;
   public float Ypos;
   public float Zpos;
   private float x;
   private float y;
   private float z;

   private void Start()
   {
      
      
   }

   public void Load()
   {
      Xpos = PlayerPrefs.GetFloat("x");
      Ypos = PlayerPrefs.GetFloat("y");
      Zpos = PlayerPrefs.GetFloat("z");
     
      Vector3 loadPosition = new Vector3(x, y, z);
      transform.position = loadPosition;
   }
}
