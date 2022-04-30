using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];





                //•	Spy: "Spy <id> <firstName> <lastName> <codeNumber>"

                if (type == nameof(Private))
                {
                    //• Private: "Private <id> <firstName> <lastName> <salary>"

                    decimal salary = decimal.Parse(tokens[4]);
                    soldiersById.Add(id, new Private(firstName, lastName, id, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    ////•	LeutenantGeneral: "LieutenantGeneral <id> <firstName> <lastName> <salary>
                    //<private1Id> <private2Id> … <privateNId>" " +
                    //    "where privateXId will always be an Id of a Private already received through the input.

                    decimal salary = decimal.Parse(tokens[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(firstName, lastName, id, salary);

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        string privateId = tokens[i];
                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }
                        IPrivate currPrivate = (IPrivate)soldiersById[privateId];
                        lieutenantGeneral.AddPrivate(currPrivate);
                    }

                    soldiersById.Add(id, lieutenantGeneral);
                }
                else if (type == nameof(Engineer))
                {
                    //// Engineer: "Engineer <id> <firstName> <lastName> <salary> <corps>
                    // <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>" where repairXPart is the name of a " +
                    //" repaired part and repairXHours the hours it took to repair it(the two parameters will always come paired).

                    decimal salary = decimal.Parse(tokens[4]);

                    bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);

                    if (!isValidCorps)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string partName = tokens[i];
                        int hoursWorked = int.Parse(tokens[i + 1]);
                        IRepair repair = new Repair(partName, hoursWorked);
                        engineer.AddRepair(repair);
                    }
                    soldiersById.Add(id, engineer);

                }
                else if (type == nameof(Commando))
                {
                    ////•	Commando: "Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName> 
                    //<mission1state> … <missionNCodeName> <missionNstate>" a missions code name, " +
                    //    "description and state will always come together.

                    decimal salary = decimal.Parse(tokens[4]);

                    bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);

                    if (!isValidCorps)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    ICommando commando = new Commando(firstName, lastName, id, salary, corps);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string missionName = tokens[i];
                        string state = tokens[i + 1];
                        bool isValidMission = Enum.TryParse(state, out MissionState mission);

                        if (!isValidMission)
                        {
                            continue;
                        }
                        IMission currMission = new Mission(missionName, mission);
                        commando.AddMission(currMission);
                    }
                    soldiersById.Add(id, commando);
                }
                else if (type == nameof(Spy))
                {
                    //•	Spy: "Spy <id> <firstName> <lastName> <codeNumber>"

                    int codeNumber = int.Parse(tokens[4]);
                    soldiersById.Add(id, new Spy(firstName, lastName, id, codeNumber));
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
