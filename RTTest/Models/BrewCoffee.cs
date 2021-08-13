using System;

namespace WebApp.Models {
    public class BrewCoffee {
        public static int CountedTime = 0;
        public int ServeTime { get; set; }
        public string Message { get; set; }
        public DateTime PreparedDate { get; set; }
        public float LocalTemp { get; set; }
        public BrewCoffee()
        {
            CountedTime++;
            ServeTime = BrewCoffee.CountedTime;
            Message = "Your piping hot coffee is ready";
            PreparedDate = DateTime.Now;
            LocalTemp = 29;
        }
    }
}
