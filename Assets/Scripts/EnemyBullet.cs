using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; // vitesse de la bulle
    Vector2 _direction; // direction des bulles
    bool isReady; // pour mémoriser la direction d'une bulle

    // fixer les valeurs par defaut
    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized; // normaliser la direction pour avoir un vecteur "unit"
        isReady = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
