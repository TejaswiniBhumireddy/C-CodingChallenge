using PetPals.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    public class CashDonation : Donation
    {
        public DateTime DonationDate { get; set; }
        private const decimal MinimumDonationAmount = 10000;


        public CashDonation(string donorName, decimal amount, DateTime donationDate)
            : base(donorName, amount)
        {
            if (amount < MinimumDonationAmount)
            {
                throw new InsufficientFundsException($"Donation amount should be at least {MinimumDonationAmount}");
            }
            DonorName = donorName;
            Amount = amount;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Cash donation recorded: Donor: {DonorName}, Amount: {Amount}, Date: {DonationDate}");
        }
    }

}
