using UnityEngine.SceneManagement;

public class FlagTracker : Singleton<FlagTracker>
{
    public int CurrentSequence => SceneManager.GetActiveScene().buildIndex - 1; // Skip menu
    public bool HasBurger;
    public bool BurgerCooking;
    public bool BurgerCooked;
    public bool StartedSleeping;
    public bool OpenedDoorForKryst;
    // Has the finale dialogue finished
    public bool BirdsAndTheBees;
    public bool Falling;

    public int HomeworkLeft = 5;

    public void Reset()
    {
        HasBurger = false;
        BurgerCooking = false;
        BurgerCooked = false;
        StartedSleeping = false;
        OpenedDoorForKryst = false;
        BirdsAndTheBees = false;
        Falling = false;

        HomeworkLeft = 5;
    }
}