using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRPZ_2_LR1
{
    public class Train
    {
        public int Speed { get; set; }
        public bool Running { get; set; }
        public int StopsCount { get; set; }
        public List<Passenger> Passengers { get; set; }= new List<Passenger>();

        public void AddPassengers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Passengers.Add(new Passenger());
            }
        }

        public void RemovePassengers(int amount)
        {
            try
            {
                if (this.Running) throw new TrainException("Train is running");
                for (int i = 0; i < amount; i++)
                {
                    this.Passengers.Remove(this.Passengers.Last());
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new TrainException(ex.Message);
            }
        }

        public void Run()
        {
            if(this.Running) throw new TrainException("Train must stop before start");
            this.Running = true;
            this.Speed = 5;
        }

        public void Stop()
        {
            if(this.Speed > 20) throw new TrainException("Train can't stop when it's speed more than 20 km/h");
            this.Running = false;
            this.Speed = 0;
            this.StopsCount++;
        }

        public void IncreaseSpeed(int amount)
        {
            if(amount > 10) throw new TrainException("Train can't change speed over than 10 km/h");
            this.Speed += amount;
        }

        public void DecreaseSpeed(int amount)
        {
            if (amount > 10) throw new TrainException("Train can't change speed over than 10 km/h");
            if(this.Speed - amount < 5) throw new TrainException("Train can't go with speed less than 5 km/h");
            this.Speed -= amount;
        }

    }
}
