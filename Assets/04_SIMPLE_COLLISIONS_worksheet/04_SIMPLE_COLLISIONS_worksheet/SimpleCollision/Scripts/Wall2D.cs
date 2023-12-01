 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 namespace Collision
 {
     public class Wall2D : MonoBehaviour
     {
         public Transform top;
         public Transform bottom;

         public Vector2 center {get; private set;}
         public Vector2 wallVec {get; private set;}
         public Vector2 normalVec {get; private set;}

         void Awake(){
             center = (top.position - bottom.position) / 2f;
             wallVec = top.position - bottom.position;
             normalVec = Vector2.Perpendicular(wallVec).normalized;
         }
     }
 }
