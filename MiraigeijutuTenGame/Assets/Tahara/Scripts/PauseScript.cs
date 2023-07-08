using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�J���҃{�^���������ꂽ���̏���������R���|�[�l���g/// </summary>
public class PauseScript : MonoBehaviour
{
    //�@�J���ҕ\����ʂ��J���{�^��
    [SerializeField] private GameObject _staffButton;
    //�@�Q�[���ɖ߂�{�^��
    [SerializeField] private GameObject _restartButton;
    //�@�J���҂�\������p�l��
    [SerializeField] private GameObject _Panel;

    /// <summary>�p�l����ON�̎�/// </summary>
    public void StopGame()
    {
        Time.timeScale = 0f;
        _staffButton.SetActive(false);
        _restartButton.SetActive(true);
        _Panel.SetActive(true);
    }
    /// <summary>�p�l����OFF�̎�/// </summary>
    public void ReStartGame()
    {
        _staffButton.SetActive(true);
        _restartButton.SetActive(false);
        _Panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
