using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    internal class AdoptionEvent
    {
        public List<IAdoptable> Participants { get; } = new List<IAdoptable>();

        public void HostEvent()
        {
            Console.WriteLine("Adoption event hosted.");
        }

        public void RegisterParticipant(IAdoptable participant)
        {
            Participants.Add(participant);
        }
    }
}
