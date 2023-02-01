using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPotion : MonoBehaviour
{
   private const string PotionSaveData = "wasUsedAlready";

   private void OnTriggerEnter2D(Collider2D col)
   {
      Destroy(col.gameObject,4);
      PlayerPrefs.SetString(PotionSaveData, "true");
   }

   private void Start()
   {
      string wasUsedAlready = PlayerPrefs.GetString(PotionSaveData);

      if (wasUsedAlready == "true")
      {
         Destroy(gameObject);
      }
   }
}
