using UnityEngine;
using UnityEngine.UI;

public class Area2_ConCollecting : MonoBehaviour
{
    private int _coins;
    private int _paper;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
     [SerializeField] private GameObject portal;
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            _coins++;
        }

        else if (collision.gameObject.CompareTag("Pages"))
        {
            Destroy(collision.gameObject);
            _paper++;
        }
        if(_coins >= 1 && _paper==3 ){
            Instantiate(portal,new Vector3(-1200,-1,0),Quaternion.identity);
        }
        coinText.text="Coins:" + _coins;
        paperText.text="Paper"+_paper;

    }
}