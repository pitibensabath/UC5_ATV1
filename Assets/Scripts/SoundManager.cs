using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public AudioSource efxSource; //Efeitos de áudio
    public static SoundManager instance = null; //Para que esta seja a única instância, o único responsável por tocar sons em diferentes fases
    public float lowPitchRange = .95f; //O mais baixo que o som irá tocar
    public float highPitchRange = 1.05f; //Contrário do anterior
     
    private void Awake() //Função que acontece quando o script/objeto é "acordado"
    {
        if (instance == null) //Quando for nula, significa que acabou de iniciar
        {
            instance = this; //A intância é igual a este próprio script 
        }
        else if(instance != this)
        {
            Destroy(gameObject); //Só pode haver uma instância cuidando de tudo, e sempre tem que ser a mesma
        }

        DontDestroyOnLoad(gameObject); //Sempre que carregar um cenário novo, não destruirá o game object. Garante que só haverá ele.
    }

    public void PlaySingle(AudioClip clip) //Tocará um só áudio. 'AudioClip' é que o vai adicionar e arrastar para o jogo
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)  //Usado quando é necessário usar áudios diferentes no jogo
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.clip = clips[randomIndex];
        efxSource.pitch = randomPitch;

        efxSource.Play();

    }
}
