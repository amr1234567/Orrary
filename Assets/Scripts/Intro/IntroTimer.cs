using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTimer : MonoBehaviour
{
    private float time;

    public TextMeshProUGUI title;
    public TextMeshProUGUI content;

    private bool once = true;


    private string titleString = "Eclipses in mythology and religion";
    private string contentString = "Before eclipses were understood as well as they are today, there was a much more fearful connotation surrounding the seemingly\r\ninexplicable events. There was very considerable confusion regarding eclipses before the 17th century because eclipses were not very\r\naccurately or scientifically described until Johannes Kepler provided a scientific explanation for eclipses in the early seventeenth century.\r\nTypically in mythology, eclipses were understood to be one variation or another of a spiritual battle between the sun and evil forces or\r\nspirits of darkness. The phenomenon of the sun seeming to disappear was a very fearful sight to all who did not understand the science of\r\neclipses as well as those who supported and believed in the idea of mythological gods. The sun was highly regarded as divine by many old\r\nreligions, and some even viewed eclipses as the sun god being overwhelmed by evil spirits. More specifically, in Norse mythology, it is\r\nbelieved that there is a wolf by the name of Fenrir that is in constant pursuit of the sun, and eclipses are thought to occur when the wolf\r\nsuccessfully devours the divine sun. Other Norse tribes believe that there are two wolves by the names of Sköll and Hati that are in pursuit\r\nof the sun and the moon, known by the names of Sol and Mani, and these tribes believe that an eclipse occurs when one of the wolves\r\nsuccessfully eats either the sun or the moon. Once again, this mythical explanation was a very common source of fear for the majority of\r\npeople at the time who believed the sun to be a sort of divine power or god because the known explanations of eclipses were quite\r\nfrequently viewed as the downfall of their highly regarded god. Similarly, other mythological explanations of eclipses describe the\r\nphenomenon of darkness covering the sky during the day as a war between the gods of the sun and the moon.\r\nIn most types of mythologies and certain religions, eclipses were seen as a sign that the gods were angry and that danger was soon to\r\ncome, so people often altered their actions in an effort to dissuade the gods from unleashing their wrath. In the Hindu religion, for\r\nexample, people often sing religious hymns for protection from the evil spirits of the eclipse, and many people of the Hindu religion refuse\r\nto eat during an eclipse to avoid the effects of the evil spirits. Hindu people living in India will also wash off in the Ganges River, which is\r\nbelieved to be spiritually cleansing, directly following an eclipse to clean themselves of the evil spirits. In early Judaism and Christianity,\r\neclipses were viewed as signs from God, and some eclipses were seen as a display of God's greatness or even signs of cycles of life and\r\ndeath. However, more ominous eclipses such as a blood moon were believed to be a divine sign that God would soon destroy their\r\nenemies";
    void FixedUpdate()
    {

        time += Time.deltaTime;

        if(time > 0.7f && once)
        {
            StartTitle();
            once = false;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
    }


    public void StartTitle()
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence2(titleString));
    }
    public void StartContent()
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(contentString));
    }



    IEnumerator TypeSentence(string sentence)
    {
        content.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            content.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(2);
    }

    IEnumerator TypeSentence2(string sentence)
    {
        title.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            title.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        StartContent();
    }
}
