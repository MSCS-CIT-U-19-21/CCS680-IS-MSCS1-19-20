#include<iostream>
#include<string>
#include <stdlib.h>     /* srand, rand */
#include <time.h>
#include <list>
#include<cstring>
#include <bits/stdc++.h>
using namespace std;

class Population
    {
    public:
        string code = "";
        float fitness = 0;

        char alpha[80]= {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    };

class Genetic_Algo{
public:
        int population_size = 1000;
        list<Population> population;
        float population_fitness[1000];
        float mutation = 0.05F;
        string goal = "helloworld21";
        int r  = rand() % 26;
        int generation = 1;
        int calculateFitness(string str);
        void generateRandomStrings();
        char generateRandomCharacter();
        void displayPopulation();
        char c;
};

int Genetic_Algo::calculateFitness(string str)
        {
        int temp_score = 0;

        for (int y = 0; y < goal.size(); y++)
            {
                if (str[y] == goal[y])
                {
                    temp_score++;
                }
                cout<<temp_score<<endl;
            }
            return temp_score;
        }

void Genetic_Algo::generateRandomStrings()
        {
            for (int x = 0; x < population_size; x++)
            {
                Population temp_population;
                temp_population.code = "";
                cout<< goal.size();
                for (int y = 0; y <  goal.size(); y++)
                {
                    temp_population.code += generateRandomCharacter();
                }
                temp_population.fitness = calculateFitness(temp_population.code);
                population.push_back(temp_population);   // Add in c#
            }

             //population.sort();
//
           //display the population
            displayPopulation();
        }

 char Genetic_Algo::generateRandomCharacter()
        {
          r = rand() % 26;   // generate a random number
          c = 'a' + r;            // Convert to a character from a-z
          cout << c;
          return c;
        }

   void Genetic_Algo::displayPopulation()
        {

            string temp_str = "a";

            for (int x = 0; x < 10; x++)
            {

               //cout<<population[x].fitness;
              // temp_str += temp_str+temp_str;
               //temp_str += population[x].code + " " + population[x].fitness + "\n";
            }
            cout<<temp_str;
        }

int main(){
Genetic_Algo h;
h.calculateFitness("helloworld21");
//h.displayPopulation();
cout<<"hell";


return 0;
}
