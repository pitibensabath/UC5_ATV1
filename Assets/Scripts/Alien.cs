 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public float vida = 100f; //Vida
    public Transform alvo; //Alvo do Alien
    public float distanciaMira = 10f; //Distância para ver o player
    public float distanciaAtaque = 3f; //Distância para o ataque (apenas representação aqui)
    public float moveSpeed = 5f; //Velocidade 

    private bool olhaEsquerda = true; //Determinar para qual lado estará virado

    // Update is called once per frame
    void Update()
    {
        {
            //Movimentação do Alien e alteração da direção 
            if (Vector3.Distance(alvo.position, this.transform.position) < distanciaMira)
            {
                Vector3 direcao = alvo.position - this.transform.position; //Achar a direção do alvo

                if (Mathf.Sign(direcao.x) == 1 && olhaEsquerda)
                {
                    Flip();
                }
                else if (Mathf.Sign(direcao.x) == -1 && !olhaEsquerda)
                {
                    Flip();
                }

                if (direcao.magnitude >= distanciaAtaque)
                {
                    Debug.DrawLine(alvo.transform.position, this.transform.position, Color.yellow); //Para ver as diferenças de posições do Alien: 'verde', se não estiver na linha de visão, 'amarelo' para quando entra nesta e quando o inimigo começa a se movimentar, 'vermelho' para o ataque.

                    if (olhaEsquerda) //Direção dos ataques
                    {
                        this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                    }
                    else if (!olhaEsquerda)
                    {
                        this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                    }

                    if (direcao.magnitude < distanciaAtaque)
                    {
                        Debug.DrawLine(alvo.transform.position, this.transform.position, Color.red);
                    }
                }
            }

            else if (Vector3.Distance(alvo.position, this.transform.position) > distanciaMira)
            {
                Debug.DrawLine(alvo.position, this.transform.position, Color.green);
            }

        }

    }

    //Função para virar o sprite
    private void Flip()
    {
        olhaEsquerda = !olhaEsquerda;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Colisões da bala com o Alien e consequências
    {
        if (collision.gameObject.tag == "Bullet")
        {
            vida -= 10;

            if (vida <= 0)
            {
                Destroy(gameObject, 0.05f);
            }

        }
    }
}
