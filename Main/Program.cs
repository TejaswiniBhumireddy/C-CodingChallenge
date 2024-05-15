using System;
using System.Data.SqlClient;
using PetPals.Exceptions;
using PetPals.Model;
using PetPals.Utility;

namespace YourNamespace
{
    class Program
    {
        static PetShelter shelter = new PetShelter();

        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection connection = DbConnUtil.GetSqlConnection())
                {
                    connection.Open();
                    Console.WriteLine("Connection established successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Adding some pets into the shelter
            shelter.AddPet(new Pet("Buddy", 5, "Golden Retriever"));
            shelter.AddPet(new Dog("Max", 3, "Labrador", "Labrador Retriever"));
            shelter.AddPet(new Cat("Whiskers", 2, "Siamese", "Cream"));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to PetPals - The Pet Adoption Platform");
                Console.WriteLine("1. Display Pet Listings");
                Console.WriteLine("2. Record Cash Donation");
                Console.WriteLine("3. Manage Adoption Events");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayPetListings();
                        break;
                    case "2":
                        RecordCashDonation();
                        break;
                    case "3":
                        ManageAdoptionEvents();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void DisplayPetListings()
        {
            Console.WriteLine("Available Pets in Shelter:");
            shelter.ListAvailablePets();
        }

        static void RecordCashDonation()
        {
            try
            {
                Console.WriteLine("Recording Cash Donation...");

                Console.Write("Enter donor name: ");
                string donorName = Console.ReadLine();

                decimal donationAmount;
                do
                {
                    Console.Write("Enter donation amount: ");
                } while (!decimal.TryParse(Console.ReadLine(), out donationAmount) || donationAmount <= 0);

                using (SqlConnection connection = DbConnUtil.GetSqlConnection())
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Donations (DonorName, Amount, DonationDate) VALUES (@DonorName, @Amount, @DonationDate)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@DonorName", donorName);
                    command.Parameters.AddWithValue("@Amount", donationAmount);
                    command.Parameters.AddWithValue("@DonationDate", DateTime.Now);
                    int rowsAffected = command.ExecuteNonQuery();


                }
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Error recording donation: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void ManageAdoptionEvents()
        {
            Console.WriteLine("Managing Adoption Events...");
        }
    }
}
