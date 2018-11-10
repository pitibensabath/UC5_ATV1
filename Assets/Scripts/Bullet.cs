using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;

    public Player player; //Referência do jogador

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Player>(); //Para determinar a direção e verificar se precisa alterar a direção da bala, inclusive do sprite.

        if (player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y); //Nova velocidade da bala

        Destroy(gameObject, 0.3f); //Destruição da bala caso não haja colisão

    }
}
