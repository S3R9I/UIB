﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class AuthenticationManager : MonoBehaviour {
    public GameObject mainMenu;

    public GameObject fieldEmailAddress;
    public GameObject fieldPassword;
    public GameObject fieldReenterPassword;

    public Text textEmail;
    public Text textPassword;
    public Text ReenterPassword;

    public bool ShowRegister = false;
    public Text RegisterText;

    public Text Login_Feedback;

    WWWForm form;
	// Use this for initialization
	void Start () {
        Login_Feedback.text = "";

    }

    public void LoginButtonTapped()
    {
        Login_Feedback.text = "Logging in...";
        StartCoroutine("RequestLogin");
    }
    public IEnumerator RequestLogin()
    {
        string email = textEmail.text;
        string password = textPassword.GetComponentInParent<InputField>().text;
        form = new WWWForm();
        form.AddField("usernamePost", email);
        form.AddField("passwordPost", password);

        WWW w = new WWW("http://81.169.177.181/UIB/action_login.php", form);

        yield return w;
        Login_Feedback.color = Color.black;
        if (string.IsNullOrEmpty(w.error))
        {

            if (w.text.ToLower().Contains("invalid email or password"))
            {
                Login_Feedback.text = "Invalid email or password";
                
            }
            else
            {
                Login_Feedback.text = "Login Successful";
                App_Manager.instance.SetUsername(email);
                SceneManager.LoadScene("Home", LoadSceneMode.Single);
            }
            }
            else
            {
                Login_Feedback.text = "An Error Occured";
            }
        }
}