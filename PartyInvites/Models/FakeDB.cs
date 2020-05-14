using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class FakeDB
    {
        //  F i e l d s   ( A l l   S t a t i c ) 

        private static GuestResponse[] responses = new GuestResponse[10];
        private static int responseCount = 0;

        //  M e t h o d s   ( A l l   S t a t i c )
        public static GuestResponse[] GetResponses()
        {
            return responses;
        }
        public static int GetResponseCount()
        {
            return responseCount;
        }

        public static void AddResponse(GuestResponse response)
        {
            responses[responseCount] = response;
            responseCount++;
        }
    }
}
