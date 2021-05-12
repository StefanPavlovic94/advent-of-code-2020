using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day5
{
    class Plane
    {
        private readonly int numberOfRows;
        private readonly int numberOfSeats;

        private List<Seat> OccupiedSeats { get; set; }

        public Plane(int numberOfRows, int numberOfSeats)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfSeats = numberOfSeats;
            OccupiedSeats = new List<Seat>();
        }

        public void OccupySeat(Ticket ticket) 
        {
            
        }
    }

    class Ticket 
    {
        private Ticket()
        {          
        }

        public static Ticket Create(string code) 
        {
            
        }

        private static bool Validate() 
        {
        
        }
    }

    enum PlaneArea 
    {
        Front,
        Back
    }

    enum RowArea 
    {
        Left, 
        Right
    }

    class Seat 
    {
        public int Id { get; }

        public Seat(int id)
        {
            Id = id;
        }
    }
}
