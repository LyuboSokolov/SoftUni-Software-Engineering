using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;

        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIsNameIsNullOrWhiteSpace(value);
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                Validator.IsValidStat(value, nameof(Endurance));
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                Validator.IsValidStat(value, nameof(Sprint));
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                Validator.IsValidStat(value, nameof(Dribble));
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                Validator.IsValidStat(value, nameof(Passing));
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                Validator.IsValidStat(value, nameof(Shooting));
                shooting = value;
            }
        }

        public double AverageSkillPoints
        {
            get
            {
                double averageSkill = (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
                return Math.Round(averageSkill);
            }
        }
    }
}
