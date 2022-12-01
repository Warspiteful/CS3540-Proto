using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
   [SerializeField] private Collider Collider;

   [SerializeField]
   private bool isEntered;
   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player")){
         isEntered = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if(other.CompareTag("Player")){
         isEntered = false;
      }
   }

   public bool GetEntered()
   {
      return isEntered;
   }
}
