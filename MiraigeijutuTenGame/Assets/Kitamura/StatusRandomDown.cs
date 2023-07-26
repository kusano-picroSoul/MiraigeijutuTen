using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
/// <summary>
/// ��ɂ���L�����̃X�e�[�^�X��30�b���ƂɃ����_����5���炷�R���|�[�l���g
/// </summary>
public class StatusRandomDown : MonoBehaviour
{
    [SerializeField] int DownNum = 5;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 30)
        {
            foreach (var charctor in LevelManager.HomeCharactorList)
            {
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    charctor.Smart -= DownNum;
                }
                else if (random == 1)
                {
                    charctor.Happy -= DownNum;
                }
                else if (random == 2)
                {
                    charctor.Hungry -= DownNum;
                }
            }
            timer = 0;
        }
    }
}
