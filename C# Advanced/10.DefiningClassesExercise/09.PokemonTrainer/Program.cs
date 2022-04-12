using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string pokemonElement = inputData[2];
                int pokemonHealth = int.Parse(inputData[3]);

                Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                
                if (trainers.FirstOrDefault(x => x.Name == trainerName) == null)
                {
                    Trainer currTrainer = new Trainer(trainerName, currPokemon);
                    trainers.Add(currTrainer);
                }
                else
                {
                    trainers.First(x => x.Name == trainerName).Pokemons.Add(currPokemon);
                }
               
                input = Console.ReadLine();
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Fire")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.IsContainCorrectPokemon(command))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            trainer.PokemonLoseHealt();
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.IsContainCorrectPokemon(command))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            trainer.PokemonLoseHealt();
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.IsContainCorrectPokemon(command))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            trainer.PokemonLoseHealt();
                        }
                    }
                }

                command = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x=> x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
