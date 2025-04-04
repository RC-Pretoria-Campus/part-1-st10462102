using System;
using System.Media;
using System.Threading;

class CyberAskBot
{
    static void Main()
    {
        try
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayAsciiArt();
            PlayVoiceGreeting();
            Console.ResetColor();

            Console.Write("\nWhat's your name? ");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User"; // Default name if input is empty
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello {userName}, I'm here to help you stay safe online!\n");

            ShowMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nType a keyword to learn more or type 'menu' to see the options again: ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease enter a valid keyword.");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGoodbye! Stay safe online!");
                    Console.ResetColor();
                    break;
                }
                else if (userInput == "menu")
                {
                    ShowMenu();
                }
                else
                {
                    HandleUserInput(userInput);
                    ShowMenu(); // Display the menu after every valid input
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void DisplayAsciiArt()
    {
        try
        {
            Console.WriteLine(@"
              __                         ____    __               __        ____            __      
             /\ \                       /\  _`\ /\ \             /\ \__    /\  _`\         /\ \__   
  ___   __  _\ \ \____     __   _ __    \ \ \/\_\ \ \___      __ \ \ ,_\   \ \ \L\ \    ___\ \ ,_\  
 /'___\/\ \/\ \ \ '__`\  /'__`\/\`'__\   \ \ \/_/\ \  _ `\  /'__`\\ \ \/    \ \  _ <'  / __`\ \ \/  
/\ \__/\ \ \_\ \ \ \L\ \/\  __/\ \ \/     \ \ \L\ \ \ \ \ \/\ \L\.\\ \ \_    \ \ \L\ \/\ \L\ \ \ \_ 
\ \____\\/`____ \ \_,__/\ \____\\ \_\      \ \____/\ \_\ \_\ \__/.\_\ \__\    \ \____/\ \____/\ \__\
 \/____/ `/___/> \/___/  \/____/ \/_/       \/___/  \/_/\/_/\/__/\/_/\/__/     \/___/  \/___/  \/__/
            /\___/                                                                                  
            \/__/                                                                                      
        Your Cybersecurity Awareness Assistant
        ");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError displaying ASCII art: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            // Full file path for the sound
            string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

            // Check if the file exists before attempting to play it
            if (System.IO.File.Exists(soundPath))
            {
                SoundPlayer player = new SoundPlayer(soundPath);
                player.PlaySync();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; // Dark Red for errors
                Console.WriteLine("[Audio Error] Cannot find the greeting.wav at the path: " + soundPath);
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; // Dark Red for errors
            Console.WriteLine("[Audio Error] Unable to play the greeting sound: " + ex.Message);
            Console.ResetColor();
        }
    }

    static void ShowMenu()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou can ask me about the following topics by typing the **keywords**:");
            Console.WriteLine("- **phishing**: Learn about phishing attacks.");
            Console.WriteLine("- **passwords**: Tips for creating strong passwords.");
            Console.WriteLine("- **browsing**: How to browse safely online.");
            Console.WriteLine("- **malware**: Understand what malware is and how to avoid it.");
            Console.WriteLine("- **firewalls**: Learn about firewalls and how they protect you.");
            Console.WriteLine("- **exit**: To end the conversation.\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError displaying the menu: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void HandleUserInput(string input)
    {
        try
        {
            if (input.Contains("phishing"))
            {
                DelayedMessage("Phishing is a type of cyber attack where attackers trick you into revealing sensitive information, such as passwords or credit card numbers, through fake emails or websites.");
            }
            else if (input.Contains("password") || input.Contains("passwords"))
            {
                DelayedMessage("To create a strong password, use at least 12 characters, including uppercase and lowercase letters, numbers, and symbols. Avoid using personal information or common words.");
            }
            else if (input.Contains("browsing") || input.Contains("safe browsing"))
            {
                DelayedMessage("For safe browsing, always use HTTPS websites, avoid clicking on suspicious links, and keep your browser and antivirus software updated.");
            }
            else if (input.Contains("malware"))
            {
                DelayedMessage("Malware is malicious software designed to harm or exploit devices. Avoid downloading files from untrusted sources and keep your antivirus software updated.");
            }
            else if (input.Contains("firewall") || input.Contains("firewalls"))
            {
                DelayedMessage("A firewall is a security system that monitors and controls incoming and outgoing network traffic. It acts as a barrier between your device and potential threats.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHmm, I didn't understand that. Try typing one of the keywords: phishing, passwords, browsing, malware, firewalls, or exit.");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError handling user input: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void DelayedMessage(string message)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThinking...");
            Thread.Sleep(1000); // Simulate a delay of 1 second
            Console.WriteLine(message + "\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError displaying message: {ex.Message}");
            Console.ResetColor();
        }
    }
}
