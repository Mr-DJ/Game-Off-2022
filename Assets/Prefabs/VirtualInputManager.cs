using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace indian_trys
{
    public class VirtualInputManager : MonoBehaviour
    {
        public static VirtualInputManager instance=null;
       private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance!=null)
            {
                Destroy(this.gameObject);
            }

        }
        public bool MoveRight;
        public bool MoveLeft;
    }
    
}

