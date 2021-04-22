using System;

namespace InvitationConsoleApp
{
    class ProgramV2
    {
        static void MainV2(string[] args)
        {
            string organizerName = GetUserInput("naam van de organisator");
            string organizerEmail = GetUserInput("e-mailadres van de organisator");

            //Gegevens opvragen van de actviteit (Datum, Titel en Omschrijving van de Activiteit

            string activityName = GetUserInput("titel van de activiteit");
            //Geef datum/nummer invoer
            DateTime activityDate = DateTime.Parse(GetUserInput("datum van de activiteit"));
            //string activityTime = GetUserInput("tijd van de activiteit");
            string activityDescription = GetUserInput("omschrijving van de activiteit", false);

            //aantal uitnodigen( 2 manieren, hoeveel in totaal of aan de hand van vraag 'wilt u meer uitnodigen'


            //Zorg ervoor dat er om een int invoer wordt gevraagd en deze als zodanig verwerkt wordt.
            int amountOfinvitees = int.Parse(GetUserInput("aantal genodigden"));

            string[] inviteeNames = new string[amountOfinvitees];
            string[] inviteeEmails = new string[amountOfinvitees];

            for (int i = 0; i < amountOfinvitees; i++)
            {
                inviteeNames[i] = GetUserInput($"naam van {i+1}/{amountOfinvitees} genodigden");
                inviteeEmails[i] = GetUserInput($"e-mailadres {i+1}/{amountOfinvitees} genodigden");
            }

            Console.WriteLine($"De activiteit {activityName} wordt georganiseerd door {organizerName} op {activityDate}.\nOrganisator e-mail: {organizerEmail}\nOmschrijving van de activiteit: {activityDescription}");

            Console.WriteLine("Press <ENTER> to exit...");

            Console.ReadLine();
        }
        private static string GetUserInput(string description)
        {
            return GetUserInput(description, true);
        }
        private static string GetUserInput(string description, bool required)
        {
            string input;
            string verplicht = string.Empty;

            if (required)
            {
                verplicht = " (verplicht)";
            }

            do
            {
                Console.WriteLine($"Geef de {description} op{verplicht}");
                input = Console.ReadLine();
                Console.Clear();

            } while (required && string.IsNullOrWhiteSpace(input));

     

            return input;
        }
    }
}