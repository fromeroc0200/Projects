using System;
using System.Collections.Generic;
using System.Text;

namespace CreateSimplifiedConstructors.Entities
{
    public class School
    {
        private string name;

        public string Name
        {
            get { return "Copy " +  name; }
            set { name = value.ToUpper(); }
        }

        public int age { get; set; }

        //Create simplified contructor
        public School(string name, int age) => (this.Name, this.age) = (name, age);
        // It's the same that ----  
        //public School(string name, int age)
        //{
        //    this.name=name;
        //    this.age=age;
        //}



        //--Se sobreescribe el metodo toString para imprimir toda la informacion
        public override string ToString()
        {
            return $"Nombre: \"{Name}\" Age {age}";
        }
    }
}
