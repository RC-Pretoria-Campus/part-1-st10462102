using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Program
    {
        static string userName = "";
        static string lastTopic = "";

        delegate void TopicHandler();

        static Dictionary<string, TopicHandler> topicHandlers = new Dictionary<string, TopicHandler>()
        {
            { "phishing", HandlePhishing },
            { "passwords", HandlePasswords },
            { "browsing", HandleBrowsing },
            { "malware", HandleMalware },
            { "firewalls", HandleFirewalls },
            { "quiz", AskQuizQuestions }
        };

        static List<string> frustrationKeywords = new List<string> { "useless", "dumb", "don't get", "confused", "stupid" };

        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            DisplayAsciiArt();
            GetUserName();
            GreetUser();

            string input = "";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nType a keyword like 'phishing', 'passwords', 'quiz', or type 'menu' to see all topics. Type 'exit' to leave.");
                Console.ResetColor();

                Console.Write($"{userName}: ");
                input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter something meaningful.");
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine($"Goodbye {userName}, stay cyber safe!");
                    break;
                }

                if (input == "menu")
                {
                    ShowMenu();
                    continue;
                }

                HandleUserInput(input);
            }
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("greeting.wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not play voice greeting. Make sure 'greeting.wav' is in the same folder.");
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
       __                         ____    __               __        ____            __      
             /\ \                       /\  _`\ /\ \             /\ \__    /\  _`\         /\ \__   
  ___   __  _\ \ \____     __   _ __    \ \ \/\_\ \ \___      __ \ \ ,_\   \ \ \L\ \    ___\ \ ,_\  
 /'___\/\ \/\ \ \ '__`\  /'__`\/\`'__\   \ \ \/_/\ \  _ `\  /'__`\\ \ \/    \ \  _ <'  / __`\ \ \/  
/\ \__/\ \ \_\ \ \ \L\ \/\  __/\ \ \/     \ \ \L\ \ \ \ \ \/\ \L\.\\ \ \_    \ \ \L\ \/\ \L\ \ \ \_ 
\ \____\\/`____ \ \_,__/\ \____\\ \_\      \ \____/\ \_\ \_\ \__/.\_\ \__\    \ \____/\ \____/\ \__\
 \/____/ `/___/> \/___/  \/____/ \/_/       \/___/  \/_/\/_/\/__/\/_/\/__/     \/___/  \/___/  \/__/
            /\___/             
");
            Console.ResetColor();
        }

        static void GetUserName()
        {
            Console.Write("Before we start, what's your name? ");
            userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Guest";
            }
        }

        static void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nHello {userName}! Welcome to the Cybersecurity Awareness Chatbot.");
            Console.WriteLine("Ask me anything about cybersecurity.");
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHere are some topics I can help with:");
            Console.ResetColor();

            Console.WriteLine("- phishing: Learn about phishing scams.");
            Console.WriteLine("- passwords: Get tips on strong passwords.");
            Console.WriteLine("- browsing: Stay safe while browsing.");
            Console.WriteLine("- malware: Understand malware threats.");
            Console.WriteLine("- firewalls: What are firewalls?");
            Console.WriteLine("- quiz: Test your cybersecurity knowledge.");
        }

        static void HandleUserInput(string input)
        {
            try
            {
                foreach (var word in frustrationKeywords)
                {
                    if (input.Contains(word))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nI'm here to help! Try using the 'menu' command to see what I can explain.");
                        Console.ResetColor();
                        return;
                    }
                }

                foreach (var key in topicHandlers.Keys)
                {
                    if (input.Contains(key))
                    {
                        lastTopic = key;
                        topicHandlers[key].Invoke();
                        return;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHmm, I didn't understand that. Try typing one of the keywords: phishing, passwords, browsing, malware, firewalls, quiz, or exit.");
                Console.ResetColor();
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
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        static void HandlePhishing()
        {
            DelayedMessage("Phishing is a type of cyber attack where attackers trick you into revealing sensitive info.");
        }

        static void HandlePasswords()
        {
            DelayedMessage("Use strong, unique passwords with symbols and numbers.");
        }

        static void HandleBrowsing()
        {
            DelayedMessage("Use HTTPS, avoid pop-ups and suspicious links.");
        }

        static void HandleMalware()
        {
            DelayedMessage("Malware is malicious software. Don’t download from unknown sources.");
        }

        static void HandleFirewalls()
        {
            DelayedMessage("Firewalls filter traffic and protect your system from threats.");
        }

        static void AskQuizQuestions()
        {
            string[] questions = new string[]
            {
                "1. What does 'phishing' usually try to steal?\n   a) Candy\n   b) Passwords\n   c) Movies",
                "2. What makes a strong password?\n   a) Your name\n   b) '12345'\n   c) Mix of characters and symbols",
                "3. Should you click unknown email links?\n   a) Yes\n   b) No\n   c) Only if curious",
                "4. What's malware?\n   a) A cookie\n   b) Harmful software\n   c) A firewall",
                "5. What does HTTPS indicate?\n   a) Secure site\n   b) Hacker site\n   c) Game server",
                "6. What's a firewall?\n   a) Wall of fire\n   b) Protection for networks\n   c) Antivirus"
            };

            string[] answers = { "b", "c", "b", "b", "a", "b" };
            int score = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCybersecurity Awareness Quiz:\n");
            Console.ResetColor();

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                Console.Write("Your answer: ");
                string response = Console.ReadLine()?.ToLower().Trim();
                if (response == answers[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong! The correct answer was: {answers[i]}\n");
                }
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You scored {score}/6. {(score >= 4 ? "Great job!" : "Keep learning!")}\n");
            Console.ResetColor();
        }
    }
}
