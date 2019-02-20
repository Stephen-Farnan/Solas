using Steamworks;
using UnityEngine;

// This is a port of StatsAndAchievements.cpp from SpaceWar, the official Steamworks Example.
class SteamAchievements : MonoBehaviour
{
    private enum Achievement : int
    {
        GAME_COMPLETED,
        NO_DEATHS,
        FIRST_TEMPLE,
        MOUNTAIN_TEMPLE,
        TRAP_TEMPLE,
        ICE_TEMPLE,
    };

    private Achievement_t[] m_Achievements = new Achievement_t[] {
        new Achievement_t(Achievement.GAME_COMPLETED, "The Cycle Continues", "Completed the final temple"),
        new Achievement_t(Achievement.NO_DEATHS, "Untouched", "Finished the game without dying"),
        new Achievement_t(Achievement.FIRST_TEMPLE, "The First Step", "Completed the first temple"),
        new Achievement_t(Achievement.MOUNTAIN_TEMPLE, "When The Wind Blows", "Completed the mountain temple"),
        new Achievement_t(Achievement.TRAP_TEMPLE, "Make The Sacrifice", "Completed the village temple"),
        new Achievement_t(Achievement.ICE_TEMPLE, "Tip Of The Iceberg", "Completed the ice temple"),
    };

    // Our GameID
    private CGameID m_GameID;

    // Did we get the stats from Steam?
    private bool m_bRequestedStats;
    private bool m_bStatsValid;

    // Should we store stats this frame?
    private bool m_bStoreStats;

    protected Callback<UserStatsReceived_t> m_UserStatsReceived;
    protected Callback<UserStatsStored_t> m_UserStatsStored;
    protected Callback<UserAchievementStored_t> m_UserAchievementStored;

    private ProgressManager progMan;

    void OnEnable()
    {
        if (!SteamManager.Initialized)
            return;

        // Cache the GameID for use in the Callbacks
        m_GameID = new CGameID(SteamUtils.GetAppID());

        m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
        m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
        m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);

