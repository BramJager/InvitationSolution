using System;
using System.Collections.Generic;
using System.Text;
using InvitationConsoleApp.Models;

namespace InvitationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var activity = new Activity();
            string organizerFirstName = GetUserInput("de voornaam van de organisator");
            string organizerSurnamePrefix = GetUserInput("het voervoegsel van de organisator", false);
            string organizerSurname = GetUserInput("de achternaam van de organisator");
            var organizerSex = (Sex)GetUserInput("het geslacht van de organisator (M = 0, F = 1, N = 2, Unknown if other entries)", true, true, true);
            var organizer = new Organizer(organizerFirstName, organizerSurnamePrefix, organizerSurname, organizerSex);
            organizer.Email = GetUserInput("het e-mailadres van de organisator");
            //Gegevens opvragen van de actviteit (Datum, Titel en Omschrijving van de Activiteit

            activity.Name = GetUserInput("titel van de activiteit");
            activity.Date = GetUserInput("datum en tijd (JJJJ-MM-DD uu:mm) van de activiteit", true, true);
            activity.Description = GetUserInput("omschrijving van de activiteit", false);

            //Aantal uitnodigen (aan de hand van vraag 'wilt u meer uitnodigen')

            List<Invitee> invitees = new List<Invitee>();

            do
            {
                string firstName = GetUserInput("de voornaam van de genodigde");
                string surnamePrefix = GetUserInput("het voervoegsel van de genodigde", false);
                string surname = GetUserInput("de achternaam van de genodigde");                
                var sex = (Sex)GetUserInput("het geslacht van de genodigde (Man = 0, Vrouw = 1, Overig = 2)", true, true, true); 
                var invitee = new Invitee(firstName, surnamePrefix, surname, sex);
                invitee.TelephoneNumber = GetUserInput("het telefoonnummer van de genodigde");
                invitee.Email = GetUserInput("de e-mail van de genodigde");
                invitees.Add(invitee);
            } while (GetUserInput("invoer 'y' als u nog een invitee wilt aanmaken") == "y");


            //Weergeven van alle uitnodigingen per genodigde aan de hand van de Stringbuilder (GELUKT?)


            foreach (var invitee in invitees)
            {
                Console.WriteLine(CreateInvitation(organizer, activity, invitee));
            }


            Console.WriteLine("Press <ENTER> to exit...");

            Console.ReadLine();
        }

        private static string CreateInvitation(Organizer organizer, Activity activity, Invitee invitee)
        {
            
            var sb = new StringBuilder();
            string invitation = string.Empty;

                sb.Append($"Geachte {invitee.Salutation} {invitee.FullName},");
                sb.AppendLine();
                sb.Append($"U bent uitgenodigd voor {activity.Name} op {activity.Date} door {organizer.FullName} die te bereiken is via dit emailadres: {organizer.Email}.");
                sb.AppendLine();
                sb.Append("Indien een omschrijving aanwezig is staat hij hieronder:");
                sb.AppendLine();
                sb.Append(activity.Description);
                sb.AppendLine();

                invitation = sb.ToString();

                sb.Clear(); 


            return invitation;
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
                Console.WriteLine($"Geef {description} op{(required ? " (verplicht)" : string.Empty)}");
                input = Console.ReadLine();
                Console.Clear();

            } while (required && string.IsNullOrWhiteSpace(input));

     

            return input;
        }
        private static DateTime GetUserInput(string description, bool required, bool date)
        {
            DateTime input;
            string temp;

            do
            {
                Console.WriteLine($"Geef {description} op{(required ? " (verplicht)" : string.Empty)}");
                temp = Console.ReadLine();
                DateTime.TryParse(temp, out input);
                Console.Clear();

            } while (required && DateTime.TryParse(temp, out _) == false);


            return input;
        }
        private static int GetUserInput(string description, bool required, bool date, bool integer)
        {
            int input;
            string temp;

            do
            {
                Console.WriteLine($"Geef {description} op{(required ? " (verplicht)" : string.Empty)}");
                temp = Console.ReadLine();
                int.TryParse(temp, out input);
                Console.Clear();

            } while (required && int.TryParse(temp, out _) == false);


            return input;
        }
    }
}