using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{

    public bool is_Main_Menu;
    public bool pause_Menu_Is_Active;
    public bool options_Menu_Is_Active;
    public Player_Location_Tracking local_Player_Location_Tracking;
    public ProgressManager local_ProgressManager;
    public GameObject pause_Menu;
    public GameObject options_Menu;
    public ThirdPerson3D player_Controls;
    public CameraFollowOrbit local_Camera_Orbit;
    public float input_Cooldown = .35f;
    public float up_Threshold = .2f;
    bool can_Take_Input = true;
    public bool is_Game_Fullscreen;
    public AudioSource menu_SFX;

    public Image main_Menu_Resume;
    public Image main_Menu_New_Game;
    public Image main_Menu_Options;
    public Image main_Menu_Quit;
    public Image main_Menu_Languages;

    public Image pause_Menu_Resume;
    public Image pause_Menu_Options;
    public Image pause_Menu_Quit;

    public Image options_Resolution;
    public Image options_Windowed;
    public Image options_Master;
    public Image options_SFX;
    public Image options_Music;
    public Image options_Back;

    public Button image_Resume_Button_Parent;

    public Slider master_Vol_Slider;
    public Slider sfx_Vol_Slider;
    public Slider music_Vol_Slider;

    public Text resolution;

    public Dropdown languages_Dropdown;
    public Scene_Management local_Scene_Management;

    public Texture2D cursor_Texture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public AudioMixer audio_Mixer;
    public Image toggle_Checkmark;
    public Fade_To_Black local_Fade_To_Black;

    Vector2 input;

    public Text resume_Text;
    public Text new_game_Text;
    public Text options_Text;
    public Text languages_Text;
    public Text quit_Text;
    public Text pause_Quit;
    public Text Resolution_Button_Text;
    public Text Windowed_Text;
    public Text Master_Text;
    public Text SFX_Text;
    public Text Music_Text;
    public Text Back_Text;

    bool languages_Active = false;

    private LocalisationManager locMan;

    public enum Resolution
    {
        _1024x768,
        _1280x720,
        _1280x768,
        _1366x768,
        _1600x900,
        _1920x1080,

    }

    public Resolution local_Resolution = Resolution._1920x1080;

    public enum Selected_Button_Main_Menu
    {
        RESUME,
        NEW_GAME,
        OPTIONS,
        LANGUAGES,
        QUIT
    }

    public Selected_Button_Main_Menu local_Selected_Button_Main_Menu;

    public enum Selected_Button_Pause_Menu
    {
        RESUME,
        OPTIONS,
        QUIT,

    }

    public Selected_Button_Pause_Menu local_Selected_Button_Pause_Menu;

    public enum Options_Buttons
    {
        RESOLUTION,
        WINDOWED,
        MASTER,
        SFX,
        MUSIC,
        BACK
    }

    public Options_Buttons local_Options_Buttons;

    public void Languages_Button()
    {
        if (is_Main_Menu && !options_Menu_Is_Active && local_Selected_Button_Main_Menu == Selected_Button_Main_Menu.LANGUAGES)
        {
            if (!languages_Active)
            {
                languages_Active = true;
                languages_Dropdown.Show();
            }
            else
            {
                languages_Active = false;
                languages_Dropdown.GetComponent<Dropdown>().Hide();
            }
        }

    }

    public void Options_Button()
    {
        options_Menu.SetActive(true);
        options_Menu_Is_Active = true;
        locMan.Set_Language();
        if (is_Main_Menu)
        {
            languages_Dropdown.GetComponent<Dropdown>().Hide();
        }

    }

    public void Continue_Game()
    {

        local_Fade_To_Black.Fade_Out();
        can_Take_Input = false;
        Time.timeScale = 1;
        StartCoroutine("Wait_Continue");
    }

    public void Back()
    {
        options_Menu.SetActive(false);
        options_Menu_Is_Active = false;
    }

    /// <summary>
    /// Hides the cursor and loads the relevant saved level of the player
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait_Continue()
    {
        yield return new WaitForSeconds(1.5f);

        Cursor.visible = false;

        switch (local_Player_Location_Tracking.local_Current_Level)
        {
            case Player_Location_Tracking.Current_Level.CABIN:
                local_Scene_Management.Load_Scene("CabinInterior");
                break;

            case Player_Location_Tracking.Current_Level.FINAL_TEMPLE:
                local_Scene_Management.Load_Scene("FinalTemple");
                break;

            case Player_Location_Tracking.Current_Level.HUB:
                local_Scene_Management.Load_Scene("Hub Scene");
                break;

            case Player_Location_Tracking.Current_Level.ICE_AREA:
                local_Scene_Management.Load_Scene("Ice Area Scene");
                break;

            case Player_Location_Tracking.Current_Level.ICE_TEMPLE:
                local_Scene_Management.Load_Scene("Temple_IceArea");
                break;

            case Player_Location_Tracking.Current_Level.MOUNTAIN_AREA:
                local_Scene_Management.Load_Scene("Mountain Area Scene");
                break;

            case Player_Location_Tracking.Current_Level.TRAP_AREA:
                local_Scene_Management.Load_Scene("Trap Area Scene");
                break;

            case Player_Location_Tracking.Current_Level.TRAP_TEMPLE:
                local_Scene_Management.Load_Scene("Temple_Trap Area");
                break;

            case Player_Location_Tracking.Current_Level.TUTORIAL_TEMPLE:
                local_Scene_Management.Load_Scene("Temple1Interior");
                break;

            case Player_Location_Tracking.Current_Level.WIND_TEMPLE:
                local_Scene_Management.Load_Scene("Temple_MountainArea");
                break;

        }
        StopAllCoroutines();
    }

    public void Toggle_Pause()
    {
        if (!pause_Menu_Is_Active)
        {
            Time.timeScale = 0;
            pause_Menu.SetActive(true);
            pause_Menu_Is_Active = true;
            player_Controls.player_Is_In_Control = false;
            local_Camera_Orbit.enabled = false;
            Cursor.visible = true;
        }

        else
        {
            Time.timeScale = 1;
            pause_Menu.SetActive(false);
            pause_Menu_Is_Active = false;
            player_Controls.player_Is_In_Control = true;
            local_Camera_Orbit.enabled = true;
            Cursor.visible = false;
        }
    }

    public void New_Game()
    {
        local_Fade_To_Black.Fade_Out();
        can_Take_Input = false;
        Time.timeScale = 1;
        local_ProgressManager = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
        local_Player_Location_Tracking.Reset_Data();
        local_ProgressManager.ClearProgressData();
        PlayerPrefs.SetInt("Progress_Started", 1);
        PlayerPrefs.Save();
        StartCoroutine("Wait_New_Game");
    }

    IEnumerator Wait_New_Game()
    {
        yield return new WaitForSeconds(1.5f);



        local_Scene_Management.Load_Scene("Story Book Scene");

        Cursor.visible = false;
        StopAllCoroutines();
    }

    public void Quit_To_Windows()
    {
        local_Fade_To_Black.Fade_Out();
        can_Take_Input = false;
        Time.timeScale = 1;
        StartCoroutine("Wait_Quit_To_Windows");

    }

    IEnumerator Wait_Quit_To_Windows()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();

    }

    public void Quit_To_Menu()
    {
        local_Fade_To_Black.Fade_Out();
        can_Take_Input = false;
        Time.timeScale = 1;
        StartCoroutine("Wait_Quit_To_Menu");

    }

    IEnumerator Wait_Quit_To_Menu()
    {
        yield return new WaitForSeconds(1.5f);

        pause_Menu.SetActive(false);
        pause_Menu_Is_Active = false;
        player_Controls.player_Is_In_Control = true;
        local_Scene_Management.Load_Scene("Main_Menu");
    }

    public void Initilaise_Sound_Sliders()
    {
        if (PlayerPrefs.HasKey("Master_Vol"))
        {
            master_Vol_Slider.value = PlayerPrefs.GetInt("Master_Vol");
        }

        if (PlayerPrefs.HasKey("SFX_Vol"))
        {
            sfx_Vol_Slider.value = PlayerPrefs.GetInt("SFX_Vol");
        }

        if (PlayerPrefs.HasKey("Music_Vol"))
        {
            music_Vol_Slider.value = PlayerPrefs.GetInt("Music_Vol");
        }

        int mast_temp = (int)master_Vol_Slider.value / 5;
        mast_temp -= 10;

        int sfx_temp = (int)sfx_Vol_Slider.value / 5;
        sfx_temp -= 10;

        int music_temp = (int)music_Vol_Slider.value / 5;
        music_temp -= 10;
        audio_Mixer.SetFloat("Master", mast_temp);
        audio_Mixer.SetFloat("Sfx", sfx_temp);
        audio_Mixer.SetFloat("Music", music_temp);
    }

    /// <summary>
    /// Intialises whether the fullscreen toggle should change to fullscreen or windowed mode on its first click
    /// </summary>
    public void Initialise_Toggle()
    {
        Screen.fullScreen = false;

        if (PlayerPrefs.GetInt("Windowed_Mode") == 1)
        {
            toggle_Checkmark.enabled = false;
            is_Game_Fullscreen = false;
            Screen.fullScreen = false;
            Change_Resolution();
            PlayerPrefs.SetInt("Windowed_Mode", 1);
            PlayerPrefs.Save();
        }
        else
        {
            //   toggle_Checkmark.enabled = true;
            // is_Game_Fullscreen = true;
            // Screen.fullScreen = true;
            Change_Resolution();
            PlayerPrefs.SetInt("Windowed_Mode", 0);
            PlayerPrefs.Save();
        }


    }


    public void Continue_Game_Button()
    {
        if (is_Main_Menu && !options_Menu_Is_Active)
        {
            Continue_Game();
        }

        else
        {
            Toggle_Pause();
        }
    }

    public void New_Game_Button()
    {
        if (is_Main_Menu && !options_Menu_Is_Active)
        {
            New_Game();
        }
    }

    public void Quit_Button()
    {
        if (is_Main_Menu && !options_Menu_Is_Active)
        {
            Quit_To_Windows();
        }
        else
        {
            Quit_To_Menu();
        }
    }

    /// <summary>
    /// Toggles the application between fullscreen and windowed mode
    /// </summary>
    public void Fullscreen_Button()
    {

        if (is_Game_Fullscreen)
        {
            toggle_Checkmark.enabled = false;
            is_Game_Fullscreen = false;
            Screen.fullScreen = false;
            Change_Resolution();
            PlayerPrefs.SetInt("Windowed_Mode", 1);
            PlayerPrefs.Save();
        }

        else
        {
            toggle_Checkmark.enabled = true;
            is_Game_Fullscreen = true;
            Screen.fullScreen = true;
            Change_Resolution();
            PlayerPrefs.SetInt("Windowed_Mode", 0);
            PlayerPrefs.Save();
        }
        PlayerPrefs.Save();

    }



    public void Resolution_Button()
    {
        local_Resolution++;
        if ((int)local_Resolution > 5)
        {
            local_Resolution = 0;
        }
        Change_Resolution();
    }


    /// <summary>
    /// Checks for input at a reduced rate to improve performance
    /// </summary>
    /// <returns></returns>
    public IEnumerator Receive_Input()
    {
        while (true)
        {

            if (local_Selected_Button_Main_Menu != Selected_Button_Main_Menu.LANGUAGES && is_Main_Menu)
            {
                languages_Dropdown.interactable = false;
            }

            else
            {
                if (is_Main_Menu)
                {
                    languages_Dropdown.interactable = true;
                }

            }


            if ((!is_Main_Menu && !pause_Menu_Is_Active))
            {
                Cursor.visible = false;
            }





            if (can_Take_Input)
            {
                input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


                if ((input.y > up_Threshold || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !languages_Active)
                {
                    input = new Vector2(0, 0);
                    if (options_Menu_Is_Active)
                    {
                        switch (local_Options_Buttons)
                        {
                            case Options_Buttons.RESOLUTION:
                                local_Options_Buttons = Options_Buttons.BACK;
                                break;


                            case Options_Buttons.WINDOWED:
                                local_Options_Buttons = Options_Buttons.RESOLUTION;
                                break;

                            case Options_Buttons.MASTER:
                                local_Options_Buttons = Options_Buttons.WINDOWED;
                                break;

                            case Options_Buttons.SFX:
                                local_Options_Buttons = Options_Buttons.MASTER;
                                break;

                            case Options_Buttons.MUSIC:
                                local_Options_Buttons = Options_Buttons.SFX;
                                break;

                            case Options_Buttons.BACK:
                                local_Options_Buttons = Options_Buttons.MUSIC;
                                break;
                        }
                    }

                    else
                    {
                        if (is_Main_Menu)
                        {
                            switch (local_Selected_Button_Main_Menu)
                            {
                                case Selected_Button_Main_Menu.RESUME:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.QUIT;
                                    break;

                                case Selected_Button_Main_Menu.NEW_GAME:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.RESUME;
                                    break;

                                case Selected_Button_Main_Menu.OPTIONS:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.NEW_GAME;
                                    break;

                                case Selected_Button_Main_Menu.LANGUAGES:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.OPTIONS;
                                    break;

                                case Selected_Button_Main_Menu.QUIT:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.LANGUAGES;
                                    break;
                            }
                        }

                        else
                        {
                            switch (local_Selected_Button_Pause_Menu)
                            {
                                case Selected_Button_Pause_Menu.RESUME:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.QUIT;
                                    break;

                                case Selected_Button_Pause_Menu.OPTIONS:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.RESUME;
                                    break;

                                case Selected_Button_Pause_Menu.QUIT:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.OPTIONS;
                                    break;
                            }
                        }
                    }

                    if (is_Main_Menu || pause_Menu_Is_Active)
                    {
                        StartCoroutine("Cooldown_Input");
                        Set_Button_Highlights();
                    }



                }

                if ((input.y < -up_Threshold || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !languages_Active)
                {

                    if (options_Menu_Is_Active)
                    {
                        switch (local_Options_Buttons)
                        {
                            case Options_Buttons.RESOLUTION:
                                local_Options_Buttons = Options_Buttons.WINDOWED;
                                break;


                            case Options_Buttons.WINDOWED:
                                local_Options_Buttons = Options_Buttons.MASTER;
                                break;

                            case Options_Buttons.MASTER:
                                local_Options_Buttons = Options_Buttons.SFX;
                                break;

                            case Options_Buttons.SFX:
                                local_Options_Buttons = Options_Buttons.MUSIC;
                                break;

                            case Options_Buttons.MUSIC:
                                local_Options_Buttons = Options_Buttons.BACK;
                                break;

                            case Options_Buttons.BACK:
                                local_Options_Buttons = Options_Buttons.RESOLUTION;
                                break;
                        }
                    }

                    else
                    {
                        if (is_Main_Menu)
                        {
                            switch (local_Selected_Button_Main_Menu)
                            {
                                case Selected_Button_Main_Menu.RESUME:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.NEW_GAME;
                                    break;

                                case Selected_Button_Main_Menu.NEW_GAME:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.OPTIONS;
                                    break;

                                case Selected_Button_Main_Menu.OPTIONS:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.LANGUAGES;
                                    break;

                                case Selected_Button_Main_Menu.LANGUAGES:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.QUIT;
                                    break;

                                case Selected_Button_Main_Menu.QUIT:
                                    local_Selected_Button_Main_Menu = Selected_Button_Main_Menu.RESUME;
                                    break;
                            }
                        }

                        else
                        {
                            switch (local_Selected_Button_Pause_Menu)
                            {
                                case Selected_Button_Pause_Menu.RESUME:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.OPTIONS;
                                    break;

                                case Selected_Button_Pause_Menu.OPTIONS:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.QUIT;
                                    break;

                                case Selected_Button_Pause_Menu.QUIT:
                                    local_Selected_Button_Pause_Menu = Selected_Button_Pause_Menu.RESUME;
                                    break;
                            }
                        }
                    }


                    if (is_Main_Menu || pause_Menu_Is_Active)
                    {
                        StartCoroutine("Cooldown_Input");
                        Set_Button_Highlights();
                    }


                }







            }

            if (input.x < -up_Threshold && options_Menu_Is_Active)
            {
                switch (local_Options_Buttons)
                {
                    case Options_Buttons.MASTER:
                        master_Vol_Slider.value = master_Vol_Slider.value - 1;
                        break;

                    case Options_Buttons.SFX:
                        sfx_Vol_Slider.value = sfx_Vol_Slider.value - 1;
                        break;

                    case Options_Buttons.MUSIC:
                        music_Vol_Slider.value = music_Vol_Slider.value - 1;
                        break;

                    default:
                        break;
                }
            }

            if (input.x > up_Threshold && options_Menu_Is_Active)
            {
                switch (local_Options_Buttons)
                {
                    case Options_Buttons.MASTER:
                        master_Vol_Slider.value = master_Vol_Slider.value + 1;
                        break;

                    case Options_Buttons.SFX:
                        sfx_Vol_Slider.value = sfx_Vol_Slider.value + 1;
                        break;

                    case Options_Buttons.MUSIC:
                        music_Vol_Slider.value = music_Vol_Slider.value + 1;
                        break;

                    default:
                        break;
                }
            }

            if (options_Menu_Is_Active)
            {
                PlayerPrefs.SetInt("Master_Vol", (int)master_Vol_Slider.value);
                PlayerPrefs.SetInt("SFX_Vol", (int)sfx_Vol_Slider.value);
                PlayerPrefs.SetInt("Music_Vol", (int)music_Vol_Slider.value);
                PlayerPrefs.Save();
                int mast_temp = (int)master_Vol_Slider.value / 5;
                mast_temp -= 10;

                int sfx_temp = (int)sfx_Vol_Slider.value / 5;
                sfx_temp -= 10;

                int music_temp = (int)music_Vol_Slider.value / 5;
                music_temp -= 10;
                audio_Mixer.SetFloat("Master", mast_temp);
                audio_Mixer.SetFloat("Sfx", sfx_temp);
                audio_Mixer.SetFloat("Music", music_temp);

                //set audio levels here
            }

            if (Input.GetButtonDown("Back"))
            {
                languages_Active = false;

                if (pause_Menu_Is_Active || is_Main_Menu)
                {
                    menu_SFX.Play();
                }

                if (options_Menu_Is_Active)
                {
                    options_Menu.SetActive(false);
                    options_Menu_Is_Active = false;
                }

                else
                {
                    if (is_Main_Menu)
                    {

                    }

                    else
                    {
                        if (pause_Menu_Is_Active)
                        {
                            Toggle_Pause();
                        }

                    }
                }

                if (is_Main_Menu || pause_Menu_Is_Active)
                {
                    StartCoroutine("Cooldown_Input");
                    Set_Button_Highlights();
                }


            }

            if (Input.GetButtonDown("Accept") || Input.GetKeyDown(KeyCode.Return))
            {
                if (pause_Menu_Is_Active || is_Main_Menu)
                {
                    menu_SFX.Play();
                }



                if (options_Menu_Is_Active)
                {
                    switch (local_Options_Buttons)
                    {
                        case Options_Buttons.RESOLUTION:
                            //change resolution
                            local_Resolution++;
                            if ((int)local_Resolution > 5)
                            {
                                local_Resolution = 0;
                            }
                            Change_Resolution();
                            break;


                        case Options_Buttons.WINDOWED:
                            //change windowed mode on or off
                            Fullscreen_Button();




                            break;

                        case Options_Buttons.BACK:
                            options_Menu.SetActive(false);
                            options_Menu_Is_Active = false;
                            break;



                    }
                }

                else
                {
                    if (is_Main_Menu && !options_Menu_Is_Active)
                    {
                        switch (local_Selected_Button_Main_Menu)
                        {
                            case Selected_Button_Main_Menu.RESUME:
                                if (PlayerPrefs.GetInt("Progress_Started") == 1)
                                {
                                    Continue_Game();
                                }

                                break;

                            case Selected_Button_Main_Menu.NEW_GAME:
                                New_Game();
                                break;

                            case Selected_Button_Main_Menu.OPTIONS:
                                options_Menu.SetActive(true);
                                options_Menu_Is_Active = true;
                                locMan.Set_Language();
                                break;

                            case Selected_Button_Main_Menu.LANGUAGES:

                                if (!options_Menu_Is_Active)
                                {
                                    Languages_Button();
                                }

                                break;

                            case Selected_Button_Main_Menu.QUIT:
                                Quit_To_Windows();
                                break;
                        }
                    }

                    else
                    {
                        if (pause_Menu_Is_Active)
                        {
                            switch (local_Selected_Button_Pause_Menu)
                            {
                                case Selected_Button_Pause_Menu.RESUME:
                                    Toggle_Pause();
                                    break;

                                case Selected_Button_Pause_Menu.OPTIONS:
                                    options_Menu.SetActive(true);
                                    options_Menu_Is_Active = true;
                                    break;

                                case Selected_Button_Pause_Menu.QUIT:
                                    Quit_To_Menu();
                                    break;
                            }
                        }

                    }
                }

                if (is_Main_Menu || pause_Menu_Is_Active)
                {
                    StartCoroutine("Cooldown_Input");
                    Set_Button_Highlights();
                }


            }

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Backspace))
            {
                languages_Active = false;

                if (pause_Menu_Is_Active || is_Main_Menu)
                {
                    menu_SFX.Play();
                }
                input = new Vector2(0, 0);
                if (!is_Main_Menu)
                {
                    options_Menu.SetActive(false);
                    options_Menu_Is_Active = false;
                    Toggle_Pause();
                }

                else
                {
                    if (options_Menu.activeSelf == true)
                    {
                        options_Menu.SetActive(false);
                        options_Menu_Is_Active = false;
                    }

                }
                if (is_Main_Menu || pause_Menu_Is_Active)
                {
                    StartCoroutine("Cooldown_Input");
                    Set_Button_Highlights();
                }


            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                languages_Active = false;
            }


            yield return new WaitForSecondsRealtime(.002f);
        }

    }


    private void Awake()
    {
        toggle_Checkmark.enabled = false;
        is_Game_Fullscreen = false;
        Screen.fullScreen = false;
        Change_Resolution();
        PlayerPrefs.SetInt("Windowed_Mode", 1);
        PlayerPrefs.Save();

        PlayerPrefs.Save();
    }
    private void Start()
    {
        local_Scene_Management = GameObject.FindGameObjectWithTag("Scene_Manager").GetComponent<Scene_Management>();
        StartCoroutine("Receive_Input");

        Initilaise_Sound_Sliders();
        Cursor.SetCursor(cursor_Texture, hotSpot, cursorMode);
        Cursor.lockState = CursorLockMode.None;
        locMan = GameObject.Find("Local Scene Manager").GetComponent<LocalisationManager>();
        Screen.fullScreen = false;
        is_Game_Fullscreen = false;
        toggle_Checkmark.enabled = false;
        //Set_Language();

        if (!is_Main_Menu)
        {
            Cursor.visible = false;
        }

        else
        {
            Cursor.visible = true;
            if (PlayerPrefs.GetInt("Progress_Started") == 0)
            {
                image_Resume_Button_Parent.interactable = false;
            }
        }




        StartCoroutine("wait_Toggle");

        Initialise_Resolution_Selected();


        if (is_Main_Menu)
        {
            Set_Button_Highlights();
        }

    }

    IEnumerator wait_Toggle()
    {
        yield return new WaitForSeconds(0.5f);
        Initialise_Toggle();
    }

    public IEnumerator Cooldown_Input()
    {
        can_Take_Input = false;
        yield return new WaitForSecondsRealtime(input_Cooldown);
        can_Take_Input = true;
    }

    /// <summary>
    /// Set which buttons are highlighted in the main menu
    /// </summary>
    public void Set_Button_Highlights()
    {
        if (pause_Menu_Is_Active || is_Main_Menu)
        {
            menu_SFX.Play();
        }

        //set the symbols beside the active button
        if (is_Main_Menu)
        {
            if (options_Menu_Is_Active)
            {
                switch (local_Options_Buttons)
                {
                    case Options_Buttons.RESOLUTION:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = true;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.WINDOWED:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = false;
                        options_Windowed.enabled = true;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.MASTER:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = true;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.SFX:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = true;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.MUSIC:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = true;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.BACK:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = true;
                        break;
                }

            }
            else
            {

                switch (local_Selected_Button_Main_Menu)
                {
                    case Selected_Button_Main_Menu.RESUME:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = true;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = false;
                        main_Menu_Languages.enabled = false;
                        break;

                    case Selected_Button_Main_Menu.NEW_GAME:
                        main_Menu_New_Game.enabled = true;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = false;
                        main_Menu_Languages.enabled = false;
                        break;

                    case Selected_Button_Main_Menu.OPTIONS:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = true;
                        main_Menu_Quit.enabled = false;
                        main_Menu_Languages.enabled = false;
                        break;

                    case Selected_Button_Main_Menu.LANGUAGES:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = false;
                        main_Menu_Languages.enabled = true;
                        break;

                    case Selected_Button_Main_Menu.QUIT:
                        main_Menu_New_Game.enabled = false;
                        main_Menu_Resume.enabled = false;
                        main_Menu_Options.enabled = false;
                        main_Menu_Quit.enabled = true;
                        main_Menu_Languages.enabled = false;
                        break;
                }
            }
        }

        else
        {

            if (options_Menu_Is_Active)
            {
                switch (local_Options_Buttons)
                {
                    case Options_Buttons.RESOLUTION:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = true;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.WINDOWED:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = true;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.MASTER:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = true;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.SFX:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = true;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.MUSIC:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = true;
                        options_SFX.enabled = false;
                        options_Back.enabled = false;
                        break;

                    case Options_Buttons.BACK:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        options_Windowed.enabled = false;
                        options_Resolution.enabled = false;
                        options_Master.enabled = false;
                        options_Music.enabled = false;
                        options_SFX.enabled = false;
                        options_Back.enabled = true;
                        break;
                }
            }
            else
            {
                switch (local_Selected_Button_Pause_Menu)
                {
                    case Selected_Button_Pause_Menu.RESUME:
                        pause_Menu_Resume.enabled = true;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = false;
                        break;

                    case Selected_Button_Pause_Menu.OPTIONS:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = true;
                        pause_Menu_Quit.enabled = false;
                        break;

                    case Selected_Button_Pause_Menu.QUIT:
                        pause_Menu_Resume.enabled = false;
                        pause_Menu_Options.enabled = false;
                        pause_Menu_Quit.enabled = true;
                        break;
                }
            }
        }

    }



    /// <summary>
    /// Updates the resolution to new value
    /// </summary>
    public void Change_Resolution()
    {
        switch ((int)local_Resolution)
        {


            case 0:
                Screen.SetResolution(1024, 768, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 0);
                resolution.text = "1024 x 768";
                break;

            case 1:
                Screen.SetResolution(1280, 720, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 1);
                resolution.text = "1280 x 720";
                break;

            case 2:
                Screen.SetResolution(1280, 768, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 2);
                resolution.text = "1280 x 768";
                break;

            case 3:
                Screen.SetResolution(1366, 768, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 3);
                resolution.text = "1366 x 768";
                break;

            case 4:
                Screen.SetResolution(1600, 900, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 4);
                resolution.text = "1600 x 900";
                break;

            case 5:
                Screen.SetResolution(1920, 1080, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 5);
                resolution.text = "1920 x 1080";
                break;

            default:
                Screen.SetResolution(1920, 1080, is_Game_Fullscreen);
                PlayerPrefs.SetInt("Resolution", 5);
                resolution.text = "1920 x 1080";
                break;


        }


        PlayerPrefs.Save();

    }

    /// <summary>
    /// Sets the application resolution to the currently saved resolution
    /// </summary>
    void Initialise_Resolution_Selected()
    {
        if (PlayerPrefs.HasKey("Resolution"))
        {
            switch (PlayerPrefs.GetInt("Resolution"))
            {

                case 0:
                    local_Resolution = (Resolution)0;
                    Screen.SetResolution(1024, 768, is_Game_Fullscreen);
                    resolution.text = "1024 x 768";
                    break;

                case 1:
                    local_Resolution = (Resolution)1; ;
                    Screen.SetResolution(1280, 720, is_Game_Fullscreen);
                    resolution.text = "1280 x 720";
                    break;

                case 2:
                    local_Resolution = (Resolution)2; ;
                    Screen.SetResolution(1280, 768, is_Game_Fullscreen);
                    resolution.text = "1280 x 768";
                    break;

                case 3:
                    local_Resolution = (Resolution)3; ;
                    Screen.SetResolution(1366, 768, is_Game_Fullscreen);
                    resolution.text = "1366 x 768";
                    break;

                case 4:
                    local_Resolution = (Resolution)4; ;
                    Screen.SetResolution(1600, 900, is_Game_Fullscreen);
                    resolution.text = "1600 x 900";
                    break;

                case 5:
                    local_Resolution = (Resolution)5; ;
                    Screen.SetResolution(1920, 1080, is_Game_Fullscreen);
                    resolution.text = "1920 x 1080";
                    break;
            }
        }

        else
        {
            local_Resolution = Resolution._1920x1080;
            resolution.text = "1920 x 1080";
            Screen.SetResolution(1920, 1080, true);
        }



        PlayerPrefs.Save();

    }


    public void Set_Language()
    {
        string fileName;



        switch (languages_Dropdown.value)
        {
            case 0:
                //English
                fileName = "SolasLocalisation_EN.json";
                local_Scene_Management.GetComponent<LocalisationManager>().LoadLocalisedText(fileName);
                break;

            case 1:
                //French
                fileName = "SolasLocalisation_FR.json";
                local_Scene_Management.GetComponent<LocalisationManager>().LoadLocalisedText(fileName);
                break;

            case 2:
                //Dutch
                break;

            case 3:
                //Espanyol
                break;

            case 4:
                //chinese simple
                break;

            case 5:
                //chinese trad
                break;

            case 6:
                //japanese
                break;

            case 7:
                //russian
                fileName = "SolasLocalisation_RU.json";
                local_Scene_Management.GetComponent<LocalisationManager>().LoadLocalisedText(fileName);
                break;

            case 8:
                //portuguese-brazil
                break;

            case 9:
                //korean
                break;

            case 10:
                //swedish
                break;

            case 11:
                //Ukraine
                break;

            case 12:
                //Polish
                break;

            case 13:
                //Italian
                break;

            case 14:
                //Greek
                break;

            case 15:
                //Hungarian
                break;

            case 16:
                //Thai
                break;

            case 17:
                //Turkey
                break;

            case 18:
                //Romanian
                break;

            case 19:
                //Portugeuse
                break;

            case 20:
                //Norwayish
                break;

            case 21:
                //Finnish
                break;

            case 22:
                //netherlands
                break;

            case 23:
                //czech
                break;

            case 24:
                //bulgarian
                break;

            case 25:
                //arabic
                break;

            case 26:
                //danish
                break;

            default:
                //english
                fileName = "SolasLocalisation_EN.json";
                local_Scene_Management.GetComponent<LocalisationManager>().LoadLocalisedText(fileName);

                break;

        }


    }

}
