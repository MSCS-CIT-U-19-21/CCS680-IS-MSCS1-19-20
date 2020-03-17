using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    
    public partial class Form1 : Form
    {
        static int population_size = 1000;
        List<Population> population = new List<Population>();
        float[] population_fitness = new float[population_size];
        float mutation = 0.05F;
        String goal = "helloworld";
        Random r = new Random();
        int generation = 1;

        public Form1()
        {
            InitializeComponent();
            //clear first the list
            population.Clear();
            //initialize the population first to random strings
            this.generateRandomStrings();
        }

        private void start_Click(object sender, EventArgs e)
        {
            while (this.population[0].code != this.goal)
            {
                this.reproduce();
                Application.DoEvents();
            }
        }

        private int calculateFitness(String str)
        {
            int temp_score = 0;
            for (int y = 0; y < this.goal.Length; y++)
            {
                if (str[y] == this.goal[y])
                {
                    temp_score++;
                }
            }
            return temp_score;
        }

        private void generateRandomStrings()
        {
            for (int x = 0; x < population_size; x++)
            {
                Population temp_population = new Population();
                temp_population.code = "";
                for (int y = 0; y < this.goal.Length; y++)
                {
                    temp_population.code += this.generateRandomCharacter();
                }
                temp_population.fitness = this.calculateFitness(temp_population.code);
                population.Add(temp_population);
            }
            population = population.OrderByDescending(x => x.fitness).ToList();

            //display the population
            this.displayPopulation();
        }

        private char generateRandomCharacter()
        {
            return Convert.ToChar(r.Next(97, 122));
        }

        private void reproduce()
        {
            List<Population> old_population = this.population;

            //create a list of numbers first for indexes with weights
            //if fitness is 2, then this list will have three records of it
            //if fitness is 0, then this list will have one record of it
            //the more fitness it has, the more likely it will be selected
            List<int> temp_weights = new List<int>();
            for (int x = 0; x < population_size; x++)
            {
                for (int y = 0; y < this.population[x].fitness + 1; y++)
                {
                    temp_weights.Add(x);
                }
            }

            for (int x = 0; x < population_size; x++)
            {
                //select the index two parents from the temp_weights based on the old population
                int index_parent_1 = r.Next(0, population_size/10);
                int index_parent_2 = r.Next(0, population_size);
                //System.Windows.Forms.MessageBox.Show("Parent 1 is " + index_parent_1 + "\nParent 2 is " + index_parent_2);
                population[x].code = this.generateNewStringFromParents(old_population[index_parent_1].code, old_population[index_parent_2].code);
                population[x].fitness = this.calculateFitness(population[x].code);
            }
            population = population.OrderByDescending(x => x.fitness).ToList();

            //display the population
            this.displayPopulation();

            //increase the number of generations
            this.generation++;
            generationText.Text = "Generation: " + this.generation;
        }

        

        private String generateNewStringFromParents(String parent_1, String parent_2)
        {
            String temp_str = "", temp_parent;
            //pick which parent will be first
            if (r.Next(0, 1)==0)
            {
                temp_parent = parent_1;
                parent_1 = parent_2;
                parent_2 = temp_parent;
            }
            int center_index = r.Next(0, this.goal.Length);
            for (int x=0; x<this.goal.Length; x++)
            {
                if (r.Next(0, 2)==0)
                {
                    temp_str += parent_1[x];
                }
                else
                {
                    temp_str += parent_2[x];
                }
            }
            //do we mutate?
            if (r.Next(0, 100) < (this.mutation * 100))
            {
                int index_to_mutate = r.Next(0, this.goal.Length);
                char[] array = temp_str.ToCharArray();
                array[index_to_mutate] = this.generateRandomCharacter();
                temp_str = new string(array);
            }
            return temp_str;
        }

        private void fastForward_Click(object sender, EventArgs e)
        {
            
        }

        private void displayPopulation()
        {
            String temp_str = "";
            for (int x = 0; x < 10; x++)
            {
                temp_str += this.population[x].code + " " + this.population[x].fitness + "\n";
            }
            populationStrings.Text = temp_str;
        }

        private void next_Click(object sender, EventArgs e)
        {
            while (this.population[0].code != this.goal)
            {
                this.reproduce();
                Application.DoEvents();
            }
        }

        private void populationStrings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}