        // These need to be reset to get the stats upon an Assembly reload in the Editor.
        m_bRequestedStats = false;
        m_bStatsValid = false;
    }

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
    }

    private void Update()
    {
        //Resetting steam achievements for testing
        /*
		if (Input.GetKeyDown(KeyCode.L))
		{
			SteamUserStats.ResetAllStats(true);
			Debug.Log("Stats and Achievements Reset");
		}*/

        if (!SteamManager.Initialized)
        {
            return;
        }

        if (!m_bRequestedStats)
        {
            // Is Steam Loaded? if no, can't get stats, done
            if (!SteamManager.Initialized)
            {
                m_bRequestedStats = true;
                return;
            }

            // If yes, request our stats
            bool bSuccess = SteamUserStats.RequestCurrentStats();

            // This function should only return false if we weren't logged in, and we already checked that.
            // But handle it being false again anyway, just ask again later.
            m_bRequestedStats = bSuccess;
        }

        if (!m_bStatsValid)
        {
            return;
        }

        // Get info from sources

        // Evaluate achievements
        foreach (Achievement_t achievement in m_Achievements)
        {
            if (achievement.m_bAchieved)
            {
                continue;
            }

            switch (achievement.m_eAchievementID)
            {
                case Achievement.GAME_COMPLETED:
                    if (progMan.noOfTemplesCompleted >= 5)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;

                case Achievement.NO_DEATHS:
                    if (progMan.noOfTemplesCompleted >= 5 && progMan.noOfDeaths == 0)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;

                case Achievement.FIRST_TEMPLE:
                    if (progMan.noOfTemplesCompleted >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;

                case Achievement.MOUNTAIN_TEMPLE:
                    if (progMan.templesCompleted[2])
                    {
                        UnlockAchievement(achievement);
                    }
                    break;

                case Achievement.TRAP_TEMPLE:
                    if (progMan.templesCompleted[1])
                    {
                        UnlockAchievement(achievement);
                    }
                    break;

                case Achievement.ICE_TEMPLE:
                    if (progMan.templesCompleted[3])
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
            }
        }

        //Store stats in the Steam database if necessary
        if (m_bStoreStats)
        {
            // already set any achievements in UnlockAchievement

            // set stats
            /*
			SteamUserStats.SetStat("NumGames", m_nTotalGamesPlayed);
			SteamUserStats.SetStat("NumWins", m_nTotalNumWins);
			SteamUserStats.SetStat("NumLosses", m_nTotalNumLosses);
			SteamUserStats.SetStat("FeetTraveled", m_flTotalFeetTraveled);
			SteamUserStats.SetStat("MaxFeetTraveled", m_flMaxFeetTraveled);
			// Update average feet / second stat
			SteamUserStats.UpdateAvgRateStat("AverageSpeed", m_flGameFeetTraveled, m_flGameDurationSeconds);
			// The averaged result is calculated for us
			SteamUserStats.GetStat("AverageSpeed", out m_flAverageSpeed);
			*/
            bool bSuccess = SteamUserStats.StoreStats();
            // If this failed, we never sent anything to the server, try
            // again later.
            m_bStoreStats = !bSuccess;
        }
    }

    //-----------------------------------------------------------------------------
    // Purpose: Game state has changed
    //-----------------------------------------------------------------------------
    /*
	public void OnGameStateChange(EClientGameState eNewState)
	{
		if (!m_bStatsValid)
			return;

		if (eNewState == EClientGameState.k_EClientGameActive)
		{
			// Reset per-game stats
			m_flGameFeetTraveled = 0;
			m_ulTickCountGameStart = Time.time;
		}
		else if (eNewState == EClientGameState.k_EClientGameWinner || eNewState == EClientGameState.k_EClientGameLoser)
		{
			if (eNewState == EClientGameState.k_EClientGameWinner)
			{
				m_nTotalNumWins++;
			}
			else
			{
				m_nTotalNumLosses++;
			}

			// Tally games
			m_nTotalGamesPlayed++;

			// Accumulate distances
			m_flTotalFeetTraveled += m_flGameFeetTraveled;

			// New max?
			if (m_flGameFeetTraveled > m_flMaxFeetTraveled)
				m_flMaxFeetTraveled = m_flGameFeetTraveled;

			// Calc game duration
			m_flGameDurationSeconds = Time.time - m_ulTickCountGameStart;

			// We want to update stats the next frame.
			m_bStoreStats = true;
		}
	}*/

    //-----------------------------------------------------------------------------
    // Purpose: Unlock this achievement
    //-----------------------------------------------------------------------------
    private void UnlockAchievement(Achievement_t achievement)
    {
        achievement.m_bAchieved = true;

        // the icon may change once it's unlocked
        //achievement.m_iIconImage = 0;

        // mark it down
        SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());

        // Store stats end of frame
        m_bStoreStats = true;
    }

    //-----------------------------------------------------------------------------
    // Purpose: We have stats data from Steam. It is authoritative, so update
    //			our data with those results now.
    //-----------------------------------------------------------------------------
    private void OnUserStatsReceived(UserStatsReceived_t pCallback)
    {
        if (!SteamManager.Initialized)
            return;

        // we may get callbacks for other games' stats arriving, ignore them
        if ((ulong)m_GameID == pCallback.m_nGameID)
        {
            if (EResult.k_EResultOK == pCallback.m_eResult)
            {
                Debug.Log("Received stats and achievements from Steam\n");

                m_bStatsValid = true;

                // load achievements
                foreach (Achievement_t ach in m_Achievements)
                {
                    bool ret = SteamUserStats.GetAchievement(ach.m_eAchievementID.ToString(), out ach.m_bAchieved);
                    if (ret)
                    {
                        ach.m_strName = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "name");
                        ach.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "desc");
                    }
                    else
                    {
                        Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + ach.m_eAchievementID + "\nIs it registered in the Steam Partner site?");
                    }
                }

                // load stats
                /*
				SteamUserStats.GetStat("NumGames", out m_nTotalGamesPlayed);
				SteamUserStats.GetStat("NumWins", out m_nTotalNumWins);
				SteamUserStats.GetStat("NumLosses", out m_nTotalNumLosses);
				SteamUserStats.GetStat("FeetTraveled", out m_flTotalFeetTraveled);
				SteamUserStats.GetStat("MaxFeetTraveled", out m_flMaxFeetTraveled);
				SteamUserStats.GetStat("AverageSpeed", out m_flAverageSpeed);
				*/
            }
            else
            {
                Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
            }
        }
    }

    //-----------------------------------------------------------------------------
    // Purpose: Our stats data was stored!
    //-----------------------------------------------------------------------------
    private void OnUserStatsStored(UserStatsStored_t pCallback)
    {
        // we may get callbacks for other games' stats arriving, ignore them
        if ((ulong)m_GameID == pCallback.m_nGameID)
        {
            if (EResult.k_EResultOK == pCallback.m_eResult)
            {
                Debug.Log("StoreStats - success");
            }
            else if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
            {
                // One or more stats we set broke a constraint. They've been reverted,
                // and we should re-iterate the values now to keep in sync.
                Debug.Log("StoreStats - some failed to validate");
                // Fake up a callback here so that we re-load the values.
                UserStatsReceived_t callback = new UserStatsReceived_t();
                callback.m_eResult = EResult.k_EResultOK;
                callback.m_nGameID = (ulong)m_GameID;
                OnUserStatsReceived(callback);
            }
            else
            {
                Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
            }
        }
    }

    //-----------------------------------------------------------------------------
    // Purpose: An achievement was stored
    //-----------------------------------------------------------------------------
    private void OnAchievementStored(UserAchievementStored_t pCallback)
    {
        // We may get callbacks for other games' stats arriving, ignore them
        if ((ulong)m_GameID == pCallback.m_nGameID)
        {
            if (0 == pCallback.m_nMaxProgress)
            {
                Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
            }
            else
            {
                Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
            }
        }
    }

    //-----------------------------------------------------------------------------
    // Purpose: Display the user's stats and achievements
    //-----------------------------------------------------------------------------
    /*
	public void Render()
	{
		if (!SteamManager.Initialized)
		{
			GUILayout.Label("Steamworks not Initialized");
			return;
		}

		GUILayout.Label("m_ulTickCountGameStart: " + m_ulTickCountGameStart);
		GUILayout.Label("m_flGameDurationSeconds: " + m_flGameDurationSeconds);
		GUILayout.Label("m_flGameFeetTraveled: " + m_flGameFeetTraveled);
		GUILayout.Space(10);
		GUILayout.Label("NumGames: " + m_nTotalGamesPlayed);
		GUILayout.Label("NumWins: " + m_nTotalNumWins);
		GUILayout.Label("NumLosses: " + m_nTotalNumLosses);
		GUILayout.Label("FeetTraveled: " + m_flTotalFeetTraveled);
		GUILayout.Label("MaxFeetTraveled: " + m_flMaxFeetTraveled);
		GUILayout.Label("AverageSpeed: " + m_flAverageSpeed);

		GUILayout.BeginArea(new Rect(Screen.width - 300, 0, 300, 800));
		foreach (Achievement_t ach in m_Achievements)
		{
			GUILayout.Label(ach.m_eAchievementID.ToString());
			GUILayout.Label(ach.m_strName + " - " + ach.m_strDescription);
			GUILayout.Label("Achieved: " + ach.m_bAchieved);
			GUILayout.Space(20);
		}

		// FOR TESTING PURPOSES ONLY!
		if (GUILayout.Button("RESET STATS AND ACHIEVEMENTS"))
		{
			SteamUserStats.ResetAllStats(true);
			SteamUserStats.RequestCurrentStats();
			OnGameStateChange(EClientGameState.k_EClientGameActive);
		}
		GUILayout.EndArea();
	}*/

    private class Achievement_t
    {
        public Achievement m_eAchievementID;
        public string m_strName;
        public string m_strDescription;
        public bool m_bAchieved;

        /// <summary>
        /// Creates an Achievement. You must also mirror the data provided here in https://partner.steamgames.com/apps/achievements/yourappid
        /// </summary>
        /// <param name="achievement">The "API Name Progress Stat" used to uniquely identify the achievement.</param>
        /// <param name="name">The "Display Name" that will be shown to players in game and on the Steam Community.</param>
        /// <param name="desc">The "Description" that will be shown to players in game and on the Steam Community.</param>
        public Achievement_t(Achievement achievementID, string name, string desc)
        {
            m_eAchievementID = achievementID;
            m_strName = name;
            m_strDescription = desc;
            m_bAchieved = false;
        }
    }
}
