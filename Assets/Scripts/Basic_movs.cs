using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace indian_trys
{
    public class Basic_movs : MonoBehaviour
    {
        public float Speed;
        void Update()
        {
            if (VirtualInputManager.instance.MoveRight && VirtualInputManager.instance.MoveLeft)
            {
                return;
            }
            if(VirtualInputManager.instance.MoveRight)
            {
                this.gameObject.transform.Translate(Speed * Time.deltaTime* Vector3.forward);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (VirtualInputManager.instance.MoveLeft)
            {
                this.gameObject.transform.Translate(Speed * Time.deltaTime* Vector3.forward);
                this.gameObject.transform.rotation=Quaternion.Euler(0f, -180f, 0f);
            }
        }
    }
}

