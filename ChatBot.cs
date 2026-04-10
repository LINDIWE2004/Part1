using System;
using System.Collections.Generic;
using System.Speech.Synthesis;


    namespace Part1
    {
    
        class ChatBot
        {
            //It is responsible for storing responses like tips, advices, malware protection , wifi safety etc
            private Dictionary<string, List<string>> responses;
            //We implemented Random so that we can be able to pick random responses and to also avoid repetition
            private Random random = new Random();
            //This is my Voice Engine
            private SpeechSynthesizer speaker = new SpeechSynthesizer();
            private AudioPlayer audio = new AudioPlayer();

            public ChatBot()
            {
            responses = new Dictionary<string, List<string>>()
{
    { "password", new List<string> {
        "Use a unique password for every account—never reuse passwords across sites.",
        "Create passwords with at least 12–16 characters using a mix of letters, numbers, and symbols.",
        "Avoid personal info like names or birthdays in your passwords.",
        "Consider using a trusted password manager to generate and store strong passwords securely."
    }},
    { "phishing", new List<string> {
        "Be cautious of emails or messages asking for sensitive information—attackers often impersonate trusted companies.",
        "Always check the sender's email address carefully for slight misspellings or unusual domains.",
        "Never click on suspicious links—hover over them to preview the real URL first.",
        "If a message creates urgency or fear, it's likely a phishing attempt—pause and verify."
    }},
    { "malware", new List<string> {
        "Only download software from official websites or trusted app stores.",
        "Keep your operating system and applications updated to patch security vulnerabilities.",
        "Use reputable antivirus or endpoint protection software and keep it updated.",
        "Avoid opening email attachments from unknown or unexpected sources."
    }},
    { "wifi", new List<string> {
        "Avoid accessing banking or sensitive accounts on public Wi-Fi networks.",
        "Use a VPN when connecting to public Wi-Fi to encrypt your internet traffic.",
        "Ensure your home Wi-Fi is secured with WPA2 or WPA3 encryption and a strong password.",
        "Disable automatic connection to open Wi-Fi networks on your device."
    }},
    { "privacy", new List<string> {
        "Limit the personal information you share on social media platforms.",
        "Review app permissions regularly and remove access that isn't necessary.",
        "Use privacy settings to control who can see your posts and personal data.",
        "Be cautious about quizzes or apps that request access to your personal information."
    }},
    { "scam", new List<string> {
        "If an offer sounds too good to be true, it probably is.",
        "Never send money or personal details to unknown individuals online.",
        "Verify requests for money—even if they appear to come from someone you know.",
        "Watch out for fake job offers or giveaways asking for upfront payments."
    }}
};
        }

        public void Start()
        {

            ShowBanner();

            // Play WAV greeting
            audio.PlayWelcomeAudio();

            //What the Bot will display once the program begins
            WriteBot("Hello! You can ask me about Phishing, WiFi, Privacy, Scam, Malware and Passwords Tips. All you need to do is type the one you wp like information on.(type 'exit' to quit).");

            //It keeps the bot running until the user exits
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteBot("Please enter something.");
                    continue;
                }

                input = input.ToLower();

                if (input.Contains("exit"))
                {
                    //Displays the message after the user presses ËXIT
                    WriteBot("Goodbye and good luck! Stay safe online!");
                    break;
                }

                string response = GetResponse(input);
                WriteBot(response);
            }
        }
            private string GetResponse(string input)
            {
                //It checks for keywords, phishing,passwords etc
                foreach (var key in responses.Keys)
                {
                    if (input.Contains(key))
                    {
                        var list = responses[key];
                        return list[random.Next(list.Count)];
                    }
                }

                //It returns general advice
                return GetDefaultResponse();
            }

        private string GetDefaultResponse()
        {
            List<string> defaultResponses = new List<string>()
    {
        "I'm here to help you stay safe online. Try asking about passwords, scams, phishing, or privacy.",
        "Cybersecurity tip: always think before you click—many attacks rely on human error.",
        "I can guide you on avoiding scams, securing accounts, and protecting your data.",
        "Can you be more specific? For example, ask me about malware, Wi-Fi safety, or phishing.",
        "Staying safe online starts with awareness—what would you like to learn about?"
    };

            return defaultResponses[random.Next(defaultResponses.Count)];
        }
        private void WriteBot(string message)
            {

                //Prints bot text in yellow
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CyberSafe Bot: " + message);
                Console.ResetColor();
            }

            private void ShowBanner()
            {
                //It sets the the text to green and then prints ASCII Art
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(@"
   _____       _                _____            ____        _   
  / ____|     | |              / ____|          |  _ \      | |  
 | |     _   _| |__   ___ _ __| (___   ___  ___| |_) | ___ | |_ 
 | |    | | | | '_ \ / _ \ '__|\___ \ / _ \/ __|  _ < / _ \| __|
 | |____| |_| | |_) |  __/ |   ____) |  __/ (__| |_) | (_) | |_ 
  \_____|\__, |_.__/ \___|_|  |_____/ \___|\___|____/ \___/ \__|
          __/ |                                                 
         |___/                                                  

              [🤖]  CyberSecBot Activated
");

                Console.ResetColor();
            }
        }

    }


    