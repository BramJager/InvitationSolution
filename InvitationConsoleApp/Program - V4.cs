using System;
using System.Collections.Generic;
using System.Text;
using InvitationConsoleApp.Models;

namespace InvitationConsoleApp
{
    class ProgramV4
    {
        static void MainV4(string[] args)
        {
            var organizer = new Organizer();
            organizer.FullName = GetUserInput("naam van de organisator");
            organizer.Email = GetUserInput("e-mailadres van de organisator");

            //Gegevens opvragen van de actviteit (Datum, Titel en Omschrijving van de Activiteit

            string activityName = GetUserInput("titel van de activiteit");
            //Geef datum/nummer invoer die verwerkt kan worden
            DateTime activityDate = DateTime.Parse(GetUserInput("datum van de activiteit"));
            string activityDescription = GetUserInput("omschrijving van de activiteit", false);

            //Aantal uitnodigen (aan de hand van vraag 'wilt u meer uitnodigen')

            List<Invitee> invitees = new List<Invitee>();

            do
            {
                var invitee = new Invitee();
                invitee.FullName = GetUserInput("naam van de genodigde");
                invitee.Email = GetUserInput("e-mail van de genodigde");
                invitees.Add(invitee);
            } while (GetUserInput("invoer 'y' als u nog een invitee wilt aanmaken") == "y");



            //Weergeven van alle uitnodigingen per genodigde aan de hand van de Stringbuilder
            var sb = new StringBuilder();

            foreach (var invitee in invitees)
            {
                Console.WriteLine($"De activiteit {activityName} wordt georganiseerd op {activityDate} door {organizer.FullName}\nOrganisator Email:{organizer.Email}\n\nOmschrijving van de activiteit:\n{activityDescription}");
            }


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

            do
            {
                Console.WriteLine($"Geef de {description} op{(required ? " (verplicht)" : string.Empty)}");
                input = Console.ReadLine();
                Console.Clear();

            } while (required && string.IsNullOrWhiteSpace(input));

     

            return input;
        }
    }
}