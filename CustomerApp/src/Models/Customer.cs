using System;
using System.Collections.Generic;

namespace CustomerApp.src.Models
{
	public struct Customer
	{
		public int ID { get; set; }

        public string Name { get; set; }


        public string MainPhone { get; set; }


        public string Phone2 { get; set; }


        public float CurrentPoints { get; set; }


        public float LastActivityPoints { get; set; }


        public string Source { get; set; }// customer form from POS or Reward 


        public string Status { get; set; }

        public string Address { get; set; }

        //public DateTime LastVisited { get; set; }

        //public DateTime RegisterDate { get; set; }


        public string MemberType { get; set; }// 1 2 3 4

        public string Email { get; set; }

        public string Notes { get; set; }

        public int TotalVisit { get; set; }

        public decimal LifeTimePoint { get; set; }

	}

}
