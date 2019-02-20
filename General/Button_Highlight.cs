using UnityEngine;

public class Button_Highlight : MonoBehaviour
{

    public enum Button
    {
        RESUME,
        NEW_GAME,
        OPTIONS,
        QUIT,
        FULLSCREEN,
        RESOLUTION,
        MASTER,
        SFX,
        MUSIC,
        BACK,
        LANGUAGES

    }
    public Button local_Button_Type;
    public Menu_Manager local_Menu_Manager;

    /// <summary>
    /// Updates relevant scripts when certain buttons are highlighted
    /// </summary>
    public void Set_Highlight()
    {
        switch (local_Button_Type)
        {
            case Button.RESUME:
                local_Menu_Manager.local_Selected_Button_Main_Menu = Menu_Manager.Selected_Button_Main_Menu.RESUME;
                local_Menu_Manager.local_Selected_Button_Pause_Menu = Menu_Manager.Selected_Button_Pause_Menu.RESUME;
                break;

            case Button.NEW_GAME:
                local_Menu_Manager.local_Selected_Button_Main_Menu = Menu_Manager.Selected_Button_Main_Menu.NEW_GAME;
                break;

            case Button.OPTIONS:
                local_Menu_Manager.local_Selected_Button_Main_Menu = Menu_Manager.Selected_Button_Main_Menu.OPTIONS;
                local_Menu_Manager.local_Selected_Button_Pause_Menu = Menu_Manager.Selected_Button_Pause_Menu.OPTIONS;
                break;

            case Button.QUIT:
                local_Menu_Manager.local_Selected_Button_Main_Menu = Menu_Manager.Selected_Button_Main_Menu.QUIT;
                local_Menu_Manager.local_Selected_Button_Pause_Menu = Menu_Manager.Selected_Button_Pause_Menu.QUIT;
                break;

            case Button.FULLSCREEN:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.WINDOWED;
                break;

            case Button.RESOLUTION:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.RESOLUTION;
                break;

            case Button.MASTER:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.MASTER;
                break;

            case Button.SFX:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.SFX;
                break;

            case Button.MUSIC:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.MUSIC;
                break;

            case Button.BACK:
                local_Menu_Manager.local_Options_Buttons = Menu_Manager.Options_Buttons.BACK;
                break;

            case Button.LANGUAGES:
                local_Menu_Manager.local_Selected_Button_Main_Menu = Menu_Manager.Selected_Button_Main_Menu.LANGUAGES;
                break;
        }

        local_Menu_Manager.Set_Button_Highlights();

    }
}
