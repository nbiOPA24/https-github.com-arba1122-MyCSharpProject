using System;
using System.Media;

public class SoundManager
{
    public void PlaySound(string soundFileName)
    {
        try
        {
            using (SoundPlayer player = new SoundPlayer(soundFileName))
            {
                player.Load();
                player.PlaySync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Fel vid uppspelning av ljud: " + e.Message);
        }
    }
}
