using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private Text GoldText; //�ؽ�Ʈ ��ü�� ã�Ƽ� ������ ����
    private int MyGold; // ���� ��尡 ������ ��Ÿ���ִ� ����
    
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

//��带 ������ ��� ����� ���� �� (��� ��뿡 ���� �κ��� �ϼ����� �ʾ� �ּ�ó��..)
/* void CommonHire() {
 * if ( ������������������� < 40 ) {
 *     MyGold -= 500;
 *     if (MyGold < 0) {
 *       MyGold += 500;
 *       //���źҰ�â�̶�..? } }
 *  else {
 *  MyGold -= 800;
 *    if (MyGold < 0) {
 *       MyGold += 800;
 *       //���źҰ�â�̶�..? } }
 */


