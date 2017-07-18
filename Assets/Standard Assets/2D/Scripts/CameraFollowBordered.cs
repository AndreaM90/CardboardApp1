using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollowBordered : MonoBehaviour
    {

        //Questo script ci permette di ottenere una camera che segua il personaggio durante il gioco e presenti dei bordi prefissati per eventuali evenienze

        public float xMargin = 1f; // Distanza su x prima del movimento della camera
        public float yMargin = 1f; // su y
        public float xSmooth = 8f; 
        public float ySmooth = 8f; 
        public Vector2 maxXAndY; //coordinate minime e massime per la camera, in modo tale da non farla uscire dai bordi dello schermo
        public Vector2 minXAndY; 

        private Transform m_Player; 

        public bool border;

        public float minX;
        public float minY;
        public float maxX;
        public float maxY;


        private void Awake()
        {
            //settaggio referenza
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private bool CheckXMargin()
        {
            
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }


        private bool CheckYMargin()
        {
            
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();

            if (border == true)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY),transform.position.z);
            }
        }


        private void TrackPlayer()
        {
            //settaggio di default
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            //richiamiamo tali metodi quando il personaggio fuoriesce dai margini impostati
            if (CheckXMargin())
            {
                
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
            }

            
            if (CheckYMargin())
            {
                
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }

            //le coordinate devono rientrare nei limiti impostati
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
