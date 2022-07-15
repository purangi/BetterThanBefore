using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private Text GoldText; //텍스트 객체를 찾아서 저장할 변수
    private int MyGold; // 직접 골드가 얼마인지 나타내주는 변수
    
    // Start is called before the first frame update
    void Start()
    {
        GoldText = GameObject.Find("Gold").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = MyGold.ToString();
        
    }
}

//골드를 선택해 평민 고용을 했을 때 (평민 고용에 대한 부분이 완성되지 않아 주석처리..)
/* void CommonHire() {
 * if ( 영지분위기결정데이터 < 40 ) {
 *     MyGold -= 500;
 *     if (MyGold < 0) {
 *       MyGold += 500;
 *       //구매불가창이뜸..? } }
 *  else {
 *  MyGold -= 800;
 *    if (MyGold < 0) {
 *       MyGold += 800;
 *       //구매불가창이뜸..? } }
 */


