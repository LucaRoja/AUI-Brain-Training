using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feetFollow : MonoBehaviour
{
    KinectBodySkeleton skeleton;
    KinectBodySkeleton temporarySkeleton;
    private Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MagicRoomKinectV2Manager.instance.MagicRoomKinectV2Manager_active)
        {
            temporarySkeleton = null;
        foreach(KinectBodySkeleton c in MagicRoomKinectV2Manager.instance.skeletons) 
            {
                //Debug.Log(c);
                if(temporarySkeleton == null && c.SpineBase.z > 0)
                {
                    temporarySkeleton = c;
                }
                else if(temporarySkeleton == null)
                    continue;
                else if(temporarySkeleton.SpineBase.z > c.SpineBase.z && c.SpineBase.z > 0)
                {
                    temporarySkeleton = c;
                }
            }
            skeleton = temporarySkeleton;
            if (skeleton != null)
                _tr.position = new Vector2((skeleton.HandRight.x * 9.33f - 4),( skeleton.HandRight.y*10.78f));
        }
    }
}
