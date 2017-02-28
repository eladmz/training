using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Algorithms.DesignPatterns.Other.MVC
{
    class MVC
    {
        /**
         * The MVC is a design pattern that focuses on seperating the behind the scenes logic and the parts that
         * communicate with the user.
         * 
         * MVC creates three different parts: the model, the view and the controller.
         * 
         * The model is the brain behind the machine, its main purpose is being the logic and processing data and
         * outputing the results.
         * 
         * The view is whats in charge of half of the communication with the user, its not meant to get the input but
         * it is in charge of the ouput. the view part is in charge of dissplaying the information, changing the
         * console and so on.
         * 
         * the controller is the part that is in charge of "knowing" the view and the model and retrieving the users
         * input and sending it to the part responsible for handling it.
         * 
         */
    }

    //model
    public class modelMVC
    {
        private int characterAge;

        public modelMVC()
        {
            
        }

        public int Age
        {
            get { return characterAge; }
            set
            {

                if (value <= 100 && value >= 0)
                {
                    characterAge = value;
                }   
            }
        }

        public string CharacterName { get; set; }
    }

    // view
    public class viewMVC
    {
        public viewMVC()
        {
 
        }

        public void printAge(string age)
        {
            Console.WriteLine(age);
        }
        public void printName(string name)
        {
            Console.WriteLine(name);
        }
        public void printCharacterData(string name, string age)
        {
            Console.WriteLine("Name: {0} Age: {1}", name, age);
        }
    }

    // controller
    public class controllerMVC
    {
        private modelMVC model;
        private viewMVC view;
        public controllerMVC(modelMVC model, viewMVC view)
        {
            this.model = model;
            this.view = view;
        }

        public void updateName(string newName)
        {
            model.CharacterName = newName;
        }

        public string getName()
        {
            return model.CharacterName;
        }

        public void updateAge(int newAge)
        {
            model.Age = newAge;
        }

        public int getAge()
        {
            return model.Age;
        }

        public void printCharacterData()
        {
            view.printCharacterData(model.CharacterName, model.Age.ToString());
        }

        public void printCharacterAge()
        {
            view.printAge(model.Age.ToString());
        }

        public void printName()
        {
            view.printName(model.CharacterName);
        }
    }
}
