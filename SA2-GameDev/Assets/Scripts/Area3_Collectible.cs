using UnityEngine;
using UnityEngine.UI;

public class Area3_Collectible : MonoBehaviour
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
        if(_coins >= 30 && _paper==2 ){
            Instantiate(portal,new Vector3(1148,6,0),Quaternion.identity);
        }
        coinText.text="Coins:" + _coins;
        paperText.text="Paper:"+_paper;

    }
}
