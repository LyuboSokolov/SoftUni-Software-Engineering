using System;
using System.Collections.Generic;
using System.Text;

namespace P09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            Pokemons.Add(pokemon);

        }
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public bool IsContainCorrectPokemon(string command)
        {
            foreach (var currPokemon in Pokemons)
            {
                if (currPokemon.Element == command)
                {
                    return true;
                }
            }
            return false;
        }

        public void PokemonLoseHealt()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;
                if (Pokemons[i].Health <= 0)
                {
                    Pokemons.Remove(Pokemons[i]);
                    i--;
                }
            }
        }
    }
}
